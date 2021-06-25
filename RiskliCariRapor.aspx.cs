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

public partial class RiskliCariRapor : System.Web.UI.Page
{
    SqlConnection conn, connBizim;
    SqlDataAdapter adpRiskli;
    DataTable tblRiskli, tblVeri;
    protected void Page_Load(object sender, EventArgs e)
    {
        #region tablo oluşuyor

        #endregion
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        VeriCek();
    }
    private void VeriCek()
    {
        adpRiskli = new SqlDataAdapter("SELECT MUSTERIAD as [MÜŞTERİ AD] ,DBSOFFLINE,DBSONLINE,ROUND(KALANLIMIT,2) " +
            "AS [KALAN LİMİT],[DURUM]= CASE WHEN DBSONLINE>0 THEN CASE WHEN (DBSONLINE*0.1)>KALANLIMIT " +
            "THEN 'RİSKLİ' ELSE 'NORMAL' END ELSE CASE WHEN (DBSOFFLINE*0.1)>KALANLIMIT " +
            "THEN 'RİSKLİ' ELSE 'NORMAL' END END,ALISLAR as [ALIŞLAR] FROM RESELLER_LIMIT WHERE KAYITTARIH =CONVERT(DATETIME,'" + DateTime.Now.ToString().Substring(0, 10).TrimEnd().TrimStart() + "',104) AND KALANLIMIT>-50 ", connBizim);
        tblVeri = new DataTable();
        adpRiskli.Fill(tblVeri);
        var sorgu = from c in tblVeri.AsEnumerable() where c.Field<string>("DURUM") == "RİSKLİ" select c;
        tblRiskli = sorgu.CopyToDataTable();
        this.grdRiskliCari.DataSource = tblRiskli;
        this.grdRiskliCari.DataBind();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void btnYazdir_Click(object sender, ImageClickEventArgs e)
    {
        if (grdRiskliCari.Rows.Count > 0)
        {
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grdRiskliCari.RenderControl(hw);
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
            grdRiskliCari.PagerSettings.Visible = true;
            grdRiskliCari.DataBind();
            VeriCek();
        }
    }
    protected void btnExcel_Click(object sender, ImageClickEventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Limit Aşan Firmalar.xls");
        Response.ContentType = "application/vnd.ms-excel";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1254");
        Response.Charset = "windows-1254";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        //grdRiskliCari.DataBind();
        //Başlık rowlarının arka planını beyaz olarak ayarlıyoruz. 
        grdRiskliCari.HeaderRow.Style.Add("background-color", "#FFFFFF");
        //Şimdide hücre başlıklarının arka planını yeşil yapıyoruz 
        grdRiskliCari.HeaderRow.Cells[0].Style.Add("background-color", "green");
        grdRiskliCari.HeaderRow.Cells[1].Style.Add("background-color", "green");
        grdRiskliCari.HeaderRow.Cells[2].Style.Add("background-color", "green");
        grdRiskliCari.HeaderRow.Cells[3].Style.Add("background-color", "green");
        grdRiskliCari.HeaderRow.Cells[4].Style.Add("background-color", "green");
        grdRiskliCari.HeaderRow.Cells[5].Style.Add("background-color", "green");
        for (int i = 0; i < grdRiskliCari.Rows.Count; i++)
        {
            GridViewRow row = grdRiskliCari.Rows[i];
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
        grdRiskliCari.RenderControl(hw);
        //Sayısal formatların bozuk çıkmaması için format belirliyoruz 
        string style = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\n<head>\n<title></title>\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=windows-1254\" />\n<style>\n</style>\n</head>\n<body>\n";
        Response.Write(style);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    protected void btnPdf_Click(object sender, ImageClickEventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition",
         "attachment;filename=Riskli Firmalar.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        //grdRiskliCari.DataBind();
        grdRiskliCari.RenderControl(hw);
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
    protected void btnAra_Click(object sender, EventArgs e)
    {
        try
        {       
        adpRiskli = new SqlDataAdapter("SELECT MUSTERIAD ,DBSOFFLINE,DBSONLINE,ROUND(KALANLIMIT,2) " +
            "AS [KALAN LİMİT],[DURUM]= CASE WHEN DBSONLINE>0 THEN CASE WHEN (DBSONLINE*0.1)>KALANLIMIT " +
            "THEN 'RİSKLİ' ELSE 'NORMAL' END ELSE CASE WHEN (DBSOFFLINE*0.1)>KALANLIMIT THEN 'RİSKLİ' " +
            "ELSE 'NORMAL' END END,ALISLAR FROM RESELLER_LIMIT WHERE KAYITTARIH =CONVERT(DATETIME,'" + DateTime.Now.ToString().Substring(0, 10).TrimEnd().TrimStart() + "',104) AND KALANLIMIT>-50 AND MUSTERIAD LIKE '%" + txtCari.Text + "%' ", connBizim);
        tblVeri = new DataTable();
        adpRiskli.Fill(tblVeri);
        var sorgu = from c in tblVeri.AsEnumerable() where c.Field<string>("DURUM") == "RİSKLİ" select c;
        tblRiskli = sorgu.CopyToDataTable();
        this.grdRiskliCari.DataSource = tblRiskli;
        this.grdRiskliCari.DataBind();
        }
        catch (Exception)
        {

        }
    }
    protected void grdRiskliCari_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
}