namespace SinusoidalArduino
{
    partial class SinusoidalArduino
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SinusoidalArduino));
            this.textBoxFreq = new System.Windows.Forms.TextBox();
            this.pictureBoxGraphic = new System.Windows.Forms.PictureBox();
            this.groupBoxFrequency = new System.Windows.Forms.GroupBox();
            this.buttonFrequency = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.backgroundWorkerMatlab = new System.ComponentModel.BackgroundWorker();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.buttonMeasure = new System.Windows.Forms.Button();
            this.buttonElaborate = new System.Windows.Forms.Button();
            this.buttonUSB = new System.Windows.Forms.Button();
            this.serialPortUSB = new System.IO.Ports.SerialPort(this.components);
            this.textBoxData = new System.Windows.Forms.TextBox();
            this.textBoxScale = new System.Windows.Forms.TextBox();
            this.groupBoxScale = new System.Windows.Forms.GroupBox();
            this.buttonClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraphic)).BeginInit();
            this.groupBoxFrequency.SuspendLayout();
            this.groupBoxScale.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxFreq
            // 
            this.textBoxFreq.Location = new System.Drawing.Point(6, 19);
            this.textBoxFreq.Name = "textBoxFreq";
            this.textBoxFreq.Size = new System.Drawing.Size(115, 20);
            this.textBoxFreq.TabIndex = 0;
            this.textBoxFreq.Text = "615000";
            this.textBoxFreq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pictureBoxGraphic
            // 
            this.pictureBoxGraphic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxGraphic.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxGraphic.Image")));
            this.pictureBoxGraphic.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxGraphic.InitialImage")));
            this.pictureBoxGraphic.Location = new System.Drawing.Point(12, 130);
            this.pictureBoxGraphic.Name = "pictureBoxGraphic";
            this.pictureBoxGraphic.Size = new System.Drawing.Size(329, 236);
            this.pictureBoxGraphic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxGraphic.TabIndex = 1;
            this.pictureBoxGraphic.TabStop = false;
            // 
            // groupBoxFrequency
            // 
            this.groupBoxFrequency.Controls.Add(this.textBoxFreq);
            this.groupBoxFrequency.Controls.Add(this.buttonFrequency);
            this.groupBoxFrequency.Location = new System.Drawing.Point(12, 38);
            this.groupBoxFrequency.Name = "groupBoxFrequency";
            this.groupBoxFrequency.Size = new System.Drawing.Size(127, 86);
            this.groupBoxFrequency.TabIndex = 2;
            this.groupBoxFrequency.TabStop = false;
            this.groupBoxFrequency.Text = "Acquisition (Sample/s)";
            // 
            // buttonFrequency
            // 
            this.buttonFrequency.Enabled = false;
            this.buttonFrequency.Location = new System.Drawing.Point(6, 45);
            this.buttonFrequency.Name = "buttonFrequency";
            this.buttonFrequency.Size = new System.Drawing.Size(79, 35);
            this.buttonFrequency.TabIndex = 4;
            this.buttonFrequency.Text = "Change Frequency";
            this.buttonFrequency.UseVisualStyleBackColor = true;
            this.buttonFrequency.Click += new System.EventHandler(this.buttonFrequency_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(266, 67);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            // 
            // backgroundWorkerMatlab
            // 
            this.backgroundWorkerMatlab.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerMatlab_DoWork);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(12, 12);
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(329, 20);
            this.textBoxLog.TabIndex = 3;
            this.textBoxLog.Text = "COM1";
            // 
            // buttonMeasure
            // 
            this.buttonMeasure.Enabled = false;
            this.buttonMeasure.Location = new System.Drawing.Point(145, 83);
            this.buttonMeasure.Name = "buttonMeasure";
            this.buttonMeasure.Size = new System.Drawing.Size(78, 35);
            this.buttonMeasure.TabIndex = 4;
            this.buttonMeasure.Text = "Measure";
            this.buttonMeasure.UseVisualStyleBackColor = true;
            this.buttonMeasure.Click += new System.EventHandler(this.buttonMeasure_Click);
            // 
            // buttonElaborate
            // 
            this.buttonElaborate.Location = new System.Drawing.Point(266, 38);
            this.buttonElaborate.Name = "buttonElaborate";
            this.buttonElaborate.Size = new System.Drawing.Size(75, 23);
            this.buttonElaborate.TabIndex = 5;
            this.buttonElaborate.Text = "Elaborate";
            this.buttonElaborate.UseVisualStyleBackColor = true;
            this.buttonElaborate.Click += new System.EventHandler(this.buttonElaborate_Click);
            // 
            // buttonUSB
            // 
            this.buttonUSB.Location = new System.Drawing.Point(347, 10);
            this.buttonUSB.Name = "buttonUSB";
            this.buttonUSB.Size = new System.Drawing.Size(75, 23);
            this.buttonUSB.TabIndex = 5;
            this.buttonUSB.Text = "Start";
            this.buttonUSB.UseVisualStyleBackColor = true;
            this.buttonUSB.Click += new System.EventHandler(this.buttonUSB_Click);
            // 
            // serialPortUSB
            // 
            this.serialPortUSB.BaudRate = 115200;
            this.serialPortUSB.DtrEnable = true;
            this.serialPortUSB.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPortUSB_DataReceived);
            // 
            // textBoxData
            // 
            this.textBoxData.Location = new System.Drawing.Point(347, 39);
            this.textBoxData.Multiline = true;
            this.textBoxData.Name = "textBoxData";
            this.textBoxData.ReadOnly = true;
            this.textBoxData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxData.Size = new System.Drawing.Size(164, 274);
            this.textBoxData.TabIndex = 3;
            // 
            // textBoxScale
            // 
            this.textBoxScale.Location = new System.Drawing.Point(6, 19);
            this.textBoxScale.Name = "textBoxScale";
            this.textBoxScale.Size = new System.Drawing.Size(106, 20);
            this.textBoxScale.TabIndex = 6;
            this.textBoxScale.Text = "16";
            this.textBoxScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBoxScale
            // 
            this.groupBoxScale.Controls.Add(this.textBoxScale);
            this.groupBoxScale.Location = new System.Drawing.Point(347, 319);
            this.groupBoxScale.Name = "groupBoxScale";
            this.groupBoxScale.Size = new System.Drawing.Size(118, 45);
            this.groupBoxScale.TabIndex = 7;
            this.groupBoxScale.TabStop = false;
            this.groupBoxScale.Text = "Scale (μs)";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(436, 9);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 5;
            this.buttonClear.Text = "Delete";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // SinusoidalArduino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 376);
            this.Controls.Add(this.groupBoxScale);
            this.Controls.Add(this.buttonMeasure);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonUSB);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonElaborate);
            this.Controls.Add(this.textBoxData);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.groupBoxFrequency);
            this.Controls.Add(this.pictureBoxGraphic);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SinusoidalArduino";
            this.Text = "SinusoidalArduino";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraphic)).EndInit();
            this.groupBoxFrequency.ResumeLayout(false);
            this.groupBoxFrequency.PerformLayout();
            this.groupBoxScale.ResumeLayout(false);
            this.groupBoxScale.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFreq;
        private System.Windows.Forms.PictureBox pictureBoxGraphic;
        private System.Windows.Forms.GroupBox groupBoxFrequency;
        private System.Windows.Forms.Button buttonMeasure;
        private System.Windows.Forms.Button buttonStop;
        private System.ComponentModel.BackgroundWorker backgroundWorkerMatlab;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Button buttonElaborate;
        private System.Windows.Forms.Button buttonFrequency;
        private System.Windows.Forms.Button buttonUSB;
        private System.IO.Ports.SerialPort serialPortUSB;
        private System.Windows.Forms.TextBox textBoxData;
        private System.Windows.Forms.TextBox textBoxScale;
        private System.Windows.Forms.GroupBox groupBoxScale;
        private System.Windows.Forms.Button buttonClear;
    }
}

