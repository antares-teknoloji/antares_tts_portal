using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CariBakiye : System.Web.UI.Page
{
    SqlConnection conn;
    SqlDataAdapter adpCari;
    DataTable tblCari;
    string navigateURL;
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
    }

    public SortDirection GridViewSortDirection
    {
        get
        {
            if (ViewState["sortDirection"] == null)
                ViewState["sortDirection"] = SortDirection.Ascending;

            return (SortDirection)ViewState["sortDirection"];
        }
        set { ViewState["sortDirection"] = value; }
    }
    protected void grdCari_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression;

        if (GridViewSortDirection == SortDirection.Ascending)
        {
            GridViewSortDirection = SortDirection.Descending;
            SortGridView(sortExpression, "DESCENDING");
        }
        else
        {
            GridViewSortDirection = SortDirection.Ascending;
            SortGridView(sortExpression, "ASCENDING");
        }
    }
    private void SortGridView(string sortExpression, string direction)
    {
        ////  You can cache the DataTable for improving performance
        //DataTable dt = GetData().Tables[0];

        //DataView dv = new DataView(dt);
        //dv.Sort = sortExpression + direction;

        //grdCari.DataSource = dv;
        //grdCari.DataBind();
    }
    protected void grdCari_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow gvRow = grdCari.Rows[index];
        int rowIndex = index;
        string cariAd = HttpUtility.HtmlDecode(grdCari.Rows[rowIndex].Cells[1].Text.ToString());
        string cariRef = grdCari.Rows[rowIndex].Cells[1].Text;
        Session["CariRef"] = cariRef.ToString();
        Session["CariAd"] = cariAd;

        if (e.CommandName == "DETAY")
        {
            navigateURL = "CariGenelBilgiler.aspx";
        }
        string target = "_blank";
        string windowProperties = "status=0, menubar=0, toolbar=0";
        string scriptText = "window.open('" + navigateURL + "','" + target + "')";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "eşsizAnahtar", scriptText, true);
    }
    protected void btnCariHesapListesi_Click(object sender, EventArgs e)
    {
        adpCari = new SqlDataAdapter("SELECT * FROM YENI_CARI_BAKIYE ORDER BY AÇIKLAMA", conn);
        tblCari = new DataTable();
        adpCari.Fill(tblCari);
        this.grdCari.DataSource = tblCari;
        this.grdCari.DataBind();
    }
}