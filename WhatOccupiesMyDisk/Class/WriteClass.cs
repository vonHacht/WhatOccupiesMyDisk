/*
 * 
 */

namespace WhatOccupiesMyDisk.Class
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class WriteClass
    {
        public void Write(DirectoriesFilesWithSizeInformation directoriesFilesWithSizeInformation, String filename)
        {
            string realpath = Path.GetFullPath(filename);

            using (StreamWriter file = new StreamWriter(realpath))
            {
                //file.Write("hello");
                file.Write(directoriesFilesWithSizeInformation.GetRawString());
            }
        }
    }
}
