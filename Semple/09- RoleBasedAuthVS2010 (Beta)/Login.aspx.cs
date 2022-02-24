using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {   if (Session["UserId"] != null)
            {
                Response.Redirect("Dashboard.aspx");
            }
    }
    protected void Submit_btn_Click(object sender, EventArgs e)
    {
      bool res=  Membership.ValidateUser(Email_txt.Text, Password_txt.Text);

      if (res == true)
      {
          string[] rolesArray = Roles.GetRolesForUser(Email_txt.Text);
          Guid UserId= new Guid(Membership.GetUser(Email_txt.Text).ProviderUserKey.ToString());

          lblResult.Text = "Login Succues";
          Session.Add("UserName", rolesArray[0]);
          Session.Add("UserId", UserId);


          Response.Redirect("Dashboard.aspx");
      }
      else {
          lblResult.Text = "Login Failed";
      }
    }
}