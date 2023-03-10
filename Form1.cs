using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iot2022___
{
    public partial class Form1 : Form
    {
        int startflag = 0;
        int flag_sensor;
        string RxString;
        string temp, light, motion = "0";
        char charb = 'B';
        public Form1()
        {
            InitializeComponent();
        }

        private void Serial_start_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = "COM4";
            serialPort1.BaudRate = 115200;
            serialPort1.Open();
            if (serialPort1.IsOpen)
            {

                textBox1.ReadOnly = false;
            }
        }

        private void Serial_stop_Click(object sender, EventArgs e)
        {
            serialPort1.Close();

            textBox1.ReadOnly = true;
        }

        private void Read_From_TS_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();

            label1.Text = client.DownloadString("http://api.thingspeak.com/channels/1984917/field/field1/last.text");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
            serialPort1.PortName = "COM4";
            serialPort1.BaudRate = 115200;
        }

        private void Current_data_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(RxString);
        }
        private void get_Temp_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();

            //string Text = client.DownloadString("http://api.thingspeak.com/channels/1984917/field/field2/last.text");

            label1.Text = client.DownloadString("http://api.thingspeak.com/channels/1984917/field/field2/last.text");


        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void get_motion_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            label1.Text = label1.Text= client.DownloadString("http://api.thingspeak.com/channels/1984917/field/field3/last.text");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!string.Equals(textBox1.Text, ""))
            {
                if (serialPort1.IsOpen) 
                {
                    serialPort1.Close();
                    try
                    {
                        if (RxString[0] == 'B')
                        {
                            //Console.WriteLine(RxString);
                            flag_sensor = 10;
                        }
                        const string WRITEKEY = "4Q4VQSV2MX8XFJDE"; ////use your channel API keys
                        string strUpdateBase = "http://api.thingspeak.com/update";
                        string strUpdateURI = strUpdateBase + "?key=" + WRITEKEY;
                        //Console.WriteLine(strUpdateURI);
                        string strField1 = textBox1.Text;
                        //string strField1 = temp;
                        //string strField2 = voice;
                        //string strField2 = "42";
                        HttpWebRequest ThingsSpeakReq;
                        HttpWebResponse ThingsSpeakResp;

                        if (flag_sensor == 11)
                        {
                            //strUpdateURI += "&field1=" + strField1;
                            strUpdateURI += "&field1=" + temp;
                        }
                        else if (flag_sensor == 12)
                        {
                            strUpdateURI += "&field2=" + light;
                            //strUpdateURI += "&field2=" + strField1;
                        }
                        else if (flag_sensor == 13)
                        {
                            strUpdateURI += "&field3=" + motion;
                        }
                        else
                        {
                        }
                            
                        flag_sensor++;

                        ThingsSpeakReq = (HttpWebRequest)WebRequest.Create(strUpdateURI);
                        ThingsSpeakResp = (HttpWebResponse)
                        ThingsSpeakReq.GetResponse();
                        ThingsSpeakResp.Close();

                        if (!(string.Equals(ThingsSpeakResp.StatusDescription, "OK")))
                        {
                            Exception exData = new Exception(ThingsSpeakResp.StatusDescription);
                            throw exData;
                        }
                        textBox1.Text = "";
                        serialPort1.Open();
                    }
                    catch (Exception ex)
                    {
                    }
                }  
            }
        }



        private void SerialPort1_DataReceived(object sender,System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            Console.WriteLine("Data Received");
            RxString = serialPort1.ReadExisting();
            Console.WriteLine(RxString);
            if (RxString.Contains(charb))
            {
                startflag = 9;
            }
            else 
            { 
            }
            if (startflag == 9)
            {
                startflag++;
            }
            else if (startflag == 10)
            {
                Console.WriteLine(RxString);
                temp = RxString;
                startflag++;
            }
            else if (startflag == 11)
            {
                Console.WriteLine(RxString);
                light = RxString;
                startflag++;
            }
            else if (startflag == 12)
            {
                Console.WriteLine(RxString);
                motion = RxString;
                startflag++;
            }
            else
            {
                // startflag = 0;
            }
            this.Invoke(new EventHandler(Current_data_Click));
        }

    }

}
