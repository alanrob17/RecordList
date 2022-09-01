using RecordList.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace RecordList
{
    public partial class DeleteRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            recordDropDownPanel.Visible = false;

            if (!Page.IsPostBack)
            {
                tablePanel.Visible = false;

                var artistData = new ArtistData();
                var artists = artistData.GetArtistList();
                artistDropDownList.DataSource = artists;
                artistDropDownList.DataTextField = "name";
                artistDropDownList.DataValueField = "ArtistId";
                artistDropDownList.DataBind();
            }
        }

        /// <summary>
        /// Get the current artists record list.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        protected void artistDropdownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var artistId = 0;
            int.TryParse(artistDropDownList.SelectedItem.Value, out artistId);

            if (artistId > 0)
            {
                // now we have to get an artists records
                var recordData = new RecordData();
                var recordList = recordData.SelectArtistRecords(artistId);
                recordDropDownList.DataSource = recordList;
                recordDropDownList.DataTextField = "name";
                recordDropDownList.DataValueField = "RecordId";
                recordDropDownList.DataBind();

                recordDropDownPanel.Visible = true;
            }
        }

        /// <summary>
        /// Edit the currently selected record.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        protected void recordDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // now we have an record to edit
            var recordId = 0;

            int.TryParse(recordDropDownList.SelectedItem.Value, out recordId);

            if (recordId > 0)
            {
                this.PopulateRecordForm(recordId);
            }
        }

        /// <summary>
        /// Populate the record form.
        /// </summary>
        /// <param name="recordId">The record id.</param>
        private void PopulateRecordForm(int recordId)
        {
            var recordData = new RecordData();
            var record = recordData.Select(recordId);

            nameLabel.Text = record.Name;
            fieldLabel.Text = record.Field;
            recordedLabel.Text = record.Recorded.ToString(CultureInfo.InvariantCulture);
            label.Text = record.Label;
            pressingLabel.Text = record.Pressing;
            ratingLabel.Text = record.Rating;
            discsLabel.Text = record.Discs.ToString(CultureInfo.InvariantCulture);
            mediaLabel.Text = record.Media;

            boughtLabel.Text = record.Bought.ToShortDateString();

            costLabel.Text = record.Cost.ToString("F", CultureInfo.InvariantCulture);
            coverNameLabel.Text = record.CoverName;
            reviewLabel.Text = record.Review;

            messageLabel.Text = string.Empty;
            tablePanel.Visible = true;
        }

        protected void deleteButton_ItemDeleted(object sender, EventArgs e)
        {
            var recordData = new RecordData();
            var recordId = int.Parse(recordDropDownList.SelectedItem.Value);

            if (recordId > 0)
            {
                recordData.Delete(recordId);
            }
            else
            {
                messageAreaDiv.Visible = true;
                messageLabel.Text = "No record to delete!";
            }

            Response.Redirect("Default");
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            //var recordData = new ArtistData();
            //var artistId = recordData.(int.Parse(recordDropDownList.SelectedItem.Value));

            //if (artistId > 0)
            //{
            //    artistData.Delete(artistId);
            //}
            //else
            //{
            //    divMessageArea.Visible = true;
            //    messageLabel.Text = "No artist to delete!";
            //}

            //Response.Redirect("Default");

        }

        protected void returnButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default");
        }
    }
}