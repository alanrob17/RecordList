using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecordList.Models
{
    public class Total
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }

        public int TotalDiscs { get; set; }

        public decimal TotalCost { get; set; }
    }
}