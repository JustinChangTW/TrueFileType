using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TrueFileType.Expansions
{
    public static class FileInfoExpansion
    {
        public static string GetFileType(this FileInfo fileInfo)
        {
            List<FileTypeCode> ImageTypes = new List<FileTypeCode>() {
                new FileTypeCode{  Hex="FFD8", Type=".jpg" },
                new FileTypeCode{  Hex="424D", Type=".bmp" },
                new FileTypeCode{  Hex="474946", Type=".gif" },
                new FileTypeCode{  Hex="89504E470D0A1A0A", Type=".png" },
                new FileTypeCode{  Hex="68656963", Type=".heic" },

            };
            string hex = string.Empty;
            using (Stream S = File.OpenRead(fileInfo.FullName))
            {
                for (int i = 0; i < 40; i++)
                {
                    hex += S.ReadByte().ToString("X2");
                    var type = ImageTypes.FirstOrDefault(x => hex.EndsWith(x.Hex))?.Type;

                    if (!String.IsNullOrEmpty(type))
                    {
                        return type;
                    }
                }
            }
            return "";
        }
    }

    class FileTypeCode
    {
        public string Hex { get; set; }
        public string Type { get; set; }
    }
}
