using System;
using System.Collections.Generic;
using System.Linq;

namespace IpfsUploader.Models
{
    public class VideoFile
    {
        public VideoFile (string sourceFilePath, params VideoSize[] videoSizes)
        {
            SourceFileItem = new FileItem(this, sourceFilePath);

            EncodedFileItems = new List<FileItem>();
            foreach (VideoSize videoSize in videoSizes)
            {   
                EncodedFileItems.Add(new FileItem(this, videoSize));
            }
        }

        public FileItem SourceFileItem { get; private set; }

        public IList<FileItem> EncodedFileItems { get; private set; }

        public bool WorkInProgress()
        {
            return EncodedFileItems.Any(f => f.WorkInProgress());
        }
    }
}