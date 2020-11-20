using System;
using System.IO;
using System.Collections.Generic;
using WhatOccupiesMyDisk.Class;

namespace WhatOccupiesMyDisk
{
    class Program
    {
        static void Main(string[] args)
        {
            /* TRY - FIX THIS */
            string testPath = @"c:\\";

            string path = testPath;
            /* TRY - FIX THIS */

            if (Directory.Exists(path))
            {
                var readClass = new ReadClass();
                var writeClass = new WriteClass();
                var currentDirectory = Directory.GetCurrentDirectory();
                string outputFilename = "output.log";
                
                var totalDirectoriesFilesWithSizeInformation = readClass.Read(path);
                
                writeClass.Write(totalDirectoriesFilesWithSizeInformation, currentDirectory + "\\" + outputFilename);

                Console.WriteLine(" ... ");

            }
            else if (File.Exists(path))
            {
                Console.WriteLine("{0} is a file !", path);
            }
            else
            {
                Console.WriteLine("{0} does not exist !", path);
            }


        }
    }
}
