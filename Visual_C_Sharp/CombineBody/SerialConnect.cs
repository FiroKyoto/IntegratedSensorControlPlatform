

namespace CombineBody
{
    using System;
    using System.IO;
    using System.IO.Ports;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SerialConnect : IDisposable
    {
        /// <summary>
        /// gets or sets debug message
        /// </summary>
        public string debugMsg { get; set; }

        /// <summary>
        /// gets or sets result string
        /// </summary>
        public string resultStr { get; set; }

        /// <summary>
        /// result data
        /// </summary>
        public List<int> orgList;

        /// <summary>
        /// The main control for communicating through the RS-232 port
        /// </summary>
        private SerialPort _serialPort;
        
        /// <summary>
        /// basic constructor
        /// </summary>
        public SerialConnect(string _portName, int _baudRate, int _dataBits)
        {
            // Create a New SerialPort object with default settings.
            this._serialPort = new SerialPort();

            // Allow the user to set the appropriate properties.
            this._serialPort.PortName = _portName;
            this._serialPort.BaudRate = _baudRate;
            this._serialPort.DataBits = _dataBits;
            this._serialPort.Parity = Parity.None;
            this._serialPort.StopBits = StopBits.One;

            try
            {
                this._serialPort.Open();
                this.orgList = new List<int>();
                //this.debugMsg = this._serialPort.PortName + " Port open is success.";
            }
            catch 
            {
                //this.debugMsg = this._serialPort.PortName + " Port open is fail.";
            }
        }

        /// <summary>
        /// Data received from ECU of Combine Body
        /// </summary>
        public void DataReceived()
        {
            if (this._serialPort.IsOpen == false)
            {
                return;
            }

            if (this.orgList != null)
            {
                this.orgList.Clear();
            }

            if (this.resultStr != null)
            {
                this.resultStr = null;
            }

            // Obtain the number of bytes waiting in the port's buffer
            int bytes = this._serialPort.BytesToRead;

            // Create a byte array buffer to hold the incoming data
            byte[] buffer = new byte[bytes];

            // Read the data from the port and store it in our buffer
            this._serialPort.Read(buffer, 0, bytes);

            // Convert byte to hex string
            this.resultStr = this.ByteArrayToHexString(buffer);

            // Convert hex string to string array
            string[] hexValuesSplit = this.resultStr.Split(' ');

            if (bytes != 0)
            {
                // Convert string array to List<int>
                for (int i = 0; i < hexValuesSplit.Length - 1; i++)
                {
                    int value = Convert.ToInt32(hexValuesSplit[i], 16);
                    this.orgList.Add(value);
                }
            }

        }

        /// <summary> Converts an array of bytes into a formatted string of hex digits (ex: E4 CA B2)</summary>
        /// <param name="data"> The array of bytes to be translated into a string of hex digits. </param>
        /// <returns> Returns a well formatted string of hex digits with spacing. </returns>
        private string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            return sb.ToString().ToUpper();
        }

        /// <summary>
        /// Writes a specified number of bytes to the serial port using data from a buffer.
        /// </summary>
        /// <param name="cmd"></param>
        public void DataWrite(byte[] cmd)
        {
            if (this._serialPort.IsOpen == false)
            {
                return;
            }

            this._serialPort.Write(cmd, 0, cmd.Length);
        }

        /// <summary>
        /// dispose
        /// </summary>
        public void Dispose()
        {
            if (this._serialPort.IsOpen == true)
            {
                this._serialPort.Close();
            }
        }

    }
}
