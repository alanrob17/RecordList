using RecordList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecordList
{
    public partial class DeleteArtist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

                var artist = artistData.Select(artistId);

                firstNameLabel.Text = artist.FirstName;
                lastNameLabel.Text = artist.LastName;
                nameLabel.Text = artist.Name;
                biographyLabel.Text = artist.Biography;
            }
            else
            {
                editPanel.Visible = false;
            }
        }

        /// <summary>
        /// After an artist has been deleted return to default.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        protected void deleteButton_ItemDeleted(object sender, EventArgs e)
        {
            var artistData = new ArtistData();
            var artistId = int.Parse(artistDropDownList.SelectedItem.Value);

            if (artistId > 0)
            {
                artistData.Delete(artistId);
            }
            else
            {
                divMessageArea.Visible = true;
                messageLabel.Text = "No artist to delete!";
            }

            Response.Redirect("Default");
        }

        protected void returnButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default");
        }
    }
}