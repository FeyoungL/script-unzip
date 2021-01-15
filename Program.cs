using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Update
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Waiting for few seconds...");
            Process[] fontLab = Process.GetProcessesByName("FontLab");
            foreach (Process item in fontLab)
            {
                item.Kill();
            }
            if (args.Length != 2)
            {
                StringBuilder argument = new StringBuilder();
                argument.AppendLine("ERROR: Args format error, args length must be 2.")
                    .Append("\tUsed \"Update.exe SrcUnzipFilePath DestUnzipFolder.\"");
                Console.WriteLine(argument);
                return;
            }

            new ZipHelper().UnZip(args[0], args[1]);
            Console.WriteLine("Src unzip file: {0}\r\nDest unzip Folder: {1}", args[0], args[1]);
            Console.WriteLine("Update/Unzip Done");

            string fullPath = args[1] + "\\" + "FontLab.exe";

            if (File.Exists(fullPath))
            {
                Process.Start(fullPath);
            }
        }
    }
}
