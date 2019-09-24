using System;
using System.IO;
using System.Threading.Tasks;

namespace BlazorInputFile
{
    public static class FileListEntryExtensions
    {
        /// <summary>
        /// Reads the entire uploaded file into a <see cref="MemoryStream"/>. This will allocate
        /// however much memory is needed to hold the entire file, or will throw if the client
        /// tries to supply more than <paramref name="maxSizeBytes"/> bytes. Be careful not to
        /// let clients allocate too much memory on the server.
        /// </summary>
        /// <param name="fileListEntry">The <see cref="IFileListEntry"/>.</param>
        /// <param name="maxSizeBytes">The maximum amount of data to accept.</param>
        public static async Task<MemoryStream> ReadAllAsync(this IFileListEntry fileListEntry, int maxSizeBytes = 1024*1024)
        {
            if (fileListEntry is null)
            {
                throw new ArgumentNullException(nameof(fileListEntry));
            }

            // We can trust .Length to be correct (and can't change later) because the implementation
            // won't supply more bytes than this, even if the JS-side code would send more data.
            var sourceData = fileListEntry.Data;
            if (sourceData.Length > maxSizeBytes)
            {
                throw new ArgumentOutOfRangeException(nameof(fileListEntry), $"The maximum allowed size is {maxSizeBytes}, but the supplied file is of length {fileListEntry.Size}.");
            }

            var result = new MemoryStream();
            await sourceData.CopyToAsync(result);
            result.Seek(0, SeekOrigin.Begin);
            return result;
        }
    }
}
