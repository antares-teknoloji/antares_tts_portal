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




public partial class AktifCari : System.Web.UI.Page
{
    SqlConnection connBizim, conn;
    DataTable tblVeri, tblIsyeri, tblVeri1, tblVeri2;
    SqlDataAdapter adpVeri, adpIsyeri, adpVeri1, adpVeri2;
    int indexOfColumn1;
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        if (!IsPostBack)
        {

        }

    }

    protected void btnShell_Click(object sender, EventArgs e)
    {
        SqlDataAdapter adpVeri = new SqlDataAdapter("SELECT  CL.DEFINITION_ AS[FIRMA ÜNVAN], TT.SATISPERSONEL AS[SATIŞ PERSONEL],CL.ADDR1 AS[ADRES 1], CL.ADDR2 AS[ADRES 2],CL.TELCODES1 AS[TEL],CL.TAXNR as [ VERGİ NO], CL.TCKNO AS [TC NO],CL.TAXOFFICE AS[VERGİ DAİRESİ] FROM BS_FATURA BF LEFT OUTER JOIN [BEKEN2010].[dbo].LG_316_CLCARD CL ON CL.CODE = BF.CARIKOD LEFT OUTER JOIN BS_DBS BD ON CL.CODE = BD.CARIKOD LEFT OUTER JOIN TTSPORTAL_CARIBILGI TT ON BF.CARIKOD = TT.CARIKOD WHERE BF.TARIH >= (SELECT MAX(TARIH) FROM BS_FATURA) AND CL.DEFINITION_ LIKE '%" + txtCariAd.Text + "%' GROUP BY CL.DEFINITION_,TT.SATISPERSONEL, CL.CODE, CL.ADDR1, CL.ADDR2, CL.TELCODES1, CL.TAXNR, CL.TAXOFFICE,CL.TCKNO ORDER BY CL.DEFINITION_ ASC", connBizim);
        System.Data.DataTable tblVeri = new System.Data.DataTable();
        
        adpVeri.Fill(tblVeri);
        grdSorgu.DataSource = tblVeri;
        grdSorgu.DataBind();
        ViewState["dirState"] = tblVeri;
        ViewState["sortdr"] = "Asc";
    }

    protected void btnTotal_Click(object sender, EventArgs e)
    {
        SqlDataAdapter adpVeri = new SqlDataAdapter("SELECT  CL.DEFINITION_ AS[FİRMA ÜNVAN], TT.SATISPERSONEL AS[SATIŞ PERSONEL],CL.ADDR1 AS[ADRES 1], CL.ADDR2 AS[ADRES 2],CL.TELCODES1 AS[TEL],CL.TAXNR AS [ VERGİ NO],CL.TCKNO AS [TC NO], CL.TAXOFFICE AS[VERGİ DAİRESİ] FROM BS_ATSFATURA BF LEFT OUTER JOIN [BEKEN2010].[dbo].LG_316_CLCARD CL ON CL.CODE = BF.CARIKOD LEFT OUTER JOIN BS_DBS BD ON CL.CODE = BD.CARIKOD LEFT OUTER JOIN TTSPORTAL_CARIBILGI TT ON BF.CARIKOD = TT.CARIKOD WHERE BF.TARIH >= (SELECT MAX(TARIH) FROM BS_ATSFATURA) AND CL.DEFINITION_ LIKE '%" + txtCariAd.Text + "%'  GROUP BY CL.DEFINITION_,TT.SATISPERSONEL, CL.CODE, CL.ADDR1, CL.ADDR2, CL.TELCODES1, CL.TAXNR, CL.TAXOFFICE,CL.TCKNO ORDER BY CL.DEFINITION_ ASC", connBizim);
        System.Data.DataTable tblVeri = new System.Data.DataTable();

        adpVeri.Fill(tblVeri);
        grdSorgu.DataSource = tblVeri;
        grdSorgu.DataBind();
        ViewState["dirState"] = tblVeri;
        ViewState["sortdr"] = "Asc";

    }
    protected void btnLukoıl_Click(object sender, EventArgs e)
    {
        SqlDataAdapter adpVeri = new SqlDataAdapter("SELECT  CL.DEFINITION_ AS [FIRMA UNVAN], TT.SATISPERSONEL AS[SATIS PERSONEL], CL.ADDR1 AS[ADRES 1], CL.ADDR2 AS[ADRES 2],CL.TELCODES1 AS[TEL], CL.TAXNR as [VERGİ NO],CL.TCKNO AS [TC NO], CL.TAXOFFICE AS[VERGİ DAİRESİ] FROM BS_YAKITMATIKFATURA BF LEFT OUTER JOIN[BEKEN2010].[dbo].LG_316_CLCARD CL ON CL.CODE = BF.CARIKOD LEFT OUTER JOIN BS_DBS BD ON CL.CODE = BD.CARIKOD LEFT OUTER JOIN TTSPORTAL_CARIBILGI TT ON BF.CARIKOD = TT.CARIKOD WHERE BF.TARIH >= (SELECT MAX(TARIH) FROM BS_YAKITMATIKFATURA)  AND CL.DEFINITION_ LIKE '%" + txtCariAd.Text + "%' GROUP BY CL.DEFINITION_,TT.SATISPERSONEL, CL.CODE, CL.ADDR1, CL.ADDR2, CL.TELCODES1, CL.TAXNR, CL.TAXOFFICE,CL.TCKNO ORDER BY CL.DEFINITION_ ASC", connBizim);
        System.Data.DataTable tblVeri = new System.Data.DataTable();

        adpVeri.Fill(tblVeri);
        grdSorgu.DataSource = tblVeri;
        grdSorgu.DataBind();
        ViewState["dirState"] = tblVeri;
        ViewState["sortdr"] = "Asc";       
    }

    protected void btnExcel_Click(object sender, ImageClickEventArgs e)
    {


            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Hilmi Beken Müşteri Raporu" + DateTime.Now.ToString("yyyy-MM-ddhh:mm:ss") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
        this.EnableViewState = false;
        System.IO.StringWriter sw = new System.IO.StringWriter();
        Encoding.GetEncoding(1254).GetBytes(sw.ToString());
        Response.Charset = "";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1254");
        System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
        
        Response.Write(" <meta http-equiv='Content-Type' content='text/html; charset=windows-1254' />" + sw.ToString());
        grdSorgu.AllowPaging = false;
    //grdSorgu.DataBind();
    //Başlık rowlarının arka planını beyaz olarak ayarlıyoruz. 
      grdSorgu.HeaderRow.Style.Add("background-color", "#FFFFFF");
            //Şimdide hücre başlıklarının arka planını yeşil yapıyoruz 
            grdSorgu.HeaderRow.Cells[0].Style.Add("background-color", "#d2e009");
            grdSorgu.HeaderRow.Cells[1].Style.Add("background-color", "#d2e009");
            grdSorgu.HeaderRow.Cells[2].Style.Add("background-color", "#d2e009");
            grdSorgu.HeaderRow.Cells[3].Style.Add("background-color", "#d2e009");
            grdSorgu.HeaderRow.Cells[4].Style.Add("background-color", "#d2e009");
            grdSorgu.HeaderRow.Cells[5].Style.Add("background-color", "#d2e009");
            grdSorgu.HeaderRow.Cells[6].Style.Add("background-color", "#d2e009");
             grdSorgu.HeaderRow.Cells[7].Style.Add("background-color", "#d2e009");

        for (int i = 0; i<grdSorgu.Rows.Count; i++)
            {
                GridViewRow row = grdSorgu.Rows[i];
    //Arka plan rengini beyaz olarak ayarlıyoruz 
    row.BackColor = System.Drawing.Color.White;
                //Her row’un text özelliğine bir class atıyoruz 
                row.Attributes.Add("class", "textmode");
                //Biraz daha güzellik katmak için 2. Row’ların arka planlarına farklı bir renk veriyoruz 
                if (i % 2 != 0)
                {
                    row.Cells[0].Style.Add("background-color", "#92b5d4");
                    row.Cells[1].Style.Add("background-color", "#92b5d4");
                    row.Cells[2].Style.Add("background-color", "#92b5d4");
                    row.Cells[3].Style.Add("background-color", "#92b5d4");
                    row.Cells[4].Style.Add("background-color", "#92b5d4");
                    row.Cells[5].Style.Add("background-color", "#92b5d4");
                    row.Cells[6].Style.Add("background-color", "#92b5d4");
                     row.Cells[7].Style.Add("background-color", "#92b5d4");
            }
            }
        grdSorgu.RenderControl(htw);
        //Sayısal formatların bozuk çıkmaması için format belirliyoruz 
        string style = @" ";
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
    protected void grdSorgu_Sorting(object sender, GridViewSortEventArgs e)
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
            grdSorgu.DataSource = dtrslt;
            grdSorgu.DataBind();
           

        }

    }

    protected void grdVeri_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
        if (e.Row.Cells.Count > indexOfColumn1)
        {
            e.Row.Cells[indexOfColumn1].Width = 80;
            e.Row.Cells[indexOfColumn1].Height = 40;
        }
    }

}