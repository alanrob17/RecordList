using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecordList
{

    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Record Database Manager";
            var dtnow = DateTime.Now;
            dateLabel.Text = dtnow.ToLongDateString();
        }
    }
}