using BrotherConnection.Mapping;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BrotherConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            var prodData3Map = JsonConvert.DeserializeObject<DataMap>(File.ReadAllText("ProductionData3.json"));
            while (true)
            {
                var DecodedResults = new Dictionary<String, String>();

                Console.Clear();
                var req = new Request();
                req.Command = "LOD";
                req.Arguments = prodData3Map.FileName;

                var rawData = req.Send().Split(new String[] { "\r\n" },StringSplitOptions.None);

                //Console.Write(req.Send());

                foreach (var line in prodData3Map.Lines)
                {
                    var rawLine = rawData[line.Number].Split(',');
                    if (rawLine[0] == line.Symbol)
                    {
                        rawLine = rawLine.Skip(1).ToArray();
                        for (int i = 1; i < line.Items.Count; i++)
                        {
                            if (line.Items[i].Type == "Number")
                            {
                                DecodedResults[line.Items[i].Name] = rawLine[i].Trim();
                            }
                            else
                            {
                                DecodedResults[line.Items[i].Name] = line.Items[i].EnumValues.First(v => v.Index == Convert.ToInt32(rawLine[i])).Value;
                            }
                        }
                    }
                }

                //req.Arguments = "PANEL";
                //Console.Write(req.Send());
                //req.Arguments = "MEM";
                //Console.Write(req.Send());
                //req.Arguments = "ALARM";
                //Console.Write(req.Send());
                //req.Arguments = "TOLNI1";
                //Console.Write(req.Send());
                //req.Arguments = "MCRNI1";
                //Console.Write(req.Send());

                foreach (var decode in DecodedResults)
                {
                    Console.WriteLine($"{decode.Key}: {decode.Value}");
                }

                Thread.Sleep(2000);
            }
        }
    }
}
