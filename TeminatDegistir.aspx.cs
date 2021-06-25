using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TeminatDegistir : System.Web.UI.Page
{
    SqlConnection connBizim, conn;
    DataTable tblVeri;
    SqlDataAdapter adpVeri;
    SqlCommand cmdGuncelle, cmdCariKod;
    string cariKod;
    protected void Page_Load(object sender, EventArgs e)
    {
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        if (!IsPostBack)
        {
            this.btnDegistir.Attributes.Add("onclick", "javascript: return confirm('Kayıt Değiştirilsin mi?');");
            VeriGetir();
        }
    }
    private void VeriGetir()
    {
        SqlCommand cmdVeri = new SqlCommand("SELECT ID,CARIKOD,CARIAD,BANKAAD,EVRAKNO,VADETARIHI,TUTAR,ACIKLAMA " +
            "FROM TEMINAT_MEKTUP WHERE ID='" + Session["refs"].ToString() + "'", connBizim);
        if (connBizim.State == ConnectionState.Closed)
        { connBizim.Open(); }
        SqlDataReader rdrVeri = cmdVeri.ExecuteReader();
        while (rdrVeri.Read())
        {
            txtCari.Text = rdrVeri[2].ToString();
            txtBanka.Text = rdrVeri[3].ToString();
            txtEvrak.Text = rdrVeri[4].ToString();
            dtTarih.Value = Convert.ToDateTime(rdrVeri[5]);
            txtTutar.Text = rdrVeri[6].ToString();
            txtAciklama.Text = rdrVeri[7].ToString();
        }
        if (connBizim.State == ConnectionState.Open)
        { connBizim.Close(); }
    }
    protected void btnDegistir_Click(object sender, EventArgs e)
    {
        cariKod = "";
        cmdGuncelle = new SqlCommand("UPDATE TEMINAT_MEKTUP SET  CARIKOD=@CARIKOD,CARIAD=@CARIAD,BANKAAD=@BANKAAD,EVRAKNO=@EVRAKNO,VADETARIHI=@VADETARIHI,TUTAR=@TUTAR,ACIKLAMA=@ACIKLAMA WHERE ID='" + Session["refs"].ToString() + "'", connBizim);
        #region carikod bulunuyor
        cmdCariKod = new SqlCommand("SELECT CODE FROM LG_316_CLCARD WHERE DEFINITION_='" + txtCari.Text + "'", conn);
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
        if (cariKod == "")
        { Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Cari Kod Bulunamadı');</script>"); }
        else
        {
            cmdGuncelle.Parameters.AddWithValue("@CARIKOD", cariKod);
            cmdGuncelle.Parameters.AddWithValue("@CARIAD", txtCari.Text);
            cmdGuncelle.Parameters.AddWithValue("@BANKAAD", txtBanka.Text);
            cmdGuncelle.Parameters.AddWithValue("@EVRAKNO", txtEvrak.Text);
            cmdGuncelle.Parameters.AddWithValue("@VADETARIHI", Convert.ToDateTime(dtTarih.Text));
            cmdGuncelle.Parameters.AddWithValue("@TUTAR", Convert.ToDouble(txtTutar.Text));
            cmdGuncelle.Parameters.AddWithValue("@ACIKLAMA", txtAciklama.Text);
            if (connBizim.State == ConnectionState.Closed)
            { connBizim.Open(); }
            cmdGuncelle.ExecuteNonQuery();
            if (connBizim.State == ConnectionState.Open)
            { connBizim.Close(); }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('İşlem Kaydedildi');</script>");
        }
    }
    protected void txtCari_TextChanged(object sender, EventArgs e)
    {
        GetProductMasterDetCari(txtCari.Text);
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
    protected void txtBanka_TextChanged(object sender, EventArgs e)
    {
        GetProductMasterDetBanka(txtBanka.Text);
    }

}