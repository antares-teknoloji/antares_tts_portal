using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class m_default : System.Web.UI.Page
{
    SqlCommand cmdCariAd;
    string cariAd, kullaniciKod, kullaniciAd;
    SqlConnection conn; 
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        kullaniciKod = "";
        kullaniciAd = "";
    }
    protected void btnGiris_Click(object sender, EventArgs e)
    {
        if (txtKullaniciAd.Text == "" || txtParola.Text == "")
        {

        }
        else
        {
            SqlDataAdapter adpVeri = new SqlDataAdapter("SELECT USERNAME,PASSWORD FROM BS_USER WHERE USERNAME='" + txtKullaniciAd.Text + "' AND PASSWORD='" + txtParola.Text + "'", conn);
            DataTable tblVeri = new DataTable();
            adpVeri.Fill(tblVeri);
            foreach (DataRow item in tblVeri.Rows)
            {
                kullaniciKod = item[0].ToString();
                kullaniciAd = item[1].ToString();
            }
            if (kullaniciKod != "")
            {
                Session["CariKod"] = kullaniciKod.ToString();
                Session["CariAd"] = kullaniciAd.ToString();
                Response.Redirect("mYonetim.aspx");
            }
        }     
    }
}