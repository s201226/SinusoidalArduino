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
long inputInt=0,
  to_count=27;
boolean stringComplete=false,
  exception_second_word=false,
  stabilized=false;

void setup() {
  //initialization
  for(i=0;i<300;i++){
    buffer_int[i]=0;
    //Serial.println(buffer_int[i]);
  }
  
  //enable interrupt
  SREG |= 0X80;
  
  //Serial
  Serial.begin(115200);
  Serial.println(START_MESSAGE);
  Serial.flush();
  
  //ADC
  ADMUX = 0xC0; //select internal 1.1V source and channel0
  ADCSRA = 0x80+prescaler_num; //prescaler a 2
  ADCSRB = 0;
  DIDR0 = 0;

  ADCSRA |= 1 << ADIF; //reset interrupt flag
  ADCSRA |= 1 << ADIE; //enable interrupt
  
  //ADCSRA |= 1 << ADSC; //start conversion
  
  //Timer
  TCCR1B = 0x01; //activate timer with clock CLOCK_FREQ
  TCCR1A = 0;
  TCCR1C = 0;
  
  TCNT1 = 0x00;
  OCR1A = 0x00;
  OCR1B = 0x00;
}

void loop() {
  //Serial.println(TCNT1);
  
  if(stringComplete){
    if(exception_second_word){ //case there is a second part of the comand
      
      inputInt=atol(inputString.c_str());
      //elaboration of properly time parameters
      
      prescaler_num=floor(log(CLOCK_FREQ/(14.0*(float)inputInt))/log(2.0));
      
      if(prescaler_num > 7){
        prescaler_num=7;
      }
      else{
        if(prescaler_num < 1){
          prescaler_num=1;
        }
      }
      
      to_count=(long)(CLOCK_FREQ/(float)inputInt)+1;
      
      if(to_count > 65535){
        to_count=65535;
      }
      else{
        if(to_count < 27){
          to_count=27;
        }
      }

      Serial.println("Prescaler changed");
      Serial.println(prescaler_num);
      Serial.println(to_count);
      Serial.println((int)(CLOCK_FREQ/(float)to_count));
      Serial.println("***********");
      
      
      //setting of the parameters
      stabilized=false;
      
      ADCSRA = prescaler_num+0x80; //set the new prescaler value

      ADCSRA |= 1 << ADIF; //reset interrupt flag
      ADCSRA |= 1 << ADIE; //enable interrupt

      OCR1B = TCNT1+to_count;
      //enable interrupt
      TIFR1 = 0x04; //reset flag of cmpB
      TIMSK1 = 0x04; //enable interrupt on cmpB

      ADCSRA |= 1 << ADSC; //start conversion
      Serial.println(TCNT1);
      delay(10);
      //waiting for the stabilization...
      while(!stabilized);
   
      //exiting part
      exception_second_word=false;
      inputString="";
      stringComplete=false;
    }
    else{
      if(inputString==MEASURE){ //measurement routine

        OCR1B = 0x00;
        TCNT1 = 0x00;
        OCR1B = TCNT1+to_count;
        //enable interrupt
        TIFR1 = 0x04; //reset flag of cmpB
        TIMSK1 = 0x04; //enable interrupt on cmpB
        
        ADCSRA |= 1 << ADSC; //start conversion

        i=0;
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

ISR(TIMER1_COMPB_vect){
  if(i<300){
    i+=1;
    //Serial.println(TCNT1);
    ADCSRA |= 1 << ADSC; //start conversion
    OCR1B += to_count; //increment OCR1B
  }
  else{
    TIMSK1 = 0; //disable compB interrupt
    
    Serial.println(FINISH_MESSAGE);
    for(i=0;i<300;i++){
      Serial.println(buffer_int[i]);
    }
    Serial.println(FINISH_PKG_MESSAGE);
    Serial.flush();
    
    i=0;
  }
  TIFR1 |= 1 << OCF1B;
}

ISR(ADC_vect){
  ADCSRA |= 1 << ADIF; //reset interrupt flag
  if(exception_second_word){
    stabilized=true;
  }
  else{
    buffer_int[i]=(int)ADC;
  }
  //Serial.println(TCNT1);
}/*Botteon Bertone Berto Prono*/

