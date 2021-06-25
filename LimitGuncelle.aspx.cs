using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LimitGuncelle : System.Web.UI.Page
{
    SqlConnection connBizim;
    SqlConnection conn;
    SqlDataAdapter adpPlaka;
    DataTable tblPlaka;
    string musteriKod,bayi,kullanici,parola;
    int sayi;
    string plaka;
    System.Web.UI.WebControls.CheckBox c;
    System.Web.UI.WebControls.Label l;
    protected void Page_Load(object sender, EventArgs e)
    {
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        //if (!IsPostBack)
        //{ VeriCek(); }
        VeriCek();
    }
    private void VeriCek()
    {
        adpPlaka = new SqlDataAdapter("SELECT [SEÇİM]='',PLAKA,ISNULL(SUM(TOPLAMTUTAR),0) AS TUTAR,[LİMİT]='',[DURUM]='' " +
            "FROM BS_DBS WHERE TARIH>=CONVERT(DATETIME,'" + DateTime.Now.AddDays(-8) + "',104) " +
            "AND TARIH<=CONVERT(DATETIME,'" + DateTime.Now.AddDays(-1) + "',104) AND CARIKOD='" + Session["CariRef"] + "' " +
            "GROUP BY PLAKA ", connBizim);
        tblPlaka = new DataTable();
        adpPlaka.Fill(tblPlaka);
        this.grdPlaka.DataSource = tblPlaka;
        this.grdPlaka.DataBind();
        chkOlustur();
        //if (1 == 2)
        //{
        #region müşteri kodu bulunuyor
        conn.Open();
        SqlCommand cmdMusteriKod = new SqlCommand("SELECT BANKNAMES7 FROM LG_316_CLCARD WHERE CODE='" + Session["CariRef"].ToString() + "'", conn);
        SqlDataReader rdrMusteriKod = cmdMusteriKod.ExecuteReader();
        while (rdrMusteriKod.Read())
        {
            musteriKod = rdrMusteriKod[0].ToString();
        }
        conn.Close();
        #endregion
        #region plaka limitler geliyor
        for (int i = 0; i < grdPlaka.Rows.Count - 1; i++)
        {
            try
            {
                tts.TTSWebServicesSoapClient limit = new tts.TTSWebServicesSoapClient();
                tts.GETCARDLIMITDAYANDCOUNTRESULT tran = limit.GetCardLimitCountandDays("0011799164", "Admin", "Beken0202b", musteriKod, "", grdPlaka.Rows[i].Cells[4].Text, "11111111111111111111");
                grdPlaka.Rows[i].Cells[5].Text = tran.CARD_LIMITDAYANDCOUNT[0].monthly_limit.ToString();
            }
            catch (Exception)
            {

            }
        }
        #endregion
        #region yakıt alım durum geliyor
        #region ana bayi bilgileri geliyor
        SqlCommand cmdBilgi = new SqlCommand("SELECT BAYIKOD,KULLANICI,PAROLA FROM TTSSIFRE", connBizim);
        if (connBizim.State == ConnectionState.Closed)
        { connBizim.Open(); }
        SqlDataReader rdrBilgi = cmdBilgi.ExecuteReader();
        while (rdrBilgi.Read())
        {
            bayi = rdrBilgi[0].ToString();
            kullanici = rdrBilgi[1].ToString();
            parola = rdrBilgi[2].ToString();
        }
        if (connBizim.State == ConnectionState.Open)
        { connBizim.Close(); }
        #endregion
        for (int i = 0; i < grdPlaka.Rows.Count - 1; i++)
        {
            try
            {
                tts.TTSWebServicesSoapClient durum = new tts.TTSWebServicesSoapClient();
                tts.GETCARDSTATUSRESULT tran = durum.GetPlateStatus(bayi, kullanici, parola, musteriKod, grdPlaka.Rows[i].Cells[4].Text, "", "11111111111111111111");
                string deneme = tran.CARD_STATUS[0].card_status;
                grdPlaka.Rows[i].Cells[6].Text = tran.CARD_STATUS[0].card_status.ToString();
            }
            catch (Exception)
            {

            }
        }
        #endregion
        //}
    }
    public void chkOlustur()
    {
        if (grdPlaka.Rows.Count > 9)
        {
            for (int i = 0; i < grdPlaka.Rows.Count; i++)
            {
                System.Web.UI.WebControls.CheckBox c = new System.Web.UI.WebControls.CheckBox();
                c.ID = "chk_" + i.ToString();
                System.Web.UI.WebControls.Label l = new System.Web.UI.WebControls.Label();
                l.Text = tblPlaka.Rows[i]["SEÇİM"].ToString();
                l.Width = 20;
                c.Width = 20;
                grdPlaka.Rows[i].Cells[0].Controls.Add(c);
                grdPlaka.Rows[i].Cells[0].Controls.Add(l);
                grdPlaka.Rows[i].Cells[3].Enabled = false;
                sayi = i;
                c.AutoPostBack = true;
                c.CheckedChanged += c_CheckedChanged;
            }
        }
        else
        {
            for (int i = 0; i < grdPlaka.Rows.Count; i++)
            {
                c = new System.Web.UI.WebControls.CheckBox();
                c.ID = "chk_" + i.ToString();
                l = new System.Web.UI.WebControls.Label();
                l.Text = tblPlaka.Rows[i]["SEÇİM"].ToString();
                l.Width = 20;
                c.Width = 20;
                grdPlaka.Rows[i].Cells[0].Controls.Add(c);
                grdPlaka.Rows[i].Cells[0].Controls.Add(l);
                grdPlaka.Rows[i].Cells[3].Enabled = false;
                sayi = i;
                c.AutoPostBack = true;
                c.CheckedChanged += c_CheckedChanged;
            }
        }
    }
    void c_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < grdPlaka.Rows.Count; i++)
        {
            System.Web.UI.WebControls.CheckBox c = (System.Web.UI.WebControls.CheckBox)grdPlaka.Rows[i].Cells[0].FindControl("chk_" + i.ToString());
            if (c.Checked) // işaretlenen checkbox kontrolü, yapılcak işlem burada tanımlanacak.
            {
                grdPlaka.Rows[i].Cells[3].Enabled = true;
            }
        }
    }
    protected void btnAra_Click(object sender, EventArgs e)
    {

    }
    protected void btnIslem_Click(object sender, EventArgs e)
    {

    }
}