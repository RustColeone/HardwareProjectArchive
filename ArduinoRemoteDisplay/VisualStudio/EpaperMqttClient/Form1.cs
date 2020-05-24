using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;
using System.Timers;

namespace EpaperMqtt
{
    public partial class Form1 : Form
    {
        
        static int timeup = 0;
        /*
        int internetconnected = 0;
        int Mqttconnected = 0;

        string Password;
        string UserID;
        string ClientID;
        string BrokerServer;
        string outtopic;
        string intopic;
        string Port;
        string WiFissid;
        string WiFipass;
        */
        private MySerialPort Myport = new MySerialPort();
        System.Timers.Timer aTimer = new System.Timers.Timer();

        public Form1()
        {
            InitializeComponent();
            LoadwhenEnter();
            comboBoxPortSetect.Items.Clear();
            try
            {
                foreach (string s in SerialPort.GetPortNames())
                {
                    comboBoxPortSetect.Items.Add(s);
                }
                comboBoxPortSetect.SelectedIndex = 0;
            }
            catch
            {
                comboBoxPortSetect.Items.Add("No serial port found");
                textBoxStatus.Text = "No Serial port found";
                comboBoxPortSetect.SelectedIndex = 0;
            }

            progressBarStatus.Maximum = 30;


            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 3000;
            //aTimer.Enabled = true;
        }      
    }
}
