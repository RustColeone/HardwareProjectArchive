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

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Hello World!");
            timeup = 1;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            //Myport.setcomstep(0, true);
            timeup = 1;
            //timer2.Enabled = false;        
        }

        private void SavewhenExit()
        {
            string path = Directory.GetCurrentDirectory();
            //@"c:\temp\MyTest.txt";
            path = path + "\\datafile.txt";
            // This text is added only once to the file.
            if (File.Exists(path))
                File.Delete(path);
            // Create a file to write to.
            ClientID = textBoxMqttClient.Text; //"clientID";
            intopic = textBoxINTopic.Text; // = "mqttdotnet/subtest/#";
            outtopic = textBoxOUTTopic.Text; // = "mqttdotnet/pubtest";
            BrokerServer = textBoxBrokerServer.Text; // = "tcp://m13.cloudmqtt.com:18462";
            Port = textBoxBrokerPort.Text;
            UserID = textBoxUserID.Text; // = "dredrqkn";
            Password = textBoxMqttPass.Text; // = "C8uapIdgxl3y";
            WiFissid = textBoxSSID.Text;
            WiFipass = textBoxSSIDPASS.Text;
            string createText = Password + Environment.NewLine
                + UserID + Environment.NewLine
                + ClientID + Environment.NewLine
                + BrokerServer + Environment.NewLine
                + outtopic + Environment.NewLine;
            File.WriteAllText(path, createText, Encoding.UTF8);
            createText = intopic + Environment.NewLine
                + Port + Environment.NewLine
                + WiFissid + Environment.NewLine
                + WiFipass + Environment.NewLine;
            File.AppendAllText(path, createText, Encoding.UTF8);
        }


        private void LoadwhenEnter()
        {
            string path = Directory.GetCurrentDirectory();
            //@"c:\temp\MyTest.txt";
            path = path + "\\datafile.txt";
            if (File.Exists(path))
            {    // Open the file to read from.
                string readText = File.ReadAllText(path);
                StringReader strReader = new StringReader(readText);
                Password = strReader.ReadLine();
                UserID = strReader.ReadLine();
                ClientID = strReader.ReadLine();
                BrokerServer = strReader.ReadLine();
                outtopic = strReader.ReadLine();
                intopic = strReader.ReadLine();
                Port = strReader.ReadLine();
                WiFissid = strReader.ReadLine(); ;
                WiFipass = strReader.ReadLine(); ;

                textBoxMqttClient.Text = ClientID; //"clientID";
                textBoxINTopic.Text = intopic; // = "mqttdotnet/subtest/#";
                textBoxOUTTopic.Text = outtopic; // = "mqttdotnet/pubtest";
                textBoxBrokerServer.Text = BrokerServer; // = "tcp://m13.cloudmqtt.com:18462";
                textBoxBrokerPort.Text = Port;
                textBoxUserID.Text = UserID; // = "dredrqkn";
                textBoxMqttPass.Text = Password; // = "C8uapIdgxl3y";
                textBoxSSID.Text = WiFissid;
                textBoxSSIDPASS.Text = WiFipass;
                strReader.Close();
            }
        }


        private void ConnectMqtt()
        {
            //aTimer.Enabled = true; //Set must completed within 3 seconds       
            timeup = 0;
            if (Myport.PortIsOpen() == false && internetconnected == 1)
                textBoxStatus.Text = "Serial Port or internet not connected";
            else
            {
                string stt = comboBoxPortSetect.SelectedItem.ToString();
                Myport.Serialinit(stt);
                //wait for return signal//
                Myport.setcomstep(true); //reset comstep
                Myport.TxText("X4X" + textBoxMqttPass.Text);
                //wait for return signal//
                do { Thread.Sleep(10); if (timeup == 1) break; } while (Myport.setcomstep() != 'a');
                progressBarStatus.Value = 16;
                Myport.TxText("X5X" + textBoxBrokerServer.Text);
                //wait for return signal//           
                do { Thread.Sleep(10); if (timeup == 1) break; } while (Myport.setcomstep() != 'b');
                progressBarStatus.Value = 17;
                Myport.TxText("X6X" + textBoxBrokerPort.Text);
                //wait for return signal//
                do { Thread.Sleep(10); if (timeup == 1) break; } while (Myport.setcomstep() != 'c');
                progressBarStatus.Value = 18;
                Myport.getRx();
                Myport.TxText("X7X" + textBoxUserID.Text);
                //wait for return signal//
                do { Thread.Sleep(10); if (timeup == 1) break; } while (Myport.setcomstep() != 'd');
                progressBarStatus.Value = 19;
                Myport.getRx();
                Myport.TxText("X8X" + textBoxMqttClient.Text);
                //wait for return signal//
                do { Thread.Sleep(10); if (timeup == 1) break; } while (Myport.setcomstep() != 'e');
                progressBarStatus.Value = 20;
                Myport.getRx();
                Myport.TxText("X9X" + "AAA");
                //wait for return signal//
                do { Thread.Sleep(10); if (timeup == 1) break; } while (Myport.setcomstep() != 'f' && Myport.setcomstep() != 'g');
                Myport.getRx();
                if (Myport.setcomstep() == 'f')
                {
                    textBoxStatus.Text = "Mqtt connected";
                    Mqttconnected = 1;
                    progressBarStatus.Value = 25;
                }
                else
                    textBoxStatus.Text = "Mqtt connect failure";
            }
            aTimer.Enabled = false;
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SavewhenExit();
        }
        /// ////////////////////////////WIFI /////////////  
        private void buttonConnectWifi_Click(object sender, EventArgs e)
        {
            buttonWiFiConnect();
            textBoxStatus.Text = "Internet connected";
            Update();
            if (internetconnected == 1)
            {
                ConnectMqtt();
                Update();
            }
            else
            {
                textBoxStatus.Text = " Internet connect failure";
            }
            if (Mqttconnected == 1)
            {
                TopicUpdata();
                Update();
                progressBarStatus.Value = 30;
                textBoxStatus.Text = " Internet and Mqtt Connected";
                buttonConnectWifi.Text = "ReConnect";
            }
            else
                buttonConnectWifi.Text = "Connect";
        }





        private void buttonWiFiConnect()
        {
            //aTimer.Enabled = true; //Set must completed within 3 seconds                          
            timeup = 0;
            if (Myport.PortIsOpen() == false)
            {
                string stt = comboBoxPortSetect.SelectedItem.ToString();
                Myport.Serialinit(stt);
            }
            if (Myport.PortIsOpen() == false)
                textBoxStatus.Text = "Port Not Open";
            else
            {
                progressBarStatus.Value = 5;
                Myport.setcomstep(true); //reset comstep     
                Myport.TxText("XgX" + textBoxSSID.Text);
                do { Thread.Sleep(10); if (timeup == 1) break; } while (Myport.setcomstep() != '7');
                progressBarStatus.Value = 10;
                Myport.TxText("XhX" + textBoxSSIDPASS.Text);
                do { Thread.Sleep(10); if (timeup == 1) break; } while (Myport.setcomstep() != '8' && Myport.setcomstep() != '9');
                if (Myport.setcomstep() == '8')
                {
                    textBoxIP.Text = Myport.getRx();
                    internetconnected = 1;
                    progressBarStatus.Value = 15;
                }
                else
                {
                    textBoxStatus.Text = "Internet connect failure";
                    internetconnected = 0;
                }
                aTimer.Enabled = false; //disable timer
            }
        }

        private void TopicUpdata()
        {//aTimer.Enabled = true; //Set must completed within 3 seconds                          
            timeup = 0;
            //wait for return signal//
            Myport.setcomstep(true); //reset comstep
            Myport.TxText("XUX" + textBoxINTopic.Text);
            do { Thread.Sleep(10); if (timeup == 1) break; } while (Myport.setcomstep() != '3');
            textBoxINTopic.Text = Myport.getRx();
            Myport.TxText("XVX" + textBoxOUTTopic.Text);
            do { Thread.Sleep(10); if (timeup == 1) break; } while (Myport.setcomstep() != '4');
            textBoxOUTTopic.Text = Myport.getRx();
            buttonTopicUpdata.Text = "Updated";
            aTimer.Enabled = false; //disable timer
        }


        private void buttonTopicUpdata_Click(object sender, EventArgs e)
        {
            TopicUpdata();
        }

        private void textBoxINTopic_TextChanged(object sender, EventArgs e)
        {
            buttonTopicUpdata.Text = "Update";
        }

        private void textBoxOUTTopic_TextChanged(object sender, EventArgs e)
        {
            buttonTopicUpdata.Text = "Update";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //aTimer.Enabled = true; //Set must completed within 3 seconds                          
            timeup = 0;
            buttonTX.Text = "TX Ready";
            //wait for return signal//
            Myport.setcomstep(true); //reset comstep
            buttonTX.Text = "TX wait";
            Myport.TxText("XTX" + textBoxTXdata.Text);
            do { Thread.Sleep(10); if (timeup == 1) break; } while (Myport.setcomstep() != '2');
            buttonTX.Text = "TX OK";
            aTimer.Enabled = false; //disable timer
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            //aTimer.Enabled = true; //Set must completed within 3 seconds                          
            timeup = 0;
            //wait for return signal//
            Myport.setcomstep(true); //reset comstep
            Myport.TxText("XYX" + textBoxTXdata.Text);
            do { Thread.Sleep(10); if (timeup == 1) break; } while (Myport.setcomstep() != '6');
            textBoxRXtopic.Text = Myport.getRx();
            Myport.TxText("XWX" + textBoxTXdata.Text);
            do { Thread.Sleep(10); if (timeup == 1) break; } while (Myport.setcomstep() != '5');
            textBoxRXdata.Text = Myport.getRx();
            buttonRefresh.Text = "Refresh OK";
            aTimer.Enabled = false; //disable timer
        }
    }
}