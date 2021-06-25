using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class KargoBilgileri : System.Web.UI.Page
{
    SqlDataAdapter adpVeri;
    DataTable tblVeri;
    SqlCommand cmdSil;
    SqlConnection conn, connBizim;
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
    }
    protected void btnSorgula_Click(object sender, EventArgs e)
    {
        adpVeri = new SqlDataAdapter("SELECT TARIH,TAKIPNO,CARIAD,CARIKOD,MAIL FROM KARGO_TAKIP WHERE TARIH=CONVERT(DATETIME,'" + dtTarih.Text + "',104)", connBizim);
        tblVeri = new DataTable();
        adpVeri.Fill(tblVeri);
        this.grdKargoBilgi.DataSource = tblVeri;
        this.grdKargoBilgi.DataBind();
    }
    protected void btnSil_Click(object sender, EventArgs e)
    {
        cmdSil = new SqlCommand("DELETE FROM KARGO_TAKIP WHERE TARIH=CONVERT(DATETIME,'" + dtTarih.Text + "',104)", connBizim);
        if (connBizim.State == ConnectionState.Closed)
        { connBizim.Open(); }
        cmdSil.ExecuteNonQuery();
        if (connBizim.State == ConnectionState.Open)
        { connBizim.Close(); }
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Seçmiş olduğunuz tarihte ki kayıtlar silinmiştir');</script>");
    }
}