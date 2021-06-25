using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mCariKart : System.Web.UI.Page
{
    SqlConnection conn;
    SqlDataAdapter adpCari;
    DataTable tblCari;
    string navigateURL;
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        if (!IsPostBack)
        {
            VeriCek();
        }
        try
        {

            //Attribute to show the Plus Minus Button.
            grdCari.HeaderRow.Cells[2].Attributes["data-class"] = "expand";

            //Attribute to hide column in Phone.        
            grdCari.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
            grdCari.HeaderRow.Cells[0].Attributes["data-hide"] = "phone";
            grdCari.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
            grdCari.HeaderRow.Cells[4].Attributes["data-hide"] = "phone";
            grdCari.HeaderRow.Cells[5].Attributes["data-hide"] = "phone";
            grdCari.HeaderRow.Cells[6].Attributes["data-hide"] = "phone";
            grdCari.HeaderRow.Cells[8].Attributes["data-hide"] = "phone";
            grdCari.HeaderRow.Cells[7].Attributes["data-hide"] = "phone";
            //Adds THEAD and TBODY to GridView.
            grdCari.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch (Exception)
        {


        }
    }
    private void VeriCek()
    {
        adpCari = new SqlDataAdapter("SELECT TOP 10 CODE AS [CARİ KOD],DEFINITION_ AS [CARİ AD],DBSLIMIT2 " +
            "AS [MÜŞTERİ LİMİT],SPECODE3 AS [ÖDEME TÜR],BANKIBANS3 AS [BANKA KODU],BANKNAMES1 AS [VADE],TELNRS1" +
            " AS [TELEFON],BANKNAMES7 AS [FİLO KODU] FROM LG_316_CLCARD WHERE ACTIVE=0", conn);
        tblCari = new DataTable();
        adpCari.Fill(tblCari);
        this.grdCari.DataSource = tblCari;
        this.grdCari.DataBind();

        //Attribute to show the Plus Minus Button.
        grdCari.HeaderRow.Cells[2].Attributes["data-class"] = "expand";

        //Attribute to hide column in Phone.        
        grdCari.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
        grdCari.HeaderRow.Cells[0].Attributes["data-hide"] = "phone";
        grdCari.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
        grdCari.HeaderRow.Cells[4].Attributes["data-hide"] = "phone";
        grdCari.HeaderRow.Cells[5].Attributes["data-hide"] = "phone";
        grdCari.HeaderRow.Cells[6].Attributes["data-hide"] = "phone";
        grdCari.HeaderRow.Cells[8].Attributes["data-hide"] = "phone";
        grdCari.HeaderRow.Cells[7].Attributes["data-hide"] = "phone";


        //Adds THEAD and TBODY to GridView.
        grdCari.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    protected void btnAra_Click(object sender, EventArgs e)
    {
        adpCari = new SqlDataAdapter("SELECT  CODE AS [CARİ KOD],DEFINITION_ AS [CARİ AD],DBSLIMIT2 " +
            "AS [MÜŞTERİ LİMİT],SPECODE3 AS [ÖDEME TÜR],BANKIBANS3 AS [BANKA KODU],BANKNAMES1 AS [VADE],TELNRS1 " +
            "AS [TELEFON],BANKNAMES7 AS [FİLO KODU] FROM LG_316_CLCARD WHERE ACTIVE=0 AND DEFINITION_ LIKE '%" + txtCariAd.Text + "%'", conn);
        tblCari = new DataTable();
        adpCari.Fill(tblCari);
        this.grdCari.DataSource = tblCari;
        this.grdCari.DataBind();

        //Attribute to show the Plus Minus Button.
        grdCari.HeaderRow.Cells[2].Attributes["data-class"] = "expand";

        //Attribute to hide column in Phone.        
        grdCari.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
        grdCari.HeaderRow.Cells[0].Attributes["data-hide"] = "phone";
        grdCari.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
        grdCari.HeaderRow.Cells[4].Attributes["data-hide"] = "phone";
        grdCari.HeaderRow.Cells[5].Attributes["data-hide"] = "phone";
        grdCari.HeaderRow.Cells[6].Attributes["data-hide"] = "phone";
        grdCari.HeaderRow.Cells[8].Attributes["data-hide"] = "phone";
        grdCari.HeaderRow.Cells[7].Attributes["data-hide"] = "phone";


        //Adds THEAD and TBODY to GridView.
        grdCari.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    protected void grdCari_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow gvRow = grdCari.Rows[index];
        int rowIndex = index;
        string cariRef = grdCari.Rows[rowIndex].Cells[1].Text;
        Session["CariRef"] = cariRef.ToString();
        //Response.Redirect("CariGenelBilgiler.aspx");           
        navigateURL = "mCariGenelBilgiler.aspx";
        string target = "_blank";
        string windowProperties = "status=0, menubar=0, toolbar=0";
        string scriptText = "window.open('" + navigateURL + "','" + target + "')";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "eşsizAnahtar", scriptText, true);


        grdCari.HeaderRow.Cells[2].Attributes["data-class"] = "expand";

        //Attribute to hide column in Phone.        
        grdCari.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
        grdCari.HeaderRow.Cells[0].Attributes["data-hide"] = "phone";
        grdCari.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
        grdCari.HeaderRow.Cells[4].Attributes["data-hide"] = "phone";
        grdCari.HeaderRow.Cells[5].Attributes["data-hide"] = "phone";
        grdCari.HeaderRow.Cells[6].Attributes["data-hide"] = "phone";
        grdCari.HeaderRow.Cells[8].Attributes["data-hide"] = "phone";
        grdCari.HeaderRow.Cells[7].Attributes["data-hide"] = "phone";
        //Adds THEAD and TBODY to GridView.
        grdCari.HeaderRow.TableSection = TableRowSection.TableHeader;


    }
}