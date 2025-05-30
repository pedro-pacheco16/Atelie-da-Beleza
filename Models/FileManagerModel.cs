﻿namespace PaulaPachecoHairStyle.Models
{
    public class FileManagerModel
    {
        public FileInfo[] Files { get; set; }

        public IFormFile IFormFile { get; set; }

        public List<IFormFile> IFormFiles { get; set; }

        public string PathImages { get; set; }
    }
}
