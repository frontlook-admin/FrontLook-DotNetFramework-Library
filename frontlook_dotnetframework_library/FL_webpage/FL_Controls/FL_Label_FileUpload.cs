using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace frontlook_dotnetframework_library.FL_webpage.FL_Controls
{
    class FL_Label_FileUpload
    {
        public static HtmlGenericControl FL_Label_FileUpload_Default(string Control_id)
        {
            string Control_id_t = Control_id.Replace(" ", "");
            HtmlGenericControl div1 = new HtmlGenericControl("div");
            div1.Attributes.Add("class", "form-group");
            div1.Attributes.Add("runat", "server");

            Label lbl = new Label();
            lbl.Text = Control_id;
            lbl.Attributes.Add("ForeColor", "Black");
            lbl.CssClass = "col-md-4 Control-label textfield";

            HtmlGenericControl div2 = new HtmlGenericControl("div");

            div2.Attributes.Add("class", "col-md-8");
            div2.Attributes.Add("runat", "server");

            var FileUpload = new FileUpload();
            FileUpload.AllowMultiple = false;
            //FileUpload.PostedFile.InputStream.
            FileUpload.ID = Control_id_t;

            lbl.AssociatedControlID = Control_id_t;
            // ASSIGN A CLASS. WE'LL USE THE CLASS NAME TO EXTRACT DATA USING JQUERY.
            FileUpload.CssClass = "form-control";

            // CREATE AN INSTANCE OF TEXTBOX.
            // WITH EVERY COLUMN NAME, WE'LL CREATE AND ADD A TEXTBOX.

            div2.Controls.Add(FileUpload);
            div1.Controls.Add(lbl);
            div1.Controls.Add(div2);

            return div1;
        }
    }
}
