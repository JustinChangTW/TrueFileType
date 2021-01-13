using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TrueFileType.Expansions;

namespace TrueFileType
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string file = "";
            if (args.ToString()!="")
            {
                file = @".\image\01.heic";
            }

            var fileInfo = new FileInfo(file);

            var type = fileInfo.GetFileType();

            Console.WriteLine(type);
        }

    }


}
