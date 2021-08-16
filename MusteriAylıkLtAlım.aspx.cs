using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MusteriAylıkLtAlım : System.Web.UI.Page
{
    SqlConnection connBizim;
    SqlDataAdapter adpArama, adpVeri;
    DataTable tblArama;
    int indexOfColumn = 0;
    int indexOfColumn1 = 1;
    int indexOfColum2 = 2;
    string navigateURL;

    protected void Page_Load(object sender, EventArgs e)
    {
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
    }
    protected void btnSorgula_Click(object sender, EventArgs e)
    {


        if (dpYil.SelectedItem.Text == "2021")
        {

            connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);

            adpArama = new SqlDataAdapter("SELECT TCG.CARIKOD,TCG.CARIAD AS [FİRMA ÜNVAN], TCG.SATISPERSONEL AS [SATIŞ PERSONEL],(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-01-01') AND(TARIH <= '2021-01-31') AND(BS.CARIKOD = CARIKOD)) AS OCAK,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-02-01') AND(TARIH <= '2021-02-28') AND(BS.CARIKOD = CARIKOD)) AS ŞUBAT,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-03-01') AND(TARIH <= '2021-03-31') AND(BS.CARIKOD = CARIKOD)) AS MART,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-04-01') AND(TARIH <= '2021-04-30') AND(BS.CARIKOD = CARIKOD)) AS NİSAN,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-05-01') AND(TARIH <= '2021-05-31') AND(BS.CARIKOD = CARIKOD)) AS MAYIS,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-06-01') AND(TARIH <= '2021-06-30') AND(BS.CARIKOD = CARIKOD)) AS HAZİRAN,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-07-01') AND(TARIH <= '2021-07-31') AND(BS.CARIKOD = CARIKOD)) AS TEMMUZ, (SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-08-01') AND(TARIH <= '2021-08-31') AND(BS.CARIKOD = CARIKOD)) AS AĞUSTOS, (SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-09-01') AND(TARIH <= '2021-09-30') AND(BS.CARIKOD = CARIKOD)) AS EYLÜL, (SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM  dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-10-01') AND(TARIH <= '2021-10-31') AND(BS.CARIKOD = CARIKOD)) AS EKİM, (SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-11-01') AND(TARIH <= '2021-11-30') AND(BS.CARIKOD = CARIKOD)) AS KASIM,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-12-01') AND(TARIH <= '2021-12-31') AND(BS.CARIKOD = CARIKOD)) AS ARALIK, (SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-01-01') AND(TARIH <= '2021-12-31') AND(BS.CARIKOD = CARIKOD)) AS TOPLAM, TCG.TAAHHUTLITRE AS[TONAJ TAAH] FROM dbo.BS_FATURA AS BS LEFT OUTER JOIN dbo.TTSPORTAL_CARIBILGI AS TCG ON TCG.CARIKOD = BS.CARIKOD LEFT OUTER JOIN BEKEN2010.dbo.LG_316_CLCARD AS CL ON CL.CODE = TCG.CARIKOD WHERE(BS.TARIH >= '2015-01-01') AND(BS.TARIH <= '2021-12-31') AND(TCG.MUSTERIISTASYON IN('SHELL', 'KORKUTELİ', 'AFYON', 'ATSO')) AND(CL.ACTIVE = 0)  GROUP BY TCG.CARIAD, BS.CARIKOD, TCG.SATISPERSONEL, TCG.TAAHHUTLITRE,TCG.CARIKOD ", connBizim);


            tblArama = new DataTable();
            adpArama.Fill(tblArama);
            this.grdVeri.DataSource = tblArama;
            this.grdVeri.DataBind();



            ViewState["dirState"] = tblArama;
            ViewState["sortdr"] = "Asc";

        }
        else if (dpYil.SelectedItem.Text == "2020")
        {
            SqlDataAdapter adpVeri = new SqlDataAdapter("SELECT * FROM MUSTERIDEVAM_2020", connBizim);
            DataTable tblVeri = new DataTable();
            adpVeri.Fill(tblVeri);

            grdVeri.DataSource = tblVeri;
            grdVeri.DataBind();


            ViewState["dirState"] = tblVeri;
            ViewState["sortdr"] = "Asc";

        }

    }

    protected void btnArama_Click(object sender, EventArgs e)
    {
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        if (dpYil.SelectedItem.Text == "2020")
        {

            if (txtCariAd.Text != "")
            {
                adpArama = new SqlDataAdapter("SELECT TCG.CARIKOD,TCG.CARIAD AS [FİRMA ÜNVAN], TCG.SATISPERSONEL AS [SATIŞ PERSONEL],(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2020-01-01') AND(TARIH <= '2020-01-31') AND(BS.CARIKOD = CARIKOD)) AS OCAK,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-02-01') AND(TARIH <= '2020-02-28') AND(BS.CARIKOD = CARIKOD)) AS ŞUBAT,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2020-03-01') AND(TARIH <= '2020-03-31') AND(BS.CARIKOD = CARIKOD)) AS MART,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2020-04-01') AND(TARIH <= '2020-04-30') AND(BS.CARIKOD = CARIKOD)) AS NİSAN,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2020-05-01') AND(TARIH <= '2020-05-31') AND(BS.CARIKOD = CARIKOD)) AS MAYIS,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2020-06-01') AND(TARIH <= '2020-06-30') AND(BS.CARIKOD = CARIKOD)) AS HAZİRAN,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2020-07-01') AND(TARIH <= '2020-07-31') AND(BS.CARIKOD = CARIKOD)) AS TEMMUZ, (SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM dbo.BS_FATURA AS BSC WHERE(TARIH >= '2020-08-01') AND(TARIH <= '2020-08-31') AND(BS.CARIKOD = CARIKOD)) AS AĞUSTOS, (SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2020-09-01') AND(TARIH <= '2020-09-30') AND(BS.CARIKOD = CARIKOD)) AS EYLÜL, (SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM  dbo.BS_FATURA AS BSC WHERE(TARIH >= '2020-10-01') AND(TARIH <= '2020-10-31') AND(BS.CARIKOD = CARIKOD)) AS EKİM, (SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2020-11-01') AND(TARIH <= '2020-11-30') AND(BS.CARIKOD = CARIKOD)) AS KASIM,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2020-12-01') AND(TARIH <= '2020-12-31') AND(BS.CARIKOD = CARIKOD)) AS ARALIK, (SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM dbo.BS_FATURA AS BSC WHERE(TARIH >= '2020-01-01') AND(TARIH <= '2020-12-31') AND(BS.CARIKOD = CARIKOD)) AS TOPLAM, TCG.TAAHHUTLITRE AS[TONAJ TAAH] FROM dbo.BS_FATURA AS BS LEFT OUTER JOIN dbo.TTSPORTAL_CARIBILGI AS TCG ON TCG.CARIKOD = BS.CARIKOD LEFT OUTER JOIN BEKEN2010.dbo.LG_316_CLCARD AS CL ON CL.CODE = TCG.CARIKOD WHERE(BS.TARIH >= '2015-01-01') AND(BS.TARIH <= '2021-12-31') AND(TCG.MUSTERIISTASYON IN('SHELL', 'KORKUTELİ', 'AFYON', 'ATSO')) AND(CL.ACTIVE = 0)  AND TCG.CARIAD LIKE '%" + txtCariAd.Text + "%'   GROUP BY TCG.CARIAD, BS.CARIKOD, TCG.SATISPERSONEL, TCG.TAAHHUTLITRE,TCG.CARIKOD ", connBizim);


                tblArama = new DataTable();
                adpArama.Fill(tblArama);
                this.grdVeri.DataSource = tblArama;
                this.grdVeri.DataBind();
                ViewState["dirState"] = tblArama;
                ViewState["sortdr"] = "Asc";

            }
            else if (cmbSatisEleman.Text != "")
            {
                adpArama = new SqlDataAdapter("SELECT TCG.CARIKOD,TCG.CARIAD AS [FİRMA ÜNVAN], TCG.SATISPERSONEL AS [SATIŞ PERSONEL],(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2020-01-01') AND(TARIH <= '2020-01-31') AND(BS.CARIKOD = CARIKOD)) AS OCAK,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-02-01') AND(TARIH <= '2020-02-28') AND(BS.CARIKOD = CARIKOD)) AS ŞUBAT,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2020-03-01') AND(TARIH <= '2020-03-31') AND(BS.CARIKOD = CARIKOD)) AS MART,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2020-04-01') AND(TARIH <= '2020-04-30') AND(BS.CARIKOD = CARIKOD)) AS NİSAN,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2020-05-01') AND(TARIH <= '2020-05-31') AND(BS.CARIKOD = CARIKOD)) AS MAYIS,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2020-06-01') AND(TARIH <= '2020-06-30') AND(BS.CARIKOD = CARIKOD)) AS HAZİRAN,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2020-07-01') AND(TARIH <= '2020-07-31') AND(BS.CARIKOD = CARIKOD)) AS TEMMUZ, (SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM dbo.BS_FATURA AS BSC WHERE(TARIH >= '2020-08-01') AND(TARIH <= '2020-08-31') AND(BS.CARIKOD = CARIKOD)) AS AĞUSTOS, (SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2020-09-01') AND(TARIH <= '2020-09-30') AND(BS.CARIKOD = CARIKOD)) AS EYLÜL, (SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM  dbo.BS_FATURA AS BSC WHERE(TARIH >= '2020-10-01') AND(TARIH <= '2020-10-31') AND(BS.CARIKOD = CARIKOD)) AS EKİM, (SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2020-11-01') AND(TARIH <= '2020-11-30') AND(BS.CARIKOD = CARIKOD)) AS KASIM,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2020-12-01') AND(TARIH <= '2020-12-31') AND(BS.CARIKOD = CARIKOD)) AS ARALIK, (SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM dbo.BS_FATURA AS BSC WHERE(TARIH >= '2020-01-01') AND(TARIH <= '2020-12-31') AND(BS.CARIKOD = CARIKOD)) AS TOPLAM, TCG.TAAHHUTLITRE AS[TONAJ TAAH] FROM dbo.BS_FATURA AS BS LEFT OUTER JOIN dbo.TTSPORTAL_CARIBILGI AS TCG ON TCG.CARIKOD = BS.CARIKOD LEFT OUTER JOIN BEKEN2010.dbo.LG_316_CLCARD AS CL ON CL.CODE = TCG.CARIKOD WHERE(BS.TARIH >= '2015-01-01') AND(BS.TARIH <= '2021-12-31') AND(TCG.MUSTERIISTASYON IN('SHELL', 'KORKUTELİ', 'AFYON', 'ATSO')) AND(CL.ACTIVE = 0)    AND TCG.SATISPERSONEL LIKE '%" + cmbSatisEleman.Text + "%'  GROUP BY TCG.CARIAD, BS.CARIKOD, TCG.SATISPERSONEL, TCG.TAAHHUTLITRE,TCG.CARIKOD ", connBizim);
                tblArama = new DataTable();
                adpArama.Fill(tblArama);
                this.grdVeri.DataSource = tblArama;
                this.grdVeri.DataBind();
                ViewState["dirState"] = tblArama;
                ViewState["sortdr"] = "Asc";
            }




        }
        else if (dpYil.SelectedItem.Text == "2021")
        {


            if (txtCariAd.Text != "")
            {

                connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);

                adpArama = new SqlDataAdapter("SELECT TCG.CARIKOD,TCG.CARIAD AS [FİRMA ÜNVAN], TCG.SATISPERSONEL AS [SATIŞ PERSONEL],(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-01-01') AND(TARIH <= '2021-01-31') AND(BS.CARIKOD = CARIKOD)) AS OCAK,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-02-01') AND(TARIH <= '2021-02-28') AND(BS.CARIKOD = CARIKOD)) AS ŞUBAT,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-03-01') AND(TARIH <= '2021-03-31') AND(BS.CARIKOD = CARIKOD)) AS MART,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-04-01') AND(TARIH <= '2021-04-30') AND(BS.CARIKOD = CARIKOD)) AS NİSAN,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-05-01') AND(TARIH <= '2021-05-31') AND(BS.CARIKOD = CARIKOD)) AS MAYIS,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-06-01') AND(TARIH <= '2021-06-30') AND(BS.CARIKOD = CARIKOD)) AS HAZİRAN,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-07-01') AND(TARIH <= '2021-07-31') AND(BS.CARIKOD = CARIKOD)) AS TEMMUZ, (SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-08-01') AND(TARIH <= '2021-08-31') AND(BS.CARIKOD = CARIKOD)) AS AĞUSTOS, (SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-09-01') AND(TARIH <= '2021-09-30') AND(BS.CARIKOD = CARIKOD)) AS EYLÜL, (SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM  dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-10-01') AND(TARIH <= '2021-10-31') AND(BS.CARIKOD = CARIKOD)) AS EKİM, (SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-11-01') AND(TARIH <= '2021-11-30') AND(BS.CARIKOD = CARIKOD)) AS KASIM,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-12-01') AND(TARIH <= '2021-12-31') AND(BS.CARIKOD = CARIKOD)) AS ARALIK, (SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-01-01') AND(TARIH <= '2021-12-31') AND(BS.CARIKOD = CARIKOD)) AS TOPLAM, TCG.TAAHHUTLITRE AS[TONAJ TAAH] FROM dbo.BS_FATURA AS BS LEFT OUTER JOIN dbo.TTSPORTAL_CARIBILGI AS TCG ON TCG.CARIKOD = BS.CARIKOD LEFT OUTER JOIN BEKEN2010.dbo.LG_316_CLCARD AS CL ON CL.CODE = TCG.CARIKOD WHERE(BS.TARIH >= '2015-01-01') AND(BS.TARIH <= '2021-12-31') AND(TCG.MUSTERIISTASYON IN('SHELL', 'KORKUTELİ', 'AFYON', 'ATSO')) AND(CL.ACTIVE = 0)  AND TCG.CARIAD LIKE '%" + txtCariAd.Text + "%'    GROUP BY TCG.CARIAD, BS.CARIKOD, TCG.SATISPERSONEL, TCG.TAAHHUTLITRE,TCG.CARIKOD ", connBizim);


                tblArama = new DataTable();
                adpArama.Fill(tblArama);
                this.grdVeri.DataSource = tblArama;
                this.grdVeri.DataBind();
                ViewState["dirState"] = tblArama;
                ViewState["sortdr"] = "Asc";
            }

            else if (cmbSatisEleman.Text != "")
            {

                connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);

                adpArama = new SqlDataAdapter("SELECT TCG.CARIKOD,TCG.CARIAD AS [FİRMA ÜNVAN], TCG.SATISPERSONEL AS [SATIŞ PERSONEL],(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-01-01') AND(TARIH <= '2021-01-31') AND(BS.CARIKOD = CARIKOD)) AS OCAK,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-02-01') AND(TARIH <= '2021-02-28') AND(BS.CARIKOD = CARIKOD)) AS ŞUBAT,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-03-01') AND(TARIH <= '2021-03-31') AND(BS.CARIKOD = CARIKOD)) AS MART,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-04-01') AND(TARIH <= '2021-04-30') AND(BS.CARIKOD = CARIKOD)) AS NİSAN,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-05-01') AND(TARIH <= '2021-05-31') AND(BS.CARIKOD = CARIKOD)) AS MAYIS,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-06-01') AND(TARIH <= '2021-06-30') AND(BS.CARIKOD = CARIKOD)) AS HAZİRAN,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-07-01') AND(TARIH <= '2021-07-31') AND(BS.CARIKOD = CARIKOD)) AS TEMMUZ, (SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-08-01') AND(TARIH <= '2021-08-31') AND(BS.CARIKOD = CARIKOD)) AS AĞUSTOS, (SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-09-01') AND(TARIH <= '2021-09-30') AND(BS.CARIKOD = CARIKOD)) AS EYLÜL, (SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM  dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-10-01') AND(TARIH <= '2021-10-31') AND(BS.CARIKOD = CARIKOD)) AS EKİM, (SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-11-01') AND(TARIH <= '2021-11-30') AND(BS.CARIKOD = CARIKOD)) AS KASIM,(SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM      dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-12-01') AND(TARIH <= '2021-12-31') AND(BS.CARIKOD = CARIKOD)) AS ARALIK, (SELECT ISNULL(SUM(MIKTAR), 0) AS Expr1 FROM dbo.BS_FATURA AS BSC WHERE(TARIH >= '2021-01-01') AND(TARIH <= '2021-12-31') AND(BS.CARIKOD = CARIKOD)) AS TOPLAM, TCG.TAAHHUTLITRE AS[TONAJ TAAH] FROM dbo.BS_FATURA AS BS LEFT OUTER JOIN dbo.TTSPORTAL_CARIBILGI AS TCG ON TCG.CARIKOD = BS.CARIKOD LEFT OUTER JOIN BEKEN2010.dbo.LG_316_CLCARD AS CL ON CL.CODE = TCG.CARIKOD WHERE(BS.TARIH >= '2015-01-01') AND(BS.TARIH <= '2021-12-31') AND(TCG.MUSTERIISTASYON IN('SHELL', 'KORKUTELİ', 'AFYON', 'ATSO')) AND(CL.ACTIVE = 0)  AND TCG.SATISPERSONEL LIKE '%" + cmbSatisEleman.Text + "%' GROUP BY TCG.CARIAD, BS.CARIKOD, TCG.SATISPERSONEL, TCG.TAAHHUTLITRE,TCG.CARIKOD  ", connBizim);


                tblArama = new DataTable();
                adpArama.Fill(tblArama);
                this.grdVeri.DataSource = tblArama;
                this.grdVeri.DataBind();
                ViewState["dirState"] = tblArama;
                ViewState["sortdr"] = "Asc";
            }
        }
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
            for (int i = 0; i < grdVeri.Rows.Count; i++)
            {
                for (int j = 2; j < 15; j++)
                {
                    decimal sayi = Convert.ToDecimal(grdVeri.Rows[i].Cells[j].Text);
                    grdVeri.Rows[i].Cells[j].Text = sayi.ToString("N");
                }
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
        if (e.Row.Cells.Count > indexOfColumn1)
        {
            e.Row.Cells[indexOfColumn1].Visible = false;
        }


        if (e.Row.Cells.Count > indexOfColumn)
        {
            e.Row.Cells[indexOfColumn].Width = 100;

        }
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
        SqlDataAdapter adpCariKod = new SqlDataAdapter("select CARIKOD from TTSPORTAL_CARIBILGI where CARIAD='" + cariAd + "'", connBizim);
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
}
