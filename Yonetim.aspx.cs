using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetim : System.Web.UI.Page
{
    SqlConnection conn;
    SqlDataAdapter adpCari;
    DataTable tblCari;
    //SqlDataAdapter adpLimit;
    //DataTable tblLimit;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rdpSure.SelectedIndex = 0;
        }
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);

        adpCari = new SqlDataAdapter("SELECT CODE AS [CARİ KOD],DEFINITION_ AS [CARİ AD],[SON FATURA TARİHİ]= (SELECT MAX(DATE_) " +
            "FROM LG_316_01_INVOICE INV WHERE INV.CLIENTREF=CL.LOGICALREF AND TRCODE IN  (7,8) AND INV.BRANCH='120') " +
            "FROM LG_316_CLCARD CL WHERE LOGICALREF NOT IN (SELECT CLIENTREF FROM LG_316_01_INVOICE WHERE TRCODE IN  (7,8) " +
            "AND DATE_>=CONVERT(DATETIME,'" + DateTime.Now.AddDays(-30) + "',104) AND BRANCH ='120') AND LOGICALREF IN (SELECT CLIENTREF " +
            "FROM LG_316_01_INVOICE WHERE TRCODE IN  (7,8) AND DATE_>=CONVERT(DATETIME,'" + DateTime.Now.AddDays(-395) + "',104)" +
            "AND  DATE_<=CONVERT(DATETIME,'" + DateTime.Now.AddDays(-30) + "',104) AND BRANCH ='120') AND CODE LIKE '120%'  " +
            "AND ACTIVE=0 ORDER BY [SON FATURA TARİHİ] DESC", conn);
        tblCari = new DataTable();
        adpCari.Fill(tblCari);
        this.grdCari.DataSource = tblCari;
        this.grdCari.DataBind();
        //LimitCek();
        //}
        //private void LimitCek()
        //{
        //    adpLimit = new SqlDataAdapter("SELECT ALIMTARIH,MUSTERIAD,BAKIYE,ALISLAR,TOPLAM,DBSOFFLINE,DBSONLINE,KALANLIMIT,DBSTARIH FROM RESELLER_LIMIT WHERE KAYITTARIH=CONVERT(DATETIME,'" + DateTime.Now.ToString().Substring(0, 10).TrimEnd().TrimStart() + "',104)", connBizim);
        //    tblLimit = new DataTable();
        //    adpLimit.Fill(tblLimit);
        //    this.grdLimit.DataSource = tblLimit;
        //    this.grdLimit.DataBind();
        //}
        //protected void btnTeminatMektup_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("TeminatListe.aspx");
        //}
        //protected void grdLimit_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs e)
        //{
        //    if (e.Column.FieldName == "BAKIYE")
        //    {
        //        e.DisplayText = String.Format("{0,12:N2}", Convert.ToDouble(e.GetFieldValue("BAKIYE")));
        //    }
        //    if (e.Column.FieldName == "ALISLAR")
        //    {
        //        e.DisplayText = String.Format("{0,12:N2}", Convert.ToDouble(e.GetFieldValue("ALISLAR")));
        //    }
        //    if (e.Column.FieldName == "TOPLAM")
        //    {
        //        e.DisplayText = String.Format("{0,12:N2}", Convert.ToDouble(e.GetFieldValue("TOPLAM")));
        //    }
        //    if (e.Column.FieldName == "DBSOFFLINE")
        //    {
        //        e.DisplayText = String.Format("{0,12:N2}", Convert.ToDouble(e.GetFieldValue("DBSOFFLINE")));
        //    }
        //    if (e.Column.FieldName == "DBSONLINE")
        //    {
        //        e.DisplayText = String.Format("{0,12:N2}", Convert.ToDouble(e.GetFieldValue("DBSONLINE")));
        //    }
        //    if (e.Column.FieldName == "KALANLIMIT")
        //    {
        //        e.DisplayText = String.Format("{0,12:N2}", Convert.ToDouble(e.GetFieldValue("KALANLIMIT")));
        //    }
        //}
        //protected void btnArama_Click(object sender, EventArgs e)
        //{
        //if (txtCariAd.Text != "")
        //{
        //    adpLimit = new SqlDataAdapter("SELECT ALIMTARIH,MUSTERIAD,BAKIYE,ALISLAR,TOPLAM,DBSOFFLINE,DBSONLINE,KALANLIMIT,DBSTARIH FROM RESELLER_LIMIT WHERE KAYITTARIH=CONVERT(DATETIME,'" + DateTime.Now.ToString().Substring(0, 10).TrimEnd().TrimStart() + "',104) AND MUSTERIAD LIKE'%" + txtCariAd.Text + "%'", connBizim);
        //    tblLimit = new DataTable();
        //    adpLimit.Fill(tblLimit);
        //    this.grdLimit.DataSource = tblLimit;
        //    this.grdLimit.DataBind();
        //}
        //else
        //{
        //    LimitCek();
        //}
        if (Session["Kullanici"].ToString() == "melih" || Session["Kullanici"].ToString() == "semih")
        {
            btnGenelRapor.Enabled = true;
            btnCariBakiye.Enabled = true;
        }
    }
    protected void btnCariHesapListesi_Click(object sender, EventArgs e)
    {
        Response.Redirect("CariKart.aspx");
    }
    protected void btnCariAra_Click(object sender, EventArgs e)
    {
        if (rdpSure.SelectedIndex == 0)
        {
            adpCari = new SqlDataAdapter("SELECT CODE AS [FİRMA KOD],DEFINITION_ AS" +
                " [CARİ AD],[SON FATURA TARİHİ]= (SELECT MAX(DATE_) " +
                "FROM LG_316_01_INVOICE INV WHERE INV.CLIENTREF=CL.LOGICALREF " +
                "AND INV.BRANCH='120' AND TRCODE IN  (7,8)) FROM LG_316_CLCARD CL" +
                " WHERE LOGICALREF NOT IN (SELECT CLIENTREF FROM LG_316_01_INVOICE " +
                "WHERE TRCODE IN  (7,8) AND DATE_>=CONVERT(DATETIME,'" + DateTime.Now.AddDays(-30) + "',104) " +
                "AND BRANCH ='120') AND LOGICALREF IN (SELECT CLIENTREF FROM LG_316_01_INVOICE WHERE TRCODE " +
                "IN  (7,8) AND DATE_>=CONVERT(DATETIME,'" + DateTime.Now.AddDays(-395) + "',104) AND " +
                " DATE_<=CONVERT(DATETIME,'" + DateTime.Now.AddDays(-30) + "',104) AND BRANCH ='120') AND" +
                " CODE LIKE '120%'  AND ACTIVE=0 AND DEFINITION_ LIKE '%" + txtCariAd.Text + "%' ORDER BY [SON FATURA TARİHİ] DESC", conn);
        }
        else if (rdpSure.SelectedIndex == 1)
        {
            adpCari = new SqlDataAdapter("SELECT CODE AS [FİRMA KOD],DEFINITION_ AS [CARİ AD],[SON FATURA TARİHİ]= (SELECT MAX(DATE_) " +
                "FROM LG_316_01_INVOICE INV WHERE INV.CLIENTREF=CL.LOGICALREF AND INV.BRANCH='120' AND TRCODE IN  (7,8)) " +
                "FROM LG_316_CLCARD CL WHERE LOGICALREF NOT IN (SELECT CLIENTREF FROM LG_316_01_INVOICE WHERE TRCODE IN  (7,8) " +
                "AND DATE_>=CONVERT(DATETIME,'" + DateTime.Now.AddDays(-90) + "',104) AND BRANCH ='120') " +
                "AND LOGICALREF IN (SELECT CLIENTREF FROM LG_316_01_INVOICE WHERE TRCODE IN  (7,8) " +
                "AND DATE_>=CONVERT(DATETIME,'" + DateTime.Now.AddDays(-395) + "',104) " +
                "AND  DATE_<=CONVERT(DATETIME,'" + DateTime.Now.AddDays(-90) + "',104)" +
                "AND BRANCH ='120') AND CODE LIKE '120%'  AND ACTIVE=0 " +
                "AND DEFINITION_ LIKE '%" + txtCariAd.Text + "%' ORDER BY [SON FATURA TARİHİ] DESC", conn);
        }
        else if (rdpSure.SelectedIndex == 2)
        {
            adpCari = new SqlDataAdapter("SELECT CODE AS [FİRMA KOD],DEFINITION_ AS [CARİ AD],[SON FATURA TARİHİ]= (SELECT MAX(DATE_) " +
                "FROM LG_316_01_INVOICE INV WHERE INV.CLIENTREF=CL.LOGICALREF AND INV.BRANCH='120' AND TRCODE IN  (7,8)) " +
                "FROM LG_316_CLCARD CL WHERE LOGICALREF NOT IN (SELECT CLIENTREF FROM LG_316_01_INVOICE WHERE TRCODE IN  (7,8) " +
                "AND DATE_>=CONVERT(DATETIME,'" + DateTime.Now.AddDays(-180) + "',104) AND BRANCH ='120') " +
                "AND LOGICALREF IN (SELECT CLIENTREF FROM LG_316_01_INVOICE WHERE TRCODE IN  (7,8) " +
                "AND DATE_>=CONVERT(DATETIME,'" + DateTime.Now.AddDays(-395) + "',104) " +
                "AND  DATE_<=CONVERT(DATETIME,'" + DateTime.Now.AddDays(-180) + "',104) AND BRANCH ='120') " +
                "AND CODE LIKE '120%'  AND ACTIVE=0 AND DEFINITION_ LIKE '%" + txtCariAd.Text + "%' ORDER BY [SON FATURA TARİHİ] DESC", conn);
        }
        //else if (rdpSure.SelectedIndex == 3)
        //{
        //    adpCari = new SqlDataAdapter("SELECT CODE AS [CARİ KOD],DEFINITION_ AS [CARİ AD],[SON FATURA TARİHİ]= (SELECT MAX(DATE_) FROM LG_316_01_INVOICE INV WHERE INV.CLIENTREF=CL.LOGICALREF) FROM LG_316_CLCARD CL WHERE LOGICALREF NOT IN (SELECT CLIENTREF FROM LG_316_01_INVOICE WHERE TRCODE IN  (7,8) AND DATE_>=CONVERT(DATETIME,'" + DateTime.Now.AddDays(-365) + "',104) AND BRANCH ='120') AND LOGICALREF IN (SELECT CLIENTREF FROM LG_316_01_INVOICE WHERE TRCODE IN  (7,8)  AND BRANCH ='120') AND CODE LIKE '120%'  AND ACTIVE=0 AND DEFINITION_ LIKE %" + txtCariAd.Text + "%' ORDER BY DEFINITION_", conn);
        //}
        tblCari = new DataTable();
        adpCari.Fill(tblCari);
        this.grdCari.DataSource = tblCari;
        this.grdCari.DataBind();
    }
    protected void btnGenelRapor_Click(object sender, EventArgs e)
    {
        Response.Redirect("GenelRapor.aspx");
    }
    protected void btnCariBakiye_Click(object sender, EventArgs e)
    {
        Response.Redirect("CariBakiye.aspx");
    }
}