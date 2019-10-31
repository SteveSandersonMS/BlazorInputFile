﻿using System;
using System.IO;

namespace BlazorInputFile
{
    public interface IFileListEntry
    {
        DateTime LastModified { get; }

        string Name { get; }

        long Size { get; }

        string Type { get; }

        string Url { get; }

        Stream Data { get; }

        event EventHandler OnDataRead;
    }
}
