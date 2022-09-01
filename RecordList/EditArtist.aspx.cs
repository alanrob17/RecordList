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
    public partial class EditArtist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // var dtnow = DateTime.Now;
            // dateLabel.Text = dtnow.ToLongDateString();

            divMessageArea.Visible = false;

            if (!Page.IsPostBack)
            {
                editPanel.Visible = false;

                var artistData = new ArtistData();
                var artists = artistData.GetArtistList();
                artistDropDownList.DataSource = artists;
                artistDropDownList.DataTextField = "name";
                artistDropDownList.DataValueField = "ArtistId";
                artistDropDownList.DataBind();
            }
        }

        protected void artistDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // now we have an artist to edit
            var artistId = int.Parse(artistDropDownList.SelectedItem.Value);

            if (artistId > 0)
            {
                editPanel.Visible = true;
                var artistData = new ArtistData();

                var artist = artistData.Select(int.Parse(artistDropDownList.SelectedItem.Value));

                firstNameTextBox.Text = artist.FirstName;
                lastNameTextBox.Text = artist.LastName;
                nameTextBox.Text = artist.Name;
                biographyTextBox.Text = artist.Biography;
            }
            else
            {
                editPanel.Visible = false;
            }
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            var artistData = new ArtistData();
            var artist = new Artist();

            // set member properties
            artist.ArtistId = Convert.ToInt32(artistDropDownList.SelectedItem.Value);
            artist.FirstName = firstNameTextBox.Text;
            artist.LastName = lastNameTextBox.Text;
            artist.Name = nameTextBox.Text;
            artist.Biography = biographyTextBox.Text;

            var artistId = artistData.UpdateArtist(artist.ArtistId, artist.FirstName, artist.LastName, artist.Name, artist.Biography);

            divMessageArea.Visible = true;

            // Show the new artist id
            if (artistId == 0)
            {
                messageLabel.Text = "ERROR: Artist was not added! " + artistId;
            }
            else
            {
                messageLabel.Text = "Artist Id: " + artistId + "<br/>";
                messageLabel.Text += "<strong>" + artist.Biography + "</strong>";
            }
        }

        protected void returnButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default");
        }
    }
}