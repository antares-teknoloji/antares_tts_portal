using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PlakaListe : System.Web.UI.Page
{
    SqlConnection connBizim;
    SqlDataAdapter adpPlaka;
    DataTable tblPlaka;
    SqlCommand cmdSil;
    protected void Page_Load(object sender, EventArgs e)
    {
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        if (!IsPostBack)
        { VeriGetir(); }
    }
    private void VeriGetir()
    {
        adpPlaka = new SqlDataAdapter("SELECT DEFINITION_ AS [CARİ],BS.PLAKA AS PLAKA " +
            "FROM BS_PLAKA BS LEFT OUTER JOIN BEKEN2010.DBO.LG_316_CLCARD CL ON CL.CODE=BS.CARIKOD" +
            " WHERE BS.CARIKOD='" + Session["CariRef"].ToString() + "'", connBizim);
        tblPlaka = new DataTable();
        adpPlaka.Fill(tblPlaka);
        this.grdPlaka.DataSource = tblPlaka;
        this.grdPlaka.DataBind();
    }
    protected void btnArama_Click(object sender, EventArgs e)
    {
        PlakaCek();
    }
    private void PlakaCek()
    {
        if (txtPlaka.Text != "")
        {
            adpPlaka = new SqlDataAdapter("SELECT DEFINITION_ AS [CARİ],BS.PLAKA AS PLAKA FROM BS_PLAKA BS " +
                "LEFT OUTER JOIN BEKEN2010.DBO.LG_316_CLCARD CL ON CL.CODE=BS.CARIKOD WHERE BS.PLAKA LIKE '%" + txtPlaka.Text + "%' " +
                "AND BS.CARIKOD='" + Session["CariRef"].ToString() + "'", connBizim);
            tblPlaka = new DataTable();
            adpPlaka.Fill(tblPlaka);
            this.grdPlaka.DataSource = tblPlaka;
            this.grdPlaka.DataBind();
        }
        //else if (txtCariAd.Text != "")
        //{
        //    adpPlaka = new SqlDataAdapter("SELECT DEFINITION_ AS [CARİ],BS.PLAKA AS PLAKA FROM BS_PLAKA BS LEFT OUTER JOIN BEKEN2010.DBO.LG_316_CLCARD CL ON CL.CODE=BS.CARIKOD WHERE CL.DEFINITION_ LIKE '%" + txtCariAd.Text + "%'", connBizim);
        //    tblPlaka = new DataTable();
        //    adpPlaka.Fill(tblPlaka);
        //    this.grdPlaka.DataSource = tblPlaka;
        //    this.grdPlaka.DataBind();
        //}
        else
        {
            VeriGetir();
        }
    }
    protected void grdPlaka_PageIndexChanged(object sender, EventArgs e)
    {
        PlakaCek();
    }
    protected void grdPlaka_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName == "Sil")
        //{
        //    int index = Convert.ToInt32(e.CommandArgument);
        //    GridViewRow gvRow = grdPlaka.Rows[index];
        //    int rowIndex = index;
        //    cmdSil = new SqlCommand("DELETE FROM BS_PLAKA WHERE PLAKA='" + grdPlaka.Rows[rowIndex].Cells[2].Text + "'", connBizim);
        //    if (connBizim.State == ConnectionState.Closed)
        //    { connBizim.Open(); }
        //    cmdSil.ExecuteNonQuery();
        //    if (connBizim.State == ConnectionState.Open)
        //    { connBizim.Close(); }
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('KAYIT SİLİNDİ');</script>");
        //    VeriGetir();
        //}
    }
    protected void grdPlaka_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdPlaka_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdPlaka_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        cmdSil = new SqlCommand("DELETE FROM BS_PLAKA WHERE PLAKA='" + grdPlaka.Rows[e.RowIndex].Cells[2].Text + "'", connBizim);
        if (connBizim.State == ConnectionState.Closed)
        { connBizim.Open(); }
        cmdSil.ExecuteNonQuery();
        if (connBizim.State == ConnectionState.Open)
        { connBizim.Close(); }
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('KAYIT SİLİNDİ');</script>");
        VeriGetir();
    }
    protected void grdPlaka_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdPlaka.PageIndex = e.NewPageIndex;
        VeriGetir();
    }
    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        if (Session["CariRef"] != "")
        {
            #region cari kontrol ediliyor
            SqlDataAdapter adpKontrol = new SqlDataAdapter("SELECT LOGICALREF,CODE,DEFINITION_ FROM BEKEN2010.DBO.LG_316_CLCARD WHERE CODE='" + Session["CariRef"].ToString() + "'", connBizim);
            DataTable tblKontrol = new DataTable();
            adpKontrol.Fill(tblKontrol);
            #endregion
            if (tblKontrol.Rows.Count == 1)
            {
                SqlCommand cmdKaydet = new SqlCommand("INSERT INTO BS_PLAKA (LOGICALREF,CARIKOD,PLAKA,DURUM,LIMIT) VALUES (@LOGICALREF,@CARIKOD,@PLAKA,@DURUM,@LIMIT)", connBizim);
                cmdKaydet.Parameters.AddWithValue("@LOGICALREF", tblKontrol.Rows[0][0].ToString());
                cmdKaydet.Parameters.AddWithValue("@CARIKOD", tblKontrol.Rows[0][1].ToString());
                cmdKaydet.Parameters.AddWithValue("@PLAKA", txtPlakaKaydet.Text);
                cmdKaydet.Parameters.AddWithValue("@DURUM", "AÇIK");
                cmdKaydet.Parameters.AddWithValue("@LIMIT", "0");
                connBizim.Open();
                cmdKaydet.ExecuteNonQuery();
                connBizim.Close();
                Response.Write("Plaka Kaydedildi");
                VeriGetir();
                txtPlakaKaydet.Text = "";
            }
            else
            {
                Response.Write("Cari Bulunamadı");
            }
        }
    }
}