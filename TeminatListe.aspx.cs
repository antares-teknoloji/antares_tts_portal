using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;


public partial class TeminatListe : System.Web.UI.Page
{
    SqlConnection connBizim;
    SqlDataAdapter adpVeri;
    DataTable tblVeri;
    SqlCommand cmdSil;
    string navigateURL;
    protected void Page_Load(object sender, EventArgs e)
    {
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        VeriGetir();
    }
    private void VeriGetir()
    {
        adpVeri = new SqlDataAdapter("SELECT ID,CARIKOD as [FİRMA KOD],CARIAD AS [FİRMA ÜNVAN],BANKAAD AS [BANKA AD],EVRAKNO AS [EVRAK NO],VADETARIHI AS [VADE TARİHİ],TUTAR,ACIKLAMA FROM TEMINAT_MEKTUP", connBizim);
        tblVeri = new DataTable();
        adpVeri.Fill(tblVeri);
        this.grdTeminat.DataSource = tblVeri;
        this.grdTeminat.DataBind();
    }
    protected void grdTeminat_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[2].Visible = false;
    }
    protected void grdTeminat_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdTeminat_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName == "Sil")
        //{
        //    int index = Convert.ToInt32(e.CommandArgument);
        //    GridViewRow gvRow = grdTeminat.Rows[index];
        //    int rowIndex = index;
        //    cmdSil = new SqlCommand("DELETE FROM TEMINAT_MEKTUP WHERE ID='" + grdTeminat.Rows[rowIndex].Cells[2].Text + "'", connBizim);
        //    if (connBizim.State == ConnectionState.Closed)
        //    { connBizim.Open(); }
        //    cmdSil.ExecuteNonQuery();
        //    if (connBizim.State == ConnectionState.Open)
        //    { connBizim.Close(); }
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('KAYIT SİLİNDİ');</script>");
        //    VeriGetir();
        //}
        if (e.CommandName == "Degistir")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow gvRow = grdTeminat.Rows[index];
            int rowIndex = index;
            string refs = grdTeminat.Rows[rowIndex].Cells[2].Text;
            Session["refs"] = refs.ToString();
            navigateURL = "TeminatDegistir.aspx";
            string target = "_blank";
            string windowProperties = "status=yes, menubar=yes, toolbar=yes";
            string scriptText = "window.open('" + navigateURL + "','" + target + "','" + windowProperties + "')";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "eşsizAnahtar", scriptText, true);
        }
    }
    protected void grdTeminat_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdTeminat_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {   
        cmdSil = new SqlCommand("DELETE FROM TEMINAT_MEKTUP WHERE ID='" + grdTeminat.Rows[e.RowIndex].Cells[2].Text + "'", connBizim);
        if (connBizim.State == ConnectionState.Closed)
        { connBizim.Open(); }
        cmdSil.ExecuteNonQuery();
        if (connBizim.State == ConnectionState.Open)
        { connBizim.Close(); }
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('KAYIT SİLİNDİ');</script>");
        VeriGetir();
    }
}