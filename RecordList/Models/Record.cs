using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RecordList.Models
{
    public class Record
    {
        #region " Properties "

        public int RecordId { get; set; } // identity field

        public int ArtistId { get; set; } // relate to the artist entity

        public string ArtistName { get; set; }

        public string Name { get; set; }

        public string Field { get; set; }

        public int Recorded { get; set; }

        public string Label { get; set; }

        public string Pressing { get; set; }

        public string Rating { get; set; }

        public int Discs { get; set; }

        public string Media { get; set; }

        public DateTime Bought { get; set; }

        public decimal Cost { get; set; }

        public string CoverName { get; set; }

        public string Review { get; set; }

        #endregion
    }
}