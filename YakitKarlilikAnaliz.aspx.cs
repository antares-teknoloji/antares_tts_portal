using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class YakitKarlilikAnaliz : System.Web.UI.Page
{
    SqlConnection connBizim, conn;
    DataTable tblVeri, tblIsyeri;
    SqlDataAdapter adpVeri, adpIsyeri;
    string navigateURL;
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        if (!IsPostBack)
        {

            SqlDataAdapter adpIsyeri = new SqlDataAdapter("SELECT ISYERIAD FROM AKTARIM.DBO.ISYERI WHERE TTSISYERI IN (120) ", connBizim);
            System.Data.DataTable tblIsyeri = new System.Data.DataTable();
            adpIsyeri.Fill(tblIsyeri);
            for (int i = 0; i < tblIsyeri.Rows.Count; i++)
            {
                dpIsyeri.Items.Add(tblIsyeri.Rows[i][0].ToString());
            }
            dpIsyeri.SelectedIndex = 0;

            SqlDataAdapter adpIsyeri2 = new SqlDataAdapter("SELECT DISTINCT ISYERI FROM YAKIT_KARLILIK  ", connBizim);
            System.Data.DataTable tblIsyeri2 = new System.Data.DataTable();
            adpIsyeri2.Fill(tblIsyeri2);
            for (int i = 0; i < tblIsyeri2.Rows.Count; i++)
            {
                dpİs.Items.Add(tblIsyeri2.Rows[i][0].ToString());
            }           
            if (dpİs.SelectedValue == "DÖŞEMEALTI")
            {
                SqlDataAdapter adpIsyeri1 = new SqlDataAdapter("SELECT DISTINCT URUNCINS FROM YAKIT_KARLILIK WHERE TARIH>='2020-01-01 00:00:00.000' AND ISYERI='DÖŞEMEALTI'", connBizim);
                System.Data.DataTable tblIsyeri1 = new System.Data.DataTable();

                adpIsyeri1.Fill(tblIsyeri1);
                for (int i = 0; i < tblIsyeri1.Rows.Count; i++)
                {
                    dpGrafik.Items.Add(tblIsyeri1.Rows[i][0].ToString());
                }
                dpGrafik.SelectedIndex = 0;
            }
            else if (dpİs.SelectedValue == "KORKUTELİ")
            {
                SqlDataAdapter adpIsyeri1 = new SqlDataAdapter("SELECT DISTINCT URUNCINS FROM YAKIT_KARLILIK WHERE TARIH>='2020-01-01 00:00:00.000' AND ISYERI='KORKUTELİ'", connBizim);
                System.Data.DataTable tblIsyeri1 = new System.Data.DataTable();
                adpIsyeri1.Fill(tblIsyeri1);
                for (int i = 0; i < tblIsyeri1.Rows.Count; i++)
                {

                    dpGrafik.Items.Add(tblIsyeri1.Rows[i][0].ToString());
                }
                dpGrafik.SelectedIndex = 0;
            }

            else if (dpİs.SelectedValue == "AFYON")
            {
                SqlDataAdapter adpIsyeri1 = new SqlDataAdapter("SELECT DISTINCT URUNCINS FROM YAKIT_KARLILIK WHERE TARIH>='2020-01-01 00:00:00.000' AND ISYERI='AFYON'", connBizim);
                System.Data.DataTable tblIsyeri1 = new System.Data.DataTable();
                adpIsyeri1.Fill(tblIsyeri1);
                for (int i = 0; i < tblIsyeri1.Rows.Count; i++)
                {
                    dpGrafik.Items.Add(tblIsyeri1.Rows[i][0].ToString());
                }
                dpGrafik.SelectedIndex = 0;
            }
            else if (dpİs.SelectedValue == "NEBİLER")
            {
                SqlDataAdapter adpIsyeri1 = new SqlDataAdapter("SELECT DISTINCT URUNCINS FROM YAKIT_KARLILIK WHERE TARIH>='2020-01-01 00:00:00.000' AND ISYERI='NEBİER'", connBizim);
                System.Data.DataTable tblIsyeri1 = new System.Data.DataTable();
                adpIsyeri1.Fill(tblIsyeri1);
                for (int i = 0; i < tblIsyeri1.Rows.Count; i++)
                {
                    dpGrafik.Items.Add(tblIsyeri1.Rows[i][0].ToString());
                }
                dpGrafik.SelectedIndex = 0;
            }
            else if (dpİs.SelectedValue == "KEMER")
            {
                SqlDataAdapter adpIsyeri1 = new SqlDataAdapter("SELECT DISTINCT URUNCINS FROM YAKIT_KARLILIK WHERE TARIH>='2020-01-01 00:00:00.000' AND ISYERI='KEMER'", connBizim);
                System.Data.DataTable tblIsyeri1 = new System.Data.DataTable();
                adpIsyeri1.Fill(tblIsyeri1);
                for (int i = 0; i < tblIsyeri1.Rows.Count; i++)
                {
                    dpGrafik.Items.Add(tblIsyeri1.Rows[i][0].ToString());
                }
                dpGrafik.SelectedIndex = 0;
            }
            else if (dpİs.SelectedValue == "ATSO")
            {
                SqlDataAdapter adpIsyeri1 = new SqlDataAdapter("SELECT DISTINCT URUNCINS FROM YAKIT_KARLILIK WHERE TARIH>='2020-01-01 00:00:00.000' AND ISYERI='ATSO'", connBizim);
                System.Data.DataTable tblIsyeri1 = new System.Data.DataTable();
                adpIsyeri1.Fill(tblIsyeri1);
                for (int i = 0; i < tblIsyeri1.Rows.Count; i++)
                {
                    dpGrafik.Items.Add(tblIsyeri1.Rows[i][0].ToString());
                }
                dpGrafik.SelectedIndex = 0;
            }
            else if (dpİs.SelectedValue == "PERGE")
            {
                SqlDataAdapter adpIsyeri1 = new SqlDataAdapter("SELECT DISTINCT URUNCINS FROM YAKIT_KARLILIK WHERE TARIH>='2020-01-01 00:00:00.000' AND ISYERI='PERGE'", connBizim);
                System.Data.DataTable tblIsyeri1 = new System.Data.DataTable();
                adpIsyeri1.Fill(tblIsyeri1);
                for (int i = 0; i < tblIsyeri1.Rows.Count; i++)
                {
                    dpGrafik.Items.Add(tblIsyeri1.Rows[i][0].ToString());
                }
                dpGrafik.SelectedIndex = 0;
            }
            else if (dpİs.SelectedValue == "LUKOIL")
            {
                SqlDataAdapter adpIsyeri1 = new SqlDataAdapter("SELECT DISTINCT URUNCINS FROM YAKIT_KARLILIK WHERE TARIH>='2020-01-01 00:00:00.000' AND ISYERI='LUKOIL'", connBizim);
                System.Data.DataTable tblIsyeri1 = new System.Data.DataTable();
                adpIsyeri1.Fill(tblIsyeri1);
                for (int i = 0; i < tblIsyeri1.Rows.Count; i++)
                {
                    dpGrafik.Items.Add(tblIsyeri1.Rows[i][0].ToString());
                }
                dpGrafik.SelectedIndex = 0;
            }
        }       
    }
    protected void Sorgu(object sender, EventArgs e)
    {
        VeriGetirir();
    }
    private void VeriGetirir()
    {

        SqlDataAdapter adpVeri = new SqlDataAdapter("SELECT CONVERT(VARCHAR(10),TARIH, 104) AS [TARİH],ISYERI AS[İŞYERİ], URUNCINS AS[ÜRÜN CİNSİ],cast(RAFINERIFIYAT AS decimal(10, 2)) AS [RAFİNERİ FİYAT],cast(ALISFIYAT AS decimal(10, 2)) AS [ALIŞ FİYAT],cast(SATISFIYAT as decimal (10, 2)) AS [SATIŞ FİYAT],cast(KARTUTAR as decimal(10, 2)) AS [KAR TUTAR],KARORAN AS[KAR YÜZDESİ],CASE WHEN ISYERI IN('KORKUTELİ', 'AFYON', 'ATSO', 'LUKOIL','KEMER', 'PERGE','NEBILER') THEN left('%' + cast ([KARMARJI] AS VARCHAR (10)),6) WHEN ISYERI = 'DOSEMEALTI' THEN '0'  END AS KARMARJI FROM AKTARIM.DBO.YAKIT_KARLILIK WHERE  ISYERI= '" + dpIsyeri.SelectedValue + "'    ORDER BY TARIH DESC", connBizim);
       System.Data.DataTable tblVeri = new System.Data.DataTable();
        adpVeri.Fill(tblVeri);
        grdSorgu.DataSource = tblVeri;
        grdSorgu.DataBind();
 
    }
    protected void btnSorgula1_Click(object sender, EventArgs e)
    {
        SqlDataAdapter adpVeri = new SqlDataAdapter("SELECT CONVERT(VARCHAR(10),TARIH, 104) AS [TARİH],ISYERI AS[İŞYERİ], URUNCINS AS [ÜRÜN CİNSİ],cast(RAFINERIFIYAT AS decimal(10, 2)) AS [RAFİNERİ FİYAT],cast(ALISFIYAT AS decimal(10, 2)) AS [ALIŞ FİYAT],cast(SATISFIYAT as decimal (10, 2)) AS [SATIŞ FİYAT],cast(KARTUTAR as decimal(10, 2)) AS [KAR TUTAR],KARORAN AS[KAR YÜZDESİ],CASE WHEN ISYERI IN('KORKUTELİ', 'AFYON', 'ATSO', 'LUKOIL','KEMER', 'PERGE','NEBILER') THEN left('%' + cast ([KARMARJI] AS VARCHAR (10)),6) WHEN ISYERI = 'DOSEMEALTI' THEN '0'  END AS KARMARJI FROM AKTARIM.DBO.YAKIT_KARLILIK  WHERE  ISYERI IS NOT NULL AND TARIH>='2020-01-01'  ORDER BY TARIH DESC,URUNCINS", connBizim);
        System.Data.DataTable tblVeri = new System.Data.DataTable();
        adpVeri.Fill(tblVeri);
        grdSorgu.DataSource = tblVeri;
        grdSorgu.DataBind();
        //this.grdCari.Columns[0].Visible = false;
    }

    protected void btnSorgula2_Click(object sender, EventArgs e)
    {



        if (dpİs.SelectedValue == "DÖŞEMEALTI")
        {
            connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
            SqlDataAdapter adpVeri = new SqlDataAdapter("SELECT DISTINCT URUNCINS FROM YAKIT_KARLILIK WHERE TARIH>='2020-01-01 00:00:00.000' AND ISYERI='DÖŞEMEALTI' AND URUNCINS =  '" + dpGrafik.SelectedValue + "'", connBizim);
            DataTable tblGrafik = new DataTable();
            adpVeri.Fill(tblGrafik);

            if (dpGrafik.SelectedValue == "KURŞUNSUZ BENZİN 95 OKTAN-SHELL FUELSAVE")
            {
                Response.Redirect("Grafik%20RAFİNE%20DÖŞEMEALTI/KursunsuzFuelsave.aspx");
                //or
                Server.Transfer("Grafik%20RAFİNE%20DÖŞEMEALTI/KursunsuzFuelsave.aspx");
            }
            else if (dpGrafik.SelectedValue == "MOTORİN-SHELL FUELSAVE DIESEL")
            {
                Response.Redirect("Grafik%20RAFİNE%20DÖŞEMEALTI/MotorinFuelsave.aspx");
                //or
                Server.Transfer("Grafik%20RAFİNE%20DÖŞEMEALTI/MotorinFuelsave.aspx");

            }
            else if (dpGrafik.SelectedValue == "MOTORİN-SHELL V-POWER  NITRO+ DIESEL")
            {

                Response.Redirect("Grafik%20RAFİNE%20DÖŞEMEALTI/MotorinVpower.aspx");
                //or
                Server.Transfer("Grafik%20RAFİNE%20DÖŞEMEALTI/MotorinVpower.aspx");
            }
            else if (dpGrafik.SelectedValue == "OTOGAZ-SHELL AUTOGAZ LPG")
            {
                Response.Redirect("Grafik%20RAFİNE%20DÖŞEMEALTI/OtogazShellLpg.aspx");
                //or
                Server.Transfer("Grafik%20RAFİNE%20DÖŞEMEALTI/OtogazShellLpg.aspx");

                navigateURL = "GrafikDlpg.aspx";
            }
            else if (dpGrafik.SelectedValue == "KURŞUNSUZ BENZİN 95 OKTAN  V POWER")
            {
                Response.Redirect("Grafik%20RAFİNE%20DÖŞEMEALTI/KursunsuzVpower.aspx");
                //or
                Server.Transfer("Grafik%20RAFİNE%20DÖŞEMEALTI/KursunsuzVpower.aspx");
            }
            string target = "_blank";
            string windowProperties = "status=0, menubar=0, toolbar=0";
            string scriptText = "window.open('" + navigateURL + "','" + target + "')";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "eşsizAnahtar", scriptText, true);
            tblGrafik.Rows.Clear();
        }
       else if (dpİs.SelectedValue == "ATSO")
        {

            connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
            SqlDataAdapter adpVeri = new SqlDataAdapter("SELECT DISTINCT URUNCINS FROM YAKIT_KARLILIK WHERE TARIH>='2020-01-01 00:00:00.000' AND ISYERI='ATSO' AND URUNCINS =  '" + dpGrafik.SelectedValue + "'", connBizim);
            DataTable tblGrafik = new DataTable();
            adpVeri.Fill(tblGrafik);

            if (dpGrafik.SelectedValue == "KURŞUNSUZ BENZİN 95 OKTAN-SHELL FUELSAVE")
            {
                Response.Redirect("Grafik%20RAFİNE%20ATSO/KursunsuzFuelsave.aspx");
                //or
                Server.Transfer("Grafik%20RAFİNE%20ATSO/KursunsuzFuelsave.aspx");
            }
            else if (dpGrafik.SelectedValue == "MOTORİN-SHELL FUELSAVE DIESEL")
            {
                Response.Redirect("Grafik%20RAFİNE%20ATSO/MotorinFuelsave.aspx");
                //or
                Server.Transfer("Grafik%20RAFİNE%20ATSO/MotorinFuelsave.aspx");

            }
            else if (dpGrafik.SelectedValue == "MOTORİN-SHELL V-POWER  NITRO+ DIESEL")
            {

                Response.Redirect("Grafik%20RAFİNE%20ATSO/MotorinVpower.aspx");
                //or
                Server.Transfer("Grafik%20RAFİNE%20ATSO/MotorinVpower.aspx");
            }
            else if (dpGrafik.SelectedValue == "OTOGAZ-SHELL AUTOGAZ LPG")
            {
                Response.Redirect("Grafik%20RAFİNE%20ATSO/OtogazShellLpg.aspx");
                //or
                Server.Transfer("Grafik%20RAFİNE%20ATSO/OtogazShellLpg.aspx");

                navigateURL = "GrafikDlpg.aspx";
            }
            else if (dpGrafik.SelectedValue == "KURŞUNSUZ BENZİN 95 OKTAN  V POWER")
            {
                Response.Redirect("Grafik%20RAFİNE%20ATSO/KursunsuzVpower.aspx");
                //or
                Server.Transfer("Grafik%20RAFİNE%20ATSO/KursunsuzVpower.aspx");
            }
            string target = "_blank";
            string windowProperties = "status=0, menubar=0, toolbar=0";
            string scriptText = "window.open('" + navigateURL + "','" + target + "')";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "eşsizAnahtar", scriptText, true);
            tblGrafik.Rows.Clear();
        }
        else if (dpİs.SelectedValue == "AFYON")
        {

            connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
            SqlDataAdapter adpVeri = new SqlDataAdapter("SELECT DISTINCT URUNCINS FROM YAKIT_KARLILIK WHERE TARIH>='2020-01-01 00:00:00.000' AND ISYERI='AFYON' AND URUNCINS =  '" + dpGrafik.SelectedValue + "'", connBizim);
            DataTable tblGrafik = new DataTable();
            adpVeri.Fill(tblGrafik);

            if (dpGrafik.SelectedValue == "KURŞUNSUZ BENZİN 95 OKTAN-SHELL FUELSAVE")
            {
                Response.Redirect("Grafik%20RAFİNE%20AFYON/KursunsuzFuelsave.aspx");
                //or
                Server.Transfer("Grafik%20RAFİNE%20AFYON/KursunsuzFuelsave.aspx");
            }
            else if (dpGrafik.SelectedValue == "MOTORİN-SHELL FUELSAVE DIESEL")
            {
                Response.Redirect("Grafik%20RAFİNE%20AFYON/MotorinFuelsave.aspx");
                //or
                Server.Transfer("Grafik%20RAFİNE%20AFYON/MotorinFuelsave.aspx");

            }
            else if (dpGrafik.SelectedValue == "MOTORİN-SHELL V-POWER  NITRO+ DIESEL")
            {

                Response.Redirect("Grafik%20RAFİNE%20AFYON/MotorinVpower.aspx");
                //or
                Server.Transfer("Grafik%20RAFİNE%20AFYON/MotorinVpower.aspx");
            }
            else if (dpGrafik.SelectedValue == "OTOGAZ-SHELL AUTOGAZ LPG")
            {
                Response.Redirect("Grafik%20RAFİNE%20AFYON/OtogazShellLpg.aspx");
                //or
                Server.Transfer("Grafik%20RAFİNE%20AFYON/OtogazShellLpg.aspx");

                navigateURL = "GrafikDlpg.aspx";
            }
            else if (dpGrafik.SelectedValue == "KURŞUNSUZ BENZİN 95 OKTAN  V POWER")
            {
                Response.Redirect("Grafik%20RAFİNE%20AFYON/KursunuzVpower.aspx");
                //or
                Server.Transfer("Grafik%20RAFİNE%20AFYON/KursunuzVpower.aspx");
            }
            string target = "_blank";
            string windowProperties = "status=0, menubar=0, toolbar=0";
            string scriptText = "window.open('" + navigateURL + "','" + target + "')";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "eşsizAnahtar", scriptText, true);
            tblGrafik.Rows.Clear();
        }
        else if (dpİs.SelectedValue == "KEMER")
        {

            connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
            SqlDataAdapter adpVeri = new SqlDataAdapter("SELECT DISTINCT URUNCINS FROM YAKIT_KARLILIK WHERE TARIH>='2020-01-01 00:00:00.000' AND ISYERI='KEMER' AND URUNCINS =  '" + dpGrafik.SelectedValue + "'", connBizim);
            DataTable tblGrafik = new DataTable();
            adpVeri.Fill(tblGrafik);

            if (dpGrafik.SelectedValue == "KURŞUNSUZ BENZİN 95 OKTAN(LUK)")
            {
                Response.Redirect("Grafik%20RAFİNE%20KEMER/Kursunsuz(Luk).aspx");
                //or
                Server.Transfer("Grafik%20RAFİNE%20KEMER/Kursunsuz(Luk).aspx");
            }
            else if (dpGrafik.SelectedValue == "MOTORİN (+) (ECTO eurodiesel)")
            {
                Response.Redirect("Grafik%20RAFİNE%20KEMER/MotorinEuro.aspx");
                //or
                Server.Transfer("Grafik%20RAFİNE%20KEMER/MotorinEuro.aspx");

            }
            else if (dpGrafik.SelectedValue == "MOTORİN (ECTO PRODIESEL)")
            {

                Response.Redirect("Grafik%20RAFİNE%20KEMER/MotorinPro.aspx");
                //or
                Server.Transfer("Grafik%20RAFİNE%20KEMER/MotorinPro.aspx");
            }
            else if (dpGrafik.SelectedValue == "LPG OTOGAZ - LUKOİL")
            {
                Response.Redirect("Grafik%20RAFİNE%20KEMER/LpgOtogaz(Luk).aspx");
                //or
                Server.Transfer("Grafik%20RAFİNE%20KEMER/LpgOtogaz(Luk).aspx");

                
            }
           
            string target = "_blank";
            string windowProperties = "status=0, menubar=0, toolbar=0";
            string scriptText = "window.open('" + navigateURL + "','" + target + "')";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "eşsizAnahtar", scriptText, true);
            tblGrafik.Rows.Clear();
        }
    }
    
}