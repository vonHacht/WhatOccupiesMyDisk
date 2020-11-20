using System;
using System.Collections.Generic;
using System.Text;

namespace WhatOccupiesMyDisk.Class
{
    public class DirectoriesFilesWithSizeInformation : Dictionary<String, long>
    {
        // redundant function
        public void AddPlain(String directory, long size)
        {
            Add(directory, size);
        }

        public void AddDictionary(Dictionary<String, long> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            foreach (KeyValuePair<String, long> kvp in source)
                Add(kvp.Key, kvp.Value);
        }

        public String GetRawString()
        {
            return String.Join(Environment.NewLine, this);
        }

    }
}
