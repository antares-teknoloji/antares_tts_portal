using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TeminatMektup : System.Web.UI.Page
{
    string navigateURL, cariKod;
    SqlConnection conn;
    SqlConnection connBizim;
    SqlDataAdapter adpVeri;
    DataTable tblVeri;
    SqlCommand cmdKaydet;
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        if (!IsPostBack)
            VeriCek();
    }
    private void VeriCek()
    {
        adpVeri = new SqlDataAdapter("SELECT DEFINITION_ FROM LG_316_CLCARD WHERE ACTIVE=0", conn);
        tblVeri = new DataTable();
        adpVeri.Fill(tblVeri);
    }
    private void GetProductMasterDetCari(string ProductName)
    {
        try
        {
            adpVeri = new SqlDataAdapter("SELECT DEFINITION_ FROM LG_316_CLCARD WHERE ACTIVE=0 AND DEFINITION_ LIKE '%" + txtCari.Text + "%'", conn);
            tblVeri = new DataTable();
            adpVeri.Fill(tblVeri);
            //Binding TextBox From dataTable  
            txtCari.Text = tblVeri.Rows[0]["DEFINITION_"].ToString();
        }
        catch (Exception)
        {

        }
    }
    private void GetProductMasterDetBanka(string ProductName)
    {
        try
        {
            adpVeri = new SqlDataAdapter("SELECT DEFINITION_ FROM LG_316_BNCARD WHERE DEFINITION_ LIKE '%" + txtBanka.Text + "%'", conn);
            tblVeri = new DataTable();
            adpVeri.Fill(tblVeri);
            //Binding TextBox From dataTable  
            txtBanka.Text = tblVeri.Rows[0]["DEFINITION_"].ToString();
        }
        catch (Exception)
        {

        }
    }
    protected void btnEkle_Click(object sender, EventArgs e)
    {
        cmdKaydet = new SqlCommand("INSERT INTO TEMINAT_MEKTUP (CARIKOD,CARIAD,BANKAAD,EVRAKNO,VADETARIHI,TARIH,TUTAR,ACIKLAMA) VALUES (@CARIKOD,@CARIAD,@BANKAAD,@EVRAKNO,@VADETARIHI,@TARIH,@TUTAR,@ACIKLAMA)", connBizim);
        #region cari kod bulunuyor
        SqlCommand cmdCariKod = new SqlCommand("SELECT CODE FROM LG_316_CLCARD WHERE DEFINITION_='" + txtCari.Text + "'", conn);
        if (conn.State == ConnectionState.Closed)
        { conn.Open(); }
        SqlDataReader rdrCariKod = cmdCariKod.ExecuteReader();
        while (rdrCariKod.Read())
        {
            cariKod = rdrCariKod[0].ToString();
        }
        if (conn.State == ConnectionState.Open)
        { conn.Close(); }
        #endregion
        cmdKaydet.Parameters.AddWithValue("@CARIKOD", cariKod);
        cmdKaydet.Parameters.AddWithValue("@CARIAD", txtCari.Text);
        cmdKaydet.Parameters.AddWithValue("@BANKAAD", txtBanka.Text);
        cmdKaydet.Parameters.AddWithValue("@EVRAKNO", txtEvrak.Text);
        cmdKaydet.Parameters.AddWithValue("@VADETARIHI", Convert.ToDateTime(dtTarih.Text));
        cmdKaydet.Parameters.AddWithValue("@TARIH", Convert.ToDateTime(DateTime.Now.ToString().Substring(0, 10)));
        cmdKaydet.Parameters.AddWithValue("@TUTAR", Convert.ToDouble(txtTutar.Text));
        cmdKaydet.Parameters.AddWithValue("@ACIKLAMA", txtAciklama.Text);
        if (connBizim.State == ConnectionState.Closed)
        { connBizim.Open(); }
        cmdKaydet.ExecuteNonQuery();
        if (connBizim.State == ConnectionState.Open)
        { connBizim.Close(); }
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('iŞLEM KAYDEDİLDİ');</script>");
        Response.Redirect("TeminatMektup.aspx");
    }
    protected void txtCari_TextChanged(object sender, EventArgs e)
    {
        GetProductMasterDetCari(txtCari.Text);
    }
    protected void txtBanka_TextChanged(object sender, EventArgs e)
    {
        GetProductMasterDetBanka(txtBanka.Text);
    }
}