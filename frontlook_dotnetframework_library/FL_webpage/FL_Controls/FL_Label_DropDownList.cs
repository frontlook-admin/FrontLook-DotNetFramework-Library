using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using frontlook_dotnetframework_library.FL_webpage.FL_DataBase.FL_MySql;
using MySql.Data.MySqlClient;
using _sql = frontlook_dotnetframework_library.FL_webpage.FL_DataBase.FL_MySql.FL_MySqlExecutor;


namespace frontlook_dotnetframework_library.FL_webpage.FL_Controls
{
    public static class FL_Label_DropDownList
    {
        public static HtmlGenericControl FL_form_create_dropdownlist1(string control_id, MySqlConnection con = null, MySqlCommand cmd = null,
            string query = null, string field1 = null, string field2 = null, string table_name = null)
        {
            string control_id_t = control_id.Replace(" ", "");
            HtmlGenericControl div1 = new HtmlGenericControl("div");
            div1.Attributes.Add("class", "form-group nav");
            div1.Attributes.Add("runat", "server");

            Label lbl = new Label();
            lbl.Text = control_id;
            lbl.CssClass = "col-md-4 control-label";

            HtmlGenericControl div2 = new HtmlGenericControl("div");

            div2.Attributes.Add("class", "col-md-8");
            div2.Attributes.Add("runat", "server");

            DropDownList ddl = new DropDownList();
            ddl.ID = control_id_t;

            lbl.AssociatedControlID = control_id_t;
            // ASSIGN A CLASS. WE'LL USE THE CLASS NAME TO EXTRACT DATA USING JQUERY.
            ddl.CssClass = "form-control";

            // CREATE AN INSTANCE OF TEXTBOX.
            // WITH EVERY COLUMN NAME, WE'LL CREATE AND ADD A TEXTBOX.

            div2.Controls.Add(ddl);
            div1.Controls.Add(lbl);
            div1.Controls.Add(div2);

            if (!string.IsNullOrEmpty(field1))
            {
                ddl.Items.Clear();
                var item1 = new ListItem
                {
                    Text = "-Select " + control_id + "-",
                    Value = "0"
                };
                ddl.Items.Add(item1);
                if (!string.IsNullOrEmpty(query))
                {
                    cmd.CommandText = query;
                }
                else
                {
                    cmd.CommandText = "SELECT '" + field1 + "','" + field2 + "' FROM '" + table_name + "';";
                }
                cmd.Connection = con;
                _sql.Con_switch(con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var item = new ListItem
                    {
                        Text = reader[field1].ToString(),
                        Value = reader[field2].ToString()
                    };
                    ddl.Items.Add(item);
                }
                reader.Close();
                FL_MySqlExecutor.Con_switch(con);
            }

            return div1;
        }

        /*public static HtmlGenericControl FL_form_create_dropdownlist1(string control_id, DropDownList ddl, MySqlConnection con = null, MySqlCommand cmd = null,
            string query = null, string field1 = null, string field2 = null, string table_name = null)
        {
            HtmlGenericControl div1 = new HtmlGenericControl("div");
            div1.Attributes.Add("class", "form-group nav");
            div1.Attributes.Add("runat", "server");

            Label lbl = new Label();
            lbl.Text = control_id;
            lbl.CssClass = "col-md-4 control-label";

            HtmlGenericControl div2 = new HtmlGenericControl("div");

            div2.Attributes.Add("class", "col-md-8");
            div2.Attributes.Add("runat", "server");

            ddl.ID = control_id;

            lbl.AssociatedControlID = control_id;
            // ASSIGN A CLASS. WE'LL USE THE CLASS NAME TO EXTRACT DATA USING JQUERY.
            ddl.CssClass = "form-control";

            // CREATE AN INSTANCE OF TEXTBOX.
            // WITH EVERY COLUMN NAME, WE'LL CREATE AND ADD A TEXTBOX.

            div2.Controls.Add(ddl);
            div1.Controls.Add(lbl);
            div1.Controls.Add(div2);

            if (!string.IsNullOrEmpty(field1))
            {
                ddl.Items.Clear();
                var item1 = new ListItem
                {
                    Text = "-Select " + control_id + "-",
                    Value = "0"
                };
                ddl.Items.Add(item1);
                if (!string.IsNullOrEmpty(query))
                {
                    cmd.CommandText = query;
                }
                else
                {
                    cmd.CommandText = "SELECT '" + field1 + "','" + field2 + "' FROM '" + table_name + "';";
                }
                cmd.Connection = con;
                _sql.Con_switch(con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var item = new ListItem
                    {
                        Text = reader[field1].ToString(),
                        Value = reader[field2].ToString()
                    };
                    ddl.Items.Add(item);
                }
                reader.Close();
                FL_MySqlExecutor.Con_switch(con);
            }

            return div1;
        }*/
    }
}