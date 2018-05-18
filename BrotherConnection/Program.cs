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

                Console.Write(req.Send());

                //*
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
                } //*/

                /*
                var filesToLoad = new List<String>
                {
                    "POSNI#",
                    "POSSI#",
                    "TOLSI#",
                    "MCRNI#",
                    "MCRSI#",
                    "EXIO#",
                    "ATCTL",
                    "GCOMT",
                    "CSTPL1",
                    "CSTTP1",
                    "SYSC99",
                    "SYSC98",
                    "SYSC97",
                    "SYSC96",
                    "SYSC95",
                    "SYSC94",
                    "SYSC89",
                    "PRD1",
                    "PRDC2",
                    "PRD3",
                    "MAINTC",
                    "WKCNTR",
                    "MSRRSC",
                    "PAINT",
                    "WVPRM",
                    "PLCDAT",
                    "PLCMON",
                    "SHTCUT",
                    "IO",
                    "MEM",
                    "PANEL",
                    "PDSP",
                    "VER",
                    "LOG",
                    "LOGBK",
                    "ALARM",
                    "OPLOG",
                    "PRTCTC"
                };

                foreach (var file in filesToLoad)
                {                    
                    if (file.Contains("#"))
                    {
                        for (int i = 0; i <= 10 ; i++)
                        {
                            var toLoad = file.Replace('#', i.ToString().Last()); // 0 is 10, not 0
                            req.Arguments = toLoad;
                            File.WriteAllText(toLoad + ".RAW", req.Send());
                            Console.WriteLine($"Loaded {toLoad}");
                        }
                    }
                    else
                    {
                        req.Arguments = file;
                        File.WriteAllText(file + ".RAW", req.Send());
                        Console.WriteLine($"Loaded {file}");
                    }
                    Thread.Sleep(500);
                } //*/

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

                //*
                foreach (var decode in DecodedResults)
                {
                    Console.WriteLine($"{decode.Key}: {decode.Value}");
                } //*/

                //throw new NotImplementedException();

                Thread.Sleep(2000);
            }
        }
    }
}
