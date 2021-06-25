using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AylıkMusteriAlım : System.Web.UI.Page
{
    SqlConnection connBizim;
    SqlDataAdapter adpVeri;
    protected void Page_Load(object sender, EventArgs e)
    {
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
    }

    protected void btnSorgula_Click(object sender, EventArgs e)
    {

        SqlCommand cmdSorgu = new SqlCommand();
        cmdSorgu.Connection = connBizim;
        cmdSorgu.CommandTimeout = 1800000000;
        if (dpTur.Text == "TL")
        {
            cmdSorgu.CommandText = "FIRMAKARLILIK_SHEL_2020_TL";
        }
        else
        {
            cmdSorgu.CommandText = "FIRMAKARLILIK_SHEL_2020_LITRE";

        }
        //cmdSorgu.Parameters.AddWithValue("@TTS6", txt775.Text);
        cmdSorgu.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adpFirmaKarDiger = new SqlDataAdapter();
        adpFirmaKarDiger.SelectCommand = cmdSorgu;
        System.Data.DataTable tblFirmaKarDiger = new System.Data.DataTable();
        adpFirmaKarDiger.Fill(tblFirmaKarDiger);
        grdVeri.DataSource = tblFirmaKarDiger;
        grdVeri.DataBind();
        ViewState["dirState"] = tblFirmaKarDiger;
        ViewState["sortdr"] = "Asc";
        for (int i = 0; i < grdVeri.Rows.Count; i++)
        {
            for (int j = 1; j < 40; j++)
            {
                decimal sayi = Convert.ToDecimal(grdVeri.Rows[i].Cells[j].Text);
                grdVeri.Rows[i].Cells[j].Text = sayi.ToString("N");
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


        }

    }
}