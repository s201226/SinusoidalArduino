using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinusoidalArduino
{
    public partial class SinusoidalArduino : Form
    {
        private const string MEASURE_MSG = "Measure\n";
        private const string FREQUENCY_MSG = "NewFrequency\n";
        private const string PKG_MESSAGE = "Measured Data";
        private const string FINISH_PKG_MESSAGE = "Pkg Finished";
        private const string PATH = @"./Measurement.dat";
        private int frequency = 10;
        private string BuffChars;
        private string aLine;
        private List<int> data = new List<int> { };

        public SinusoidalArduino()
        {
            InitializeComponent();
        }

        private void buttonUSB_Click(object sender, EventArgs e)
        {
            if (serialPortUSB.IsOpen)
            {
                textBoxLog.Text = "COM1";
                serialPortUSB.Close();
                buttonUSB.Text="Start";
                buttonMeasure.Enabled = false;
                buttonFrequency.Enabled = false;
            }
            else
            {
                serialPortUSB.PortName = textBoxLog.Text;
                try
                {
                    serialPortUSB.Open();
                }
                catch (System.IO.IOException) { }
                if(serialPortUSB.IsOpen)
                {
                    buttonUSB.Text = "Stop";
                    buttonMeasure.Enabled = true;
                    buttonFrequency.Enabled = true;
                }
            }
        }

        private void buttonMeasure_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(PATH))
            {
                System.IO.File.Delete(PATH);
            }
            serialPortUSB.Write(MEASURE_MSG);
        }

        private void buttonFrequency_Click(object sender, EventArgs e)
        {
            serialPortUSB.Write(FREQUENCY_MSG);

            try
            {
                frequency = Int32.Parse(textBoxFreq.Text);
            }
            catch (FormatException)
            {
                frequency = 150000;
            }
            if (frequency > 10)
            {
                serialPortUSB.Write(frequency.ToString()+'\n');
            }
            else
            {
                serialPortUSB.Write("1500\n");
            }  
        }

        private void serialPortUSB_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int lPos;

            if (e.EventType == System.IO.Ports.SerialData.Chars)
            {
                BuffChars += serialPortUSB.ReadExisting();
                lPos = BuffChars.IndexOf("\n");
                while (lPos > 0)
                {
                    aLine = BuffChars.Substring(0, lPos);

                    dataHandler(aLine);

                    BuffChars = BuffChars.Substring(lPos + 1);
                    lPos = BuffChars.IndexOf("\n");
                }
            }
        }

        void dataHandler(string str)
        {
            try
            {
                Int32.Parse(str);
                dataWriterAppend(textBoxData, str);
            }
            catch
            {
                dataWriter(textBoxLog, str);

                if (str == FINISH_PKG_MESSAGE)
                {
                    using (System.IO.StreamWriter sw = System.IO.File.CreateText(PATH))
                    {
                        int[] data_arr = data.ToArray();
                        for (int i = 0; i < data_arr.Length; i++)
                        {
                            sw.WriteLine(data_arr[i]);
                        }
                    }
                }
            }
        }

        delegate void CrossThreadUSB(TextBox output, string str);
        private void dataWriter(TextBox output, string str)
        {
            if (output.InvokeRequired)
            {
                CrossThreadUSB writer = new CrossThreadUSB(dataWriter);
                this.Invoke(writer, new object[] { output, str });
            }
            else
            {
                output.Text = str;
            }
        }

        delegate void CrossThreadUSBAppend(TextBox output, string str);
        void dataWriterAppend(TextBox output, string str)
        {
            if (output.InvokeRequired)
            {
                CrossThreadUSBAppend writer = new CrossThreadUSBAppend(dataWriterAppend);
                this.Invoke(writer, new object[] { output, str });
            }
            else
            {
                data.Add(Int32.Parse(str));
                output.AppendText(str + "\n");
            }
        }

        private void buttonElaborate_Click(object sender, EventArgs e)
        {
            backgroundWorkerMatlab.RunWorkerAsync(textBoxScale.Text);
        }

        private void backgroundWorkerMatlab_DoWork(object sender, DoWorkEventArgs e)
        {
            int scale = Int32.Parse((string)e.Argument);

            BackgroundWorker worker = (BackgroundWorker)sender;

            int num_val = (int)(((double)scale) * 0.000001 * frequency);
            if (num_val < 1 | num_val > 300)
            {
                num_val = 150;
            }

            MLApp.MLApp matlab = new MLApp.MLApp();

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxData.Text = "";
        }
    }
}
