using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSmartHouse.Form
{
    public partial class Main : System.Web.UI.Page
    {
        WebSmartHouse.House.Device.Kettle Kettle;


        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Button1.Click+=CreateNewKettle_Click;
            }
           
        }

        private void CreateNewKettle_Click(object sender,EventArgs e)
        {

        }
    }
}