using RecordList.Data;
using RecordList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecordList
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var dtnow = DateTime.Now;
            dateLabel.Text = dtnow.ToLongDateString();
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            var artist = new Artist
            {
                FirstName = this.firstNameTextBox.Text.Trim(),
                LastName = this.lastNameTextBox.Text.Trim()
            };

            // Show the message area
            divMessageArea.Visible = true;

            if (string.IsNullOrEmpty(artist.LastName))
            {
                messageLabel.Text = "You must enter a Last name!";
            }
            else
            {
                var artistId = 0;
                var artistData = new ArtistData();

                artistId = string.IsNullOrEmpty(artist.FirstName) ? artistData.GetArtistId(string.Empty, artist.LastName) : artistData.GetArtistId(artist.FirstName, artist.LastName);

                if (artistId > 0)
                {
                    Response.Redirect("GetArtist/aid" + artistId);
                }
                else
                {
                    messageLabel.Text = "Name wasn't found!";
                }
            }
        }
    }
}