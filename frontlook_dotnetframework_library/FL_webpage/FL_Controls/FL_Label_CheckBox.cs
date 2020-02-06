using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace frontlook_dotnetframework_library.FL_webpage.FL_Controls
{
    /// <summary>
    /// Defines the <see cref="FL_Label_CheckBox" />
    /// </summary>
    public static class FL_Label_CheckBox
    {
        /// <summary>
        /// The FL_label_checkbox
        /// </summary>
        /// <param name="Control_id">The Control_id<see cref="string"/></param>
        /// <returns>The <see cref="HtmlGenericControl"/></returns>
        public static HtmlGenericControl FL_label_checkbox(string Control_id)
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

            CheckBox chkbox = new CheckBox();
            chkbox.ID = Control_id_t;

            lbl.AssociatedControlID = Control_id_t;
            // ASSIGN A CLASS. WE'LL USE THE CLASS NAME TO EXTRACT DATA USING JQUERY.
            chkbox.CssClass = "checkbox";

            // CREATE AN INSTANCE OF TEXTBOX.
            // WITH EVERY COLUMN NAME, WE'LL CREATE AND ADD A TEXTBOX.

            div2.Controls.Add(chkbox);
            div1.Controls.Add(lbl);
            div1.Controls.Add(div2);

            return div1;
        }

        /// <summary>
        /// The FL_label_readonly_checkbox
        /// </summary>
        /// <param name="Control_id">The Control_id<see cref="string"/></param>
        /// <returns>The <see cref="HtmlGenericControl"/></returns>
        public static HtmlGenericControl FL_label_readonly_checkbox(string Control_id)
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

            CheckBox chkbox = new CheckBox();
            chkbox.ID = Control_id_t;
            chkbox.Enabled = true;

            lbl.AssociatedControlID = Control_id_t;
            // ASSIGN A CLASS. WE'LL USE THE CLASS NAME TO EXTRACT DATA USING JQUERY.
            chkbox.CssClass = "checkbox";

            // CREATE AN INSTANCE OF TEXTBOX.
            // WITH EVERY COLUMN NAME, WE'LL CREATE AND ADD A TEXTBOX.

            div2.Controls.Add(chkbox);
            div1.Controls.Add(lbl);
            div1.Controls.Add(div2);

            return div1;
        }
    }
}
