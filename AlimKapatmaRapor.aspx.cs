using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
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

public partial class AlimKapatmaRapor : System.Web.UI.Page
{
    SqlConnection connBizim, conn;
    SqlDataAdapter adpVeri;
    DataTable tblVeri;
    System.Web.UI.WebControls.CheckBox c;
    System.Web.UI.WebControls.Label l;
    string musteriKod, bayi, kullanici, parola;
    int sayi;
    protected void Page_Load(object sender, EventArgs e)
    {
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        VeriGetir(); 
        #region ana bayi bilgileri geliyor
        SqlCommand cmdBilgi = new SqlCommand("SELECT BAYIKOD,KULLANICI,PAROLA FROM TTSSIFRE", connBizim);
        if (connBizim.State == ConnectionState.Closed)
        { connBizim.Open(); }
        SqlDataReader rdrBilgi = cmdBilgi.ExecuteReader();
        while (rdrBilgi.Read())
        {
            bayi = rdrBilgi[0].ToString();
            kullanici = rdrBilgi[1].ToString();
            parola = rdrBilgi[2].ToString();
        }
        if (connBizim.State == ConnectionState.Open)
        { connBizim.Close(); }
        #endregion
    }
    private void VeriGetir()
    {
        adpVeri = new SqlDataAdapter("SELECT [SEÇ]='',MUSTERIKOD,MUSTERIAD ,DBSOFFLINE,DBSONLINE,ROUND(KALANLIMIT,2) " +
            "AS [KALAN LİMİT],ALISLAR FROM RESELLER_LIMIT RL LEFT OUTER JOIN BEKEN2010.DBO.LG_316_CLCARD CL ON CL.CODE=RL.MUSTERIKOD " +
            "WHERE KAYITTARIH =CONVERT(DATETIME,'" + DateTime.Now.ToString().Substring(0, 10).TrimEnd().TrimStart() + "',104) AND KALANLIMIT<-50 AND CL.DBSLIMIT3<>1", connBizim);
        tblVeri = new DataTable();
        adpVeri.Fill(tblVeri);
        this.grdKapatilacak.DataSource = tblVeri;
        this.grdKapatilacak.DataBind();      
        chkOlustur();
    }
    public void chkOlustur()
    {
        for (int i = 0; i < grdKapatilacak.Rows.Count; i++)
        {
            c = new System.Web.UI.WebControls.CheckBox();
            c.ID = "chk_" + i.ToString();
            l = new System.Web.UI.WebControls.Label();
            l.Text = tblVeri.Rows[i]["SEÇ"].ToString();
            l.Width = 20;
            c.Width = 20;
            grdKapatilacak.Rows[i].Cells[0].Controls.Add(c);
            grdKapatilacak.Rows[i].Cells[0].Controls.Add(l);
            grdKapatilacak.Rows[i].Cells[3].Enabled = false;
            sayi = i;
            //c.AutoPostBack = true;
            c.CheckedChanged += c_CheckedChanged;
        }
    }
    void c_CheckedChanged(object sender, EventArgs e)
    {
        //for (int i = 0; i < grdKapatilacak.Rows.Count; i++)
        //{
        //    System.Web.UI.WebControls.CheckBox c = (System.Web.UI.WebControls.CheckBox)grdKapatilacak.Rows[i].Cells[0].FindControl("chk_" + i.ToString());
        //    if (c.Checked) // işaretlenen checkbox kontrolü, yapılcak işlem burada tanımlanacak.
        //    {
        //        // grdKapatilacak.Rows[i].Cells[3].Enabled = true;
        //    }
        //}
    }
    protected void grdKapatilacak_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdKapatilacak_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdKapatilacak.PageIndex = e.NewPageIndex;
        VeriGetir();
    }
    protected void btnAra_Click(object sender, EventArgs e)
    {
        adpVeri = new SqlDataAdapter("SELECT [SEÇ]='',MUSTERIKOD,MUSTERIAD ,DBSOFFLINE,DBSONLINE,ROUND(KALANLIMIT,2) " +
            "AS [KALAN LİMİT],ALISLAR FROM RESELLER_LIMIT RL LEFT OUTER JOIN BEKEN2010.DBO.LG_316_CLCARD CL ON CL.CODE=RL.MUSTERIKOD " +
            "WHERE KAYITTARIH =CONVERT(DATETIME,'" + DateTime.Now.ToString().Substring(0, 10).TrimEnd().TrimStart() + "',104) " +
            "AND KALANLIMIT<-50 AND MUSTERIAD LIKE '%" + txtCari.Text + "%' AND CL.DBSLIMIT3<>1", connBizim);
        tblVeri = new DataTable();
        adpVeri.Fill(tblVeri);
        this.grdKapatilacak.DataSource = tblVeri;
        this.grdKapatilacak.DataBind();        
        chkOlustur();
    }
    protected void btnKapat_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < grdKapatilacak.Rows.Count; i++)
        {
            if (c.Checked == true)
            {
                #region müşteri kodu bulunuyor
                conn.Open();
                SqlCommand cmdMusteriKod = new SqlCommand("SELECT BANKNAMES7 FROM LG_316_CLCARD WHERE CODE='" + Session["CariRef"].ToString() + "'", conn);
                SqlDataReader rdrMusteriKod = cmdMusteriKod.ExecuteReader();
                while (rdrMusteriKod.Read())
                {
                    musteriKod = rdrMusteriKod[0].ToString();
                }
                conn.Close();
                #endregion
                #region cari plakalar bulunuyor
                SqlDataAdapter adpCariPlaka = new SqlDataAdapter("SELECT PLAKA FROM BS_PLAKA WHERE CARIKOD='" + grdKapatilacak.Rows[i].Cells[1].ToString() + "'", connBizim);
                DataTable tblCariPlaka = new DataTable();
                adpCariPlaka.Fill(tblCariPlaka);
                #endregion
                #region kapatılıyor
                foreach (DataRow item in tblCariPlaka.Rows)
                {
                    tts.TTSWebServicesSoapClient plakaKapama = new tts.TTSWebServicesSoapClient();
                    tts.SETCARDSTATUSRESULT pro = plakaKapama.SetPlateStatus(bayi, kullanici, parola, musteriKod, item[0].ToString(), "2", "10", "11111111111111111111");
                    if (pro.PROCESSRESULT.Success == true)
                    {

                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + pro.PROCESSRESULT.Message.ToString() + "');</script>");
                    }
                }
                #endregion
                #region cari durum kapalı olarak güncelleniyor
                SqlCommand cmdDurum = new SqlCommand("UPDATE LG_316_CLCARD SET DBSLIMIT3=1 WHERE CODE='" + Session["CariRef"].ToString() + "'", conn);
                conn.Open();
                cmdDurum.ExecuteNonQuery();
                conn.Close();
                #endregion
            }
        }
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert(Seçili Carilerin Yakıt Alımı Durdurulmuştur);</script>");
    }
    protected void btnYazdir_Click(object sender, ImageClickEventArgs e)
    {
        if (grdKapatilacak.Rows.Count > 0)
        {
            grdKapatilacak.PagerSettings.Visible = false;
            //grdKapatilacak.DataBind();
            //  VeriGetir();
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grdKapatilacak.RenderControl(hw);
            string gridHTML = sw.ToString().Replace("\"", "'")
                .Replace(System.Environment.NewLine, "");
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload = new function(){");
            sb.Append("var printWin = window.open('', '', 'left=0");
            sb.Append(",top=0,width=1000,height=600,status=0');");
            sb.Append("printWin.document.write(\"");
            sb.Append(gridHTML);
            sb.Append("\");");
            sb.Append("printWin.document.close();");
            sb.Append("printWin.focus();");
            sb.Append("printWin.print();");
            sb.Append("printWin.close();};");
            sb.Append("</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
            grdKapatilacak.PagerSettings.Visible = true;
            grdKapatilacak.DataBind();
            VeriGetir();
        }
    }
    protected void btnExcel_Click(object sender, ImageClickEventArgs e)
    {
        grdKapatilacak.HeaderRow.Cells[0].Visible = false;
        for (int i = 0; i < grdKapatilacak.Rows.Count; i++)
        {
            grdKapatilacak.Rows[i].Cells[0].Visible = false;
        }
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Limit Aşan Firmalar.xls");
        Response.ContentType = "application/vnd.ms-excel";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1254");
        Response.Charset = "windows-1254";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        //grdKapatilacak.DataBind();
        //Başlık rowlarının arka planını beyaz olarak ayarlıyoruz. 
        grdKapatilacak.HeaderRow.Style.Add("background-color", "#FFFFFF");
        //Şimdide hücre başlıklarının arka planını yeşil yapıyoruz 
        grdKapatilacak.HeaderRow.Cells[0].Style.Add("background-color", "green");
        grdKapatilacak.HeaderRow.Cells[1].Style.Add("background-color", "green");
        grdKapatilacak.HeaderRow.Cells[2].Style.Add("background-color", "green");
        grdKapatilacak.HeaderRow.Cells[3].Style.Add("background-color", "green");
        grdKapatilacak.HeaderRow.Cells[4].Style.Add("background-color", "green");
        grdKapatilacak.HeaderRow.Cells[5].Style.Add("background-color", "green");
        for (int i = 0; i < grdKapatilacak.Rows.Count; i++)
        {
            GridViewRow row = grdKapatilacak.Rows[i];
            //Arka plan rengini beyaz olarak ayarlıyoruz 
            row.BackColor = System.Drawing.Color.White;
            //Her row’un text özelliğine bir class atıyoruz 
            row.Attributes.Add("class", "textmode");
            //Biraz daha güzellik katmak için 2. Row’ların arka planlarına farklı bir renk veriyoruz 
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#C2D69B");
                row.Cells[1].Style.Add("background-color", "#C2D69B");
                row.Cells[2].Style.Add("background-color", "#C2D69B");
                row.Cells[3].Style.Add("background-color", "#C2D69B");
                row.Cells[4].Style.Add("background-color", "#C2D69B");
                row.Cells[5].Style.Add("background-color", "#C2D69B");
            }
        }
        grdKapatilacak.RenderControl(hw);
        //Sayısal formatların bozuk çıkmaması için format belirliyoruz 
        string style = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\n<head>\n<title></title>\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=windows-1254\" />\n<style>\n</style>\n</head>\n<body>\n";
        Response.Write(style);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    protected void btnPdf_Click(object sender, ImageClickEventArgs e)
    {
        grdKapatilacak.HeaderRow.Cells[0].Visible = false;
        for (int i = 0; i < grdKapatilacak.Rows.Count; i++)
        {
            grdKapatilacak.Rows[i].Cells[0].Visible = false;
        }
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition",
         "attachment;filename=Limiti Aşan Firmalar.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw); 
        //grdKapatilacak.DataBind();
        grdKapatilacak.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
}