using System;
using System.Collections.Generic;
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
            while (true)
            {
                Console.Clear();
                var req = new Request();
                req.Command = "LOD";
                req.Arguments = "PDSP";
                Console.Write(req.Send());
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

                Thread.Sleep(2000);
            }
        }
    }
}
