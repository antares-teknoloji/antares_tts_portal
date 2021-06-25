using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class YakitBloke : System.Web.UI.Page
{
    SqlConnection conn;
    SqlConnection connBizim;
    DataTable tblPlaka;
    SqlDataAdapter adpPlaka;
    SqlCommand cmdLimit;
    string musteriKod, bayi, kullanici, parola;
    string plaka;
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
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
      
        if (!IsPostBack)
        { VeriCek(); }
        #region limit çekiliyor
        cmdLimit = new SqlCommand("SELECT DBSLIMIT2,DBSLIMIT1 FROM LG_316_CLCARD WHERE CODE='" + Session["CariRef"] + "'", conn);
        conn.Open();
        SqlDataReader rdrLimit = cmdLimit.ExecuteReader();
        while (rdrLimit.Read())
        {
            lblOfflineLimit.Text = rdrLimit[0].ToString();
            lblOnlineLimit.Text = rdrLimit[1].ToString();
        }
        conn.Close();
        #endregion
    }
    private void VeriCek()
    {
        adpPlaka = new SqlDataAdapter("SELECT ID,LOGICALREF,CARIKOD AS [CARİ KOD],PLAKA,[LİMİT]='',[DURUM]='' FROM BS_PLAKA WHERE CARIKOD='" + Session["CariRef"] + "'", connBizim);
        tblPlaka = new DataTable();
        adpPlaka.Fill(tblPlaka);
        this.grdPlaka.DataSource = tblPlaka;
        this.grdPlaka.DataBind();
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
                tts.GETCARDLIMITDAYANDCOUNTRESULT tran = limit.GetCardLimitCountandDays(bayi, kullanici, parola, musteriKod, "", grdPlaka.Rows[i].Cells[4].Text, "11111111111111111111");
                grdPlaka.Rows[i].Cells[5].Text = tran.CARD_LIMITDAYANDCOUNT[0].monthly_limit.ToString();
            }
            catch (Exception)
            {

            }
        }
        #endregion
        #region yakıt alım durum geliyor
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
    }
    protected void chkSec_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow satirbilgi in grdPlaka.Rows)
        {
            CheckBox chk = (CheckBox)satirbilgi.FindControl("chkSecim");
            if (chkSec.Checked == true)
            { chk.Checked = true; }
            else
            {
                chk.Checked = false;
            }
        }
    }
    protected void grdPlaka_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
    }
    protected void btnIslem_Click(object sender, EventArgs e)
    {
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
        foreach (GridViewRow satirbilgi in grdPlaka.Rows)
        {
            CheckBox chk = (CheckBox)satirbilgi.FindControl("chkSecim");
            if (chk.Checked == true)
            {
                plaka = satirbilgi.Cells[4].Text;
                if (plaka != "")
                {
                    tts.TTSWebServicesSoapClient plakaKapama = new tts.TTSWebServicesSoapClient();
                    tts.SETCARDSTATUSRESULT pro = plakaKapama.SetPlateStatus(bayi, kullanici, parola, musteriKod, plaka, "2", "10", "11111111111111111111");
                    if (pro.PROCESSRESULT.Success == true)
                    {

                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + pro.PROCESSRESULT.Message.ToString() + "');</script>");
                    }
                }
            }
        }
    }
}