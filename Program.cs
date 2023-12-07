using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BitrateCalculation
{
    internal class Program
    {
        static void Main()
        {
            // Defining a path to JSON file
            string jsonPath = @"C:\Users\User\Desktop\BitrateCalculation\AristaData.json";

            //Reading from JSON file
            string jsonData = File.ReadAllText(jsonPath);

            //Deserializing JSON string to class object 
            AristaData aristaData = JsonConvert.DeserializeObject<AristaData>(jsonData);

            // Defining polling rate in Hz
            int pollingRate = 2;

            // Bitrate calculation for Tx and Rx using formula: 
            // bitrate [bits per second]= number of bytes * 8 [bit] * polling rate [Hz = 1/s]  
            var bitrateValueRx = aristaData.NIC[0].Rx * 8 * pollingRate;
            var bitrateValueTx = aristaData.NIC[0].Tx * 8 * pollingRate;
            
            // Printing Bitrate value for Rx and Tx
            Console.WriteLine("Bitrate value on Rx: " + bitrateValueRx);
            Console.WriteLine("Bitrate value on Tx: " + bitrateValueTx);

        }
    }
}
