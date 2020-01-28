using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using frontlook_dotnetframework_library.FL_webpage.FL_DataBase.FL_MySql;
using MySql.Data.MySqlClient;
using _sql = frontlook_dotnetframework_library.FL_webpage.FL_DataBase.FL_SqlExecutor;


namespace frontlook_dotnetframework_library.FL_webpage.FL_Controls
{
    public static class FL_Label_DropDownList
    {
        public static HtmlGenericControl FL_form_create_dropdownlist1(string Control_Id, MySqlConnection Con = null, MySqlCommand Cmd = null,
            string Query = null, string Field1 = null, string Field2 = null, string Table_Name = null)
        {
            var Control_Id_T = Control_Id.Replace(" ", "");
            var Div1 = new HtmlGenericControl("div");
            Div1.Attributes.Add("class", "form-group nav");
            Div1.Attributes.Add("runat", "server");

            var Lbl = new Label { Text = Control_Id, CssClass = "col-md-4 Control-label" };

            var Div2 = new HtmlGenericControl("div");

            Div2.Attributes.Add("class", "col-md-8");
            Div2.Attributes.Add("runat", "server");

            DropDownList ddl = new DropDownList();
            ddl.ID = Control_Id_T;

            Lbl.AssociatedControlID = Control_Id_T;
            // ASSIGN A CLASS. WE'LL USE THE CLASS NAME TO EXTRACT DATA USING JQUERY.
            ddl.CssClass = "form-Control";

            // CREATE AN INSTANCE OF TEXTBOX.
            // WITH EVERY COLUMN NAME, WE'LL CREATE AND ADD A TEXTBOX.

            Div2.Controls.Add(ddl);
            Div1.Controls.Add(Lbl);
            Div1.Controls.Add(Div2);

            if (!string.IsNullOrEmpty(Field1))
            {
                ddl.Items.Clear();
                var Item1 = new ListItem
                {
                    Text = "-Select " + Control_Id + "-",
                    Value = "0"
                };
                ddl.Items.Add(Item1);
                if (!string.IsNullOrEmpty(Query))
                {
                    Cmd.CommandText = Query;
                }
                else
                {
                    Cmd.CommandText = "SELECT '" + Field1 + "','" + Field2 + "' FROM '" + Table_Name + "';";
                }
                Cmd.Connection = Con;
                _sql.Con_switch(Con);
                MySqlDataReader reader = Cmd.ExecuteReader();

                while (reader.Read())
                {
                    var item = new ListItem
                    {
                        Text = reader[Field1].ToString(),
                        Value = reader[Field2].ToString()
                    };
                    ddl.Items.Add(item);
                }
                reader.Close();
                _sql.Con_switch(Con);
            }

            return Div1;
        }

        /*public static HtmlGenericControl FL_form_create_dropdownlist1(string Control_id, DropDownList ddl, MySqlConnection Con = null, MySqlCommand Cmd = null,
            string Query = null, string field1 = null, string field2 = null, string table_name = null)
        {
            HtmlGenericControl div1 = new HtmlGenericControl("div");
            div1.Attributes.Add("class", "form-group nav");
            div1.Attributes.Add("runat", "server");

            Label lbl = new Label();
            lbl.Text = Control_id;
            lbl.CssClass = "col-md-4 Control-label";

            HtmlGenericControl div2 = new HtmlGenericControl("div");

            div2.Attributes.Add("class", "col-md-8");
            div2.Attributes.Add("runat", "server");

            ddl.ID = Control_id;

            lbl.AssociatedControlID = Control_id;
            // ASSIGN A CLASS. WE'LL USE THE CLASS NAME TO EXTRACT DATA USING JQUERY.
            ddl.CssClass = "form-Control";

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
                    Text = "-Select " + Control_id + "-",
                    Value = "0"
                };
                ddl.Items.Add(item1);
                if (!string.IsNullOrEmpty(Query))
                {
                    Cmd.CommandText = Query;
                }
                else
                {
                    Cmd.CommandText = "SELECT '" + field1 + "','" + field2 + "' FROM '" + table_name + "';";
                }
                Cmd.Connection = Con;
                _sql.Con_switch(Con);
                MySqlDataReader reader = Cmd.ExecuteReader();

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
                FL_MySqlExecutor.Con_switch(Con);
            }

            return div1;
        }*/
    }
}