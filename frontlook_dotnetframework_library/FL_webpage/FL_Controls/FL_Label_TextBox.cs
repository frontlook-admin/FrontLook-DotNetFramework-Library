using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace frontlook_dotnetframework_library.FL_webpage.FL_Controls
{
    public static class FL_Label_TextBox
    {
        public static HtmlGenericControl FL_label_textbox_default(string control_id)
        {
            string control_id_t = control_id.Replace(" ", "");
            HtmlGenericControl div1 = new HtmlGenericControl("div");
            div1.Attributes.Add("class", "form-group");
            div1.Attributes.Add("runat", "server");

            Label lbl = new Label();
            lbl.Text = control_id;
            lbl.Attributes.Add("ForeColor", "Black");
            lbl.CssClass = "col-md-4 control-label textfield";

            HtmlGenericControl div2 = new HtmlGenericControl("div");

            div2.Attributes.Add("class", "col-md-8");
            div2.Attributes.Add("runat", "server");

            TextBox txt = new TextBox();
            txt.ID = control_id_t;

            lbl.AssociatedControlID = control_id_t;
            // ASSIGN A CLASS. WE'LL USE THE CLASS NAME TO EXTRACT DATA USING JQUERY.
            txt.CssClass = "form-control";

            // CREATE AN INSTANCE OF TEXTBOX.
            // WITH EVERY COLUMN NAME, WE'LL CREATE AND ADD A TEXTBOX.

            div2.Controls.Add(txt);
            div1.Controls.Add(lbl);
            div1.Controls.Add(div2);

            return div1;
        }

        public static HtmlGenericControl FL_label_readonly_textbox_default(string control_id)
        {
            string control_id_t = control_id.Replace(" ", "");
            HtmlGenericControl div1 = new HtmlGenericControl("div");
            div1.Attributes.Add("class", "form-group");
            div1.Attributes.Add("runat", "server");

            Label lbl = new Label();
            lbl.Text = control_id;
            lbl.Attributes.Add("ForeColor", "Black");
            lbl.CssClass = "col-md-4 control-label textfield";

            HtmlGenericControl div2 = new HtmlGenericControl("div");

            div2.Attributes.Add("class", "col-md-8");
            div2.Attributes.Add("runat", "server");

            TextBox txt = new TextBox();
            txt.ID = control_id_t;

            lbl.AssociatedControlID = control_id_t;
            // ASSIGN A CLASS. WE'LL USE THE CLASS NAME TO EXTRACT DATA USING JQUERY.
            txt.CssClass = "form-control";
            txt.ReadOnly = true;

            // CREATE AN INSTANCE OF TEXTBOX.
            // WITH EVERY COLUMN NAME, WE'LL CREATE AND ADD A TEXTBOX.

            div2.Controls.Add(txt);
            div1.Controls.Add(lbl);
            div1.Controls.Add(div2);

            return div1;
        }

        public static HtmlGenericControl FL_label_textbox_date(string control_id)
        {
            string control_id_t = control_id.Replace(" ", "");
            HtmlGenericControl div1 = new HtmlGenericControl("div");
            div1.Attributes.Add("class", "form-group");
            div1.Attributes.Add("runat", "server");

            Label lbl = new Label();
            lbl.Text = control_id;
            lbl.Attributes.Add("ForeColor", "Black");
            lbl.CssClass = "col-md-4 control-label textfield";

            HtmlGenericControl div2 = new HtmlGenericControl("div");

            div2.Attributes.Add("class", "col-md-8");
            div2.Attributes.Add("runat", "server");

            TextBox txt = new TextBox();
            txt.ID = control_id_t;

            lbl.AssociatedControlID = control_id_t;
            // ASSIGN A CLASS. WE'LL USE THE CLASS NAME TO EXTRACT DATA USING JQUERY.
            txt.CssClass = "form-control";
            txt.TextMode = TextBoxMode.Date;

            // CREATE AN INSTANCE OF TEXTBOX.
            // WITH EVERY COLUMN NAME, WE'LL CREATE AND ADD A TEXTBOX.

            div2.Controls.Add(txt);
            div1.Controls.Add(lbl);
            div1.Controls.Add(div2);

            return div1;
        }

        public static HtmlGenericControl FL_label_readonly_textbox_date(string control_id)
        {
            string control_id_t = control_id.Replace(" ", "");
            HtmlGenericControl div1 = new HtmlGenericControl("div");
            div1.Attributes.Add("class", "form-group");
            div1.Attributes.Add("runat", "server");

            Label lbl = new Label();
            lbl.Text = control_id;
            lbl.Attributes.Add("ForeColor", "Black");
            lbl.CssClass = "col-md-4 control-label textfield";

            HtmlGenericControl div2 = new HtmlGenericControl("div");

            div2.Attributes.Add("class", "col-md-8");
            div2.Attributes.Add("runat", "server");

            TextBox txt = new TextBox();
            txt.ID = control_id_t;

            lbl.AssociatedControlID = control_id_t;
            // ASSIGN A CLASS. WE'LL USE THE CLASS NAME TO EXTRACT DATA USING JQUERY.
            txt.CssClass = "form-control";
            txt.TextMode = TextBoxMode.Date;
            txt.ReadOnly = true;

            // CREATE AN INSTANCE OF TEXTBOX.
            // WITH EVERY COLUMN NAME, WE'LL CREATE AND ADD A TEXTBOX.

            div2.Controls.Add(txt);
            div1.Controls.Add(lbl);
            div1.Controls.Add(div2);

            return div1;
        }

        public static HtmlGenericControl FL_label_textbox_datetime(string control_id)
        {
            string control_id_t = control_id.Replace(" ", "");
            HtmlGenericControl div1 = new HtmlGenericControl("div");
            div1.Attributes.Add("class", "form-group");
            div1.Attributes.Add("runat", "server");

            Label lbl = new Label();
            lbl.Text = control_id;
            lbl.Attributes.Add("ForeColor", "Black");
            lbl.CssClass = "col-md-4 control-label textfield";

            HtmlGenericControl div2 = new HtmlGenericControl("div");

            div2.Attributes.Add("class", "col-md-8");
            div2.Attributes.Add("runat", "server");

            TextBox txt = new TextBox();
            txt.ID = control_id_t;

            lbl.AssociatedControlID = control_id_t;
            // ASSIGN A CLASS. WE'LL USE THE CLASS NAME TO EXTRACT DATA USING JQUERY.
            txt.CssClass = "form-control";
            txt.TextMode = TextBoxMode.DateTime;

            // CREATE AN INSTANCE OF TEXTBOX.
            // WITH EVERY COLUMN NAME, WE'LL CREATE AND ADD A TEXTBOX.

            div2.Controls.Add(txt);
            div1.Controls.Add(lbl);
            div1.Controls.Add(div2);

            return div1;
        }

        public static HtmlGenericControl FL_label_readonly_textbox_datetime(string control_id)
        {
            string control_id_t = control_id.Replace(" ", "");
            HtmlGenericControl div1 = new HtmlGenericControl("div");
            div1.Attributes.Add("class", "form-group");
            div1.Attributes.Add("runat", "server");

            Label lbl = new Label();
            lbl.Text = control_id;
            lbl.Attributes.Add("ForeColor", "Black");
            lbl.CssClass = "col-md-4 control-label textfield";

            HtmlGenericControl div2 = new HtmlGenericControl("div");

            div2.Attributes.Add("class", "col-md-8");
            div2.Attributes.Add("runat", "server");

            TextBox txt = new TextBox();
            txt.ID = control_id_t;

            lbl.AssociatedControlID = control_id_t;
            // ASSIGN A CLASS. WE'LL USE THE CLASS NAME TO EXTRACT DATA USING JQUERY.
            txt.CssClass = "form-control";
            txt.TextMode = TextBoxMode.DateTime;
            txt.ReadOnly = true;

            // CREATE AN INSTANCE OF TEXTBOX.
            // WITH EVERY COLUMN NAME, WE'LL CREATE AND ADD A TEXTBOX.

            div2.Controls.Add(txt);
            div1.Controls.Add(lbl);
            div1.Controls.Add(div2);

            return div1;
        }

        public static HtmlGenericControl FL_label_textbox_datetimelocal(string control_id)
        {
            string control_id_t = control_id.Replace(" ", "");
            HtmlGenericControl div1 = new HtmlGenericControl("div");
            div1.Attributes.Add("class", "form-group");
            div1.Attributes.Add("runat", "server");

            Label lbl = new Label();
            lbl.Text = control_id;
            lbl.Attributes.Add("ForeColor", "Black");
            lbl.CssClass = "col-md-4 control-label textfield";

            HtmlGenericControl div2 = new HtmlGenericControl("div");

            div2.Attributes.Add("class", "col-md-8");
            div2.Attributes.Add("runat", "server");

            TextBox txt = new TextBox();
            txt.ID = control_id_t;

            lbl.AssociatedControlID = control_id_t;
            // ASSIGN A CLASS. WE'LL USE THE CLASS NAME TO EXTRACT DATA USING JQUERY.
            txt.CssClass = "form-control";
            txt.TextMode = TextBoxMode.DateTimeLocal;

            // CREATE AN INSTANCE OF TEXTBOX.
            // WITH EVERY COLUMN NAME, WE'LL CREATE AND ADD A TEXTBOX.

            div2.Controls.Add(txt);
            div1.Controls.Add(lbl);
            div1.Controls.Add(div2);

            return div1;
        }

        public static HtmlGenericControl FL_label_readonly_textbox_datetimelocal(string control_id)
        {
            string control_id_t = control_id.Replace(" ", "");
            HtmlGenericControl div1 = new HtmlGenericControl("div");
            div1.Attributes.Add("class", "form-group");
            div1.Attributes.Add("runat", "server");

            Label lbl = new Label();
            lbl.Text = control_id;
            lbl.Attributes.Add("ForeColor", "Black");
            lbl.CssClass = "col-md-4 control-label textfield";

            HtmlGenericControl div2 = new HtmlGenericControl("div");

            div2.Attributes.Add("class", "col-md-8");
            div2.Attributes.Add("runat", "server");

            TextBox txt = new TextBox();
            txt.ID = control_id_t;

            lbl.AssociatedControlID = control_id_t;
            // ASSIGN A CLASS. WE'LL USE THE CLASS NAME TO EXTRACT DATA USING JQUERY.
            txt.CssClass = "form-control";
            txt.TextMode = TextBoxMode.DateTimeLocal;
            txt.ReadOnly = true;

            // CREATE AN INSTANCE OF TEXTBOX.
            // WITH EVERY COLUMN NAME, WE'LL CREATE AND ADD A TEXTBOX.

            div2.Controls.Add(txt);
            div1.Controls.Add(lbl);
            div1.Controls.Add(div2);

            return div1;
        }
    }
}