using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    SqlCommand cmdCariAd;
    string cariAd, kullaniciKod, kullaniciAd, kullanici;
    SqlConnection conn;
    protected void Page_Load(object sender, EventArgs e)
    {
        string userAgent = Request.UserAgent.ToString().ToLower();
        if (userAgent != null)
        {
            if (Request.Browser.IsMobileDevice == true)
            {
                //Response.Redirect("m.default.aspx");
            }
        }
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
                kullanici = txtKullaniciAd.Text.ToString();
                Session["CariKod"] = kullaniciKod.ToString();
                Session["CariAd"] = kullaniciAd.ToString();
                Session["Kullanici"] = kullanici.ToString();
                Response.Redirect("Yonetim.aspx");
            }
        }
    }
}