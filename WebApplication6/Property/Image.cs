using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace main.Property
{
    public class Image
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public byte[] Picture { get; set; }

        public List<Users> Users { get; set; }
    }
}