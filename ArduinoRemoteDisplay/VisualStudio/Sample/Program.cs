using System;
using System.Collections.Generic;
using System.Text;

using MqttLib;

namespace Sample
{
    class Program
    {
        static void Main()
        {
            // if (args.Length != 4)
            // {
            //
            //    Console.WriteLine("Usage: " + Environment.GetCommandLineArgs()[0]
            //         + " cloudmqtt_connectionString ClientId cloudmqtt_username cloudmqtt_password");
            //   return;
            //}
            string [] args1=new string[4];
            Console.WriteLine("Starting MqttDotNet sample program.");
            Console.WriteLine("Press any key to stop\n");
            args1[0] = "tcp://m13.cloudmqtt.com:18462";
            args1[1] = "GGGG";
            args1[2] = "dredrqkn";
            args1[3] = "C8uapIdgxl3y";
            Program prog = new Program(args1[0], args1[1], args1[2], args1[3]);
            prog.Start();
            prog.RegisterOurSubscriptions();
            prog.PublishSomething();
            //do
           // {
              //                
            //} while (true);
            prog.Stop();
        }

        IMqtt _client;

        Program(string connectionString, string clientId, string username, string password)
        {
            // Instantiate client using MqttClientFactor

            _client = MqttClientFactory.CreateClient(connectionString, clientId, username, password);

            // Setup some useful client delegate callbacks
            _client.Connected += new ConnectionDelegate(client_Connected);
            _client.ConnectionLost += new ConnectionDelegate(_client_ConnectionLost);
            _client.PublishArrived += new PublishArrivedDelegate(client_PublishArrived);
        }

        void Start()
        {
            // Connect to broker in 'CleanStart' mode
            Console.WriteLine("Client connecting\n");
            _client.Connect(true);
        }

        void Stop()
        {
            if (_client.IsConnected)
            {
                Console.WriteLine("Client disconnecting\n");
                _client.Disconnect();
                Console.WriteLine("Client disconnected\n");
            }
        }

        void client_Connected(object sender, EventArgs e)
        {
            Console.WriteLine("Client connected\n");
            RegisterOurSubscriptions();
            PublishSomething();
        }

        void _client_ConnectionLost(object sender, EventArgs e)
        {
            Console.WriteLine("Client connection lost\n");
        }

        void RegisterOurSubscriptions()
        {
            Console.WriteLine("Subscribing to mqttdotnet/subtest/#\n");
            _client.Subscribe("mqttdotnet/subtest/#", QoS.BestEfforts);
        }

        void PublishSomething()
        {
            Console.WriteLine("Publishing on mqttdotnet/pubtest\n");
            _client.Publish("mqttdotnet/pubtest", "Hello MQTT World", QoS.BestEfforts, false);
        }

        bool client_PublishArrived(object sender, PublishArrivedArgs e)
        {
            Console.WriteLine("Received Message");
            Console.WriteLine("Topic: " + e.Topic);
            Console.WriteLine("Payload: " + e.Payload);
            Console.WriteLine();
            return true;
        }
    }
}