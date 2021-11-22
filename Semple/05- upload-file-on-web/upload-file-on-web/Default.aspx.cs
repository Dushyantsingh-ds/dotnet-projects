/* 
 * The whole code developed by Dushyant Singh 04:58PM 07-10-2021 IST
 * 
 * Follow me for more recipes:
 * LinkedIn: https://www.linkedin.com/in/dushyantsingh-ds/
 * Twitter:  https://twitter.com/dushyantsingh_d  
 * Github: https://github.com/Dushyantsingh-ds
 * Instagram: https://www.linkedin.com/in/dushyantsingh-ds/ 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace upload_file_on_web
{
    public partial class Default : System.Web.UI.Page
    {
        string guid = Guid.NewGuid().ToString();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = " ";

            if (FileUpload1.HasFile)
            {
                string extension = System.IO.Path.GetExtension(FileUpload1.FileName);
                if( extension == ".png" || extension == ".jpg" || extension == ".jpeg" || extension == ".gif")
                {
                    string path = Server.MapPath("Images\\");
                    string ImgName = guid + FileUpload1.FileName;

                    FileUpload1.SaveAs(path + ImgName);
                    Label1.Text = "Uploaded Sucessfully at " + path;
                }
                else
                {
                    Label1.Text = "Please select correct formate : PNG, JPG, JPEG, Gif";
                }
            }
            else
            {
                Label1.Text = "Please select something";
            }
        }
    }
}