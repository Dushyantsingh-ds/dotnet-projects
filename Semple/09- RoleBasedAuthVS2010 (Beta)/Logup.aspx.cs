using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Drawing;

public partial class Logup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Submit_btn_Click(object sender, EventArgs e)
    {
        try
        {
            MembershipCreateStatus createStatus;
   
            MembershipUser user = Membership.CreateUser(Email_txt.Text, Password_txt.Text, "dev@g.com", "How was your day?", "Fantastic", true, out createStatus);
            switch (createStatus)
            {
                //This Case Occured whenver User Created Successfully in database  
                case MembershipCreateStatus.Success:
                    Roles.AddUserToRole(Email_txt.Text, "Administrator");

                    lblResult.ForeColor = Color.Green;
                    lblResult.Text = "The user account was successfully created";
                    Email_txt.Text = string.Empty;
                    Password_txt.Text = string.Empty;

                   

                    break;
                // This Case Occured whenver we send duplicate UserName  
                case MembershipCreateStatus.DuplicateUserName:
                    lblResult.ForeColor = Color.Red;
                    lblResult.Text = "The user with the same UserName already exists!";
                    break;
                //This Case Occured whenver we give duplicate mail id  
                case MembershipCreateStatus.DuplicateEmail:
                    lblResult.ForeColor = Color.Red;
                    lblResult.Text = "The user with the same email address already exists!";
                    break;
                //This Case Occured whenver we send invalid mail format  
                case MembershipCreateStatus.InvalidEmail:
                    lblResult.ForeColor = Color.Red;
                    lblResult.Text = "The email address you provided is invalid.";
                    break;
                //This Case Occured whenver we send empty data or Invalid Data  
                case MembershipCreateStatus.InvalidAnswer:
                    lblResult.ForeColor = Color.Red;
                    lblResult.Text = "The security answer was invalid.";
                    break;
                // This Case Occured whenver we supplied weak password  
                case MembershipCreateStatus.InvalidPassword:
                    lblResult.ForeColor = Color.Red;
                    lblResult.Text = "The password you provided is invalid. It must be 7 characters long and have at least 1 special character.";
                    break;
                default:
                    lblResult.ForeColor = Color.Red;
                    lblResult.Text = "There was an unknown error; the user account was NOT created.";
                    break;
            }
        }
        catch (Exception ex)
        {
            lblResult.Text = ex.ToString();
        }
    }
}