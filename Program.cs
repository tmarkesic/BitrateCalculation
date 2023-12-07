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
    public class Program
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

            // Bitrate calculation for Tx and Rx
            var bitrateValueRx = CalculateBitrate(aristaData.NIC[0].Rx, pollingRate);
            var bitrateValueTx = CalculateBitrate(aristaData.NIC[0].Tx, pollingRate);
            
            // Printing Bitrate value for Rx and Tx
            Console.WriteLine("Bitrate value on Rx: " + bitrateValueRx);
            Console.WriteLine("Bitrate value on Tx: " + bitrateValueTx);

        }

        static long CalculateBitrate(long dataAmount, int pollingRate)
        {
            // Calculate bitrate using the formula:
            // bitrate[bits per second] = data amount * 8 [bits] * polling rate [Hz = 1/s]           
            long bitrate = dataAmount * 8 * pollingRate;
            return bitrate;
        }
    }
}
