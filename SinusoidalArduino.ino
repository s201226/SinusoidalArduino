/*starting frequency 16MHz
 * you can set the ADC frequency or start a measurement
 * in 
 */
const long CLOCK_FREQ=16000000;
const String START_MESSAGE="Starting sensor...",
  ERROR_MESSAGE="Error: command not found",
  FINISH_MESSAGE="Measured Data",
  FINISH_PKG_MESSAGE="Pkg Finished",
  NEW_FREQUENCY="NewFrequency\n",
  MEASURE="Measure\n";

String inputString="";
int prescaler_num=1,
  buffer_int[300],
  i=0;
int inputInt=0;
long to_count=27;
boolean stringComplete=false,
  exception_second_word=false,
  stabilized=false;

void setup() {
  Serial.begin(115200);
  Serial.println(START_MESSAGE);
  Serial.flush();

  for(i=0;i<300;i++){
    buffer_int[i]=0;
    //Serial.println(buffer_int[i]);
  }

  //ADMUX= 0x40;
  ADMUX = 0xC0; //select internal 1.1V source and channel0
  
  ADCSRA |= prescaler_num; //prescaler a 128
  
  ADCSRA |= 1 << ADEN; //activate ADC
  //enable interrupt
  SREG |= 0X80;
  ADCSRA |= 1 << ADIF; //reset flag
  ADCSRA |= 1 << ADIE;

  TCCR1A = 0;
  TCCR1B = 0x01; //<< CS10; //activate timer with clock CLOCK_FREQ
  TCCR1C = 0;
  TIFR1 |= 1 << OCF1A;
  TIMSK1 = 0 << OCIE1A;
}

void loop() {
  //Serial.println(TCNT1);
  //delay(100);
  if(stringComplete){
    if(exception_second_word){ //case there is a second part of the comand
      
      inputInt=atoi(inputString.c_str());
      //elaboration of properly time parameters
      prescaler_num=floor(log(CLOCK_FREQ/(14.0*(float)inputInt))/log(2.0));
      
      if(prescaler_num>7) prescaler_num=7;
      else{
        if(prescaler_num<1) prescaler_num=1;
      }
      
      to_count=(long)(CLOCK_FREQ/(float)inputInt)+1;
      //setting of the parameters
      stabilized=false;
      ADCSRA |= prescaler_num;

      Serial.println("q");
      Serial.println(prescaler_num);
      Serial.println(to_count);
      Serial.println((int)(CLOCK_FREQ/(float)to_count));
        
      ADCSRA |= 1 << ADSC; //test convertion
      delay(10);
      //waiting for the stabilization...
      while(!stabilized);
      
      //Serial.println(prescaler_num);
      //exiting part
      exception_second_word=false;
      inputString="";
      stringComplete=false;
    }
    else{
      if(inputString==MEASURE){ //measurement routine
        i=0;
        
        //enable interrupt
        TIFR1 |= 1 << OCF1A;
        TIMSK1 |= 1 << OCIE1A;
        TCNT1 = 0x0000;

        ADCSRA |= 1 << ADSC; //start conversion
        OCR1A = TCNT1+to_count;
      }
      else{
        if(inputString==NEW_FREQUENCY){ //setting new frequency
          exception_second_word=true;
        }
        else
        {
          Serial.println(ERROR_MESSAGE);
        }
      }
      //exiting part
      stringComplete=false;
      inputString="";
    }
  }
}

void serialEvent(){
  while(Serial.available()){
    char inChar=(char)Serial.read();
    inputString+=inChar;
    if(inChar=='\n'){
      stringComplete=true;
      Serial.flush();
    }
  }
}

ISR(TIMER1_COMPA_vect){
  i+=1;
  if(i<300){
    ADCSRA |= 1 << ADSC; //start conversion
    OCR1A += to_count;
  }
  else{
    //TCCR1A &= 0 << CS10; //disactivate timer
    TIMSK1 &= 0 << OCIE1A;
    
    Serial.println(FINISH_MESSAGE);
    for(i=0;i<300;i++) Serial.println(buffer_int[i]);
    Serial.println(FINISH_PKG_MESSAGE);
    Serial.flush();
    
    i=0;
  }
  TIFR1 |= 1 << OCF1A;
}

ISR(ADC_vect){
  if(exception_second_word){
    stabilized=true;
  }
  else{
    buffer_int[i]=(int)ADC;
  }
}/*Botteon Bertone Berto Prono*/

