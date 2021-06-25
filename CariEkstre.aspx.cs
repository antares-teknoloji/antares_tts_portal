using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CariEkstre : System.Web.UI.Page
{
    double borc = 0;
    double alacak = 0;
    bool sayfa = false;
    double bakiye = 0;
    string borcGrid, c1;
    DataTable tbl;
    SqlConnection conn;
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);

        if (dtBaslangic.Text != "" && dtBitis.Text != "")
        {
            VeriGetir(dtBaslangic.Text, dtBitis.Text, Session["CariRef"].ToString());
        }
        else
        {
            VeriGetir("02.01.2016", "31.12.2050", Session["CariRef"].ToString());
        }
        VeriGetir1();

    }
    private void VeriGetir(string basTar, string bitTar, string c1)
    {
        SqlDataAdapter adpEkstre = new SqlDataAdapter("SELECT [TARİH]=CONVERT(DATETIME,'" + basTar + "',104),[FİŞ TÜRÜ]=''," +
            "[REFERANS]='',[AÇIKLAMA]='Devir Fişi',[BORÇ]=(SELECT ISNULL(SUM(AMOUNT),0) FROM LG_316_01_CLFLINE CLF " +
            "LEFT OUTER JOIN LG_316_CLCARD CL ON CL.LOGICALREF=CLF.CLIENTREF WHERE SIGN=0 AND CL.CODE='" + c1 + "' " +
            "AND CLF.DATE_>='2016-01-01'  AND CLF.DATE_<=CONVERT(DATETIME,'" + basTar + "',104)   AND CANCELLED=0),  \r\n" +
"[ALACAK]=(SELECT ISNULL(SUM(AMOUNT),0) FROM LG_316_01_CLFLINE CLF LEFT OUTER JOIN LG_316_CLCARD CL " +
"ON CL.LOGICALREF=CLF.CLIENTREF WHERE SIGN=1 AND CL.CODE='" + c1 + "' AND CLF.DATE_>='2016-01-01' " +
" AND CLF.DATE_<=CONVERT(DATETIME,'" + basTar + "',104)  AND CANCELLED=0),[BAKİYE]='0',[İŞYERİ]=''", conn);
        DataTable tblEkstre = new DataTable();
        adpEkstre.Fill(tblEkstre);
        SqlDataAdapter adpEkstreDetay = new SqlDataAdapter("SELECT CLF.DATE_ AS [TARİH],\r\n" +
"[FİŞ TÜRÜ]= \r\n" +
"CASE WHEN CLF.TRCODE=37 THEN  \r\n" +
"'Perakende Satış'  \r\n" +
"ELSE  \r\n" +
"CASE WHEN CLF.TRCODE=32 THEN  \r\n" +
"'Perakende Satış İade'  \r\n" +
"ELSE  \r\n" +
"CASE WHEN CLF.TRCODE=20 THEN  \r\n" +
"'Gelen Havale'  \r\n" +
"ELSE CASE WHEN CLF.TRCODE=5 THEN \r\n" +
"'Virman'  \r\n" +
"ELSE CASE WHEN CLF.TRCODE=31 THEN \r\n" +
"'Satınalma Faturası' \r\n" +
"ELSE CASE WHEN CLF.TRCODE=21 THEN \r\n" +
"'Gönderilen Havale' \r\n" +
  "ELSE CASE WHEN CLF.TRCODE=14 THEN \r\n" +
"'AÇILIŞ FİŞİ' \r\n" +
" ELSE CASE WHEN CLF.TRCODE=70 THEN \r\n" +
"'KREDİ KARTI FİŞİ' \r\n" +
" ELSE CASE WHEN CLF.TRCODE=62 THEN \r\n" +
"'SENET GİRİŞİ' \r\n" +
" ELSE CASE WHEN CLF.TRCODE=61 THEN \r\n" +
"'ÇEK' \r\n" +
"END \r\n" +
"END  \r\n" +
"END  \r\n" +
"END  \r\n" +
"END  \r\n" +
"END  \r\n" +
"END \r\n" +
"END  \r\n" +
"END  \r\n" +
"END  \r\n" +
",CLF.LOGICALREF [REFERANS], \r\n" +
"CLF.LINEEXP AS [AÇIKLAMA],\r\n" +
"[BORÇ]=  \r\n" +
"CASE WHEN CLF.SIGN=0 THEN   \r\n" +
"CLF.AMOUNT  \r\n" +
"ELSE   \r\n" +
"'0'  \r\n" +
"END, \r\n" +
"[ALACAK]=  \r\n" +
"CASE WHEN CLF.SIGN=1 THEN   \r\n" +
"CLF.AMOUNT   \r\n" +
"ELSE   \r\n" +
" '0'  \r\n" +
"END,[BAKİYE]='0',  \r\n" +
" [İŞYERİ]= \r\n" +
"CASE WHEN CLF.BRANCH=10 THEN  \r\n" +
"'Döşemealtı'  \r\n" +
"ELSE  \r\n" +
"CASE WHEN CLF.BRANCH=20 THEN  \r\n" +
"'Korkuteli'  \r\n" +
"ELSE  \r\n" +
"CASE WHEN CLF.BRANCH=40 THEN  \r\n" +
"'Atso'  \r\n" +
"ELSE  \r\n" +
"CASE WHEN CLF.BRANCH=50 THEN  \r\n" +
"'Lukoıl'  \r\n" +
"ELSE CASE WHEN CLF.BRANCH=60 THEN  \r\n" +
"'Kemer'  \r\n" +
"ELSE CASE WHEN CLF.BRANCH=110 THEN  \r\n" +
"'Perge'  \r\n" +
  "ELSE CASE WHEN CLF.BRANCH=90 THEN  \r\n" +
"'Nebiler'  \r\n" +
"END \r\n" +
"END  \r\n" +
"END  \r\n" +
"END  \r\n" +
"END  \r\n" +
"END  \r\n" +
"END \r\n" +
"FROM LG_316_01_CLFLINE CLF LEFT OUTER JOIN LG_316_CLCARD CL " +
"ON CL.LOGICALREF=CLF.CLIENTREF  WHERE  CL.CODE = '" + c1 + "' " +
" AND CL.ACTIVE=0 and CLF.TRCODE<>'14' AND  CLF.DATE_>=CONVERT(DATETIME,'" + basTar + "',104) " +
"AND DATE_<=CONVERT(DATETIME,'" + bitTar + "',104) AND CLF.CANCELLED=0 AND CLF.PAIDINCASH=0 order by [TARİH] ", conn);
        adpEkstreDetay.Fill(tblEkstre);
        grdEkstre.DataSource = tblEkstre;
        grdEkstre.DataBind();

        for (int i = 0; i < grdEkstre.Rows.Count; i++)
        {
            grdEkstre.Rows[i].Cells[0].Text = grdEkstre.Rows[i].Cells[0].Text.ToString().Substring(0, 10);
            borc = Convert.ToDouble(grdEkstre.Rows[i].Cells[4].Text.ToString());
            alacak = Convert.ToDouble(grdEkstre.Rows[i].Cells[5].Text.ToString());
            if (i > 0)
            {

                if (grdEkstre.Rows[i].Cells[4].Text != "0")
                { grdEkstre.Rows[i].Cells[6].Text = Convert.ToString(borc + Convert.ToDouble(grdEkstre.Rows[i - 1].Cells[6].Text)); }
                else
                {
                    { grdEkstre.Rows[i].Cells[6].Text = Convert.ToString(Convert.ToDouble(grdEkstre.Rows[i - 1].Cells[6].Text) - alacak); }
                }
            }
            else
            {
                grdEkstre.Rows[i].Cells[6].Text = Convert.ToString(borc - alacak);
            }
            decimal sayi = Convert.ToDecimal(grdEkstre.Rows[i].Cells[4].Text);
            grdEkstre.Rows[i].Cells[4].Text = sayi.ToString("N");
            decimal sayi1 = Convert.ToDecimal(grdEkstre.Rows[i].Cells[5].Text);
            grdEkstre.Rows[i].Cells[5].Text = sayi1.ToString("N");
            decimal sayi2 = Convert.ToDecimal(grdEkstre.Rows[i].Cells[6].Text);
            grdEkstre.Rows[i].Cells[6].Text = sayi2.ToString("N");
            grdEkstre.Rows[i].Cells[2].Visible = false;
            grdEkstre.HeaderRow.Cells[2].Visible = false;


            //c = new LinkButton();
            //c.ID = "ch_" + i.ToString();
            //c.Text = grdEkstre.Rows[i].Cells[1].Text;
            //grdEkstre.Rows[i].Cells[1].Controls.Add(c);
        }
    }
    protected void btnYazdir_Click(object sender, ImageClickEventArgs e)
    {


    }
    protected void btnExcel_Click(object sender, ImageClickEventArgs e)
    {
        grdEkstre.HeaderRow.Cells[0].Visible = false;
        for (int i = 0; i < grdEkstre.Rows.Count; i++)
        {
            grdEkstre.Rows[i].Cells[0].Visible = false;
        }
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Hilmi Beken Cari Ekstre.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        grdEkstre.AllowPaging = false;
        //grdEkstre.DataBind();
        //Başlık rowlarının arka planını beyaz olarak ayarlıyoruz. 
        grdEkstre.HeaderRow.Style.Add("background-color", "#FFFFFF");
        //Şimdide hücre başlıklarının arka planını yeşil yapıyoruz 
        grdEkstre.HeaderRow.Cells[0].Style.Add("background-color", "green");
        grdEkstre.HeaderRow.Cells[1].Style.Add("background-color", "green");
        grdEkstre.HeaderRow.Cells[2].Style.Add("background-color", "green");
        //grdEkstre.HeaderRow.Cells[3].Style.Add("background-color", "green");
        grdEkstre.HeaderRow.Cells[4].Style.Add("background-color", "green");
        grdEkstre.HeaderRow.Cells[5].Style.Add("background-color", "green");
        grdEkstre.HeaderRow.Cells[6].Style.Add("background-color", "green");
        grdEkstre.HeaderRow.Cells[7].Style.Add("background-color", "green");
        for (int i = 0; i < grdEkstre.Rows.Count; i++)
        {
            GridViewRow row = grdEkstre.Rows[i];
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
                //row.Cells[3].Style.Add("background-color", "#C2D69B");
                row.Cells[4].Style.Add("background-color", "#C2D69B");
                row.Cells[5].Style.Add("background-color", "#C2D69B");
                row.Cells[6].Style.Add("background-color", "#C2D69B");
                //   row.Cells[7].Style.Add("background-color", "#C2D69B");
            }
        }
        grdEkstre.RenderControl(hw);
        //Sayısal formatların bozuk çıkmaması için format belirliyoruz 
        string style = @" ";
        Response.Write(style);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }

    protected void btnPdf_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void btnSorgula_Click(object sender, EventArgs e)
    {
        VeriGetir(dtBaslangic.Text, dtBitis.Text, Session["CariRef"].ToString());
    }

    public void VeriGetir1()
    {
        lblCariAd.Text = Session["CariAd"].ToString();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
}