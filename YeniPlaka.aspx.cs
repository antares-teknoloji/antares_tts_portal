using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class YeniPlaka : System.Web.UI.Page
{
    SqlConnection conn,connBizim;
    SqlDataAdapter adpVeri;
    DataTable tblVeri;
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        if (!IsPostBack)
        {
            this.btnKaydet.Attributes.Add("onclick", "javascript: return confirm('Veri Kaydedilsin mi?');");
        }
    }
    protected void txtCariAd_TextChanged(object sender, EventArgs e)
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
    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        //if (txtCari.Text != "" || txtPlaka.Text != "")
        //{
        //    #region cari kontrol ediliyor
        //    SqlDataAdapter adpKontrol = new SqlDataAdapter("SELECT LOGICALREF,CODE,DEFINITION_ FROM LG_316_CLCARD WHERE DEFINITION_='" + txtCari.Text + "'", conn);
        //    DataTable tblKontrol = new DataTable();
        //    adpKontrol.Fill(tblKontrol);
        //    #endregion
        //    if (tblKontrol.Rows.Count == 1)
        //    {
        //        SqlCommand cmdKaydet = new SqlCommand("INSERT INTO BS_PLAKA (LOGICALREF,CARIKOD,PLAKA,DURUM,LIMIT) VALUES (@LOGICALREF,@CARIKOD,@PLAKA,@DURUM,@LIMIT)", connBizim);
        //        cmdKaydet.Parameters.AddWithValue("@LOGICALREF",tblKontrol.Rows[0][0].ToString());
        //        cmdKaydet.Parameters.AddWithValue("@CARIKOD", tblKontrol.Rows[0][1].ToString());
        //        cmdKaydet.Parameters.AddWithValue("@PLAKA", txtPlaka.Text);
        //        cmdKaydet.Parameters.AddWithValue("@DURUM","AÇIK");
        //        cmdKaydet.Parameters.AddWithValue("@LIMIT", "0");
        //        connBizim.Open();
        //        cmdKaydet.ExecuteNonQuery();
        //        connBizim.Close();
        //        Response.Write("Plaka Kaydedildi");
        //        txtCari.Text = "";
        //        txtPlaka.Text = "";
        //    }
        //    else
        //    {
        //        Response.Write("Cari Bulunamadı");
        //    }
        //}
    }
}