using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cari_Sec : System.Web.UI.Page
{
    SqlConnection conn;
    SqlDataAdapter adpCari;
    DataTable tblCari;
    protected void Page_Load(object sender, EventArgs e)
    {       
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        if (!IsPostBack)
        VeriCek();
    }
    private void VeriCek()
    {
        adpCari = new SqlDataAdapter("SELECT CODE AS [CARİ KOD],DEFINITION_ AS [CARİ AD] FROM LG_316_CLCARD WHERE ACTIVE=0", conn);
        tblCari = new DataTable();
        adpCari.Fill(tblCari);
        grdCari.DataSource = tblCari;
        grdCari.DataBind();
    }
    protected void grdPlaka_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void btnAra_Click(object sender, EventArgs e)
    {
        adpCari = new SqlDataAdapter("SELECT CODE AS [CARİ KOD],DEFINITION_ AS [CARİ AD] FROM LG_316_CLCARD WHERE ACTIVE=0  " +
            "AND CODE LIKE '%" + txtCariKod.Text + "%' AND DEFINITION_ LIKE '%" + txtCariAd.Text + "%'", conn);
        tblCari = new DataTable();
        adpCari.Fill(tblCari);
        grdCari.DataSource = tblCari;
        grdCari.DataBind();
    }
}