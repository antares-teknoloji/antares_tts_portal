using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HbYakitDurum : System.Web.UI.Page
{
    SqlConnection conn;
    SqlDataAdapter adpKapali, adpAcik;
    DataTable tblKapali, tblAcik;
    SqlCommand cmdKapat, cmdAc;
    System.Web.UI.WebControls.CheckBox cacik, ckapali;
    System.Web.UI.WebControls.Label lacik, lkapali;
    int sayi;
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        VeriCek();
    }
    private void VeriCek()
    {
        #region açıklar geliyor
        adpAcik = new SqlDataAdapter("SELECT [SEÇ]='',CODE AS [CARİ KOD],DEFINITION_ " +
            "AS [CARİ AD],BANKBRANCHS1 AS [DURUM] FROM LG_316_CLCARD WHERE BANKBRANCHS1='ACIK'" +
            " AND ACTIVE=0 AND CODE LIKE '%120%' ORDER BY DEFINITION_", conn);
        tblAcik = new DataTable();
        adpAcik.Fill(tblAcik);
        this.grdAcik.DataSource = tblAcik;
        this.grdAcik.DataBind();
        chkOlusturAcik();
        #endregion
        #region kapalılar geliyor
        adpKapali = new SqlDataAdapter("SELECT [SEÇ]='',CODE AS [CARİ KOD],DEFINITION_ AS" +
            " [CARİ AD],BANKBRANCHS1 AS [DURUM] FROM LG_316_CLCARD WHERE BANKBRANCHS1='KAPALI' AND ACTIVE=0 " +
            "AND CODE LIKE '%120%' ORDER BY DEFINITION_", conn);
        tblKapali = new DataTable();
        adpKapali.Fill(tblKapali);
        this.grdKapali.DataSource = tblKapali;
        this.grdKapali.DataBind();
        chkOlusturKapali();
        #endregion
    }
    public void chkOlusturAcik()
    {
        for (int i = 0; i < grdAcik.Rows.Count; i++)
        {
            cacik = new System.Web.UI.WebControls.CheckBox();
            cacik.ID = "chk_" + i.ToString();
            lacik = new System.Web.UI.WebControls.Label();
            lacik.Text = tblAcik.Rows[i]["SEÇ"].ToString();
            lacik.Width = 20;
            cacik.Width = 20;
            grdAcik.Rows[i].Cells[0].Controls.Add(cacik);
            grdAcik.Rows[i].Cells[0].Controls.Add(lacik);
            //grdAcik.Rows[i].Cells[3].Enabled = false;
            sayi = i;
            //cacik.AutoPostBack = true;
            cacik.CheckedChanged += c_CheckedChanged;
        }
    }
    public void chkOlusturKapali()
    {
        for (int i = 0; i < grdKapali.Rows.Count; i++)
        {
            ckapali = new System.Web.UI.WebControls.CheckBox();
            ckapali.ID = "chk_" + i.ToString();
            lkapali = new System.Web.UI.WebControls.Label();
            lkapali.Text = tblKapali.Rows[i]["SEÇ"].ToString();
            lkapali.Width = 20;
            ckapali.Width = 20;
            grdKapali.Rows[i].Cells[0].Controls.Add(ckapali);
            grdKapali.Rows[i].Cells[0].Controls.Add(lkapali);
            //grdKapali.Rows[i].Cells[3].Enabled = false;
            //sayi = i;
            //ckapali.AutoPostBack = true;
            cacik.CheckedChanged += c_CheckedChanged;
        }
    }
    void c_CheckedChanged(object sender, EventArgs e)
    {
    }
    protected void btnAra_Click(object sender, EventArgs e)
    {
        #region açıklar geliyor
        adpAcik = new SqlDataAdapter("SELECT [SEÇ]='',CODE AS [CARİ KOD],DEFINITION_ AS [CARİ AD],BANKBRANCHS1 AS [DURUM] FROM LG_316_CLCARD WHERE BANKBRANCHS1='ACIK' AND ACTIVE=0 AND CODE LIKE '%120%' AND DEFINITION_ LIKE '%" + txtCari.Text + "%' ORDER BY DEFINITION_", conn);
        tblAcik = new DataTable();
        adpAcik.Fill(tblAcik);
        this.grdAcik.DataSource = tblAcik;
        this.grdAcik.DataBind();
        chkOlusturAcik();
        #endregion
        #region kapalılar geliyor
        adpKapali = new SqlDataAdapter("SELECT [SEÇ]='',CODE AS [CARİ KOD],DEFINITION_ AS [CARİ AD],BANKBRANCHS1 AS [DURUM] FROM LG_316_CLCARD WHERE BANKBRANCHS1='KAPALI' AND ACTIVE=0 AND CODE LIKE '%120%' AND DEFINITION_ LIKE '%" + txtCari.Text + "%' ORDER BY DEFINITION_", conn);
        tblKapali = new DataTable();
        adpKapali.Fill(tblKapali);
        this.grdKapali.DataSource = tblKapali;
        this.grdKapali.DataBind();
        chkOlusturKapali();
        #endregion
    }
    protected void btnAc_Click(object sender, EventArgs e)
    {

        for (int i = 0; i < grdKapali.Rows.Count; i++)
        {
            System.Web.UI.WebControls.CheckBox ckapali = (System.Web.UI.WebControls.CheckBox)grdKapali.Rows[i].Cells[0].FindControl("chk_" + i.ToString());
            if (ckapali.Checked == true)
            {
                cmdAc = new SqlCommand("UPDATE LG_316_CLCARD SET BANKBRANCHS1='ACIK' WHERE CODE='" + grdKapali.Rows[i].Cells[1].Text.ToString() + "'", conn);
                if (conn.State == ConnectionState.Closed)
                { conn.Open(); }
                cmdAc.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                { conn.Close(); }
            }
        }
        VeriCek();
    }
    protected void btnKapat_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < grdAcik.Rows.Count; i++)
        {
            System.Web.UI.WebControls.CheckBox cacik = (System.Web.UI.WebControls.CheckBox)grdAcik.Rows[i].Cells[0].FindControl("chk_" + i.ToString());
            if (cacik.Checked == true)
            {
                cmdKapat = new SqlCommand("UPDATE LG_316_CLCARD SET BANKBRANCHS1='KAPALI' WHERE CODE='" + grdAcik.Rows[i].Cells[1].Text.ToString() + "'", conn);
                if (conn.State == ConnectionState.Closed)
                { conn.Open(); }
                cmdKapat.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                { conn.Close(); }
            }
        }
        VeriCek();
    }
}