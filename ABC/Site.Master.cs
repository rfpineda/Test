﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABC
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Btn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session["EMPLEADO"] = null;
            Response.Redirect("~/Frm_Login.aspx");
        }
    }
}