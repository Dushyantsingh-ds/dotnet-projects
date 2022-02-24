using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsCallback)
        {
            if (Session["UserId"] == null)
            {
                Session.RemoveAll();
                Response.Redirect("Login.aspx");
            }
            else
            {
                Username_lbl.Text = Session["UserName"].ToString();
                UserId_lbl.Text = Session["UserId"].ToString();
            }
        }
    }

    protected void Logout_btn_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("Login.aspx");
    }
}