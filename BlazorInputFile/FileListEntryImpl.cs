﻿using System;
using System.IO;

namespace BlazorInputFile
{
    // This is public only because it's used in a JSInterop method signature,
    // but otherwise is intended as internal
    public class FileListEntryImpl : IFileListEntry
    {
        internal InputFile Owner { get; set; }

        private Stream _stream;

        public event EventHandler OnDataRead;

        public int Id { get; set; }

        public DateTime LastModified { get; set; }

        public string Name { get; set; }

        public long Size { get; set; }

        public string Type { get; set; }
        public string Url { get; set; }

        public Stream Data
        {
            get
            {
                _stream ??= Owner.OpenFileStream(this);
                return _stream;
            }
        }

        internal void RaiseOnDataRead()
        {
            OnDataRead?.Invoke(this, null);
        }
    }
}
