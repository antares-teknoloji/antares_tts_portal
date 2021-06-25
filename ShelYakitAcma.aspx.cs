using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShelYakitAcma : System.Web.UI.Page
{
    SqlConnection conn, connBizim;
    SqlDataAdapter adpArama;
    SqlDataAdapter adpCari;
    DataTable tblCari;
    DataTable tblArama;
    DataTable tblPlaka, tblPlakaPasif;
    int sayi;
    string navigateURL;
    string bayi, kullanici, parola, shellMusteriKod;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { VeriCek(); }
    }
    private void chkOlustur()
    {
        for (int i = 0; i < tblPlaka.Rows.Count; i++)
        {
            CheckBox c = new CheckBox();
            c.ID = "ch_" + i.ToString();
            Label l = new Label();
            l.Text = tblPlaka.Rows[i]["SEC"].ToString();
            grdPlaka.Rows[i].Cells[0].Controls.Add(c);
            grdPlaka.Rows[i].Cells[0].Controls.Add(l);
            //c.CheckedChanged += c_CheckedChanged;
            c.AutoPostBack = true;
            if (grdPlaka.Rows[i].Cells[2].Text == "AKTİF")
            {
                c.Checked = true;
            }
            else
            {
                c.Checked = false; ;
            }
            this.grdPlaka.Rows[i].Cells[0].Width = 10;
        }
    }
    private void VeriCek()
    {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        adpCari = new SqlDataAdapter("SELECT TOP 20 CODE AS [CARİ KOD],DEFINITION_ AS [FİRMA ÜNVAN],Cast(REPLACE(ONLINELIMIT,',','.') As decimal(15,2)) + Cast(REPLACE(OFFLINELIMIT,',','.') As decimal(15,2)) AS [MÜŞTERİ LİMİT] ,ODEMETUR AS [ÖDEME TÜR],BANKADBSKOD AS [BANKA KODU],SHELLVADE1,TELEFON='',SHELLMUSTERIKOD AS [FİLO KODU] FROM LG_316_CLCARD CL LEFT OUTER JOIN AKTARIM.DBO.TTSPORTAL_CARIBILGI TC  ON CL.CODE=TC.CARIKOD WHERE ACTIVE=0 AND CODE LIKE '120%' OR ACTIVE=0 AND CODE LIKE '320%'  GROUP BY CARIKOD,CARIAD,ODEMETUR,BANKADBSKOD,SHELLVADE1,SHELLMUSTERIKOD,ONLINELIMIT,OFFLINELIMIT,CODE,DEFINITION_", conn);
        tblCari = new DataTable();
        adpCari.Fill(tblCari);
        this.grdCari.DataSource = tblCari;
        this.grdCari.DataBind();
    }
    protected void btnArama_Click(object sender, EventArgs e)
    {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        if (txtPlaka.Text != "")
        {
            adpArama = new SqlDataAdapter("SELECT CODE AS [CARİ KOD],DEFINITION_ AS [FİRMA ÜNVAN],Cast(REPLACE(ONLINELIMIT,',','.') As decimal(15,2)) + Cast(REPLACE(OFFLINELIMIT,',','.') As decimal(15,2)) AS [MÜŞTERİ LİMİT] ,ODEMETUR AS [ÖDEME TÜR],BANKADBSKOD AS [BANKA KODU],SHELLVADE1,TELEFON='',SHELLMUSTERIKOD AS [FİLO KODU] FROM LG_316_CLCARD CL LEFT OUTER JOIN AKTARIM.DBO.TTSPORTAL_CARIBILGI TC  ON CL.CODE=TC.CARIKOD LEFT OUTER JOIN AKTARIM.DBO.BS_PLAKA BS ON BS.CARIKOD= CL.CODE WHERE ACTIVE=0 AND CODE LIKE '120%' AND BS.PLAKA LIKE '%" + txtPlaka.Text + "%' OR ACTIVE=0 AND CODE LIKE '320%' AND BS.PLAKA LIKE '%" + txtPlaka.Text + "%'  GROUP BY TC.CARIKOD,CARIAD,ODEMETUR,BANKADBSKOD,SHELLVADE1,SHELLMUSTERIKOD,ONLINELIMIT,OFFLINELIMIT,CODE,DEFINITION_", conn);
            tblArama = new DataTable();
            adpArama.Fill(tblArama);
            this.grdCari.DataSource = tblArama;
            this.grdCari.DataBind();
            //this.grdCari.Columns[0].Visible = false;
        }
        else if (txtCariAd.Text != "")
        {
            adpArama = new SqlDataAdapter("SELECT CODE AS [CARİ KOD],DEFINITION_ AS [FİRMA ÜNVAN],Cast(REPLACE(ONLINELIMIT,',','.') As decimal(15,2)) + Cast(REPLACE(OFFLINELIMIT,',','.') As decimal(15,2)) AS [MÜŞTERİ LİMİT] ,ODEMETUR AS [ÖDEME TÜR],BANKADBSKOD AS [BANKA KODU],SHELLVADE1,TELEFON='',SHELLMUSTERIKOD AS [FİLO KODU] FROM LG_316_CLCARD CL LEFT OUTER JOIN AKTARIM.DBO.TTSPORTAL_CARIBILGI TC  ON CL.CODE=TC.CARIKOD WHERE ACTIVE=0 AND DEFINITION_ LIKE '%" + txtCariAd.Text + "%'  GROUP BY CARIKOD,CARIAD,ODEMETUR,BANKADBSKOD,SHELLVADE1,SHELLMUSTERIKOD,ONLINELIMIT,OFFLINELIMIT,CODE,DEFINITION_", conn);
            tblArama = new DataTable();
            adpArama.Fill(tblArama);
            this.grdCari.DataSource = tblArama;
            this.grdCari.DataBind();
            //this.grdCari.Columns[0].Visible = false;
        }
        else
        {
            conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
            adpCari = new SqlDataAdapter("SELECT CODE AS [CARİ KOD],DEFINITION_ AS [FİRMA ÜNVAN],Cast(REPLACE(ONLINELIMIT,',','.') As decimal(15,2)) + Cast(REPLACE(OFFLINELIMIT,',','.') As decimal(15,2)) AS [MÜŞTERİ LİMİT] ,ODEMETUR AS [ÖDEME TÜR],BANKADBSKOD AS [BANKA KODU],SHELLVADE1,TELEFON='',SHELLMUSTERIKOD AS [FİLO KODU] FROM LG_316_CLCARD CL LEFT OUTER JOIN AKTARIM.DBO.TTSPORTAL_CARIBILGI TC  ON CL.CODE=TC.CARIKOD WHERE ACTIVE=0 AND CODE LIKE '120%' OR ACTIVE=0 AND CODE LIKE '320%'  GROUP BY CARIKOD,CARIAD,ODEMETUR,BANKADBSKOD,SHELLVADE1,SHELLMUSTERIKOD,ONLINELIMIT,OFFLINELIMIT,CODE,DEFINITION_", conn);
            tblCari = new DataTable();
            adpCari.Fill(tblCari);
            this.grdCari.DataSource = tblCari;
            this.grdCari.DataBind();
            //this.grdCari.Columns[0].Visible = false;
        }
    }
    protected void grdCari_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow gvRow = grdCari.Rows[index];
        int rowIndex = index;
        string cariAd = HttpUtility.HtmlDecode(grdCari.Rows[rowIndex].Cells[2].Text.ToString());
        string cariRef = grdCari.Rows[rowIndex].Cells[1].Text;
        Session["CariRef"] = cariRef.ToString();
        Session["CariAd"] = cariAd;



        SqlDataAdapter adpPlaka = new SqlDataAdapter("SELECT PLAKA,DURUM FROM AKTARIM.DBO.BS_PLAKA WHERE CARIKOD='" + cariRef.ToString() + "' AND DURUM='AKTİF'", conn);
        tblPlaka = new DataTable();
        adpPlaka.Fill(tblPlaka);
        this.grdPlaka.DataSource = tblPlaka;
        this.grdPlaka.DataBind();

        SqlDataAdapter adpPlakaPasif = new SqlDataAdapter("SELECT PLAKA,DURUM FROM AKTARIM.DBO.BS_PLAKA WHERE CARIKOD='" + cariRef.ToString() + "' AND DURUM<>'AKTİF'", conn);
        tblPlakaPasif = new DataTable();
        adpPlakaPasif.Fill(tblPlakaPasif);
        this.grdPlakaPasif.DataSource = tblPlakaPasif;
        this.grdPlakaPasif.DataBind();



        #region ana bayi bilgileri geliyor
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        SqlCommand cmdBilgi = new SqlCommand("SELECT BAYIKOD,KULLANICI,PAROLA FROM TTSSIFRE", connBizim);
        if (connBizim.State == ConnectionState.Closed)
        { connBizim.Open(); }
        SqlDataReader rdrBilgi = cmdBilgi.ExecuteReader();
        while (rdrBilgi.Read())
        {
            Session["bayi"] = rdrBilgi[0].ToString();
            Session["kullanici"] = rdrBilgi[1].ToString();
            Session["parola"] = rdrBilgi[2].ToString();
        }
        if (connBizim.State == ConnectionState.Open)
        { connBizim.Close(); }
        #endregion
        #region shell musterikod geliyor
        SqlDataAdapter adpMusteriKod = new SqlDataAdapter("SELECT SHELLMUSTERIKOD FROM TTSPORTAL_CARIBILGI WHERE CARIKOD='" + cariRef.ToString() + "'", connBizim);
        DataTable tblMusteriKod = new DataTable();
        adpMusteriKod.Fill(tblMusteriKod);
        Session["shellMusteriKod"] = tblMusteriKod.Rows[0][0].ToString();
        #endregion



        //chkOlustur();

    }
    protected void grdCari_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdCari_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void chkHeader_CheckedChanged(object sender, EventArgs e)
    {

        bool secim = ((CheckBox)grdPlaka.HeaderRow.FindControl("chkHeader")).Checked;
        for (int i = 0; i < grdPlaka.Rows.Count; i++)
        {
            if (secim == true)
            {
                ((CheckBox)grdPlaka.Rows[i].FindControl("chkSecim")).Checked = true;
            }
            else
            {
                ((CheckBox)grdPlaka.Rows[i].FindControl("chkSecim")).Checked = false;
            }
        }
    } 
    protected void chkHeaderPasif_CheckedChanged(object sender, EventArgs e)
    {

        bool secim = ((CheckBox)grdPlakaPasif.HeaderRow.FindControl("chkHeaderPasif")).Checked;
        for (int i = 0; i < grdPlakaPasif.Rows.Count; i++)
        {
            if (secim == true)
            {
                ((CheckBox)grdPlakaPasif.Rows[i].FindControl("chkSecimPasif")).Checked = true;
            }
            else
            {
                ((CheckBox)grdPlakaPasif.Rows[i].FindControl("chkSecimPasif")).Checked = false;
            }
        }
    }
    protected void btnAc_Click(object sender, EventArgs e)
    {
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        for (int i = 0; i < grdPlaka.Rows.Count; i++)
        {
            if (((CheckBox)grdPlaka.Rows[i].FindControl("chkSecim")).Checked == true)
            {
                var musterikod = Session["shellMusteriKod"].ToString();
                tts.TTSWebServicesSoapClient yakitKapama = new tts.TTSWebServicesSoapClient();
                tts.SETCARDSTATUSRESULT pro = yakitKapama.SetPlateStatus(Session["bayi"].ToString(), Session["kullanici"].ToString(), Session["parola"].ToString(), Session["shellMusteriKod"].ToString(), grdPlaka.Rows[i].Cells[1].Text.ToString(), "1", "", "");
                if (pro.PROCESSRESULT.Success == true)
                {
                    SqlCommand cmdPlakaDurumGuncelle = new SqlCommand("UPDATE BS_PLAKA SET DURUM='AKTİF' WHERE PLAKA='" + grdPlaka.Rows[i].Cells[1].Text.ToString() + "'", connBizim);
                    if (connBizim.State == ConnectionState.Closed)
                    {
                        connBizim.Open();
                    }
                    cmdPlakaDurumGuncelle.ExecuteNonQuery();
                    if (connBizim.State == ConnectionState.Open)
                    {
                        connBizim.Close();
                    }
                }
                else
                {
                    var mesaj = pro.PROCESSRESULT.Message.ToString();
                }
            }
        }

        for (int i = 0; i < grdPlakaPasif.Rows.Count; i++)
        {
            if (((CheckBox)grdPlakaPasif.Rows[i].FindControl("chkSecimPasif")).Checked == true)
            {
                tts.TTSWebServicesSoapClient yakitKapama = new tts.TTSWebServicesSoapClient();
                tts.SETCARDSTATUSRESULT pro = yakitKapama.SetPlateStatus(Session["bayi"].ToString(), Session["kullanici"].ToString(), Session["parola"].ToString(), Session["shellMusteriKod"].ToString(), grdPlakaPasif.Rows[i].Cells[1].Text.ToString(), "1", "", "11111111111111111111");
                if (pro.PROCESSRESULT.Success == true)
                {
                    SqlCommand cmdPlakaDurumGuncelle = new SqlCommand("UPDATE BS_PLAKA SET DURUM='AKTİF' WHERE PLAKA='" + grdPlakaPasif.Rows[i].Cells[1].Text.ToString() + "'", connBizim);
                    if (connBizim.State == ConnectionState.Closed)
                    {
                        connBizim.Open();
                    }
                    cmdPlakaDurumGuncelle.ExecuteNonQuery();
                    if (connBizim.State == ConnectionState.Open)
                    {
                        connBizim.Close();
                    }
                }
                else
                {

                }
            }
        }



    }
    protected void btnKapat_Click(object sender, EventArgs e)
    {
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        for (int i = 0; i < grdPlaka.Rows.Count; i++)
        {
            if (((CheckBox)grdPlaka.Rows[i].FindControl("chkSecim")).Checked == true)
            {
                tts.TTSWebServicesSoapClient yakitKapama = new tts.TTSWebServicesSoapClient();
                tts.SETCARDSTATUSRESULT pro = yakitKapama.SetPlateStatus(Session["bayi"].ToString(), Session["kullanici"].ToString(), Session["parola"].ToString(), Session["shellMusteriKod"].ToString(), grdPlaka.Rows[i].Cells[1].Text.ToString(), "2", "10", "11111111111111111111");
                if (pro.PROCESSRESULT.Success == true)
                {
                    SqlCommand cmdPlakaDurumGuncelle = new SqlCommand("UPDATE BS_PLAKA SET DURUM='PASİF' WHERE PLAKA='" + grdPlaka.Rows[i].Cells[1].Text.ToString() + "'", connBizim);
                    if (connBizim.State == ConnectionState.Closed)
                    {
                        connBizim.Open();
                    }
                    cmdPlakaDurumGuncelle.ExecuteNonQuery();
                    if (connBizim.State == ConnectionState.Open)
                    {
                        connBizim.Close();
                    }
                }
                else
                {

                }
            }
        }
        for (int i = 0; i < grdPlakaPasif.Rows.Count; i++)
        {
            if (((CheckBox)grdPlakaPasif.Rows[i].FindControl("chkSecimPasif")).Checked == true)
            {
                tts.TTSWebServicesSoapClient yakitKapama = new tts.TTSWebServicesSoapClient();
                tts.SETCARDSTATUSRESULT pro = yakitKapama.SetPlateStatus(Session["bayi"].ToString(), Session["kullanici"].ToString(), Session["parola"].ToString(), Session["shellMusteriKod"].ToString(), grdPlakaPasif.Rows[i].Cells[1].Text.ToString(), "2", "10", "11111111111111111111");
                if (pro.PROCESSRESULT.Success == true)
                {
                    SqlCommand cmdPlakaDurumGuncelle = new SqlCommand("UPDATE BS_PLAKA SET DURUM='PASİF' WHERE PLAKA='" + grdPlakaPasif.Rows[i].Cells[1].Text.ToString() + "'", connBizim);
                    if (connBizim.State == ConnectionState.Closed)
                    {
                        connBizim.Open();
                    }
                    cmdPlakaDurumGuncelle.ExecuteNonQuery();
                    if (connBizim.State == ConnectionState.Open)
                    {
                        connBizim.Close();
                    }
                }
                else
                {

                }
            }
        }
    }
}