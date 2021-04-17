using System;
using System.IO;
using Newtonsoft.Json;
using CLD3Lib;
using System.Text;

namespace CLD3WinProcess
{
    class Program
    {
        static void Main(string[] args)
        {
            //we have to read instructions from the Console and send back output
            //on startup we have to send a "Ready" message to the parent
            Console.WriteLine("ready");

            //start the processor
            var processor = new cld3WinProcess();

            //now do a loop and wait for tasks
            while (true)
            {
                var command = Console.ReadLine();
                //split into processorTask JSON and output path
                var frags = command.Split('\t');
                var task = JsonConvert.DeserializeObject<cld3WinTask>(frags[0]);
                var outputPath = frags[1];
                //now we read the bingscrapedata array
                var data = JsonConvert.DeserializeObject<cld3Input>(File.ReadAllText(task.tempFile));
                var output = processor.run(data);
                //write the data in XORed format (stupid Microsoft defender stuff)
                //convert to byte array
                var arr = Encoding.UTF8.GetBytes(output);
                byte mask = 0xFF;
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = (byte)(arr[i] ^ mask);
                }
                File.WriteAllBytes(outputPath, arr);
                //now signal to the parent that the task is done
                Console.WriteLine("ok");
            }
        }
    }
}
