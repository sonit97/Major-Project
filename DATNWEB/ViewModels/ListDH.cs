using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DATNWEB.Models
{
    public class ListDH
    {
        public int MaDDH { get; set; }

        public DateTime? NgayDat { get; set; }

        public string Description { get; set; }

        public bool? TinhTrang { get; set; }
    }
}