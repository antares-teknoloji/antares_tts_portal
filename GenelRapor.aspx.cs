using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GenelRapor : System.Web.UI.Page
{
    SqlConnection connBizim;
    double kar;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Kullanici"].ToString() == "melih" || Session["Kullanici"].ToString() == "semih")
        {
            #region bağlantılar geliyor
            connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
            #endregion
            SqlCommand cmdSorgu = new SqlCommand();
            cmdSorgu.Connection = connBizim;
            cmdSorgu.CommandTimeout = 1800000000;
            cmdSorgu.CommandText = "GENEL_RAPOR_ANAEKRAN";
            //cmdSorgu.Parameters.AddWithValue("@TTS65", txt65.Text);

            cmdSorgu.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adpFirma = new SqlDataAdapter();
            adpFirma.SelectCommand = cmdSorgu;
            System.Data.DataTable tblFima = new System.Data.DataTable();
            adpFirma.Fill(tblFima);
            grdCari.DataSource = tblFima;
            grdCari.DataBind();
            //Attribute to show the Plus Minus Button.
            grdCari.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

            //Attribute to hide column in Phone.        
            //phone
            //tablet          bütün cihazlar için aynı sonucu "all" verir
            //all
            grdCari.HeaderRow.Cells[2].Attributes["data-hide"] = "all";
            grdCari.HeaderRow.Cells[3].Attributes["data-hide"] = "all";
            grdCari.HeaderRow.Cells[1].Attributes["data-hide"] = "all";
            grdCari.HeaderRow.Cells[4].Attributes["data-hide"] = "all";
            grdCari.HeaderRow.Cells[5].Attributes["data-hide"] = "all";
            grdCari.HeaderRow.Cells[6].Attributes["data-hide"] = "all";
            //Adds THEAD and TBODY to GridView.
            grdCari.HeaderRow.TableSection = TableRowSection.TableHeader;
            #region sayı alanları güncelleniyor
            for (int i = 0; i < grdCari.Rows.Count; i++)
            {
                if (grdCari.Rows[i].Cells[1].Text != "&nbsp;")
                {
                    decimal sayi = Convert.ToDecimal(grdCari.Rows[i].Cells[1].Text);
                    grdCari.Rows[i].Cells[1].Text = sayi.ToString("N");
                }
                if (grdCari.Rows[i].Cells[2].Text != "&nbsp;")
                {
                    decimal sayi1 = Convert.ToDecimal(grdCari.Rows[i].Cells[2].Text);
                    grdCari.Rows[i].Cells[2].Text = sayi1.ToString("N");
                }
                if (grdCari.Rows[i].Cells[3].Text != "&nbsp;")
                {
                    decimal sayi3 = Convert.ToDecimal(grdCari.Rows[i].Cells[3].Text);
                    grdCari.Rows[i].Cells[3].Text = sayi3.ToString("N");
                }
                if (grdCari.Rows[i].Cells[4].Text != "&nbsp;")
                {
                    decimal sayi4 = Convert.ToDecimal(grdCari.Rows[i].Cells[4].Text);
                    grdCari.Rows[i].Cells[4].Text = sayi4.ToString("N");
                }
                if (grdCari.Rows[i].Cells[5].Text != "&nbsp;")
                {
                    decimal sayi5 = Convert.ToDecimal(grdCari.Rows[i].Cells[5].Text);
                    grdCari.Rows[i].Cells[5].Text = sayi5.ToString("N");
                }
                if (grdCari.Rows[i].Cells[6].Text != "&nbsp;")
                {
                    decimal sayi6 = Convert.ToDecimal(grdCari.Rows[i].Cells[6].Text);
                    grdCari.Rows[i].Cells[6].Text = sayi6.ToString("N");
                }
                if (grdCari.Rows[i].Cells[7].Text != "&nbsp;")
                {
                    decimal sayi7 = Convert.ToDecimal(grdCari.Rows[i].Cells[7].Text);
                    grdCari.Rows[i].Cells[7].Text = sayi7.ToString("N");
                }
                if (grdCari.Rows[i].Cells[8].Text != "&nbsp;")
                {
                    decimal sayi8 = Convert.ToDecimal(grdCari.Rows[i].Cells[8].Text);
                    grdCari.Rows[i].Cells[8].Text = sayi8.ToString("N");
                }
                if (grdCari.Rows[i].Cells[9].Text != "&nbsp;")
                {
                    decimal sayi9 = Convert.ToDecimal(grdCari.Rows[i].Cells[9].Text);
                    grdCari.Rows[i].Cells[9].Text = sayi9.ToString("N");
                }
            }
            #endregion
            #region toplam kar geliyor
            for (int i = 0; i < grdCari.Rows.Count; i++)
            {
                if (grdCari.Rows[i].Cells[9].Text != "&nbsp;")
                {
                    kar += Convert.ToDouble(grdCari.Rows[i].Cells[9].Text);
                }
            }
            lblGenelToplamKar.Text = kar.ToString();
            #endregion

        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
    protected void btnArama_Click(object sender, EventArgs e)
    {

    }
}