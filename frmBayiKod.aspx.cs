using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmBayiKod : System.Web.UI.Page
{
    SqlDataAdapter adpBayiKod, adpFirma, adpMusteriKod;
    DataTable tblBayiKod, tblFirma, tblMusteriKod;
    SqlConnection connBizim;
    string firma = "";
    string firmaYeni = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        if (!Page.IsPostBack)
        {


            adpMusteriKod = new SqlDataAdapter("select SHELLMUSTERIKOD from TTSPORTAL_CARIBILGI GROUP BY SHELLMUSTERIKOD", connBizim);
            tblMusteriKod = new DataTable();
            adpMusteriKod.Fill(tblMusteriKod);
            for (int i = 0; i < tblMusteriKod.Rows.Count; i++)
            {
                lstMusteriKod.Items.Add(tblMusteriKod.Rows[i][0].ToString());
            }



        }

    }

    protected void lstKodlar_SelectedIndexChanged(object sender, EventArgs e)
    {


        firma = lstFirmalar.SelectedValue.ToString();

        lstFirmalar.Items.Clear();
        adpFirma = new SqlDataAdapter("SELECT CARIAD FROM TTSPORTAL_CARIBILGI WHERE ANABAYIKOD='" + lstKodlar.SelectedValue.ToString() + "'", connBizim);
        tblFirma = new DataTable();
        adpFirma.Fill(tblFirma);
        //lstFirmalar.DataSource = tblFirma.;
        //lstFirmalar.DataBind();

        for (int i = 0; i < tblFirma.Rows.Count; i++)
        {
            // lstFirmalar.Items.Add();
            lstFirmalar.Items.Add(tblFirma.Rows[i][0].ToString());
        }
    }



    protected void btnDegistir_Click(object sender, EventArgs e)
    {
        if (txtYeniKod.Text != "")
        {

            SqlCommand cmdKodGuncelle = new SqlCommand("UPDATE TTSPORTAL_CARIBILGI SET ANABAYIKOD='" + txtYeniKod.Text + "' WHERE CARIAD='" + lstKodlar.Text + "'", connBizim);
            if (connBizim.State == ConnectionState.Closed)
            {
                connBizim.Open();
            }
            cmdKodGuncelle.ExecuteNonQuery();
            if (connBizim.State == ConnectionState.Open)
            {
                connBizim.Close();
            }
        }
    }


    protected void btnTumSag_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < lstFirmalar.Items.Count; i++)
        {
            lstTasinacakFirmalar.Items.Add(lstFirmalar.Items[i].Value.ToString());

        }
        lstFirmalar.Items.Clear();
    }

    protected void btnTumSol_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < lstTasinacakFirmalar.Items.Count; i++)
        {
            lstFirmalar.Items.Add(lstTasinacakFirmalar.Items[i].Value.ToString());

        }
        lstTasinacakFirmalar.Items.Clear();
    }

    protected void btnSag_Click(object sender, EventArgs e)
    {



        lstTasinacakFirmalar.Items.Add(firma.ToString());

        for (int i = 0; i < lstTasinacakFirmalar.Items.Count; i++)
        {
            lstFirmalar.Items.Remove(lstTasinacakFirmalar.Items[i].Text.ToString());
        }


        // index = 0;

    }
    protected void btnTasi_Click(object sender, EventArgs e)
    {
        if (txtYeniKod.Text != "")
        {
            for (int i = 0; i < lstTasinacakFirmalar.Items.Count; i++)
            {
                SqlCommand cmdTasi = new SqlCommand("UPDATE TTSPORTAL_CARIBILGI SET ANABAYIKOD='" + txtYeniKod.Text + "' WHERE CARIAD ='" + lstTasinacakFirmalar.Items[i].Text.ToString() + "'", connBizim);
                if (connBizim.State == ConnectionState.Closed)
                {
                    connBizim.Open();
                }
                cmdTasi.ExecuteNonQuery();
                if (connBizim.State == ConnectionState.Open)
                {
                    connBizim.Close();
                }
            }
        }
        Response.Redirect("frmBayiKod.aspx");
    }

    protected void btnSol_Click(object sender, EventArgs e)
    {
        firmaYeni = lstTasinacakFirmalar.SelectedValue.ToString();

        lstFirmalar.Items.Add(firmaYeni.ToString());



        lstTasinacakFirmalar.Items.Remove(firmaYeni.ToString());

    }



    protected void btnTasi_Click1(object sender, EventArgs e)
    {

    }

    protected void lstMusteriKod_SelectedIndexChanged(object sender, EventArgs e)
    {
        lstKodlar.Items.Clear();
        adpBayiKod = new SqlDataAdapter("select ANABAYIKOD from TTSPORTAL_CARIBILGI WHERE ANABAYIKOD<>'0' AND ANABAYIKOD <>'NULL' AND SHELLMUSTERIKOD='" + lstMusteriKod.SelectedValue.ToString() + "' GROUP BY ANABAYIKOD ORDER BY ANABAYIKOD", connBizim);
        tblBayiKod = new DataTable();
        adpBayiKod.Fill(tblBayiKod);
        for (int i = 0; i < tblBayiKod.Rows.Count; i++)
        {
            lstKodlar.Items.Add(tblBayiKod.Rows[i][0].ToString());
        }
    }

    protected void btnSorgula_Click(object sender, EventArgs e)
    {
        adpMusteriKod = new SqlDataAdapter("select SHELLMUSTERIKOD from TTSPORTAL_CARIBILGI WHERE   CARIAD LIKE '%" + txtMusteriAd.Text + "%' GROUP BY SHELLMUSTERIKOD", connBizim);
        tblMusteriKod = new DataTable();
        adpMusteriKod.Fill(tblMusteriKod);
        for (int i = 0; i < tblMusteriKod.Rows.Count; i++)
        {
            lstMusteriKod.Items.Add(tblMusteriKod.Rows[i][0].ToString());
        }
    }
}