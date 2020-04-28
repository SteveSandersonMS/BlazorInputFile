using System;
using System.IO;

namespace BlazorInputFile
{
    public interface IFileListEntry
    {
        DateTime LastModified { get; }

        string Name { get; }

        long Size { get; }

        string Type { get; }

        public string RelativePath { get; set; }

        Stream Data { get; }

        event EventHandler OnDataRead;
    }
}
