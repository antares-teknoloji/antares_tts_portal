using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mYonetim : System.Web.UI.Page
{
    SqlConnection connBizim;
    SqlDataAdapter adpLimit;
    DataTable tblLimit;
    protected void Page_Load(object sender, EventArgs e)
    {
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        LimitCek();
    }
    private void LimitCek()
    {
        adpLimit = new SqlDataAdapter("SELECT ALIMTARIH,MUSTERIAD,BAKIYE,ALISLAR,TOPLAM,DBSOFFLINE,DBSONLINE,KALANLIMIT,DBSTARIH " +
            "FROM RESELLER_LIMIT WHERE KAYITTARIH=CONVERT(DATETIME,'" + DateTime.Now.ToString().Substring(0, 10).TrimEnd().TrimStart() + "',104)", connBizim);
        tblLimit = new DataTable();
        adpLimit.Fill(tblLimit);
        this.grdLimit.DataSource = tblLimit;
        this.grdLimit.DataBind();

        //Attribute to show the Plus Minus Button.
        grdLimit.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

        //Attribute to hide column in Phone.
        grdLimit.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
        grdLimit.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
        grdLimit.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
        grdLimit.HeaderRow.Cells[4].Attributes["data-hide"] = "phone";
        grdLimit.HeaderRow.Cells[5].Attributes["data-hide"] = "phone";
        grdLimit.HeaderRow.Cells[6].Attributes["data-hide"] = "phone";
        grdLimit.HeaderRow.Cells[7].Attributes["data-hide"] = "phone";
        grdLimit.HeaderRow.Cells[8].Attributes["data-hide"] = "phone";

        //Adds THEAD and TBODY to GridView.
        grdLimit.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    protected void btnAra_Click(object sender, EventArgs e)
    {
        adpLimit = new SqlDataAdapter("SELECT ALIMTARIH,MUSTERIAD,BAKIYE,ALISLAR,TOPLAM,DBSOFFLINE,DBSONLINE,KALANLIMIT,DBSTARIH " +
            "FROM RESELLER_LIMIT WHERE KAYITTARIH=CONVERT(DATETIME,'" + DateTime.Now.ToString().Substring(0, 10).TrimEnd().TrimStart() + "',104) AND MUSTERIAD LIKE '%" + txtCariAd.Text + "%'", connBizim);
        tblLimit = new DataTable();
        adpLimit.Fill(tblLimit);
        this.grdLimit.DataSource = tblLimit;
        this.grdLimit.DataBind();

        //Attribute to show the Plus Minus Button.
        grdLimit.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

        //Attribute to hide column in Phone.
        grdLimit.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
        grdLimit.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
        grdLimit.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
        grdLimit.HeaderRow.Cells[4].Attributes["data-hide"] = "phone";
        grdLimit.HeaderRow.Cells[5].Attributes["data-hide"] = "phone";
        grdLimit.HeaderRow.Cells[6].Attributes["data-hide"] = "phone";
        grdLimit.HeaderRow.Cells[7].Attributes["data-hide"] = "phone";
        grdLimit.HeaderRow.Cells[8].Attributes["data-hide"] = "phone";

        //Adds THEAD and TBODY to GridView.
        grdLimit.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}