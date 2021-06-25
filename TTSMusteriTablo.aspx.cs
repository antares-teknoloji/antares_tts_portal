using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TTSMusteriTablo : System.Web.UI.Page
{
    SqlConnection conn,connBizim;
    SqlDataAdapter adpArama;
    SqlDataAdapter adpCari ,adpSebep,adpTakip,adpCariKod;
    DataTable tblCari,tblTakip,tblCariKod;
    DataTable tblArama;
    int sayi;
    string navigateURL;
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        if (!IsPostBack)
        {

        }
        
    }
    private void VeriCek()
    {
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);

        adpTakip = new SqlDataAdapter("SELECT DISTINCT TT.CARIAD as [FİRMA ÜNVAN],[SATIŞ PERSONEL] = TT.SATISPERSONEL,BK.ANABAYIKOD AS [ANA BAYİ KOD],[SHELL MOTORİN İÇ]=ISNULL(cast(TT.SHELLBIZIMMOTORIN AS varchar(4)) + '%',0) ,[SHELL MOTORİN DIŞ]=ISNULL(cast(TT.SHELLDIGERMOTORIN AS varchar(4)) + '%',0),[SHELL BENZİN İÇ]=ISNULL(cast(TT.SHELLBIZIMBENZIN AS varchar(4)) + '%',0) ,[SHELL BENZİN DIŞ]=ISNULL(cast(TT.SHELLDIGERBENZIN AS varchar(4)) + '%',0) ,[SÖZLEŞME BİTİŞ]=CONVERT(varchar(10),SOZLESMEBITIS, 104),[TONAJ TAAH.]=TT.TAAHHUTLITRE,[TONAJ REEL]=  CAST((SELECT ISNULL(SUM(BF.MIKTAR),0) FROM[AKTARIM].dbo.BS_FATURA BF LEFT OUTER JOIN[AKTARIM].dbo.TTSPORTAL_CARIBILGI TTC ON BF.CARIKOD=TTC.CARIAD WHERE BF.TARIH>='2020-01-01' AND BF.CARIKOD = TT.CARIKOD)/(1000) AS decimal (10, 2)),[VADE1]=TT.SHELLVADE1,[VADE2]=TT.SHELLVADE2,TT.SEKTOR AS [SEKTÖR] FROM[AKTARIM].dbo.TTSPORTAL_CARIBILGI TT LEFT OUTER JOIN[AKTARIM].dbo.BS_ATSKARLILIK BA ON TT.CARIKOD=BA.CARIKOD LEFT OUTER JOIN [AKTARIM].dbo.BS_KARLILIK BK ON TT.CARIKOD = BK.CARIKOD LEFT OUTER JOIN[AKTARIM].dbo.BS_FATURA BF ON TT.CARIKOD= BF.CARIKOD WHERE BK.TARIH>='2020-01-01'  AND (TT.CIKIS IN ('Yeniden Anlaşıldı') OR CIKIS IS NULL) GROUP BY TT.CARIAD, BK.ANABAYIKOD, TT.SATISPERSONEL, TT.SOZLESMEBITIS, BA.TARIH, BK.TARIH, BA.NETKAR,BK.KAR, TT.MUSTERIISTASYON, TT.SHELLBIZIMBENZIN, TT.SHELLBIZIMMOTORIN, TT.SHELLDIGERBENZIN,TT.SHELLDIGERMOTORIN, TT.LUKOILBIZIMBENZIN, TT.LUKOILBIZIMMOTORIN, TT.LUKOILDIGERBENZIN, TT.LUKOILDIGERMOTORIN,TT.TOTALBIZIMBENZIN, TT.TOTALBIZIMMOTORIN, TT.TOTALDIGERBENZIN, TT.TOTALDIGERMOTORIN, TT.TAAHHUTLITRE, TT.SHELLVADE1, TT.SHELLVADE2, BF.CARIKOD, TT.CARIKOD,TT.CIKIS ", conn);


        tblTakip = new DataTable();
        adpTakip.Fill(tblTakip);
        if (tblTakip.Rows.Count > 0)

        {

            grdCari.DataSource = tblTakip;

            grdCari.DataBind();

        }
        ViewState["dirState"] = tblTakip;
        ViewState["sortdr"] = "Asc";

    }
          
    protected void btnArama_Click(object sender, EventArgs e)
    {
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);

        adpTakip = new SqlDataAdapter("SELECT DISTINCT TT.CARIAD AS [FİRMA ÜNVAN],[SATIŞ PERSONEL] = TT.SATISPERSONEL,BK.ANABAYIKOD AS [ANA BAYİ KOD],[SHELL MOTORİN İÇ]=ISNULL(cast(TT.SHELLBIZIMMOTORIN AS varchar(4)) + '%',0) ,[SHELL MOTORİN DIŞ]=ISNULL(cast(TT.SHELLDIGERMOTORIN AS varchar(4)) + '%',0),[SHELL BENZİN İÇ]=ISNULL(cast(TT.SHELLBIZIMBENZIN AS varchar(4)) + '%',0) ,[SHELL BENZİN DIŞ]=ISNULL(cast(TT.SHELLDIGERBENZIN AS varchar(4)) + '%',0) ,[SÖZLEŞME BİTİŞ]=CONVERT(varchar(10),SOZLESMEBITIS, 104),[TONAJ TAAH.]=TT.TAAHHUTLITRE,[TONAJ REEL]=  CAST((SELECT ISNULL(SUM(BF.MIKTAR),0) FROM[AKTARIM].dbo.BS_FATURA BF LEFT OUTER JOIN[AKTARIM].dbo.TTSPORTAL_CARIBILGI TTC ON BF.CARIKOD=TTC.CARIAD WHERE BF.TARIH>='2020-01-01' AND BF.CARIKOD = TT.CARIKOD)/(1000) AS decimal (10, 2)),[VADE1]=TT.SHELLVADE1,[VADE2]=TT.SHELLVADE2 ,TT.SEKTOR AS [SEKTÖR] FROM[AKTARIM].dbo.TTSPORTAL_CARIBILGI TT LEFT OUTER JOIN[AKTARIM].dbo.BS_ATSKARLILIK BA ON TT.CARIKOD=BA.CARIKOD LEFT OUTER JOIN [AKTARIM].dbo.BS_KARLILIK BK ON TT.CARIKOD = BK.CARIKOD LEFT OUTER JOIN[AKTARIM].dbo.BS_FATURA BF ON TT.CARIKOD= BF.CARIKOD WHERE BK.TARIH>='2020-01-01'  AND (TT.CIKIS IN ('Yeniden Anlaşıldı') OR CIKIS IS NULL) GROUP BY TT.CARIAD, BK.ANABAYIKOD, TT.SATISPERSONEL, TT.SOZLESMEBITIS, BA.TARIH, BK.TARIH, BA.NETKAR,BK.KAR, TT.MUSTERIISTASYON, TT.SHELLBIZIMBENZIN, TT.SHELLBIZIMMOTORIN, TT.SHELLDIGERBENZIN,TT.SHELLDIGERMOTORIN, TT.LUKOILBIZIMBENZIN, TT.LUKOILBIZIMMOTORIN, TT.LUKOILDIGERBENZIN, TT.LUKOILDIGERMOTORIN,TT.TOTALBIZIMBENZIN, TT.TOTALBIZIMMOTORIN, TT.TOTALDIGERBENZIN, TT.TOTALDIGERMOTORIN, TT.TAAHHUTLITRE, TT.SHELLVADE1, TT.SHELLVADE2, BF.CARIKOD, TT.CARIKOD,TT.CIKIS,TT.SEKTOR ", conn);


        tblTakip = new DataTable();
        adpTakip.Fill(tblTakip);
        this.grdCari.DataSource = tblTakip;
        this.grdCari.DataBind();
        ViewState["dirState"] = tblTakip;
        ViewState["sortdr"] = "Asc";


        if (cmbSatisEleman.Text != "")
        {
            adpTakip = new SqlDataAdapter("SELECT DISTINCT TT.CARIAD AS [FİRMA ÜNVAN],[SATIŞ PERSONEL] = TT.SATISPERSONEL,BK.ANABAYIKOD AS [ANA BAYİ KOD],[SHELL MOTORİN İÇ]=ISNULL(cast(TT.SHELLBIZIMMOTORIN AS varchar(4)) + '%',0) ,[SHELL MOTORİN DIŞ]=ISNULL(cast(TT.SHELLDIGERMOTORIN AS varchar(4)) + '%',0),[SHELL BENZİN İÇ]=ISNULL(cast(TT.SHELLBIZIMBENZIN AS varchar(4)) + '%',0) ,[SHELL BENZİN DIŞ]=ISNULL(cast(TT.SHELLDIGERBENZIN AS varchar(4)) + '%',0) ,[SÖZLEŞME BİTİŞ]=CONVERT(varchar(10),SOZLESMEBITIS, 104),[TONAJ TAAH.]=TT.TAAHHUTLITRE,[TONAJ REEL]=  CAST((SELECT ISNULL(SUM(BF.MIKTAR),0) FROM[AKTARIM].dbo.BS_FATURA BF LEFT OUTER JOIN[AKTARIM].dbo.TTSPORTAL_CARIBILGI TTC ON BF.CARIKOD=TTC.CARIAD WHERE BF.TARIH>='2020-01-01' AND BF.CARIKOD = TT.CARIKOD)/(1000) AS decimal (10, 2)),[VADE1]=TT.SHELLVADE1,[VADE2]=TT.SHELLVADE2,TT.SEKTOR AS [SEKTÖR] FROM[AKTARIM].dbo.TTSPORTAL_CARIBILGI TT LEFT OUTER JOIN[AKTARIM].dbo.BS_ATSKARLILIK BA ON TT.CARIKOD=BA.CARIKOD LEFT OUTER JOIN [AKTARIM].dbo.BS_KARLILIK BK ON TT.CARIKOD = BK.CARIKOD LEFT OUTER JOIN[AKTARIM].dbo.BS_FATURA BF ON TT.CARIKOD= BF.CARIKOD WHERE BK.TARIH>='2020-01-01' AND (TT.CIKIS IN ('Yeniden Anlaşıldı') OR CIKIS IS NULL) and TT.SATISPERSONEL LIKE '%" + cmbSatisEleman.Text + "%'GROUP BY TT.CARIAD, BK.ANABAYIKOD, TT.SATISPERSONEL, TT.SOZLESMEBITIS, BA.TARIH, BK.TARIH, BA.NETKAR,BK.KAR, TT.MUSTERIISTASYON, TT.SHELLBIZIMBENZIN, TT.SHELLBIZIMMOTORIN, TT.SHELLDIGERBENZIN,TT.SHELLDIGERMOTORIN, TT.LUKOILBIZIMBENZIN, TT.LUKOILBIZIMMOTORIN, TT.LUKOILDIGERBENZIN, TT.LUKOILDIGERMOTORIN,TT.TOTALBIZIMBENZIN, TT.TOTALBIZIMMOTORIN, TT.TOTALDIGERBENZIN, TT.TOTALDIGERMOTORIN, TT.TAAHHUTLITRE, TT.SHELLVADE1, TT.SHELLVADE2, BF.CARIKOD, TT.CARIKOD,TT.CIKIS,TT.SEKTOR ", conn);


tblTakip = new DataTable();
            adpTakip.Fill(tblTakip);
            this.grdCari.DataSource = tblTakip;
            this.grdCari.DataBind();
            //this.grdCari.Columns[0].Visible = false;
            ViewState["dirState"] = tblTakip;
            ViewState["sortdr"] = "Asc";
        }
        else if(txtCariAd.Text != "")
        {
            adpTakip = new SqlDataAdapter("SELECT DISTINCT TT.CARIAD AS [FİRMA ÜNVAN],[SATIŞ PERSONEL] = TT.SATISPERSONEL,BK.ANABAYIKOD AS [ANA BAYİ KOD],[SHELL MOTORİN İÇ]=ISNULL(cast(TT.SHELLBIZIMMOTORIN AS varchar(4)) + '%',0) ,[SHELL MOTORİN DIŞ]=ISNULL(cast(TT.SHELLDIGERMOTORIN AS varchar(4)) + '%',0),[SHELL BENZİN İÇ]=ISNULL(cast(TT.SHELLBIZIMBENZIN AS varchar(4)) + '%',0) ,[SHELL BENZİN DIŞ]=ISNULL(cast(TT.SHELLDIGERBENZIN AS varchar(4)) + '%',0) ,[SÖZLEŞME BİTİŞ]=CONVERT(varchar(10),SOZLESMEBITIS, 104),[TONAJ TAAH.]=TT.TAAHHUTLITRE,[TONAJ REEL]=  CAST((SELECT ISNULL(SUM(BF.MIKTAR),0) FROM[AKTARIM].dbo.BS_FATURA BF LEFT OUTER JOIN[AKTARIM].dbo.TTSPORTAL_CARIBILGI TTC ON BF.CARIKOD=TTC.CARIAD WHERE BF.TARIH>='2020-01-01' AND BF.CARIKOD = TT.CARIKOD)/(1000) AS decimal (10, 2)),[VADE1]=TT.SHELLVADE1,[VADE2]=TT.SHELLVADE2,TT.SEKTOR AS [SEKTÖR] FROM[AKTARIM].dbo.TTSPORTAL_CARIBILGI TT LEFT OUTER JOIN[AKTARIM].dbo.BS_ATSKARLILIK BA ON TT.CARIKOD=BA.CARIKOD LEFT OUTER JOIN [AKTARIM].dbo.BS_KARLILIK BK ON TT.CARIKOD = BK.CARIKOD LEFT OUTER JOIN[AKTARIM].dbo.BS_FATURA BF ON TT.CARIKOD= BF.CARIKOD WHERE BK.TARIH>='2020-01-01' AND (TT.CIKIS IN ('Yeniden Anlaşıldı') OR CIKIS IS NULL) and TT.CARIAD LIKE '%" + txtCariAd.Text + "%'GROUP BY TT.CARIAD, BK.ANABAYIKOD, TT.SATISPERSONEL, TT.SOZLESMEBITIS, BA.TARIH, BK.TARIH, BA.NETKAR,BK.KAR, TT.MUSTERIISTASYON, TT.SHELLBIZIMBENZIN, TT.SHELLBIZIMMOTORIN, TT.SHELLDIGERBENZIN,TT.SHELLDIGERMOTORIN, TT.LUKOILBIZIMBENZIN, TT.LUKOILBIZIMMOTORIN, TT.LUKOILDIGERBENZIN, TT.LUKOILDIGERMOTORIN,TT.TOTALBIZIMBENZIN, TT.TOTALBIZIMMOTORIN, TT.TOTALDIGERBENZIN, TT.TOTALDIGERMOTORIN, TT.TAAHHUTLITRE, TT.SHELLVADE1, TT.SHELLVADE2, BF.CARIKOD, TT.CARIKOD,TT.CIKIS,TT.SEKTOR", conn);
            tblTakip = new DataTable();
            adpTakip.Fill(tblTakip);
            this.grdCari.DataSource = tblTakip;
            this.grdCari.DataBind();
            //this.grdCari.Columns[0].Visible = false;
            ViewState["dirState"] = tblTakip;
            ViewState["sortdr"] = "Asc";
        }       
    }
    protected void grdCari_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdCari_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdCari_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        

        int index;    
        bool bIsConverted = Int32.TryParse(e.CommandArgument.ToString(), out index );
        GridViewRow gvRow = grdCari.Rows[index];
        int rowIndex = index;
        string cariAd = HttpUtility.HtmlDecode(grdCari.Rows[rowIndex].Cells[2].Text.ToString());
       

        #region cari kod bulunuyor
        SqlDataAdapter adpCariKod = new SqlDataAdapter("select CARIKOD from TTSPORTAL_CARIBILGI WHERE CARIAD='" + cariAd + "'", connBizim);
        DataTable tblCariKod = new DataTable();
        adpCariKod.Fill(tblCariKod);
        #endregion

        Session["CariAd"] = cariAd;
        Session["CariKod"] = tblCariKod.Rows[0][0].ToString();
        Session["CariRef"] = tblCariKod.Rows[0][0].ToString();
        if (e.CommandName == "EKSTRE")
        {
            navigateURL = "CariEkstre.aspx";
        }
        else if (e.CommandName == "CARİ DETAY")
        {
            navigateURL = "CariGenelBilgiler.aspx";
        }

        string target = "_blank";
        string windowProperties = "status=0, menubar=0, toolbar=0";
        string scriptText = "window.open('" + navigateURL + "','" + target + "','" + windowProperties + "')";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "eşsizAnahtar", scriptText, true);
        


    }
    protected void btnTumsebep_Click(object sender, EventArgs e)
    {
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);

        adpTakip = new SqlDataAdapter("SELECT DISTINCT TT.CARIAD AS [FİRMA ÜNVAN],[SATIŞ PERSONEL] = TT.SATISPERSONEL,BK.ANABAYIKOD AS [ANA BAYİ KOD],[SHELL MOTORİN İÇ]=ISNULL(cast(TT.SHELLBIZIMMOTORIN AS varchar(4)) + '%',0) ,[SHELL MOTORİN DIŞ]=ISNULL(cast(TT.SHELLDIGERMOTORIN AS varchar(4)) + '%',0),[SHELL BENZİN İÇ]=ISNULL(cast(TT.SHELLBIZIMBENZIN AS varchar(4)) + '%',0) ,[SHELL BENZİN DIŞ]=ISNULL(cast(TT.SHELLDIGERBENZIN AS varchar(4)) + '%',0) ,[SÖZLEŞME BİTİŞ]=CONVERT(varchar(10),SOZLESMEBITIS, 104),[TONAJ TAAH.]=TT.TAAHHUTLITRE,[TONAJ REEL]=  CAST((SELECT ISNULL(SUM(BF.MIKTAR),0) FROM[AKTARIM].dbo.BS_FATURA BF LEFT OUTER JOIN[AKTARIM].dbo.TTSPORTAL_CARIBILGI TTC ON BF.CARIKOD=TTC.CARIAD WHERE BF.TARIH>='2020-01-01' AND BF.CARIKOD = TT.CARIKOD)/(1000) AS decimal (10, 2)),[VADE1]=TT.SHELLVADE1,[VADE2]=TT.SHELLVADE2,TT.SEKTOR AS [SEKTÖR],[ÇIKIŞ SEBEP]=TT.CIKIS FROM[AKTARIM].dbo.TTSPORTAL_CARIBILGI TT LEFT OUTER JOIN[AKTARIM].dbo.BS_ATSKARLILIK BA ON TT.CARIKOD=BA.CARIKOD LEFT OUTER JOIN [AKTARIM].dbo.BS_KARLILIK BK ON TT.CARIKOD = BK.CARIKOD LEFT OUTER JOIN[AKTARIM].dbo.BS_FATURA BF ON TT.CARIKOD= BF.CARIKOD WHERE BK.TARIH>='2020-01-01'  AND TT.CIKIS IN ('Yeni Ünvan Geçişi','Tahsilat Sorunu','Sözleşme Bitiş','İskonto Memnuniyetsizliği','Firma Tasviyesi')  GROUP BY TT.CARIAD, BK.ANABAYIKOD, TT.SATISPERSONEL, TT.SOZLESMEBITIS, BA.TARIH, BK.TARIH, BA.NETKAR,BK.KAR, TT.MUSTERIISTASYON, TT.SHELLBIZIMBENZIN, TT.SHELLBIZIMMOTORIN, TT.SHELLDIGERBENZIN,TT.SHELLDIGERMOTORIN, TT.LUKOILBIZIMBENZIN, TT.LUKOILBIZIMMOTORIN, TT.LUKOILDIGERBENZIN, TT.LUKOILDIGERMOTORIN,TT.TOTALBIZIMBENZIN, TT.TOTALBIZIMMOTORIN, TT.TOTALDIGERBENZIN, TT.TOTALDIGERMOTORIN, TT.TAAHHUTLITRE, TT.SHELLVADE1, TT.SHELLVADE2, BF.CARIKOD, TT.CARIKOD,TT.CIKIS ,TT.SEKTOR", conn);


        tblTakip = new DataTable();
        adpTakip.Fill(tblTakip);
        this.grdCari.DataSource = tblTakip;
        this.grdCari.DataBind();
        ViewState["dirState"] = tblTakip;
        ViewState["sortdr"] = "Asc";

        if (cmbSatisEleman.Text != "")
        {
            adpTakip = new SqlDataAdapter("SELECT DISTINCT TT.CARIAD AS [FİRMA ÜNVAN],[SATIŞ PERSONEL] = TT.SATISPERSONEL,BK.ANABAYIKOD AS [ANA BAYİ KOD],[SHELL MOTORİN İÇ]=ISNULL(cast(TT.SHELLBIZIMMOTORIN AS varchar(4)) + '%',0) ,[SHELL MOTORİN DIŞ]=ISNULL(cast(TT.SHELLDIGERMOTORIN AS varchar(4)) + '%',0),[SHELL BENZİN İÇ]=ISNULL(cast(TT.SHELLBIZIMBENZIN AS varchar(4)) + '%',0) ,[SHELL BENZİN DIŞ]=ISNULL(cast(TT.SHELLDIGERBENZIN AS varchar(4)) + '%',0) ,[SÖZLEŞME BİTİŞ]=CONVERT(varchar(10),SOZLESMEBITIS, 104),[TONAJ TAAH.]=TT.TAAHHUTLITRE,[TONAJ REEL]=  CAST((SELECT ISNULL(SUM(BF.MIKTAR),0) FROM[AKTARIM].dbo.BS_FATURA BF LEFT OUTER JOIN[AKTARIM].dbo.TTSPORTAL_CARIBILGI TTC ON BF.CARIKOD=TTC.CARIAD WHERE BF.TARIH>='2020-01-01' AND BF.CARIKOD = TT.CARIKOD)/(1000) AS decimal (10, 2)),[VADE1]=TT.SHELLVADE1,[VADE2]=TT.SHELLVADE2,TT.SEKTOR AS [SEKTÖR],[ÇIKIŞ SEBEP]=TT.CIKIS FROM[AKTARIM].dbo.TTSPORTAL_CARIBILGI TT LEFT OUTER JOIN[AKTARIM].dbo.BS_ATSKARLILIK BA ON TT.CARIKOD=BA.CARIKOD LEFT OUTER JOIN [AKTARIM].dbo.BS_KARLILIK BK ON TT.CARIKOD = BK.CARIKOD LEFT OUTER JOIN[AKTARIM].dbo.BS_FATURA BF ON TT.CARIKOD= BF.CARIKOD WHERE BK.TARIH>='2020-01-01' AND TT.CIKIS IN ('Yeni Ünvan Geçişi','Tahsilat Sorunu','Sözleşme Bitiş','İskonto Memnuniyetsizliği','Firma Tasviyesi') and TT.SATISPERSONEL LIKE '%" + cmbSatisEleman.Text + "%'GROUP BY TT.CARIAD, BK.ANABAYIKOD, TT.SATISPERSONEL, TT.SOZLESMEBITIS, BA.TARIH, BK.TARIH, BA.NETKAR,BK.KAR, TT.MUSTERIISTASYON, TT.SHELLBIZIMBENZIN, TT.SHELLBIZIMMOTORIN, TT.SHELLDIGERBENZIN,TT.SHELLDIGERMOTORIN, TT.LUKOILBIZIMBENZIN, TT.LUKOILBIZIMMOTORIN, TT.LUKOILDIGERBENZIN, TT.LUKOILDIGERMOTORIN,TT.TOTALBIZIMBENZIN, TT.TOTALBIZIMMOTORIN, TT.TOTALDIGERBENZIN, TT.TOTALDIGERMOTORIN, TT.TAAHHUTLITRE, TT.SHELLVADE1, TT.SHELLVADE2, BF.CARIKOD, TT.CARIKOD,TT.CIKIS,TT.SEKTOR ", conn);


            tblTakip= new DataTable();
            adpTakip.Fill(tblTakip);
            this.grdCari.DataSource = tblTakip;
            this.grdCari.DataBind();
            //this.grdCari.Columns[0].Visible = false;
            ViewState["dirState"] = tblTakip;
            ViewState["sortdr"] = "Asc";
        }
        else if (txtCariAd.Text != "")
        {
            adpTakip = new SqlDataAdapter("SELECT DISTINCT TT.CARIAD AS [FİRMA ÜNVAN],[SATIŞ PERSONEL] = TT.SATISPERSONEL,BK.ANABAYIKOD AS [ANA BAYİ KOD],[SHELL MOTORİN İÇ]=ISNULL(cast(TT.SHELLBIZIMMOTORIN AS varchar(4)) + '%',0) ,[SHELL MOTORİN DIŞ]=ISNULL(cast(TT.SHELLDIGERMOTORIN AS varchar(4)) + '%',0),[SHELL BENZİN İÇ]=ISNULL(cast(TT.SHELLBIZIMBENZIN AS varchar(4)) + '%',0) ,[SHELL BENZİN DIŞ]=ISNULL(cast(TT.SHELLDIGERBENZIN AS varchar(4)) + '%',0) ,[SÖZLEŞME BİTİŞ]=CONVERT(varchar(10),SOZLESMEBITIS, 104),[TONAJ TAAH.]=TT.TAAHHUTLITRE,[TONAJ REEL]=  CAST((SELECT ISNULL(SUM(BF.MIKTAR),0) FROM[AKTARIM].dbo.BS_FATURA BF LEFT OUTER JOIN[AKTARIM].dbo.TTSPORTAL_CARIBILGI TTC ON BF.CARIKOD=TTC.CARIAD WHERE BF.TARIH>='2020-01-01' AND BF.CARIKOD = TT.CARIKOD)/(1000) AS decimal (10, 2)),[VADE1]=TT.SHELLVADE1,[VADE2]=TT.SHELLVADE2,TT.SEKTOR AS [SEKTÖR],[ÇIKIŞ SEBEP]=TT.CIKIS FROM[AKTARIM].dbo.TTSPORTAL_CARIBILGI TT LEFT OUTER JOIN[AKTARIM].dbo.BS_ATSKARLILIK BA ON TT.CARIKOD=BA.CARIKOD LEFT OUTER JOIN [AKTARIM].dbo.BS_KARLILIK BK ON TT.CARIKOD = BK.CARIKOD LEFT OUTER JOIN[AKTARIM].dbo.BS_FATURA BF ON TT.CARIKOD= BF.CARIKOD WHERE BK.TARIH>='2020-01-01' AND TT.CIKIS IN ('Yeni Ünvan Geçişi','Tahsilat Sorunu','Sözleşme Bitiş','İskonto Memnuniyetsizliği','Firma Tasviyesi') and TT.CARIAD LIKE '%" + txtCariAd.Text + "%'GROUP BY TT.CARIAD, BK.ANABAYIKOD, TT.SATISPERSONEL, TT.SOZLESMEBITIS, BA.TARIH, BK.TARIH, BA.NETKAR,BK.KAR, TT.MUSTERIISTASYON, TT.SHELLBIZIMBENZIN, TT.SHELLBIZIMMOTORIN, TT.SHELLDIGERBENZIN,TT.SHELLDIGERMOTORIN, TT.LUKOILBIZIMBENZIN, TT.LUKOILBIZIMMOTORIN, TT.LUKOILDIGERBENZIN, TT.LUKOILDIGERMOTORIN,TT.TOTALBIZIMBENZIN, TT.TOTALBIZIMMOTORIN, TT.TOTALDIGERBENZIN, TT.TOTALDIGERMOTORIN, TT.TAAHHUTLITRE, TT.SHELLVADE1, TT.SHELLVADE2, BF.CARIKOD, TT.CARIKOD,TT.CIKIS,TT.SEKTOR", conn);
            tblTakip = new DataTable();
            adpTakip.Fill(tblTakip);
            this.grdCari.DataSource = tblTakip;
            this.grdCari.DataBind();
            //this.grdCari.Columns[0].Visible = false;
            ViewState["dirState"] = tblTakip;
            ViewState["sortdr"] = "Asc";
        }
    }
    protected void grdCari_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtrslt = (DataTable)ViewState["dirState"];
        if (dtrslt.Rows.Count > 0)
        {
            if (Convert.ToString(ViewState["sortdr"]) == "Asc")
            {
                dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                ViewState["sortdr"] = "Desc";
            }
            else
            {
                dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                ViewState["sortdr"] = "Asc";
            }
            grdCari.DataSource = dtrslt;
            grdCari.DataBind();

        }

    }
}
