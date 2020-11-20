/*
 * 
 */



namespace WhatOccupiesMyDisk.Class
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class ReadClass
    {
        public DirectoriesFilesWithSizeInformation Read(string directoryPath)
        {
            // TODO: change this name
            var listOfDirectories = new DirectoriesFilesWithSizeInformation();

            try
            {
                // Process all files
                foreach (string fileName in Directory.GetFiles(directoryPath))
                {
                    if (File.Exists(fileName))
                    {
                        listOfDirectories.AddPlain(fileName, new FileInfo(fileName).Length);
                    }
                }


                foreach (string directoryName in Directory.GetDirectories(directoryPath))
                {
                    if (Directory.Exists(directoryName))
                    {
                        listOfDirectories.AddDictionary(Read(directoryName));
                    }
                }
                    

            }
            catch (UnauthorizedAccessException unauthorizedAccessException)
            {
                listOfDirectories.AddPlain(unauthorizedAccessException.Message, 0);
            }

            //this.ReadDebugDirectoriesFilesWithSizeInformation(listOfDirectories);
            return listOfDirectories;
            
        }

        private int BytesToGigabytes(long bytes)
        {
            if (bytes > 0)
            {
                double gigabyteInBytes = Math.Pow(10, -9);
                double calculation = (double)bytes * gigabyteInBytes;
                int conversion = (int)calculation;

                Console.WriteLine("In bytes: " + bytes.ToString());
                Console.WriteLine("In gigabytes: " + calculation.ToString());

            }
   

           

            return 0;

        }

        private void ReadDebug(String location, string[] files, string[] directories)
        {
            Console.WriteLine("I'm here: " + location);
            foreach (string file in files)
                Console.WriteLine("File: " + file);
            foreach (string dir in directories)
                Console.WriteLine("Directory: " + dir);
        }

        private void ReadDebugDirectoriesFilesWithSizeInformation(DirectoriesFilesWithSizeInformation directoriesFilesWithSizeInformation)
        {
            Console.WriteLine(directoriesFilesWithSizeInformation.GetRawString());
        
        
        }
    }

  
}
