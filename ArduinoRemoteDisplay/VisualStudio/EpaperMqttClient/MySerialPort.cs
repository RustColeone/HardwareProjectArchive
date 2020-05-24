using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

//namespace ESP8266MQTTControl
//{
public class MySerialPort
{
    static int comstep = 0;
    static string bufout;
    static char[] Password = new char[55];
    static char[] UserID = new char[55];
    static char[] Connected = new char[55];
    static char[] Broker = new char[55];
    static char[] Port = new char[55];
    static char[] MqttID = new char[55];
    static char[] MqttPASS = new char[55];
    static char[] MqttClient = new char[55];

    /*
    static string SPassword;
    static string SUserID;
    static string SConnected;

    static string SBroker;
    static string SPort;
    static string SMqttID;
    static string SMqttPASS;
    static string SMqttClient;
    */

    SerialPort serialPort1 = new SerialPort();

   
    public int setcomstep(bool clr=false)
    {if (clr) comstep = 0;
        return comstep;
    }



    public MySerialPort()
    {
    }

    public bool Serialinit(string portname)
    {
        bool re = false;
        try
        {
            serialPort1.BaudRate = 38400;
            serialPort1.Parity = System.IO.Ports.Parity.None;
            serialPort1.DataBits = 8;
            serialPort1.StopBits = System.IO.Ports.StopBits.One;
            serialPort1.Handshake = System.IO.Ports.Handshake.None;
            //serialPort1.ReadTimeout = 500;
            //serialPort1.WriteTimeout = 500;
            //comboBoxPortSetect.SelectedIndex = 1;
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            serialPort1.PortName = portname;
            serialPort1.Open();
            re = true;
        }
        catch
        {
            re = false;
        }
        return re;
    }

    public bool TxText(string text)
    {if (serialPort1.IsOpen)
        {
            serialPort1.WriteLine(text);
            return serialPort1.IsOpen;
        }
        else
            return false;
    }

    public bool PortIsOpen()
    {
        return serialPort1.IsOpen;
    }


    public string getRx()
    {
        char [] cc = new char[50];       
        if(bufout.Length>8)
            cc = bufout.ToCharArray(8, bufout.Length-8);
        for (int t = 8; t < bufout.Length - 8; t++)
        {
            if (cc[t] <= ' ')
                cc[t] = '\0';
        }
        String s = new string(cc);
        return s;
    }


    
    private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
    {
        Thread.Sleep(100);
        char[] carray = new char[10];        
        SerialPort sp = (SerialPort)sender;
        string buf = sp.ReadExisting();
        if (buf.Length > 8)
        {
            carray = buf.ToCharArray(0, 3);
            if (carray[0] == 'Y' && carray[2] == 'Y')
            {
                comstep = carray[1];
                bufout = buf;
            }            
        }
    }

    ~MySerialPort()
    {
        serialPort1.Close();
    }
}

