﻿using RecordList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecordList
{
    public partial class RecordList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var dtnow = DateTime.Now;
            dateLabel.Text = dtnow.ToLongDateString();

            //// Show all records
            var recordData = new RecordData();
            var artistData = new ArtistData();
            var recordList = recordData.Select();
            var artistList = artistData.Select();

            var sb = new StringBuilder();

            var q = from a in artistList
                    orderby a.LastName, a.FirstName
                    select a;

            foreach (var artist in q)
            {
                sb.Append("<p><br/><strong><a href=\"GetArtist/aid" + artist.ArtistId + "\">" + artist.Name + "</a></strong></p>");

                var ar = from r in recordList
                         where artist.ArtistId == r.ArtistId
                         orderby r.Recorded
                         select r;

                foreach (var rec in ar)
                {
                    // RecordView.aspx?rid=12
                    sb.Append("<p>&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"GetRecord/" + rec.RecordId + "\">" + rec.Recorded + " - " + rec.Name + " - (" + rec.Media + ")</a></p>");
                }
            }

            recordLiteral.Text = sb.ToString();
        }
    }
}