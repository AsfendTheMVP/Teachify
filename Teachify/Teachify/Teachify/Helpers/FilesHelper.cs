using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Teachify.Helpers
{
   public class FilesHelper
    {
        public static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
