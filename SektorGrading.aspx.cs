using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class SektorGrading : System.Web.UI.Page
{

    SqlConnection connBizim;
    DataTable tblSektor,tblSektor1,tblSektor2,tblSektor11;
    SqlDataAdapter adpSektor, adpVeri,adpVeri1,adpVeri2;
    int sayi;
    string navigateURL;

    protected void Page_Load(object sender, EventArgs e)
    {
      
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        if (!IsPostBack)
        {
            SqlDataAdapter adpSektor = new SqlDataAdapter("SELECT FIRMA_SEKTOR FROM SEKTOR", connBizim);
            System.Data.DataTable tblSektor11 = new System.Data.DataTable();
            adpSektor.Fill(tblSektor11);
            for (int i = 0; i < tblSektor11.Rows.Count; i++)
            {
                dpSektor.Items.Add(tblSektor11.Rows[i][0].ToString());
            }
           
        }
       
        

    }
    protected void btnSorgula_Click(object sender, EventArgs e)
    {

        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        SqlDataAdapter adpVeri = new SqlDataAdapter("SELECT SEKTOR AS [SEKTÖR],CARIAD AS [ FİRMA],ANABAYIKOD AS [BAYİ KODU],TAAHHUTLITRE AS [TAAHHÜT LİTRE],TEMINATTUR AS [TEMİNAT TÜR],TEMINATTUTAR AS[TEMİNAT TUTAR], ONLINELIMIT AS[ONLİNE LİMİT], ODEMETUR AS[ÖDEME TÜR],[SÖZLEŞME BAŞLANGIÇ]=CONVERT(varchar(10), SOZLESMEBASLANGIC, 104),[SÖZLEŞME BİTİŞ]=CONVERT(varchar(10), SOZLESMEBITIS, 104), SATISPERSONEL AS[SATIŞ PERSONEL] FROM TTSPORTAL_CARIBILGI  WHERE SEKTOR =  '" + dpSektor.SelectedValue + "' ORDER BY SOZLESMEBITIS DESC", connBizim);
        DataTable tblSektor = new DataTable();
        adpVeri.Fill(tblSektor);
        this.grdSek.DataSource = tblSektor;
        this.grdSek.DataBind();

    }
    protected void btnSorgula1_Click(object sender, EventArgs e)
    {
         
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        SqlDataAdapter adpVeri = new SqlDataAdapter("SELECT distinct   [SEKTÖR]=TC.SEKTOR,[FİRMA]=TC.CARIAD, TC.TEMINATTUTAR AS [TEMİNAT TUTAR],TC.ANABAYIKOD AS [ANA BAYİ KOD],[TEMİNAT TÜRÜ] = TC.TEMINATTUR,[KÂR] = CAST((SELECT ISNULL(SUM(BK.KAR), 0) FROM[AKTARIM].dbo.BS_KARLILIK BK WHERE BK.CARIKOD = TC.CARIKOD) as decimal(10, 2)) FROM TTSPORTAL_CARIBILGI TC LEFT OUTER JOIN BS_KARLILIK BA ON TC.CARIKOD = BA.CARIKOD WHERE BA.TARIH >= '2017-01-01' GROUP BY TC.SEKTOR,TC.CARIAD,TC.TEMINATTUR,TC.CARIKOD,TARIH,TC.TEMINATTUTAR,TC.ANABAYIKOD order by TC.SEKTOR DESC ", connBizim);
        DataTable tblSektor = new DataTable();
        adpVeri.Fill(tblSektor);
        this.grdSek.DataSource = tblSektor;
        this.grdSek.DataBind();
        //this.grdCari.Columns[0].Visible = false;
    }

    protected void btnArama_Click(object sender, EventArgs e)
    {

        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        SqlDataAdapter adpVeri = new SqlDataAdapter("SELECT SEKTOR AS [SEKTÖR],CARIAD AS [ FİRMA],ANABAYIKOD AS [BAYİ KODU],TAAHHUTLITRE AS [TAAHHÜT LİTRE],TEMINATTUR AS [TEMİNAT TÜR],TEMINATTUTAR AS[TEMİNAT TUTAR], ONLINELIMIT AS[ONLİNE LİMİT], ODEMETUR AS[ÖDEME TÜR],[SÖZLEŞME BAŞLANGIÇ]=CONVERT(varchar(10), SOZLESMEBASLANGIC, 104),[SÖZLEŞME BİTİŞ]=CONVERT(varchar(10), SOZLESMEBITIS, 104), SATISPERSONEL AS[SATIŞ PERSONEL] FROM TTSPORTAL_CARIBILGI WHERE  CARIAD LIKE '%" + txtCariAd.Text + "%'  ", connBizim);
        DataTable tblSektor = new DataTable();
        adpVeri.Fill(tblSektor);
        this.grdSek.DataSource = tblSektor;
        this.grdSek.DataBind();

    }
   
    protected void grdSek_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdSek_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdSek_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow gvRow = grdSek.Rows[index];
        int rowIndex = index;
        string cariAd = HttpUtility.HtmlDecode(grdSek.Rows[rowIndex].Cells[3].Text.ToString());

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
        string scriptText = "window.open('" + navigateURL + "','" + target + "')";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "eşsizAnahtar", scriptText, true);
        tblCariKod.Rows.Clear();
    }
    
}

