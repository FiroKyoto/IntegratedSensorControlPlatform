using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Communication
{
    public class Connect
    {
        #region construct

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="_server"></param>
        /// <param name="_client"></param>
        /// <param name="_host"></param>
        /// <param name="_port"></param>
        public Connect(bool _server, bool _client, string _host, int _port)
        {
            if (_server == true)
            {
                this.ServerConnect(_host, _port);
            }

            if (_client == true)
            {
                this.ClientConnect(_host, _port);
            }
        }

        #endregion 

        #region fields

        /// <summary>
        /// server socket
        /// </summary>
        private Socket server;

        /// <summary>
        /// client socket
        /// </summary>
        private Socket client;

        /// <summary>
        /// client IPEndPoint
        /// </summary>
        private IPEndPoint clientEp;

        /// <summary>
        /// network stream
        /// </summary>
        private NetworkStream ns;

        /// <summary>
        /// stream writer
        /// </summary>
        private StreamWriter sw;

        /// <summary>
        /// stream reader
        /// </summary>
        private StreamReader sr;

        /// <summary>
        /// received Data
        /// </summary>
        public string receivedData { get; set; }

        /// <summary>
        /// gets or sets debug message
        /// </summary>
        public string debugMsg { get; set; }

        #endregion

        #region server methods

        /// <summary>
        /// Server Connect
        /// </summary>
        /// <param name="_port"></param>
        private void ServerConnect(string _host, int _port)
        {
            IPAddress address = IPAddress.Parse(_host);
            IPEndPoint ipe = new IPEndPoint(address, _port);
            this.server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            this.server.Bind(ipe);
            this.server.Listen(10);

            this.client = this.server.Accept();
            this.clientEp = (IPEndPoint)this.client.RemoteEndPoint;

            this.ns = new NetworkStream(this.client);
            this.sw = new StreamWriter(this.ns);

            this.debugMsg = this.clientEp.Address.ToString();
        }

        /// <summary>
        /// Server send to data to client
        /// </summary>
        /// <param name="_msg"></param>
        public void ServerSendDataToClient(string _msg)
        {
            if (this.client.Connected == true)
            {
                this.sw.WriteLine(_msg);
                this.sw.Flush();
            }
        }

        /// <summary>
        /// Server Dispose
        /// </summary>
        public void ServerDispose()
        {
            if (this.ns != null)
            {
                this.ns.Close();
            }

            if (this.sw != null)
            {
                this.sw.Close();
            }

            if (this.client != null)
            {
                this.client.Shutdown(SocketShutdown.Both);
                this.client.Close();
            }

            if (this.server != null)
            {
                this.server.Close();
            }
        }

        #endregion

        #region client methods

        /// <summary>
        /// client connect
        /// </summary>
        /// <param name="_host"></param>
        /// <param name="_port"></param>
        private void ClientConnect(string _host, int _port)
        {
            IPAddress address = IPAddress.Parse(_host);
            IPEndPoint ipe = new IPEndPoint(address, _port);
            this.server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                this.server.Connect(ipe);
            }
            catch (SocketException e)
            {
                this.debugMsg = "Unable to connect to server" + e.ToString();
                return;
            }

            this.ns = new NetworkStream(this.server);
            this.sr = new StreamReader(this.ns);
        }

        /// <summary>
        /// Client Receive Data From Server
        /// </summary>
        public void ClientReceiveDataFromServer()
        {
            this.receivedData = null;

            if (this.sr != null)
            {
                this.receivedData = this.sr.ReadLine();
            }
        }

        /// <summary>
        /// Client Dispose
        /// </summary>
        public void ClientDispose()
        {
            if (this.ns != null)
            {
                this.ns.Close();
            }

            if (this.sr != null)
            {
                this.sr.Close();
            }

            if (this.server != null)
            {
                this.server.Shutdown(SocketShutdown.Both);
                this.server.Close();
            }
        }

        #endregion
    }
}
