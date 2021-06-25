
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class YakitTakip : System.Web.UI.Page
{
    SqlConnection connBizim, conn;
    SqlDataAdapter adpVeri;
    DataTable tblVeri;
    string navigateURL;
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        if (dtTarih.Text == "")
        {
            VeriCek(DateTime.Now.AddDays(-1).ToString().Substring(0, 10).Trim(), txtCariAd.Text);
        }
        else
        {
            VeriCek(dtTarih.Text, txtCariAd.Text);
        }

    }

    private void VeriCek(string tarih, string cariad)
    {
        adpVeri = new SqlDataAdapter("SELECT CONVERT(DATETIME, ALIMTARIH,104) AS [SON ALIM TARİH],MUSTERIAD " +
            "AS [FİRMA],convert(varchar(50),cast(BAKIYE as money),1) AS [LOGO BAKİYE],convert(varchar(20),cast(ALISLAR as money),1) " +
            "AS [FATURALANMAMIŞ BAKİYE],convert(varchar(50),cast(TOPLAM as money),1) " +
            "AS [TOPLAM BAKİYE],convert(varchar(50),cast(DBSOFFLINE as money),1) AS [OFFLİNE LİMİT],convert(varchar(50),cast(DBSONLINE as money),1) " +
            "AS [ONLİNE LİMİT],[TOPLAM LİMİT]=convert(varchar(20),cast(((CAST (DBSOFFLINE AS DECIMAL(15,1))+CAST (DBSONLINE AS DECIMAL(15,1))))" +
            "as money),1),convert(varchar(20),cast(KALANLIMIT as money),1) AS [KALAN LİMİT], DBSTARIH AS [SON DBS TARİHİ]" +
            " FROM RESELLER_LIMIT  WHERE KAYITTARIH=CONVERT(DATETIME,'" + tarih + "',104) AND MUSTERIAD LIKE '%" + cariad + "%'", connBizim);
        tblVeri = new DataTable();
        adpVeri.Fill(tblVeri);
        this.grdVeri.DataSource = tblVeri;
        this.grdVeri.DataBind();
        for (int i = 0; i < grdVeri.Rows.Count - 1; i++)
        {
            string alimTarih = grdVeri.Rows[i].Cells[2].Text.ToString().Substring(0, 10).Trim();
            grdVeri.Rows[i].Cells[2].Text = alimTarih;

            string sonAlimTarih = grdVeri.Rows[i].Cells[11].Text.ToString().Substring(0, 10).Trim();
            grdVeri.Rows[i].Cells[11].Text = sonAlimTarih;

            string toplamLimit = grdVeri.Rows[i].Cells[9].Text.Replace(",", "");
            string kalanLimit = grdVeri.Rows[i].Cells[10].Text.Replace(",", "");

            if ((Convert.ToDouble(toplamLimit) * 0.1) > Convert.ToDouble(kalanLimit))
            {
                grdVeri.Rows[i].BackColor = Color.Yellow;
            }
            if (Convert.ToDouble(kalanLimit) < 1)
            {
                grdVeri.Rows[i].BackColor = Color.Red;
            }
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
        bool bIsConverted = Int32.TryParse(e.CommandArgument.ToString(), out index);
        GridViewRow gvRow = grdVeri.Rows[index];
        int rowIndex = index;
        string cariAd = HttpUtility.HtmlDecode(grdVeri.Rows[rowIndex].Cells[3].Text.ToString());
        //string cariRef = grdVeri.Rows[rowIndex].Cells[4].Text;

        #region cari kod bulunuyor
        SqlDataAdapter adpCariKod = new SqlDataAdapter("SELECT CODE FROM LG_316_CLCARD WHERE DEFINITION_='" + cariAd + "'", conn);
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
    }
    protected void btnArama_Click(object sender, EventArgs e)
    {
        if (dtTarih.Text == "")
        {
            VeriCek(DateTime.Now.AddDays(-1).ToString().Substring(0, 10).Trim(), txtCariAd.Text);
        }
        else
        {
            VeriCek(dtTarih.Text, txtCariAd.Text);
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
            grdVeri.DataSource = dtrslt;
            grdVeri.DataBind();

        }

    }
}