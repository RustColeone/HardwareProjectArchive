#define EPD231
//#define EPD27

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
using MqttLib;



namespace EpaperMqtt
{

    public partial class Form1 : Form
    {
        static int timeup = 0;
#if (EPD27)
        byte[] imagebuffer = new byte[5808];
#else
        byte[] imagebuffer = new byte[4000];  //picture 250 *122
#endif
        private MySerialPort Myport = new MySerialPort();
        System.Timers.Timer aTimer = new System.Timers.Timer();

        /// for PC    
        /// 
        enum Status { NotConnect, Connected, ConnectedRegisterd, ConnectionLost, UnableRegist };
        IMqtt _client;
        string IncomMessage = "100";
        string InComPicture = "";
        Status ConnectStstus = Status.NotConnect;

        string PPassword;
        string PUserID;
        string PClientID;
        string PBrokerServer;
        string Ppublishtopic;
        string Pclienttopic;
        string PPort;
        /// for PC  
        /// 
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            timeup = 1;
        }

        void refresh()
        {
            textBoxIncomming.Text = IncomMessage;
        }




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
#if (EPD27)
            progressBarUpPicture.Maximum = 95;
#else
            progressBarUpPicture.Maximum = 80;
#endif
            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Tick += new EventHandler(timer1_Tick);

            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 3000;
            //aTimer.Enabled = true;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            textBoxIncomming.Text = IncomMessage;
            timer1.Enabled = true; //disable timer          
        }


        void ProgramSetup(string connectionString, string clientId, string username, string password)
        {
            // Instantiate client using MqttClientFactor
            _client = MqttClientFactory.CreateClient(connectionString, clientId, username, password);
            // Setup some useful client delegate callbacks
            _client.Connected += new ConnectionDelegate(client_Connected);
            _client.ConnectionLost += new ConnectionDelegate(_client_ConnectionLost);
            _client.PublishArrived += new PublishArrivedDelegate(client_PublishArrived);
            //textBoxIncomming.Text = e.Payload;           
        }

        void client_Connected(object sender, EventArgs e)
        {
            textBoxMqttStatus.Text = "Client connected";
            ConnectStstus = Status.Connected;
            //buttonConnect.Enabled=true;           
            //Console.WriteLine("Client connected\n");
            //textBoxStatus.Text = "Client connected\n";
            //RegisterOurSubscriptions();
            //    PublishSomething(publishtopic, textBoxContent.Text);           
        }
        /*
        bool client_PublishArrived(object sender, PublishArrivedArgs e)
        {
            //IncomMessage = "Topic: " + e.Topic + "Payload: " + e.Payload;
            IncomMessage = e.Payload;
            return true;
        }
        */
        void _client_ConnectionLost(object sender, EventArgs e)
        {
            //Console.WriteLine("Client connection lost\n");         
            textBoxMqttStatus.Text = "Client connection lost";
            ConnectStstus = Status.ConnectionLost;
            buttonConnect.Text = "Connect";
        }

        void RegisterOurSubscriptions(string topic)
        {
            //Console.WriteLine("Subscribing to mqttdotnet/subtest/#\n");
            //    ComMessage = "Subscribing to " + topic;
            int returnvalue=_client.Subscribe(topic + "/#", QoS.BestEfforts);
            if (returnvalue > 0)
                ConnectStstus = Status.ConnectedRegisterd;
            else
            {
                textBoxAllStatus.Text = "Publish  Unable to resgisted ";
                ConnectStstus = Status.UnableRegist;
            }
        }

        void Start()
        {
            // Connect to broker in 'CleanStart' mode
            // Console.WriteLine("Client connecting\n");           
            _client.Connect(true);
        }

        void Stop()
        {
            if (_client.IsConnected)
            {
                //Console.WriteLine("Client disconnecting\n");
                textBoxMqttStatus.Text = "Mqtt disconnected";
                _client.Disconnect();
                //Console.WriteLine("Client disconnected\n");                            
            }
        }

       

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            ConnectPCMqtt(false);
        }


        private void ConnectPCMqtt(bool forceconnect)
        {

            try
            {
                if (buttonConnect.Text == "Disconnect" && forceconnect == false)
                    Stop();
                else
                {
                    if (ConnectStstus == Status.NotConnect || ConnectStstus == Status.ConnectionLost)
                    {
                        textBoxMqttStatus.Text = "Starting....";
                        textBoxAllStatus.Text = "Starting...."; ;
                        //         ComMessage = "Ready....";
                        ClientID = textBoxClientID.Text; //"clientID";
                        Pclienttopic = textBoxClientTopic.Text;  //"mqttdotnet/subtest/#";
                        Ppublishtopic = textBoxBrokerTopic.Text; //"mqttdotnet/pubtest";
                        BrokerServer = textBoxBrokerServer.Text; //"tcp://m13.cloudmqtt.com:18462";
                        UserID = textBoxUser.Text; //"dredrqkn";
                        Password = textBoxPassword.Text; // "C8uapIdgxl3y";
                        Port = textBoxBrokerPort.Text;
                        ProgramSetup("tcp://" + BrokerServer + ":" + Port, ClientID, UserID, Password);
                        Start();
                        buttonConnect.Text = "Disconnect";
                        textBoxMqttStatus.Text = "Mqtt Connected";
                        textBoxAllStatus.Text = "Mqtt Connected";
                        ConnectStstus = Status.Connected;
                    }
                    else
                    {
                        if (ConnectStstus == Status.Connected || ConnectStstus == Status.ConnectedRegisterd)
                        {
                            buttonPublish.Enabled = true;
                            Stop();
                            buttonConnect.Text = "Disconnect";
                            textBoxMqttStatus.Text = "Mqtt Connected";
                            textBoxAllStatus.Text = "Mqtt Connected";
                            Regist();
                        }
                    }
                }
            }
            catch
            {
                textBoxStatus.Text = "Error unable to connect";
                textBoxMqttStatus.Text = "Error unable to connect";
                textBoxAllStatus.Text = "Error unable to connect";
            }
        }

        void PublishSomething(string topic, MqttPayload payload)
        {
            //Console.WriteLine("Publishing on mqttdotnet/pubtest\n");
            // ComMessage = "Publishing on mqttdotnet/pubtest";
            //_client.Publish("mqttdotnet/pubtest", "Hello MQTT World", QoS.BestEfforts, false);
            _client.Publish(topic, payload, QoS.BestEfforts, false);
        }


        private void buttonPublish_Click(object sender, EventArgs e)
        {
            Publish(textBoxContent.Text);
        }

        bool client_PublishArrived(object sender, PublishArrivedArgs e)
        {
            //IncomMessage = "Topic: " + e.Topic + "Payload: " + e.Payload;                   
            if (e.Topic == "RXPicture")
                InComPicture = e.Payload;
            else
                IncomMessage = e.Payload;
            aTimer.Enabled = true; //disable timer
            return true;
        }

        // textBoxIncomming.Text = IncomMessage;
        private void Publish(string pstring)
        {
            if (ConnectStstus == Status.ConnectedRegisterd || ConnectStstus == Status.Connected)
            {
                PublishSomething(Ppublishtopic, pstring);
                textBoxClientStatus.Text = "Published";
            }
            else
                textBoxClientStatus.Text = "Publish error, Not Connected";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            //textBoxIncomming.Text = IncomMessage;
            textBoxIncomming.Text = "";
            IncomMessage = "";
        }


        private void button6_Click(object sender, EventArgs e)
        {
            timeup = 0;
            //wait for return signal//
            Myport.setcomstep(true); //reset comstep
            Myport.TxText("XYX" + textBoxTXdata.Text);
            do { Thread.Sleep(10); if (timeup == 1) break; } while (Myport.setcomstep() != '6');
            textBoxRXtopic.Text = Myport.getRx();
            Myport.TxText("XWX" + textBoxTXdata.Text);
            do { Thread.Sleep(10); if (timeup == 1) break; } while (Myport.setcomstep() != '5');
            textBoxRXdata.Text = Myport.getRx();
            //buttonRefresh.Text = "Refresh OK";
            aTimer.Enabled = false; //disable timer
        }

        /// aaaa down ////

        public byte[] GetBytes(string bitString)
        {
            return Enumerable.Range(0, bitString.Length / 8).
                Select(pos => Convert.ToByte(
                    bitString.Substring(pos * 8, 8),
                    2)
                ).ToArray();
        }

        private String HexConverter(System.Drawing.Color c)
        {
            if ((c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2")).Equals("000000"))
            //int col = c.R + c.G + c.B;            
            //if(col>1)
            {
                // image black pixel                
                return "1";
            }
            else
            {
                // image is not a black pixel
                return "0";
            }
        }

        // save text file
        private void saveTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);

            }
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picture_convert();
        }


        private void picture_convert()
        {           //264  +++++  176 +++++//
#if (EPD27)
            int pW = 264;
            int pH = 176;
#else
            int pW = 250;
            int pH = 128;//122
#endif
            textBox1.Text = "";
            int storecount = 0;
            openFileDialog1.FileName = "Bitmap file.bmp";
            openFileDialog1.Filter = "Bitmap files (*.bmp)|*.bmp|All files (*.*)|*.*";
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                Bitmap ShowImg = new Bitmap(pW, pH);//WH
                Bitmap myImg = (Bitmap)Bitmap.FromFile(file);
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("{" + Environment.NewLine);
                    StringBuilder sbLine = new StringBuilder();
                    //myImg.Width myImg.Height
                    if (radioButtonH.Checked)
                    {
                        for (int ww = pW - 1; ww >= 0; ww--)
                        {
                            for (int hh = 0; hh < pH; hh++)
                            {
                                if (ww < myImg.Width && hh < myImg.Height)   //must within store range                          
                                {
                                    Color pixelColor = myImg.GetPixel(ww, hh);
                                    sbLine.Append(HexConverter(pixelColor));
                                    if (HexConverter(pixelColor) == "0")
                                        ShowImg.SetPixel(ww, hh, Color.White);
                                    else
                                        ShowImg.SetPixel(ww, hh, Color.Black);
                                }
                                else
                                {
                                    sbLine.Append(0);
                                    ShowImg.SetPixel(ww, hh, Color.White);
                                }
                            }
                            // convert sbline string to byte array
                            byte[] buffer = GetBytes(sbLine.ToString());
                            for (int i = 0; i < pH / 8; i++)
                            {
                                imagebuffer[storecount++] = buffer[i];
                            }
                            // add first 0x to output row                        
                            sb.Append("0x");
                            // convert byte array to hex
                            sb.Append(BitConverter.ToString(buffer).Replace("-", ",0x"));
                            // clear line data
                            sbLine.Clear();
                            buffer = null;
                            // add comma to end of row
                            sb.Append(",");
                            // add new line
                            sb.Append(Environment.NewLine);
                        }
                    }
                    else
                    {
                        for (int hh = 0; hh < pH; hh++)
                        {
                            // loop each row of image
                            for (int ww = 0; ww < pW; ww++)
                            {
                                if (ww < myImg.Width && hh < myImg.Height)   //must within store range                          
                                {
                                    Color pixelColor = myImg.GetPixel(ww, hh);
                                    sbLine.Append(HexConverter(pixelColor));
                                    if (HexConverter(pixelColor) == "0")
                                        ShowImg.SetPixel(ww, hh, Color.White);
                                    else
                                        ShowImg.SetPixel(ww, hh, Color.Black);
                                }
                                else
                                {
                                    sbLine.Append(0);
                                    ShowImg.SetPixel(ww, hh, Color.White);
                                }
                            }

                            // convert sbline string to byte array
                            byte[] buffer = GetBytes(sbLine.ToString());
                            for (int i = 0; i < pW / 8; i++)
                            {
                                imagebuffer[storecount++] = buffer[i];
                            }
                            // add first 0x to output row                        
                            sb.Append("0x");
                            // convert byte array to hex
                            sb.Append(BitConverter.ToString(buffer).Replace("-", ",0x"));
                            // clear line data
                            sbLine.Clear();
                            buffer = null;
                            // add comma to end of row
                            sb.Append(",");
                            // add new line
                            sb.Append(Environment.NewLine);
                        }
                    }
                    // write output to screen
                    sb.Append("};" + Environment.NewLine);
                    textBox1.Text = sb.ToString();
                    pictureBox3.Image = ShowImg;
                }
            }
        }



        private void saveTextToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
            }
        }

        private void transferEpaper1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = pictureBox3.Image;
        }

        private void buttonPictureConvert_Click(object sender, EventArgs e)
        {
            picture_convert();
        }


        private void buttonSendtoEpaper_Click(object sender, EventArgs e)
        {
            SendtoEpaper();
        }

        private void SendtoEpaper()
        {
            int offset;
#if (EPD27)
            int bufsize = 88;
            int loopcount = 66;
#else
            int bufsize = 80;
            int loopcount = 50;
#endif
            int buffercount = 30;
            int txloop;
            byte[] txbuf = new byte[bufsize + 8];
            MqttPayload payload = new MqttPayload(txbuf, 0);
            if (ConnectStstus == Status.ConnectedRegisterd || ConnectStstus == Status.Connected)
            {
                RegisterOurSubscriptions("RXPicture");

                for (txloop = 0; txloop < loopcount; txloop++)
                {
                    offset = txloop * bufsize;
                    txbuf[1] = (byte)buffercount;
                    for (int fillpic = 0; fillpic < bufsize; fillpic++)
                        txbuf[fillpic + 8] = imagebuffer[fillpic + offset];
                    if (ConnectStstus == Status.ConnectedRegisterd || ConnectStstus == Status.Connected)
                    {
                        textBoxPublishPicStatus.Text = "Network connected";
                        textBoxPublishPicStatus.Enabled = true;
                        if (txloop == 0)
                            PublishSomething("fpicture", payload);
                        else
                            PublishSomething("spicture", payload);
                        int t = 3000;
                        try
                        {
                            do
                            {
                                Thread.Sleep(2);
                                if (InComPicture == "") InComPicture = "0";
                                if (t-- == 0)
                                    break;
                            }
                            while (Int32.Parse(InComPicture) != buffercount);
                            progressBarUpPicture.Value = Int32.Parse(InComPicture);
                        }
                        catch
                        { MessageBox.Show("Some thing wrong"); }
                    }
                    else
                    {
                        textBoxPublishPicStatus.Text = "No network connected";
                        textBoxPublishPicStatus.Enabled = false;
                    }
                    buffercount++;
                    InComPicture = "0";
                }
            }
            else
            {
                textBoxPublishPicStatus.Text = "No network connected";
                textBoxAllStatus.Text = "No network connected";
            }
        }
   
        /// aaaa up ////

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            Regist();
        }

        private void Regist()
        {
            if (ConnectStstus == Status.ConnectedRegisterd)
            {
                textBoxClientStatus.Text = "Client registed";
                textBoxAllStatus.Text = "Client registed";
            }
            else
            {
                if (ConnectStstus == Status.Connected)
                {
                    RegisterOurSubscriptions(Pclienttopic);
                    textBoxClientStatus.Text = "Client registed";
                    textBoxAllStatus.Text = "Client registed";
                    ConnectStstus = Status.ConnectedRegisterd;
                }

                else
                {
                    textBoxClientStatus.Text = "Network or Mqtt not connected";
                    textBoxAllStatus.Text = "Network or Mqtt not connected";
                }
            }
        }

        private void buttonLinkAll_Click(object sender, EventArgs e)
        {
            ConnectWifiESP8266();            
            ConnectPCMqtt(true);
            Regist();
        }
    }
}
