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
using System.ComponentModel;
using System.Drawing;




public partial class YeniTahsilat : System.Web.UI.Page
{
    SqlConnection connBizim,conn;
    SqlDataAdapter adpCari,adpVeri;
    System.Data.DataTable tblCari,tblVeri;
    string FirmaUnvani,a,b,YeniVade;
    string navigateURL;
    int indexOfColumn = 1;
    int indexOfColumn1 = 2;
    int indexOfColum0 = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        
    }
    public void btnArama_Click(object sender, EventArgs e)
    {

        VeriGetir(txtCariAd.Text);
    }

    public void btnSorgula_Click(object sender, EventArgs e)
    {

        VeriGel();
    }
    private void VeriGel ()
        {
        SqlDataAdapter adpVeri = new SqlDataAdapter("SELECT CL.CODE,CL.DEFINITION_ AS [CARİ ÜNVAN],YT.VADE,[FATURA TARİHİ]=CONVERT(varchar(10), YT.TARIH, 104),[ORJİNAL VADE] = convert(varchar(10), (DATEADD(DAY, CAST(YT.VADE AS INT), YT.TARIH)), 104),[FATURA TUTARI] = CAST(YT.FATURATUTAR as DECIMAL(15, 2)),[KALAN TUTAR] = CAST((CASE WHEN YT.KALANTUTAR > 0 THEN YT.FATURATUTAR ELSE YT.FATURATUTAR - YT.KALANTUTAR * -1 END) as DECIMAL(15, 2)),[ÖDEME TÜR]=(SELECT TCG.ODEMETUR where TCG.CARIKOD=CODE),[YENİ VADE] = (SELECT TARIH FROM[AKTARIM].dbo.YENI_VADE WHERE CARIKOD = CL.CODE),[VADE GÜN]=CASE WHEN(SELECT TARIH FROM[AKTARIM].dbo.YENI_VADE WHERE CARIKOD= CL.CODE) IS NULL THEN(DATEDIFF(day, (DATEADD(DAY, CAST(YT.VADE AS INT),YT.TARIH)),GETDATE())) ELSE(DATEDIFF(day, (DATEADD(DAY, CAST(YT.VADE AS INT),(SELECT TARIH FROM[AKTARIM].dbo.YENI_VADE WHERE CARIKOD=CL.CODE))),GETDATE())) END,[BAKİYE]=YT.BAKIYE,[AÇIKLAMA]=(SELECT ACIKLAMA FROM[AKTARIM].dbo.YENI_TAHSILAT_ACIKLAMA WHERE CARIKOD=YT.CARIKOD) FROM[AKTARIM].dbo.YENI_TAHSILAT YT LEFT OUTER JOIN LG_316_CLCARD CL ON CL.CODE=YT.CARIKOD LEFT OUTER JOIN[AKTARIM].dbo.TTSPORTAL_CARIBILGI TCG ON TCG.CARIKOD=YT.CARIKOD where YT.TARIH<>'' AND YT.BAKIYE<>'0' AND YT.VADE IS NOT NULL AND YT.VADE NOT IN ('TAKİP','AVUKA','AV.','NULL')  ", conn);
        DataTable tblVeri = new DataTable();
        adpVeri.Fill(tblVeri);
       grdVeri.DataSource = tblVeri;
        grdVeri.DataBind();
        ViewState["dirState"] = tblVeri;
        ViewState["sortdr"] = "Asc";
        

        for (int i = 0; i < grdVeri.Rows.Count - 1; i++)
        {
            string Vadegun = grdVeri.Rows[i].Cells[10].Text.ToString();
            grdVeri.Rows[i].Cells[10].Text = Vadegun;
            string YeniVade = grdVeri.Rows[i].Cells[2].Text.ToString();
            grdVeri.Rows[i].Cells[2].Text = YeniVade;


            if (Convert.ToDouble(Vadegun) > 1)
            {
                grdVeri.Rows[i].BackColor = Color.Orange;
            }
            if (Convert.ToDouble(Vadegun) > 60)
            {
                grdVeri.Rows[i].BackColor = Color.OrangeRed;
            }
           if (Convert.ToDouble(Vadegun) > 150)
            {
                grdVeri.Rows[i].BackColor = Color.Red;
            }
        }


    }

    public void btnKaydet_Click(object sender, EventArgs e)
    {
        #region eski kayıtlar kontrol ediliyor

        SqlDataAdapter adpYeniVade = new SqlDataAdapter("SELECT * FROM YENI_VADE WHERE CARIKOD='" + Session["Kod"].ToString() + "'", connBizim);
        System.Data.DataTable tblYeniVade = new System.Data.DataTable();
        adpYeniVade.Fill(tblYeniVade);
        #endregion
        if (tblYeniVade.Rows.Count == 0)
        {
            #region yeni kayıt giriliyor
            SqlCommand cmdYeniVade = new SqlCommand("INSERT INTO YENI_VADE (CARIKOD,TARIH) VALUES (@CARIKOD,@TARIH)",connBizim);
            cmdYeniVade.Parameters.AddWithValue("@CARIKOD", Session["Kod"].ToString());
            cmdYeniVade.Parameters.AddWithValue("@TARIH", Convert.ToDateTime(txtToDate.Text));
            if (connBizim.State == ConnectionState.Closed)
            {
                connBizim.Open();
            }
            cmdYeniVade.ExecuteNonQuery();
            if (connBizim.State == ConnectionState.Open)
            {
                connBizim.Close();
            }
            #endregion
        }
        else
        {
            #region kayıt güncelleniyor
            SqlCommand cmdYeniVadeGuncelle = new SqlCommand("UPDATE YENI_VADE SET TARIH=@TARIH WHERE CARIKOD='" + Session["Kod"].ToString() + "'", connBizim);
            cmdYeniVadeGuncelle.Parameters.AddWithValue("@TARIH", Convert.ToDateTime(txtToDate.Text));
            if (connBizim.State == ConnectionState.Closed)
            {
                connBizim.Open();
            }
            cmdYeniVadeGuncelle.ExecuteNonQuery();
            if (connBizim.State == ConnectionState.Open)
            {
                connBizim.Close();
            }
            #endregion
        }
        VeriGel();
    }
    public void VeriGetir(string cariAd)
    {
        #region veriler çekiliyor
        SqlDataAdapter adpVeri = new SqlDataAdapter("SELECT CL.CODE,CL.DEFINITION_ AS [CARİ ÜNVAN],YT.VADE,[FATURA TARİHİ]=CONVERT(varchar(10), YT.TARIH, 104),[ORJİNAL VADE] = convert(varchar(10), (DATEADD(DAY, CAST(YT.VADE AS INT), YT.TARIH)), 104),[FATURA TUTARI] = CAST(YT.FATURATUTAR as DECIMAL(15, 2)),[KALAN TUTAR] = CAST((CASE WHEN YT.KALANTUTAR > 0 THEN YT.FATURATUTAR ELSE YT.FATURATUTAR - YT.KALANTUTAR * -1 END) as DECIMAL(15, 2)),[ÖDEME TÜR]=(SELECT TCG.ODEMETUR where TCG.CARIKOD=CODE), [YENİ VADE] = (SELECT TARIH FROM[AKTARIM].dbo.YENI_VADE WHERE CARIKOD = CL.CODE),[VADE GÜN]=CASE WHEN(SELECT TARIH FROM[AKTARIM].dbo.YENI_VADE WHERE CARIKOD= CL.CODE) IS NULL THEN(DATEDIFF(day, (DATEADD(DAY, CAST(YT.VADE AS INT),YT.TARIH)),GETDATE())) ELSE(DATEDIFF(day, (DATEADD(DAY, CAST(YT.VADE AS INT),(SELECT TARIH FROM[AKTARIM].dbo.YENI_VADE WHERE CARIKOD=CL.CODE))),GETDATE())) END,[BAKİYE]=YT.BAKIYE,[AÇIKLAMA]=(SELECT ACIKLAMA FROM[AKTARIM].dbo.YENI_TAHSILAT_ACIKLAMA WHERE CARIKOD=YT.CARIKOD) FROM[AKTARIM].dbo.YENI_TAHSILAT YT LEFT OUTER JOIN LG_316_CLCARD CL ON CL.CODE=YT.CARIKOD LEFT OUTER JOIN[AKTARIM].dbo.TTSPORTAL_CARIBILGI TCG ON TCG.CARIKOD=YT.CARIKOD where YT.TARIH<>'' AND YT.BAKIYE<>'0' AND YT.VADE IS NOT NULL AND YT.VADE NOT IN ('TAKİP','AVUKA','AV.','NULL')AND CL.DEFINITION_ LIKE '%" + txtCariAd.Text + "%'", conn);

        DataTable tblVeri = new DataTable();
        adpVeri.Fill(tblVeri);
        this.grdVeri.DataSource = tblVeri;
        this.grdVeri.DataBind();
        ViewState["dirState"] = tblVeri;
        ViewState["sortdr"] = "Asc";
        


        //for (int i = 0; i < grdVeri.Rows.Count - 1; i++)
        //{
        //    grdVeri.Rows[i].Cells[6].Style.Format = String.Format("N2");
        //    grdVeri.Rows[i].Cells[7].Style.Format = String.Format("N2");
        //    grdVeri.Rows[i].Cells[10].Style.Format = String.Format("N2");
        //}

        #endregion
        for (int i = 0; i < grdVeri.Rows.Count - 1; i++)
        {
            string Vadegun = grdVeri.Rows[i].Cells[10].Text.ToString();
            grdVeri.Rows[i].Cells[10].Text = Vadegun;
            string YeniVade = grdVeri.Rows[i].Cells[2].Text.ToString();
            grdVeri.Rows[i].Cells[2].Text = YeniVade;


            if (Convert.ToDouble(Vadegun) > 1)
            {
                grdVeri.Rows[i].BackColor = Color.Orange;
            }
            if (Convert.ToDouble(Vadegun) > 60)
            {
                grdVeri.Rows[i].BackColor = Color.OrangeRed;
            }
            if (Convert.ToDouble(Vadegun) > 150)
            {
                grdVeri.Rows[i].BackColor = Color.Red;
            }
        }
    }

   

   

    public void btnGuncelle_Click(object sender, EventArgs e)
    {
        #region vade ayarlanıyor
        SqlCommand cmdVadeSil = new SqlCommand("DELETE FROM AKTARIM..YENI_VADE WHERE CARIKOD IN (SELECT CARIKOD FROM AKTARIM..YENI_TAHSILAT WHERE BAKIYE<20)", connBizim);
        if (connBizim.State == ConnectionState.Closed)
        {
            connBizim.Open();
        }
        cmdVadeSil.ExecuteNonQuery();
        if (connBizim.State == ConnectionState.Open)
        {
            connBizim.Close();
        }
        #endregion

        #region cariler çekiliyor
        adpCari = new SqlDataAdapter("SELECT CL.CODE FROM LG_316_01_INVOICE INV LEFT OUTER JOIN LG_316_CLCARD CL ON CL.LOGICALREF=INV.CLIENTREF WHERE INV.BRANCH=120 AND TRCODE=7  AND CL.ACTIVE=0 AND CL.CODE NOT LIKE '335%' AND CL.CODE <>'120.00.02.1.0372' GROUP BY CL.CODE", conn);
        tblCari = new System.Data.DataTable();
        adpCari.Fill(tblCari);
        #endregion

        #region tablo boşaltılıyor

        SqlCommand cmdTabloSil = new SqlCommand("DELETE FROM YENI_TAHSILAT", connBizim);
        if (connBizim.State == ConnectionState.Closed)
        {
            connBizim.Open();
        }
        cmdTabloSil.ExecuteNonQuery();


        if (connBizim.State == ConnectionState.Open)
        {
            connBizim.Close();
        }

        #endregion

        #region tabloya veri dolduruluyor
        for (int i = 0; i < tblCari.Rows.Count; i++)
        {
            SqlCommand cmdSorgu = new SqlCommand();
            cmdSorgu.Connection = conn;
            cmdSorgu.CommandTimeout = 1800000000;
            cmdSorgu.CommandText = "YENI_TAHSILAT";
            cmdSorgu.Parameters.AddWithValue("@CARIKOD", tblCari.Rows[i][0].ToString());

            cmdSorgu.CommandType = CommandType.StoredProcedure;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            cmdSorgu.ExecuteReader();
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }


            //SqlDataAdapter adpFirmaKarDiger = new SqlDataAdapter();
            //adpFirmaKarDiger.SelectCommand = cmdSorgu;
            //System.Data.DataTable tblFirmaKarDiger = new System.Data.DataTable();
            //adpFirmaKarDiger.Fill(tblFirmaKarDiger);
        }

        #endregion


       VeriGel();
    }
    
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Hilmi Beken Tahsilat Raporu" + DateTime.Now.ToString("yyyy-MM-ddhh:mm:ss") + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        this.EnableViewState = false;
        System.IO.StringWriter sw = new System.IO.StringWriter();
        Encoding.GetEncoding(1254).GetBytes(sw.ToString());
        Response.Charset = "";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1254");
        System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
        GridView dgGrid = new GridView();
        dgGrid.RowDataBound += new GridViewRowEventHandler(grdVeri_RowDataBound);
        dgGrid.DataBind();

        Response.Write(" <meta http-equiv='Content-Type' content='text/html; charset=windows-1254' />" + sw.ToString());
        grdVeri.AllowPaging = false;
        //grdSorgu.DataBind();
        //Başlık rowlarının arka planını beyaz olarak ayarlıyoruz. 
        grdVeri.HeaderRow.Style.Add("background-color", "#92b5d4");
        //Şimdide hücre başlıklarının arka planını yeşil yapıyoruz 
        for (int i = 0; i < grdVeri.Rows.Count; i++)
        {
            GridViewRow row = grdVeri.Rows[i];
            //Arka plan rengini beyaz olarak ayarlıyoruz 
            //Her row’un text özelliğine bir class atıyoruz 
            row.Attributes.Add("class", "textmode");
            //Biraz daha güzellik katmak için 2. Row’ların arka planlarına farklı bir renk veriyoruz 
          
        }
        grdVeri.RenderBeginTag(htw);
        grdVeri.HeaderRow.RenderControl(htw);
        foreach (GridViewRow row in grdVeri.Rows)
        {
            row.RenderControl(htw);
        }
        grdVeri.FooterRow.RenderControl(htw);
        grdVeri.RenderEndTag(htw);

        //Sayısal formatların bozuk çıkmaması için format belirliyoruz 
        string style = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\n<head>\n<title></title>\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=windows-1254\" />\n<style>\n</style>\n</head>\n<body>\n";
        
        Response.Write(style);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }


    
    protected void grdVeri_Sorting(object sender, GridViewSortEventArgs e)
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
            grdVeri.DataSource = dtrslt;
            grdVeri.DataBind();


        }
        for (int i = 0; i < grdVeri.Rows.Count - 1; i++)
        {
            string Vadegun = grdVeri.Rows[i].Cells[10].Text.ToString();
            grdVeri.Rows[i].Cells[10].Text = Vadegun;


            if (Convert.ToDouble(Vadegun) > 1)
            {
                grdVeri.Rows[i].BackColor = Color.Orange;
            }
            if (Convert.ToDouble(Vadegun) > 60)
            {
                grdVeri.Rows[i].BackColor = Color.OrangeRed;
            }
            if (Convert.ToDouble(Vadegun) > 150)
            {
                grdVeri.Rows[i].BackColor = Color.Red;
            }
        }
    }



    protected void grdVeri_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow row in this.grdVeri.Rows)
        {
           
 
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
                var a = row.Cells[10].Text;
               
                e.Row.Cells[9].Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(grdVeri, "Select$" + e.Row.RowIndex);
            e.Row.ToolTip = "Bu satırı seçmek için tıklayın.";
        }
    }


        if (e.Row.Cells.Count > indexOfColumn)
        {
            e.Row.Cells[indexOfColumn].Visible = false;
        }
        if (e.Row.Cells.Count > indexOfColumn1)
        {
            e.Row.Cells[indexOfColumn1].Width = 80;
            e.Row.Cells[indexOfColumn1].Height = 40;
        }
    }
    protected void grdVeri_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }

    protected void grdVeri_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        
        int index;
        bool bIsConverted = Int32.TryParse(e.CommandArgument.ToString(), out index);
        GridViewRow gvRow = grdVeri.Rows[index];
        int rowIndex = index;
        string cariAd = HttpUtility.HtmlDecode(grdVeri.Rows[rowIndex].Cells[2].Text.ToString());
        //string cariRef = grdVeri.Rows[rowIndex].Cells[4].Text;

        #region cari kod bulunuyor
        SqlDataAdapter adpCariKod = new SqlDataAdapter("SELECT CODE FROM LG_316_CLCARD WHERE DEFINITION_='" + cariAd + "'", conn);
        DataTable tblCariKod = new DataTable();
        adpCariKod.Fill(tblCariKod);
        #endregion
         Session["CariAd"] = cariAd;
        Session["CariKod"] = tblCariKod.Rows[0][0].ToString();
        Session["CariRef"] = tblCariKod.Rows[0][0].ToString();


        if (e.CommandName == "CARİ DETAY")
        {
            navigateURL = "CariGenelBilgiler.aspx";


            string target = "_blank";
            string windowProperties = "status=0, menubar=0, toolbar=0";
            string scriptText = "window.open('" + navigateURL + "','" + target + "')";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "eşsizAnahtar", scriptText, true);
            tblCariKod.Rows.Clear();
        }
    }


    protected void grdVeri_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = grdVeri.SelectedRow;
        string a = row.Cells[1].Text;
        string b = row.Cells[7].Text;
        Session["Kod"] = grdVeri.SelectedRow.Cells[1].Text;

    }
    private void txtCariAd_TextChanged(object sender, EventArgs e)
    {
        VeriGetir(txtCariAd.Text);
    }

}
