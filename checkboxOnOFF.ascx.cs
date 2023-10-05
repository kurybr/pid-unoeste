using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace westag.controles
{
    public partial class checkboxOnOFF : System.Web.UI.UserControl
    {
        public bool Checked { get { return slideThree.Checked; } }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}