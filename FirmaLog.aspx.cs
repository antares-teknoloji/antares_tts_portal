using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FirmaLog : System.Web.UI.Page
{
    string navigateURL, cariKod, cariAd;
    SqlConnection conn;
    SqlConnection connBizim;
    SqlDataAdapter adpVeri, adpCari;
    System.Data.DataTable tblVeri, tblCari;
    SqlCommand cmdKaydet, cmdSil;
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        if (!IsPostBack)
            VeriCek();
    }
    private void VeriCek()
    {
        adpVeri = new SqlDataAdapter("SELECT CARIKOD,CARIAD,TARIH,ACIKLAMA,ID FROM TTSPORTAL_FIRMALOG WHERE CARIKOD='" + Session["CariRef"].ToString() + "'", connBizim);
        tblVeri = new System.Data.DataTable();
        adpVeri.Fill(tblVeri);
        this.grdFirmaLog.DataSource = tblVeri;
        this.grdFirmaLog.DataBind();
        txtCari.Text = Session["CariAd"].ToString();
    }
    protected void btnEkle_Click(object sender, EventArgs e)
    {
        cmdKaydet = new SqlCommand("INSERT INTO TTSPORTAL_FIRMALOG (CARIKOD,CARIAD,TARIH,ACIKLAMA) VALUES (@CARIKOD,@CARIAD,@TARIH,@ACIKLAMA)", connBizim);
        cmdKaydet.Parameters.AddWithValue("@CARIKOD", Session["CariRef"].ToString());
        cmdKaydet.Parameters.AddWithValue("@CARIAD", Session["CariAd"].ToString());
        cmdKaydet.Parameters.AddWithValue("@TARIH", Convert.ToDateTime(DateTime.Now.ToString().Substring(0, 10)));
        cmdKaydet.Parameters.AddWithValue("@ACIKLAMA", txtAciklama.Text);
        connBizim.Open();
        cmdKaydet.ExecuteNonQuery();
        connBizim.Close();
        Response.Redirect("FirmaLog.aspx");
    }
    protected void grdFirmaLog_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        cmdSil = new SqlCommand("DELETE FROM TTSPORTAL_FIRMALOG WHERE ID='" + grdFirmaLog.Rows[e.RowIndex].Cells[5].Text + "'", connBizim);
        if (connBizim.State == System.Data.ConnectionState.Closed)
        { connBizim.Open(); }
        cmdSil.ExecuteNonQuery();
        if (connBizim.State == System.Data.ConnectionState.Open)
        { connBizim.Close(); }
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('KAYIT SİLİNDİ');</script>");
        VeriCek();
    }
    protected void grdFirmaLog_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[5].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        //e.Row.Cells[3].Width = 100;
    }
}