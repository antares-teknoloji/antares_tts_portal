using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Genel : System.Web.UI.MasterPage
{
    SqlConnection connBizim;
    protected void Page_Load(object sender, EventArgs e)
    {
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        string deneme = Session["Kullanici"].ToString();

        SqlDataAdapter adpYetki = new SqlDataAdapter("SELECT YETKI FROM CRM..KULLANICI WHERE KULLANICIAD='" + Session["yetki"].ToString() + "'", connBizim);
        DataTable tblYetki = new DataTable();
        adpYetki.Fill(tblYetki);

        if (tblYetki.Rows[0][0].ToString() == "admin")
        {

        }
        else
        {
            for (int i = 0; i < LinksTreeView.Nodes.Count; i++)
            {
                if (LinksTreeView.Nodes[i].Text == "Raporlar")
                {

                }
                else
                {
                    int sayi = LinksTreeView.Nodes[i].ChildNodes.Count;
                    for (int j = 0; j < sayi; j++)
                    {
                        LinksTreeView.Nodes[i].ChildNodes.RemoveAt(0);
                    }

                }

            }
        }

    }
}
