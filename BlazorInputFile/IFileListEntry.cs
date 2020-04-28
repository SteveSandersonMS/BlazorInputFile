using System;
using System.IO;
using System.Threading.Tasks;

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

        Task<IFileListEntry> ToImageFileAsync(string format, int maxWidth, int maxHeight);

        event EventHandler OnDataRead;
    }
}
