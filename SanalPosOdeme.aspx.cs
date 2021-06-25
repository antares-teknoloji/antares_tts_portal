using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class SanalPosOdeme : System.Web.UI.Page
{

    SqlConnection con;
    SqlConnection conn;
    DataTable tblVeri;
    SqlDataAdapter adpVeri;
    string navigateURL;
    UnityObjects.IData rs;
    UnityObjects.ILines tr;
    string msg = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        if (!IsPostBack)
        {
            VeriGetir();
        }
    }

    protected void VeriGetir()
    {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        SqlDataAdapter adpVeri = new SqlDataAdapter(" SELECT TOP 20  P.CARIKOD,CL.DEFINITION_,P.SIPARISNO,P.TARIH,P.TUTAR,P.DURUM,P.AKTARIMDURUM FROM POS_ODEME P LEFT OUTER JOIN BEKEN2010.dbo.LG_316_CLCARD CL ON P.CARIKOD = CL.CODE ORDER BY TARIH DESC ", conn);
        DataTable tblVeri = new DataTable();
        adpVeri.Fill(tblVeri);
        grdPos.DataSource = tblVeri;

        DataBind();
        for (int i = 0; i < grdPos.Rows.Count; i++)
        {
            if (grdPos.Rows[i].Cells[7].Text.ToString() == "1")
            {
               
                grdPos.Rows[i].BackColor = Color.Red;
            }
            grdPos.Rows[i].Cells[7].Visible = false;
        }


    }
    protected void SorguCek(object sender, EventArgs e)
    {
        VeriGetir(txtCarıAd.Text);
    }
    private void VeriGetir(string cariad)
    {
        {
            SqlDataAdapter adpVeri = new SqlDataAdapter("SELECT P.CARIKOD,CL.DEFINITION_ AS[CARİ AD], P.SIPARISNO,P.TARIH,P.TUTAR,P.DURUM,P.AKTARIMDURUM FROM POS_ODEME P LEFT OUTER JOIN BEKEN2010.dbo.LG_316_CLCARD CL ON P.CARIKOD = CL.CODE WHERE TARIH>=CONVERT(DATETIME,'" + txtFromDate.Text + "',104) AND TARIH<=CONVERT(DATETIME,'" + txtToDate.Text + "',104) AND CL.DEFINITION_ LIKE '%" + txtCarıAd.Text + "%' order by TARIH ", conn);
            DataTable tblVeri = new DataTable();
            adpVeri.Fill(tblVeri);
            grdPos.DataSource = tblVeri;

            DataBind();
            for (int i = 0; i < grdPos.Rows.Count; i++)
            {
                if (grdPos.Rows[i].Cells[7].Text.ToString() == "1")
                {

                    grdPos.Rows[i].BackColor = Color.Red;
                }
                grdPos.Rows[i].Cells[7].Visible = false;
            }

        }
    }
    protected void grdPos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowIndex == 0)
                e.Row.Style.Add("height", "50px");

            if (e.Row.Cells[7].Text.ToString() == "1")
            {
                e.Row.BackColor = Color.Red;
            }
        }


    }


    protected void grdPos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow gvRow = grdPos.Rows[index];
        int rowIndex = index;
        string cariAd = HttpUtility.HtmlDecode(grdPos.Rows[rowIndex].Cells[2].Text.ToString());
        string cariRef = grdPos.Rows[rowIndex].Cells[1].Text;
        Session["CariRef"] = cariRef.ToString();
        Session["CariAd"] = cariAd;
        Session["SIPARIS_NO"] = grdPos.Rows[rowIndex].Cells[3].Text;

        #region kayıt kontrol 
        SqlDataAdapter adpDurum = new SqlDataAdapter("SELECT * FROM POS_ODEME WHERE SIPARISNO='" + Session["SIPARIS_NO"].ToString() + "' AND AKTARIMDURUM=1", conn);
        DataTable tblDurum = new DataTable();
        adpDurum.Fill(tblDurum);
        #endregion

        if (tblDurum.Rows.Count == 0)
        {
            //0532621 9093 ninat

            Aktarimlarcs.ilkDeger();


            if (Aktarimlarcs.baglan("LOGO", "HBCLOGO", 316) == true)
            {
                msg = "";
                rs = Aktarimlarcs.uo.NewDataObject(UnityObjects.DataObjectType.doARAPVoucher);
                rs.New();
                rs.FillAccCodes();
                rs.DataFields.FieldByName("NUMBER").Value = "~";
                rs.DataFields.FieldByName("DATE").Value = Convert.ToDateTime(grdPos.Rows[rowIndex].Cells[4].Text);
                rs.DataFields.FieldByName("TYPE").Value = 70;
                rs.DataFields.FieldByName("NOTES1").Value = "sanal pos";
                // rs.DataFields.FieldByName("AUXIL_CODE").Value = "ozelkod";
                //rs.DataFields.FieldByName("AUTH_CODE").Value = "yetki";

                rs.DataFields.FieldByName("ARP_CODE").Value = Session["CariRef"].ToString();
                rs.DataFields.FieldByName("DIVISION").Value = "10";
                rs.DataFields.FieldByName("BANKACC_CODE").Value = "014   .00.K099";
                //rs.DataFields.FieldByName("GL_CODE").Value = tblAnaCari.Rows[0][0].ToString();
                //rs.DataFields.FieldByName("APPROVE").Value = 1;
                //rs.DataFields.FieldByName("APPROVE_DATE").Value = Convert.ToDateTime(dtBaslangic.Text);
                tr = rs.DataFields.FieldByName("TRANSACTIONS").Lines;
                tr.AppendLine();
                tr[0].FieldByName("ARP_CODE").Value = Session["CariRef"].ToString();//cari değişecek
                tr[0].FieldByName("DOC_NUMBER").Value = "makbuz";
                //tr[0].FieldByName("GL_CODE1").Value = tblAnaCari.Rows[0][0].ToString();
                //tr[0].FieldByName("GL_CODE2").Value = muhasebeKod;
                //tr[0].FieldByName("BANK_GL_CODE").Value = muhasebeKod;
                tr[0].FieldByName("DESCRIPTION").Value = 1;
                tr[0].FieldByName("CREDIT").Value = grdPos.Rows[rowIndex].Cells[5].Text.ToString().Replace(",", ".");
                tr[0].FieldByName("TC_XRATE").Value = 1;
                tr[0].FieldByName("TC_AMOUNT").Value = grdPos.Rows[rowIndex].Cells[5].Text.ToString().Replace(",", ".");
                //tr[0].FieldByName("CREDIT_CARD_NO").Value = "kart no";        
                tr[0].FieldByName("BANKACC_CODE").Value = "014   .00.K099";

                #region post ediliyor
                if (rs.Post())
                {
                    SqlCommand cmdSlipDurum = new SqlCommand("UPDATE POS_ODEME SET AKTARIMDURUM=1 WHERE SIPARISNO='" + Session["SIPARIS_NO"].ToString() + "'", conn);
                    if (conn.State == ConnectionState.Closed)
                    { conn.Open(); }
                    cmdSlipDurum.ExecuteNonQuery();
                    if (conn.State == ConnectionState.Open)
                    { conn.Close(); }

                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "durum", "<script>alert('aktarılmıştır');</script>");
                }
                else
                {
                    if (rs.ErrorCode == 0)
                    { // hata var ama hata veri tabanı hatası değil. Öyleyse hata XML hatasıdır.
                        msg += " XML error";
                        for (int h = 0; h <= rs.ValidateErrors.Count - 1; h++)
                        {
                            msg += "Err Id:" + rs.ValidateErrors[h].ID.ToString();
                            msg += "Err Code:" + rs.ValidateErrors[h].Error.ToString();
                        }
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "durum", "<script>alert('" + msg + "');</script>");
                    }
                    else
                    {// hata var ve hata veri tabanı hatası.
                        msg = "Veri Tabanı Hatası:" + rs.ErrorCode.ToString() + " -" + rs.ErrorDesc;
                    }
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "durum", "<script>alert('" + msg + "');</script>");
                }
                //rs = null;
                #endregion

            }
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "durum", "<script>alert('Seçili Kayıt Önceden Aktarılmıştır.');</script>");
        }

    }

    private class Aktarimlarcs
    {
        public static UnityObjects.UnityApplication uo;
        public static bool UnityBagli;
        public static void ilkDeger()
        { uo = new UnityObjects.UnityApplication(); }
        public static bool bagliyim()
        {
            if (uo.Connect())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool baglan(string username, string password, int firmnumber)
        {
            uo.Login(username, password, firmnumber);
            if (uo.Connected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

