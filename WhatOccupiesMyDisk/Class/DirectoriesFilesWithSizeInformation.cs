

namespace WhatOccupiesMyDisk.Class
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class DirectoriesFilesWithSizeInformation : Dictionary<String, long>
    {
        //private DirectoriesFilesWithSizeInformation _directoryWithSizeInformation;

        // redundant function
        public void AddPlain(String directory, long size)
        {
            //Add(directory, size);
            AddToDirectoryWithSizeInformation(directory, size);
        }

        public void AddDictionary(Dictionary<String, long> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            foreach (KeyValuePair<String, long> kvp in source)
            {
                //Add(kvp.Key, kvp.Value);
                AddToDirectoryWithSizeInformation(kvp.Key, kvp.Value);
            } 
        }

        public String GetRawString()
        {
            return String.Join(Environment.NewLine, this);
            //return String.Join(Environment.NewLine, _directoryWithSizeInformation);
        }

        private void AddToDirectoryWithSizeInformation(String path, long size)
        {
            String directoryName = DirectoryName(path);   

            if (ContainsKey(directoryName))
            {
                this[directoryName] = this[directoryName] + size;
            }
            else
            {
                Add(directoryName, size);
            }
        }

        private String DirectoryName(String path)
        {
            if (Directory.Exists(path))
            {
                return path;
            }

            return Path.GetDirectoryName(path);
        }
    }
}
