
namespace iot2022___
{
    partial class Form1
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
            this.Serial_start = new System.Windows.Forms.Button();
            this.Serial_stop = new System.Windows.Forms.Button();
            this.Read_From_TS = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Current_data = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.get_Temp = new System.Windows.Forms.Button();
            this.get_motion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Serial_start
            // 
            this.Serial_start.Location = new System.Drawing.Point(32, 36);
            this.Serial_start.Name = "Serial_start";
            this.Serial_start.Size = new System.Drawing.Size(75, 23);
            this.Serial_start.TabIndex = 0;
            this.Serial_start.Text = "Serial_start";
            this.Serial_start.UseVisualStyleBackColor = true;
            this.Serial_start.Click += new System.EventHandler(this.Serial_start_Click);
            // 
            // Serial_stop
            // 
            this.Serial_stop.Location = new System.Drawing.Point(32, 128);
            this.Serial_stop.Name = "Serial_stop";
            this.Serial_stop.Size = new System.Drawing.Size(75, 23);
            this.Serial_stop.TabIndex = 1;
            this.Serial_stop.Text = "Serial_stop";
            this.Serial_stop.UseVisualStyleBackColor = true;
            this.Serial_stop.Click += new System.EventHandler(this.Serial_stop_Click);
            // 
            // Read_From_TS
            // 
            this.Read_From_TS.Location = new System.Drawing.Point(32, 303);
            this.Read_From_TS.Name = "Read_From_TS";
            this.Read_From_TS.Size = new System.Drawing.Size(75, 23);
            this.Read_From_TS.TabIndex = 2;
            this.Read_From_TS.Text = "Temperature";
            this.Read_From_TS.UseVisualStyleBackColor = true;
            this.Read_From_TS.Click += new System.EventHandler(this.Read_From_TS_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(152, 332);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Value";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Current_data
            // 
            this.Current_data.AutoSize = true;
            this.Current_data.Location = new System.Drawing.Point(152, 138);
            this.Current_data.Name = "Current_data";
            this.Current_data.Size = new System.Drawing.Size(68, 13);
            this.Current_data.TabIndex = 4;
            this.Current_data.Text = "Current_data";
            this.Current_data.Click += new System.EventHandler(this.Current_data_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(155, 227);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.PortName = "COM4";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // get_Temp
            // 
            this.get_Temp.Location = new System.Drawing.Point(32, 332);
            this.get_Temp.Name = "get_Temp";
            this.get_Temp.Size = new System.Drawing.Size(75, 23);
            this.get_Temp.TabIndex = 6;
            this.get_Temp.Text = "Light";
            this.get_Temp.UseVisualStyleBackColor = true;
            this.get_Temp.Click += new System.EventHandler(this.get_Temp_Click);
            // 
            // get_motion
            // 
            this.get_motion.Location = new System.Drawing.Point(32, 373);
            this.get_motion.Name = "get_motion";
            this.get_motion.Size = new System.Drawing.Size(75, 23);
            this.get_motion.TabIndex = 7;
            this.get_motion.Text = "Motion";
            this.get_motion.UseVisualStyleBackColor = true;
            this.get_motion.Click += new System.EventHandler(this.get_motion_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.get_motion);
            this.Controls.Add(this.get_Temp);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Current_data);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Read_From_TS);
            this.Controls.Add(this.Serial_stop);
            this.Controls.Add(this.Serial_start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Serial_start;
        private System.Windows.Forms.Button Serial_stop;
        private System.Windows.Forms.Button Read_From_TS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Current_data;
        private System.Windows.Forms.TextBox textBox1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button get_Temp;
        private System.Windows.Forms.Button get_motion;
    }
}

