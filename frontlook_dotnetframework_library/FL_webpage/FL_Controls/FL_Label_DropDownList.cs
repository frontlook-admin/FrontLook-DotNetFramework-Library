using MySql.Data.MySqlClient;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using _sql = frontlook_dotnetframework_library.FL_webpage.FL_DataBase.FL_SqlExecutor;

namespace frontlook_dotnetframework_library.FL_webpage.FL_Controls
{
    /// <summary>
    /// Defines the <see cref="FL_Label_DropDownList" />
    /// </summary>
    public static class FL_Label_DropDownList
    {
        /// <summary>
        /// The FL_form_create_dropdownlist1
        /// </summary>
        /// <param name="Control_Id">The Control_Id<see cref="string"/></param>
        /// <param name="Con">The Con<see cref="MySqlConnection"/></param>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <param name="Field1">The Field1<see cref="string"/></param>
        /// <param name="Field2">The Field2<see cref="string"/></param>
        /// <param name="Table_Name">The Table_Name<see cref="string"/></param>
        /// <returns>The <see cref="HtmlGenericControl"/></returns>
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
    }
}
