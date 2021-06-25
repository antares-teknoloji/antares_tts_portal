using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AkaryakitTeklifBilgi : System.Web.UI.Page
{
    SqlConnection connBizim;
    SqlDataAdapter adpDizel, adpBenzin, adpTotalDizel, adpTotalBenzin, adpLukoilDizel, adpLukoilBenzin, adpGiderKesinti;
    DataTable tblDizel, tblBenzin, tblTotalDizel, tblTotalBenzin, tblLukoilDizel, tblLukoilBenzin, tblGiderKesinti;
    SqlCommand cmdDizelEkle, cmdDizelSil, cmdBenzinEkle, cmdBenzinSil, cmdTotalDizelekle, cmdTotalDizelSil, cmdTotalBenzinekle, cmdTotalBenzinSil, cmdLukoilDizelEkle, cmdLukoilDizelSil, cmdLukoilBenzinEkle, cmdLukoilBenzinSil, cmdGiderKesintiGuncelle;
    System.Web.UI.WebControls.Label Sec;
    System.Web.UI.WebControls.CheckBox chkSec;
    protected void Page_Load(object sender, EventArgs e)
    {
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        if (!IsPostBack)
        {
            VeriCek();
            VeriCekBenzin();
            VeriCekTotalDizel();
            VeriCekTotalBenzin();
            VeriCekLukoilDizel();
            VeriCekLukoilBenzin();
            VeriCekGiderKesinti();
        }
    }
    private void VeriCekGiderKesinti()
    {
        adpGiderKesinti = new SqlDataAdapter("SELECT * FROM SATIS_GIDER_KESINTI", connBizim);
        tblGiderKesinti = new DataTable();
        adpGiderKesinti.Fill(tblGiderKesinti);
        txtShellKatkiPayi.Text = tblGiderKesinti.Rows[0][1].ToString();
        txtIstasyonGideri.Text = tblGiderKesinti.Rows[0][2].ToString();
        txtKrediKartiKomisyon.Text = tblGiderKesinti.Rows[0][3].ToString();
        txtShellKesinti.Text = tblGiderKesinti.Rows[0][4].ToString();
        txtBenzinDizelFark.Text = tblGiderKesinti.Rows[0][5].ToString();
        txtOdemeVadeKesinti.Text = tblGiderKesinti.Rows[0][6].ToString();

    }
    private void VeriCekLukoilBenzin()
    {
        adpLukoilBenzin = new SqlDataAdapter("SELECT [SEÇ]='',ID,LIMIT,KOD,ICISKONTO " +
            "AS [İÇ İSKONTO],DISISKONTO AS [DIŞ İSKONTO] FROM SATIS_LUKOIL_BENZIN_TEKLIF", connBizim);
        tblLukoilBenzin = new DataTable();
        adpLukoilBenzin.Fill(tblLukoilBenzin);
        grdLukoilBenzin.DataSource = tblLukoilBenzin;
        grdLukoilBenzin.DataBind();
        chkOlusturLukoilBenzin();
    }
    private void chkOlusturLukoilBenzin()
    {
        int sayi;
        for (int i = 0; i < grdLukoilBenzin.Rows.Count; i++)
        {
            chkSec = new System.Web.UI.WebControls.CheckBox();
            chkSec.ID = "chk_" + i.ToString();
            Sec = new System.Web.UI.WebControls.Label();
            Sec.Text = tblLukoilBenzin.Rows[i]["SEÇ"].ToString();
            Sec.Width = 20;
            chkSec.Width = 20;
            grdLukoilBenzin.Rows[i].Cells[0].Controls.Add(chkSec);
            grdLukoilBenzin.Rows[i].Cells[0].Controls.Add(Sec);
            //grdDizel.Rows[i].Cells[3].Enabled = false;
            sayi = i;
            //chkSec.AutoPostBack = true;
            chkSec.CheckedChanged += c_CheckedChanged;
        }
    }
    private void VeriCekLukoilDizel()
    {
        adpLukoilDizel = new SqlDataAdapter("SELECT [SEÇ]='',ID,LIMIT,KOD,ICISKONTO " +
            "AS [İÇ İSKONTO],DISISKONTO AS [DIŞ İSKONTO] FROM SATIS_LUKOIL_DIZEL_TEKLIF", connBizim);
        tblLukoilDizel = new DataTable();
        adpLukoilDizel.Fill(tblLukoilDizel);
        grdLukoilDizel.DataSource = tblLukoilDizel;
        grdLukoilDizel.DataBind();
        chkOlusturLukoilDizel();
    }
    private void chkOlusturLukoilDizel()
    {
        int sayi;
        for (int i = 0; i < grdLukoilDizel.Rows.Count; i++)
        {
            chkSec = new System.Web.UI.WebControls.CheckBox();
            chkSec.ID = "chk_" + i.ToString();
            Sec = new System.Web.UI.WebControls.Label();
            Sec.Text = tblLukoilDizel.Rows[i]["SEÇ"].ToString();
            Sec.Width = 20;
            chkSec.Width = 20;
            grdLukoilDizel.Rows[i].Cells[0].Controls.Add(chkSec);
            grdLukoilDizel.Rows[i].Cells[0].Controls.Add(Sec);
            //grdDizel.Rows[i].Cells[3].Enabled = false;
            sayi = i;
            //chkSec.AutoPostBack = true;
            chkSec.CheckedChanged += c_CheckedChanged;
        }
    }
    private void VeriCekTotalBenzin()
    {
        adpTotalBenzin = new SqlDataAdapter("SELECT [SEÇ]='',ID,LIMIT,KOD,ICISKONTO " +
            "AS [İÇ İSKONTO],DISISKONTO AS [DIŞ İSKONTO] FROM SATIS_TOTAL_TEKLIF_BENZIN", connBizim);
        tblTotalBenzin = new DataTable();
        adpTotalBenzin.Fill(tblTotalBenzin);
        grdTotalBenzin.DataSource = tblTotalBenzin;
        grdTotalBenzin.DataBind();
        chkOlusturTotalBenzin();
    }
    private void chkOlusturTotalBenzin()
    {
        int sayi;
        for (int i = 0; i < grdTotalBenzin.Rows.Count; i++)
        {
            chkSec = new System.Web.UI.WebControls.CheckBox();
            chkSec.ID = "chk_" + i.ToString();
            Sec = new System.Web.UI.WebControls.Label();
            Sec.Text = tblTotalBenzin.Rows[i]["SEÇ"].ToString();
            Sec.Width = 20;
            chkSec.Width = 20;
            grdTotalBenzin.Rows[i].Cells[0].Controls.Add(chkSec);
            grdTotalBenzin.Rows[i].Cells[0].Controls.Add(Sec);
            //grdDizel.Rows[i].Cells[3].Enabled = false;
            sayi = i;
            //chkSec.AutoPostBack = true;
            chkSec.CheckedChanged += c_CheckedChanged;
        }
    }
    private void VeriCekTotalDizel()
    {
        adpTotalDizel = new SqlDataAdapter("SELECT [SEÇ]='',ID,LIMIT,KOD,ICISKONTO " +
            "AS [İÇ İSKONTO],DISISKONTO AS [DIŞ İSKONTO] FROM SATIS_TOTAL_TEKLIF_DIZEL", connBizim);
        tblTotalDizel = new DataTable();
        adpTotalDizel.Fill(tblTotalDizel);
        grdTotalDizel.DataSource = tblTotalDizel;
        grdTotalDizel.DataBind();
        chkOlusturTotalDizel();
    }
    private void chkOlusturTotalDizel()
    {
        int sayi;
        for (int i = 0; i < grdTotalDizel.Rows.Count; i++)
        {
            chkSec = new System.Web.UI.WebControls.CheckBox();
            chkSec.ID = "chk_" + i.ToString();
            Sec = new System.Web.UI.WebControls.Label();
            Sec.Text = tblTotalDizel.Rows[i]["SEÇ"].ToString();
            Sec.Width = 20;
            chkSec.Width = 20;
            grdTotalDizel.Rows[i].Cells[0].Controls.Add(chkSec);
            grdTotalDizel.Rows[i].Cells[0].Controls.Add(Sec);
            //grdDizel.Rows[i].Cells[3].Enabled = false;
            sayi = i;
            //chkSec.AutoPostBack = true;
            chkSec.CheckedChanged += c_CheckedChanged;
        }
    }
    private void VeriCekBenzin()
    {
        adpBenzin = new SqlDataAdapter("SELECT [SEÇ]='',ID,LIMIT,KOD,ICISKONTO " +
            "AS [İÇ İSKONTO],DISISKONTO AS [DIŞ İSKONTO] FROM SATIS_TEKLIF_BENZIN", connBizim);
        tblBenzin = new DataTable();
        adpBenzin.Fill(tblBenzin);
        grdBenzin.DataSource = tblBenzin;
        grdBenzin.DataBind();
        chkOlusturBenzin();
    }
    private void VeriCek()
    {
        adpDizel = new SqlDataAdapter("SELECT [SEÇ]='',ID,LIMIT,KOD FROM SATIS_TEKLIF_DIZEL", connBizim);
        tblDizel = new DataTable();
        adpDizel.Fill(tblDizel);
        grdDizel.DataSource = tblDizel;
        grdDizel.DataBind();
        chkOlustur();
        //grdDizel.Columns[1].Visible = false;
    }
    protected void btnEkle_Click(object sender, EventArgs e)
    {
        cmdDizelEkle = new SqlCommand("INSERT INTO SATIS_TEKLIF_DIZEL (LIMIT,KOD) VALUES (@LIMIT,@KOD)", connBizim);
        cmdDizelEkle.Parameters.AddWithValue("@LIMIT", txtLimit.Text);
        cmdDizelEkle.Parameters.AddWithValue("@KOD", txtKod.Text);
        connBizim.Open();
        cmdDizelEkle.ExecuteNonQuery();
        connBizim.Close();
        Response.Redirect("AkaryakitTeklifBilgi.aspx");
    }
    public void chkOlusturBenzin()
    {
        int sayi;
        for (int i = 0; i < grdBenzin.Rows.Count; i++)
        {
            chkSec = new System.Web.UI.WebControls.CheckBox();
            chkSec.ID = "chk_" + i.ToString();
            Sec = new System.Web.UI.WebControls.Label();
            Sec.Text = tblBenzin.Rows[i]["SEÇ"].ToString();
            Sec.Width = 20;
            chkSec.Width = 20;
            grdBenzin.Rows[i].Cells[0].Controls.Add(chkSec);
            grdBenzin.Rows[i].Cells[0].Controls.Add(Sec);
            //grdDizel.Rows[i].Cells[3].Enabled = false;
            sayi = i;
            //chkSec.AutoPostBack = true;
            chkSec.CheckedChanged += c_CheckedChanged;
        }
    }
    public void chkOlustur()
    {
        int sayi;
        for (int i = 0; i < grdDizel.Rows.Count; i++)
        {
            chkSec = new System.Web.UI.WebControls.CheckBox();
            chkSec.ID = "chk_" + i.ToString();
            Sec = new System.Web.UI.WebControls.Label();
            Sec.Text = tblDizel.Rows[i]["SEÇ"].ToString();
            Sec.Width = 20;
            chkSec.Width = 20;
            grdDizel.Rows[i].Cells[0].Controls.Add(chkSec);
            grdDizel.Rows[i].Cells[0].Controls.Add(Sec);
            //grdDizel.Rows[i].Cells[3].Enabled = false;
            sayi = i;
            //chkSec.AutoPostBack = true;
            chkSec.CheckedChanged += c_CheckedChanged;
        }
    }
    void c_CheckedChanged(object sender, EventArgs e)
    {
    }
    protected void btnSil_Click(object sender, EventArgs e)
    {

        for (int i = 0; i < grdDizel.Rows.Count; i++)
        {
            System.Web.UI.WebControls.CheckBox chkSec = (System.Web.UI.WebControls.CheckBox)grdDizel.Rows[i].Cells[0].FindControl("chk_" + i.ToString());
            if (chkSec.Checked == true)
            {
                cmdDizelSil = new SqlCommand("DELETE FROM SATIS_TEKLIF_DIZEL WHERE ID='" + grdDizel.Rows[i].Cells[1].Text.ToString() + "'", connBizim);
                connBizim.Open();
                cmdDizelSil.ExecuteNonQuery();
                connBizim.Close();
                VeriCek();
            }
        }
    }
    protected void grdDizel_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
    }
    protected void btnTotalDizelEkle_Click(object sender, EventArgs e)
    {
        cmdTotalDizelekle = new SqlCommand("INSERT INTO SATIS_TOTAL_TEKLIF_DIZEL (LIMIT,KOD,ICISKONTO,DISISKONTO) " +
            "VALUES (@LIMIT,@KOD,@ICISKONTO,@DISISKONTO)", connBizim);
        cmdTotalDizelekle.Parameters.AddWithValue("@LIMIT", txtTotalDizelLimit.Text);
        cmdTotalDizelekle.Parameters.AddWithValue("@KOD", txtTotalDizelKod.Text);
        cmdTotalDizelekle.Parameters.AddWithValue("@ICISKONTO", txtTotalDizelIcIskonto.Text);
        cmdTotalDizelekle.Parameters.AddWithValue("@DISISKONTO", txtTotalDizelDisIskonto.Text);
        connBizim.Open();
        cmdTotalDizelekle.ExecuteNonQuery();
        connBizim.Close();
        Response.Redirect("AkaryakitTeklifBilgi.aspx");
    }
    protected void btnBenzinEkle_Click(object sender, EventArgs e)
    {
        cmdBenzinEkle = new SqlCommand("INSERT INTO SATIS_TEKLIF_BENZIN (LIMIT,KOD,ICISKONTO,DISISKONTO)" +
            " VALUES (@LIMIT,@KOD,@ICISKONTO,@DISISKONTO)", connBizim);
        cmdBenzinEkle.Parameters.AddWithValue("@LIMIT", txtBenzinLimit.Text);
        cmdBenzinEkle.Parameters.AddWithValue("@KOD", txtBenzinKod.Text);
        cmdBenzinEkle.Parameters.AddWithValue("@ICISKONTO", txtBenzinIcIskonto.Text);
        cmdBenzinEkle.Parameters.AddWithValue("@DISISKONTO", txtBenzinDisIskonto.Text);
        connBizim.Open();
        cmdBenzinEkle.ExecuteNonQuery();
        connBizim.Close();
        Response.Redirect("AkaryakitTeklifBilgi.aspx");
    }
    protected void btnTotalDizelSil_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < grdTotalDizel.Rows.Count; i++)
        {
            System.Web.UI.WebControls.CheckBox chkSec = (System.Web.UI.WebControls.CheckBox)grdTotalDizel.Rows[i].Cells[0].FindControl("chk_" + i.ToString());
            if (chkSec.Checked == true)
            {
                cmdTotalDizelSil = new SqlCommand("DELETE FROM SATIS_TOTAL_TEKLIF_DIZEL WHERE ID='" + grdTotalDizel.Rows[i].Cells[1].Text.ToString() + "'", connBizim);
                connBizim.Open();
                cmdTotalDizelSil.ExecuteNonQuery();
                connBizim.Close();
                Response.Redirect("AkaryakitTeklifBilgi.aspx");
            }
        }
    }
    protected void btnBenzinSil_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < grdBenzin.Rows.Count; i++)
        {
            System.Web.UI.WebControls.CheckBox chkSec = (System.Web.UI.WebControls.CheckBox)grdBenzin.Rows[i].Cells[0].FindControl("chk_" + i.ToString());
            if (chkSec.Checked == true)
            {
                cmdBenzinSil = new SqlCommand("DELETE FROM SATIS_TEKLIF_BENZIN WHERE ID='" + grdBenzin.Rows[i].Cells[1].Text.ToString() + "'", connBizim);
                connBizim.Open();
                cmdBenzinSil.ExecuteNonQuery();
                connBizim.Close();
                Response.Redirect("AkaryakitTeklifBilgi.aspx");
            }
        }
    }
    protected void btnTotalBenzinEkle_Click(object sender, EventArgs e)
    {
        cmdTotalBenzinekle = new SqlCommand("INSERT INTO SATIS_TOTAL_TEKLIF_BENZIN (LIMIT,KOD,ICISKONTO,DISISKONTO) " +
            "VALUES (@LIMIT,@KOD,@ICISKONTO,@DISISKONTO)", connBizim);
        cmdTotalBenzinekle.Parameters.AddWithValue("@LIMIT", txtTotalBenzinLimit.Text);
        cmdTotalBenzinekle.Parameters.AddWithValue("@KOD", txtTotalBenzinKod.Text);
        cmdTotalBenzinekle.Parameters.AddWithValue("@ICISKONTO", txtTotalBenzinIcIskonto.Text);
        cmdTotalBenzinekle.Parameters.AddWithValue("@DISISKONTO", txtTotalBenzinDisIskonto.Text);
        connBizim.Open();
        cmdTotalBenzinekle.ExecuteNonQuery();
        connBizim.Close();
        Response.Redirect("AkaryakitTeklifBilgi.aspx");
    }
    protected void btnTotalBenzinSil_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < grdTotalBenzin.Rows.Count; i++)
        {
            System.Web.UI.WebControls.CheckBox chkSec = (System.Web.UI.WebControls.CheckBox)grdTotalBenzin.Rows[i].Cells[0].FindControl("chk_" + i.ToString());
            if (chkSec.Checked == true)
            {
                cmdTotalBenzinSil = new SqlCommand("DELETE FROM SATIS_TOTAL_TEKLIF_BENZIN WHERE ID='" + grdTotalBenzin.Rows[i].Cells[1].Text.ToString() + "'", connBizim);
                connBizim.Open();
                cmdTotalBenzinSil.ExecuteNonQuery();
                connBizim.Close();
                Response.Redirect("AkaryakitTeklifBilgi.aspx");
            }
        }
    }
    protected void btnLukoilDizelEkle_Click(object sender, EventArgs e)
    {
        cmdLukoilDizelEkle = new SqlCommand("INSERT INTO SATIS_LUKOIL_DIZEL_TEKLIF (LIMIT,KOD,ICISKONTO,DISISKONTO) " +
            "VALUES (@LIMIT,@KOD,@ICISKONTO,@DISISKONTO)", connBizim);
        cmdLukoilDizelEkle.Parameters.AddWithValue("@LIMIT", txtLukoilDizelLimit.Text);
        cmdLukoilDizelEkle.Parameters.AddWithValue("@KOD", txtLukoilDizelKod.Text);
        cmdLukoilDizelEkle.Parameters.AddWithValue("@ICISKONTO", txtLukoilDizelIcIskonto.Text);
        cmdLukoilDizelEkle.Parameters.AddWithValue("@DISISKONTO", txtLukoilDizelDisIskonto.Text);
        connBizim.Open();
        cmdLukoilDizelEkle.ExecuteNonQuery();
        connBizim.Close();
        Response.Redirect("AkaryakitTeklifBilgi.aspx");
    }
    protected void btnLukoilDizelSil_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < grdLukoilDizel.Rows.Count; i++)
        {
            System.Web.UI.WebControls.CheckBox chkSec = (System.Web.UI.WebControls.CheckBox)grdLukoilDizel.Rows[i].Cells[0].FindControl("chk_" + i.ToString());
            if (chkSec.Checked == true)
            {
                cmdLukoilDizelSil = new SqlCommand("DELETE FROM SATIS_LUKOIL_DIZEL_TEKLIF WHERE ID='" + grdLukoilDizel.Rows[i].Cells[1].Text.ToString() + "'", connBizim);
                connBizim.Open();
                cmdLukoilDizelSil.ExecuteNonQuery();
                connBizim.Close();
                Response.Redirect("AkaryakitTeklifBilgi.aspx");
            }
        }
    }
    protected void btnLukoilBenzinEkle_Click(object sender, EventArgs e)
    {
        cmdLukoilBenzinEkle = new SqlCommand("INSERT INTO SATIS_LUKOIL_BENZIN_TEKLIF (LIMIT,KOD,ICISKONTO,DISISKONTO) VALUES (@LIMIT,@KOD,@ICISKONTO,@DISISKONTO)", connBizim);
        cmdLukoilBenzinEkle.Parameters.AddWithValue("@LIMIT", txtLukoilBenzinLimit.Text);
        cmdLukoilBenzinEkle.Parameters.AddWithValue("@KOD", txtLukoilBenzinKod.Text);
        cmdLukoilBenzinEkle.Parameters.AddWithValue("@ICISKONTO", txtLukoilBenzinIcIskonto.Text);
        cmdLukoilBenzinEkle.Parameters.AddWithValue("@DISISKONTO", txtLukoilBenzinDisIskonto.Text);
        connBizim.Open();
        cmdLukoilBenzinEkle.ExecuteNonQuery();
        connBizim.Close();
        Response.Redirect("AkaryakitTeklifBilgi.aspx");
    }
    protected void btnLukoilBenzinSil_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < grdLukoilBenzin.Rows.Count; i++)
        {
            System.Web.UI.WebControls.CheckBox chkSec = (System.Web.UI.WebControls.CheckBox)grdLukoilBenzin.Rows[i].Cells[0].FindControl("chk_" + i.ToString());
            if (chkSec.Checked == true)
            {
                cmdLukoilBenzinSil = new SqlCommand("DELETE FROM SATIS_LUKOIL_BENZIN_TEKLIF WHERE ID='" + grdLukoilBenzin.Rows[i].Cells[1].Text.ToString() + "'", connBizim);
                connBizim.Open();
                cmdLukoilBenzinSil.ExecuteNonQuery();
                connBizim.Close();
                Response.Redirect("AkaryakitTeklifBilgi.aspx");
            }
        }
    }
    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        cmdGiderKesintiGuncelle = new SqlCommand("UPDATE SATIS_GIDER_KESINTI SET SHELLKATKIPAYI=@SHELLKATKIPAYI,ISTASYONGIDERI=@ISTASYONGIDERI," +
            "KREDIKARTIKOMISYONU=@KREDIKARTIKOMISYONU,SHELLKESINTI=@SHELLKESINTI,BENZINDIZEL=@BENZINDIZEL,ODEMEVADEKESINTI=@ODEMEVADEKESINTI", connBizim);
        cmdGiderKesintiGuncelle.Parameters.AddWithValue("@SHELLKATKIPAYI", Convert.ToDouble(txtShellKatkiPayi.Text));
        cmdGiderKesintiGuncelle.Parameters.AddWithValue("@ISTASYONGIDERI", Convert.ToDouble(txtIstasyonGideri.Text));
        cmdGiderKesintiGuncelle.Parameters.AddWithValue("@KREDIKARTIKOMISYONU", Convert.ToDouble(txtKrediKartiKomisyon.Text));
        cmdGiderKesintiGuncelle.Parameters.AddWithValue("@SHELLKESINTI", Convert.ToDouble(txtShellKesinti.Text));
        cmdGiderKesintiGuncelle.Parameters.AddWithValue("@BENZINDIZEL", Convert.ToDouble(txtBenzinDizelFark.Text));
        cmdGiderKesintiGuncelle.Parameters.AddWithValue("@ODEMEVADEKESINTI", Convert.ToDouble(txtOdemeVadeKesinti.Text));
        connBizim.Open();
        cmdGiderKesintiGuncelle.ExecuteNonQuery();
        connBizim.Close();
        Response.Redirect("AkaryakitTeklifBilgi.aspx");
    }
}