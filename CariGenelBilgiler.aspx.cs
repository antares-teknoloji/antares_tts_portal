using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CariGenelBilgiler : System.Web.UI.Page
{
    SqlConnection conn, connBizim;
    SqlCommand cmdMukellef;
    SqlDataAdapter adpBankaAd, adpVeri;
    DataTable tblBankaAd, tblVeri;
    string mukellef;
    string navigateURL;
    SqlDataReader reader;

    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        if (!IsPostBack)
        {
            Sektordropdown();
            Cıkısdropdown();
            rdpBayi.SelectedIndex = 0;
            VeriCek();
            DosyaCek();

            TeminatMektupCek();
            TahsilatTur();
            #region banka adları geliyor
            adpBankaAd = new SqlDataAdapter("SELECT DEFINITION_ FROM LG_316_BNCARD", conn);
            tblBankaAd = new DataTable();
            adpBankaAd.Fill(tblBankaAd);
            foreach (DataRow item in tblBankaAd.Rows)
            {
                cmbBankaAd.Items.Add(item[0].ToString());
                cmbBankaAd2.Items.Add(item[0].ToString());
            }
            #endregion
            #region kullanıcı yetki
            if (Session["Kullanici"].ToString() == "melih")
            {
                btnKaydet.Enabled = true;
                btnSil.Enabled = true;
                btnIndir.Enabled = true;
                btnGuncelle.Enabled = true;
                btnGuncelle1.Enabled = true;
            }
            else if (Session["Kullanici"].ToString() == "volkan")
            {
                btnKaydet.Enabled = true;
                btnSil.Enabled = true;
                btnIndir.Enabled = true;
                btnGuncelle.Enabled = true;
                btnGuncelle1.Enabled = true;

            }

            #endregion
            #region mükellef durum alınıyor
            cmdMukellef = new SqlCommand("select MAX(INV.LOGICALREF), INV.EINVOICE from LG_316_CLCARD CL LEFT OUTER JOIN LG_316_01_INVOICE INV " +
                "ON INV.CLIENTREF=CL.LOGICALREF WHERE CL.CODE='" + Session["CariRef"].ToString() + "' AND INV.TRCODE IN (7,8) GROUP BY INV.EINVOICE", conn);
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            SqlDataReader rdrMukellef = cmdMukellef.ExecuteReader();
            while (rdrMukellef.Read())
            {
                mukellef = rdrMukellef[1].ToString();
            }
            if (conn.State == ConnectionState.Open)
            { conn.Close(); }
            if (mukellef == "1")
            {
                txtFaturaTur.Text = "E FATURA";
            }
            else
            {
                txtFaturaTur.Text = "E ARŞİV";
            }
            #endregion

        }
    }
    private void DosyaCek()
    {
        SqlDataAdapter adpKlasor = new SqlDataAdapter("SELECT DOSYAAD FROM TTS_DOSYA WHERE CARIKOD='" + Session["CariRef"].ToString() + "'", connBizim);
        DataTable tblKlasor = new DataTable();
        adpKlasor.Fill(tblKlasor);
        lstKlasor.Items.Clear();
        foreach (DataRow item in tblKlasor.Rows)
        {
            lstKlasor.Items.Add(item[0].ToString());
        }
    }
    private void TeminatMektupCek()
    {
        SqlDataAdapter adpVeri = new SqlDataAdapter("SELECT ID,CARIKOD,CARIAD,BANKAAD,EVRAKNO,VADETARIHI,TUTAR,ACIKLAMA " +
            "FROM TEMINAT_MEKTUP WHERE CARIKOD='" + Session["CariRef"].ToString() + "'", connBizim);
        DataTable tblVeri = new DataTable();
        adpVeri.Fill(tblVeri);
        this.grdTeminat.DataSource = tblVeri;
        this.grdTeminat.DataBind();
        this.grdTeminat.Columns[0].Visible = false;
    }
    private void TahsilatTur()
    {
        SqlDataAdapter adpTahsilatTur = new SqlDataAdapter("SELECT TAHSILATTUR FROM CARI_TAHSILAT_TUR", connBizim);
        System.Data.DataTable tblTahsilatTur = new System.Data.DataTable();
        adpTahsilatTur.Fill(tblTahsilatTur);
        for (int i = 0; i < tblTahsilatTur.Rows.Count; i++)
        {
            cmbOdemeTur.Items.Add(tblTahsilatTur.Rows[i][0].ToString());
        }
    }
    private void VeriCek()
    {
        string deneme = Session["CariRef"].ToString();
        SqlCommand cmdVeriCek = new SqlCommand("SELECT * FROM TTSPORTAL_CARIBILGI WHERE CARIKOD= '" + Session["CariRef"].ToString() + "'", connBizim);
        connBizim.Open();
        SqlDataReader rdrVeriCek = cmdVeriCek.ExecuteReader();
        while (rdrVeriCek.Read())
        {

            txtCariAd.Text = rdrVeriCek[2].ToString();

            txtShellBindirimMotorinTl.Text = rdrVeriCek[43].ToString();
            txtShellBindirimTl.Text = rdrVeriCek[44].ToString();
            txtShellDindirimMotorinTl.Text = rdrVeriCek[45].ToString();
            txtShellDindirimTl.Text = rdrVeriCek[46].ToString();
            txtTotalBindirim.Text = rdrVeriCek[30].ToString();
            txtTotalDindirim.Text = rdrVeriCek[32].ToString();
            txtLukoilBindirim.Text = rdrVeriCek[26].ToString();
            txtLukoilDindirim.Text = rdrVeriCek[28].ToString();
            txtTaahhutLitre.Text = rdrVeriCek[5].ToString();
            txtOfflineLimit.Text = rdrVeriCek[13].ToString();
            cmbIstasyon.Text = rdrVeriCek[14].ToString();
            cmbOdemeTur.Text = rdrVeriCek[15].ToString();
            txtOnlineLimit.Text = rdrVeriCek[12].ToString();
            txtMusteriKod.Text = rdrVeriCek[36].ToString();
            txtBankaKod.Text = rdrVeriCek[17].ToString();
            txtVade1.Text = rdrVeriCek[19].ToString();
            cmbAnaCari.Text = rdrVeriCek[10].ToString();
            txtAnaBayiKod.Text = rdrVeriCek[11].ToString();
            cmbTeminatTur.Text = rdrVeriCek[6].ToString();
            //txtOdemePlan.Text=rdrVeriCek[16].ToString();           
            txtLukoilBindirimMotorin.Text = rdrVeriCek[25].ToString();
            txtLukoilDindirimMotorin.Text = rdrVeriCek[27].ToString();
            txtTotalBindirimMotorin.Text = rdrVeriCek[29].ToString();
            txtTotalDindirimMotorin.Text = rdrVeriCek[31].ToString();
            cmbTeminatTur2.Text = rdrVeriCek[8].ToString();
            txtTeminatTutar2.Text = rdrVeriCek[9].ToString();
            txtKargoEslestirme.Text = rdrVeriCek[20].ToString();
            txtBankaKod2.Text = rdrVeriCek[18].ToString();
            txtVade2.Text = rdrVeriCek[48].ToString();
            txtLukoilAnaBayiKod.Text = rdrVeriCek[49].ToString();
            txtLukoilOdemeVade1.Text = rdrVeriCek[50].ToString();
            txtLukoilOdemeVade2.Text = rdrVeriCek[51].ToString();
            txtTotalAnaBayiKod.Text = rdrVeriCek[52].ToString();
            txtTotalOdemeVade1.Text = rdrVeriCek[53].ToString();
            txtTotalOdemeVade2.Text = rdrVeriCek[54].ToString();
            txtTotalOdemeVade3.Text = rdrVeriCek[55].ToString();
            dpSektor.Text = rdrVeriCek[57].ToString();
            dpCıkıs.Text = rdrVeriCek[58].ToString();
            txtPratıkKartNo.Text = rdrVeriCek[59].ToString();



            //string deneme = rdrVeriCek[56].ToString(); ;
            if (rdrVeriCek[56].ToString() != "")
            {
                rdpBayi.SelectedIndex = Convert.ToInt32(rdrVeriCek[56]);
            }


            if (rdrVeriCek[3].ToString() == "1")
            { chkOtomatikSistem.Checked = true; }
            if (rdrVeriCek[33].ToString() != "")
            {
                dtBas.Value = Convert.ToDateTime(rdrVeriCek[33]);
                dtBit.Value = Convert.ToDateTime(rdrVeriCek[34]);
            }
            if (rdrVeriCek[4].ToString() == "H")
            { chkBakiyeListe.Checked = true; }
            else
            { chkBakiyeListe.Checked = false; }
            if (rdrVeriCek[42].ToString() == "1")
            {
                lblDurum.Text = "Açık";
            }
            else
            {
                lblDurum.Text = "Kapalı";
            }
            txtTeminatTutar.Text = rdrVeriCek[7].ToString();
            txtAciklama.Text = rdrVeriCek[37].ToString();
            cmbSatisEleman.Text = rdrVeriCek[35].ToString();
            cmbBankaAd.Text = rdrVeriCek[39].ToString();
            cmbBankaAd2.Text = rdrVeriCek[40].ToString();
            txtTolerans.Text = rdrVeriCek[47].ToString();
            txtOnlineLimit2.Text = rdrVeriCek[38].ToString();
            if (rdrVeriCek[41].ToString() == "1")
            {
                chkGenelRapor.Checked = true;
            }
            else
            {
                chkGenelRapor.Checked = false;
            }
            double toplam, offline, online;
            offline = Convert.ToDouble(txtOfflineLimit.Text.ToString().Replace(".", ","));
            online = Convert.ToDouble(txtOnlineLimit.Text.ToString().Replace(".", ",")) + Convert.ToDouble(txtOnlineLimit2.Text.ToString().Replace(".", ","));
            toplam = offline + online;
            txtTumLimit.Text = toplam.ToString();

        }
        connBizim.Close();
        #region firma logları çekiliyor
        adpVeri = new SqlDataAdapter("SELECT TARIH,ACIKLAMA FROM TTSPORTAL_FIRMALOG WHERE CARIKOD='" + Session["CariRef"].ToString() + "'", connBizim);
        tblVeri = new System.Data.DataTable();
        adpVeri.Fill(tblVeri);
        this.grdFirmaLog.DataSource = tblVeri;
        this.grdFirmaLog.DataBind();
        #endregion
    }
    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        #region cari kontrol ediliyor
        SqlDataAdapter adpCariKontrol = new SqlDataAdapter("SELECT * FROM TTSPORTAL_CARIBILGI WHERE CARIKOD='" + Session["CariRef"].ToString() + "'", connBizim);
        DataTable tblCariKontrol = new DataTable();
        adpCariKontrol.Fill(tblCariKontrol);
        if (tblCariKontrol.Rows.Count == 0)
        {
            SqlCommand cmdKaydet = new SqlCommand("INSERT INTO TTSPORTAL_CARIBILGI (CARIKOD,CARIAD,OTOMATIKLISTE,BAKIYELISTE,TAAHHUTLITRE,TEMINATTUR,TEMINATTUTAR,TEMINATTUR2,TEMINATTUTAR2,ANACARI,ANABAYIKOD,OFFLINELIMIT,MUSTERIISTASYON,ODEMETUR,BANKADBSKOD,BANKADBSKOD2,SHELLVADE1,SHELLVADE2,KARGOESLESTIRME,LUKOILBIZIMMOTORIN,LUKOILBIZIMBENZIN,LUKOILDIGERMOTORIN,LUKOILDIGERBENZIN,TOTALBIZIMMOTORIN,TOTALBIZIMBENZIN,TOTALDIGERMOTORIN,TOTALDIGERBENZIN,SOZLESMEBASLANGIC,SOZLESMEBITIS,SATISPERSONEL,SHELLMUSTERIKOD,ACIKLAMA,BANKAAD,BANKAAD2,ONLINELIMIT,GENELRAPOR,SHELLBIZIMMOTORINTL,SHELLBIZIMBENZINTL,SHELLDIGERMOTORINTL,SHELLDIGERBENZINTL,TOLERANSSURE,ONLINELIMIT2,LUKOILANABAYIKOD,LUKOILODEMEVADE1,LUKOILODEMEVADE2,TOTALANABAYIKOD,TOTALODEMEVADE1,TOTALODEMEVADE2,TOTALODEMEVADE3,ANABAYI,SEKTOR,CIKIS,PRATIKKARTNO) VALUES (@CARIKOD,@CARIAD,@OTOMATIKLISTE,@BAKIYELISTE,@TAAHHUTLITRE,@TEMINATTUR,@TEMINATTUTAR,@TEMINATTUR2,@TEMINATTUTAR2,@ANACARI,@ANABAYIKOD,@OFFLINELIMIT,@MUSTERIISTASYON,@ODEMETUR,@BANKADBSKOD,@BANKADBSKOD2,@SHELLVADE1,@SHELLVADE2,@KARGOESLESTIRME,@LUKOILBIZIMMOTORIN,@LUKOILBIZIMBENZIN,@LUKOILDIGERMOTORIN,@LUKOILDIGERBENZIN,@TOTALBIZIMMOTORIN,@TOTALBIZIMBENZIN,@TOTALDIGERMOTORIN,@TOTALDIGERBENZIN,@SOZLESMEBASLANGIC,@SOZLESMEBITIS,@SATISPERSONEL,@SHELLMUSTERIKOD,@ACIKLAMA,@BANKAAD,@BANKAAD2,@ONLINELIMIT,@GENELRAPOR,@SHELLBIZIMMOTORINTL,@SHELLBIZIMBENZINTL,@SHELLDIGERMOTORINTL,@SHELLDIGERBENZINTL,@TOLERANSSURE,@ONLINELIMIT2,@LUKOILANABAYIKOD,@LUKOILODEMEVADE1,@LUKOILODEMEVADE2,@TOTALANABAYIKOD,@TOTALODEMEVADE1,@TOTALODEMEVADE2,@TOTALODEMEVADE3,@ANABAYI,@SEKTOR,@CIKIS,@PRATIKKARTNO)", connBizim);
            cmdKaydet.Parameters.AddWithValue("@CARIKOD", Session["CariRef"].ToString());
            cmdKaydet.Parameters.AddWithValue("@CARIAD", Session["CariAd"].ToString());
            if (chkOtomatikSistem.Checked == true)
            { cmdKaydet.Parameters.AddWithValue("@OTOMATIKLISTE", "1"); }
            else
            { cmdKaydet.Parameters.AddWithValue("@OTOMATIKLISTE", "0"); }
            if (chkBakiyeListe.Checked == true)
            { cmdKaydet.Parameters.AddWithValue("@BAKIYELISTE", "H"); }
            else
            { cmdKaydet.Parameters.AddWithValue("@BAKIYELISTE", ""); }
            cmdKaydet.Parameters.AddWithValue("@TAAHHUTLITRE", txtTaahhutLitre.Text);
            cmdKaydet.Parameters.AddWithValue("@TEMINATTUR", cmbTeminatTur.Text);
            cmdKaydet.Parameters.AddWithValue("@TEMINATTUTAR", txtTeminatTutar.Text);
            cmdKaydet.Parameters.AddWithValue("@TEMINATTUR2", cmbTeminatTur2.Text);
            cmdKaydet.Parameters.AddWithValue("@TEMINATTUTAR2", txtTeminatTutar2.Text);
            cmdKaydet.Parameters.AddWithValue("@ANACARI", cmbAnaCari.Text);
            cmdKaydet.Parameters.AddWithValue("@ANABAYIKOD", txtAnaBayiKod.Text);
            if (txtOfflineLimit.Text == "")
            { cmdKaydet.Parameters.AddWithValue("@OFFLINELIMIT", "0"); }
            else
            { cmdKaydet.Parameters.AddWithValue("@OFFLINELIMIT", txtOfflineLimit.Text); }
            cmdKaydet.Parameters.AddWithValue("@MUSTERIISTASYON", cmbIstasyon.Text);
            cmdKaydet.Parameters.AddWithValue("@ODEMETUR", cmbOdemeTur.Text);
            cmdKaydet.Parameters.AddWithValue("@BANKADBSKOD", txtBankaKod.Text);
            cmdKaydet.Parameters.AddWithValue("@BANKADBSKOD2", txtBankaKod2.Text);
            cmdKaydet.Parameters.AddWithValue("@SHELLVADE1", txtVade1.Text);
            cmdKaydet.Parameters.AddWithValue("@SHELLVADE2", txtVade2.Text);
            cmdKaydet.Parameters.AddWithValue("@KARGOESLESTIRME", txtKargoEslestirme.Text);

            cmdKaydet.Parameters.AddWithValue("@SHELLDIGERBENZIN", "0");
            cmdKaydet.Parameters.AddWithValue("@LUKOILBIZIMMOTORIN", txtLukoilBindirimMotorin.Text);
            cmdKaydet.Parameters.AddWithValue("@LUKOILBIZIMBENZIN", txtLukoilBindirim.Text);
            cmdKaydet.Parameters.AddWithValue("@LUKOILDIGERMOTORIN", txtLukoilDindirimMotorin.Text);
            cmdKaydet.Parameters.AddWithValue("@LUKOILDIGERBENZIN", txtLukoilDindirim.Text);
            cmdKaydet.Parameters.AddWithValue("@TOTALBIZIMMOTORIN", txtTotalBindirimMotorin.Text);
            cmdKaydet.Parameters.AddWithValue("@TOTALBIZIMBENZIN", txtTotalBindirim.Text);
            cmdKaydet.Parameters.AddWithValue("@TOTALDIGERMOTORIN", txtTotalDindirimMotorin.Text);
            cmdKaydet.Parameters.AddWithValue("@TOTALDIGERBENZIN", txtTotalDindirim.Text);
            cmdKaydet.Parameters.AddWithValue("@SOZLESMEBITIS", Convert.ToDateTime(dtBit.Text));
            cmdKaydet.Parameters.AddWithValue("@SOZLESMEBASLANGIC", Convert.ToDateTime(dtBas.Text));
            cmdKaydet.Parameters.AddWithValue("@SATISPERSONEL", cmbSatisEleman.Text);
            cmdKaydet.Parameters.AddWithValue("@SHELLMUSTERIKOD", txtMusteriKod.Text);
            cmdKaydet.Parameters.AddWithValue("@ACIKLAMA", txtAciklama.Text);
            cmdKaydet.Parameters.AddWithValue("@BANKAAD", cmbBankaAd.Text);
            cmdKaydet.Parameters.AddWithValue("@BANKAAD2", cmbBankaAd2.Text);


            if (txtOnlineLimit.Text == "")
            {
                cmdKaydet.Parameters.AddWithValue("@ONLINELIMIT", "0");
            }
            else
            {
                cmdKaydet.Parameters.AddWithValue("@ONLINELIMIT", Convert.ToDouble(txtOnlineLimit.Text));
            }

            if (chkGenelRapor.Checked == false)
            {
                cmdKaydet.Parameters.AddWithValue("@GENELRAPOR", "0");
            }
            else
            {
                cmdKaydet.Parameters.AddWithValue("@GENELRAPOR", "1");
            }
            cmdKaydet.Parameters.AddWithValue("@SHELLBIZIMMOTORINTL", txtShellBindirimMotorinTl.Text);
            cmdKaydet.Parameters.AddWithValue("@SHELLBIZIMBENZINTL", txtShellBindirimTl.Text);
            cmdKaydet.Parameters.AddWithValue("@SHELLDIGERMOTORINTL", txtShellDindirimMotorinTl.Text);
            cmdKaydet.Parameters.AddWithValue("@SHELLDIGERBENZINTL", txtShellDindirimTl.Text);
            cmdKaydet.Parameters.AddWithValue("@TOLERANSSURE", txtTolerans.Text);
            if (txtOnlineLimit2.Text == "")
            {
                cmdKaydet.Parameters.AddWithValue("@ONLINELIMIT2", "0");
            }
            else
            {
                cmdKaydet.Parameters.AddWithValue("@ONLINELIMIT2", Convert.ToDouble(txtOnlineLimit2.Text));
            }
            cmdKaydet.Parameters.AddWithValue("@LUKOILANABAYIKOD", txtLukoilAnaBayiKod.Text);
            cmdKaydet.Parameters.AddWithValue("@LUKOILODEMEVADE1", txtLukoilOdemeVade1.Text);
            cmdKaydet.Parameters.AddWithValue("@LUKOILODEMEVADE2", txtLukoilOdemeVade2.Text);
            cmdKaydet.Parameters.AddWithValue("@TOTALANABAYIKOD", txtTotalAnaBayiKod.Text);
            cmdKaydet.Parameters.AddWithValue("@TOTALODEMEVADE1", txtTotalOdemeVade1.Text);
            cmdKaydet.Parameters.AddWithValue("@TOTALODEMEVADE2", txtTotalOdemeVade2.Text);
            cmdKaydet.Parameters.AddWithValue("@TOTALODEMEVADE3", txtTotalOdemeVade3.Text);
            cmdKaydet.Parameters.AddWithValue("@ANABAYI", rdpBayi.SelectedIndex);
            cmdKaydet.Parameters.AddWithValue("@SEKTOR", dpSektor.Text);
            cmdKaydet.Parameters.AddWithValue("@CIKIS", dpCıkıs.Text);
            cmdKaydet.Parameters.AddWithValue("@PRATIKKARTNO", txtPratıkKartNo.Text);
            connBizim.Open();
            cmdKaydet.ExecuteNonQuery();
            connBizim.Close();
            KlasorOlustur();
            DosyaYukle();
            RegisterStartupScript("PencereyiKapa", "<script>window.close(); </script>");
        }
        else
        {
            SqlCommand cmdGuncelle = new SqlCommand("UPDATE TTSPORTAL_CARIBILGI SET OTOMATIKLISTE=@OTOMATIKLISTE,BAKIYELISTE=@BAKIYELISTE,TAAHHUTLITRE=@TAAHHUTLITRE,TEMINATTUR=@TEMINATTUR,TEMINATTUTAR=@TEMINATTUTAR,TEMINATTUR2=@TEMINATTUR2,TEMINATTUTAR2=@TEMINATTUTAR2,ANACARI=@ANACARI,ANABAYIKOD=@ANABAYIKOD,OFFLINELIMIT=@OFFLINELIMIT,MUSTERIISTASYON=@MUSTERIISTASYON,ODEMETUR=@ODEMETUR,BANKADBSKOD=@BANKADBSKOD,BANKADBSKOD2=@BANKADBSKOD2,SHELLVADE1=@SHELLVADE1,SHELLVADE2=@SHELLVADE2,KARGOESLESTIRME=@KARGOESLESTIRME,SHELLDIGERBENZIN=@SHELLDIGERBENZIN,LUKOILBIZIMMOTORIN=@LUKOILBIZIMMOTORIN,LUKOILBIZIMBENZIN=@LUKOILBIZIMBENZIN,LUKOILDIGERMOTORIN=@LUKOILDIGERMOTORIN,LUKOILDIGERBENZIN=@LUKOILDIGERBENZIN,TOTALBIZIMMOTORIN=@TOTALBIZIMMOTORIN,TOTALBIZIMBENZIN=@TOTALBIZIMBENZIN,TOTALDIGERMOTORIN=@TOTALDIGERMOTORIN,TOTALDIGERBENZIN=@TOTALDIGERBENZIN,SOZLESMEBASLANGIC=@SOZLESMEBASLANGIC,SOZLESMEBITIS=@SOZLESMEBITIS,SATISPERSONEL=@SATISPERSONEL,SHELLMUSTERIKOD=@SHELLMUSTERIKOD,ACIKLAMA=@ACIKLAMA,BANKAAD=@BANKAAD,BANKAAD2=@BANKAAD2,GENELRAPOR=@GENELRAPOR,SHELLBIZIMMOTORINTL=@SHELLBIZIMMOTORINTL,SHELLBIZIMBENZINTL=@SHELLBIZIMBENZINTL,SHELLDIGERMOTORINTL=@SHELLDIGERMOTORINTL,SHELLDIGERBENZINTL=@SHELLDIGERBENZINTL,TOLERANSSURE=@TOLERANSSURE,LUKOILANABAYIKOD=@LUKOILANABAYIKOD,LUKOILODEMEVADE1=@LUKOILODEMEVADE1,LUKOILODEMEVADE2=@LUKOILODEMEVADE2,TOTALANABAYIKOD=@TOTALANABAYIKOD,TOTALODEMEVADE1=@TOTALODEMEVADE1,TOTALODEMEVADE2=@TOTALODEMEVADE2,TOTALODEMEVADE3=@TOTALODEMEVADE3,ANABAYI=@ANABAYI,SEKTOR=@SEKTOR,CIKIS=@CIKIS,PRATIKKARTNO=@PRATIKKARTNO WHERE CARIKOD='" + Session["CariRef"].ToString() + "'", connBizim);

            if (chkOtomatikSistem.Checked == true)
            { cmdGuncelle.Parameters.AddWithValue("@OTOMATIKLISTE", "1"); }
            else
            { cmdGuncelle.Parameters.AddWithValue("@OTOMATIKLISTE", "0"); }
            if (chkBakiyeListe.Checked == true)
            { cmdGuncelle.Parameters.AddWithValue("@BAKIYELISTE", "H"); }
            else
            { cmdGuncelle.Parameters.AddWithValue("@BAKIYELISTE", ""); }
            cmdGuncelle.Parameters.AddWithValue("@TAAHHUTLITRE", txtTaahhutLitre.Text);
            cmdGuncelle.Parameters.AddWithValue("@TEMINATTUR", cmbTeminatTur.Text);
            cmdGuncelle.Parameters.AddWithValue("@TEMINATTUTAR", txtTeminatTutar.Text);
            cmdGuncelle.Parameters.AddWithValue("@TEMINATTUR2", cmbTeminatTur2.Text);
            cmdGuncelle.Parameters.AddWithValue("@TEMINATTUTAR2", txtTeminatTutar2.Text);
            cmdGuncelle.Parameters.AddWithValue("@ANACARI", cmbAnaCari.Text);
            cmdGuncelle.Parameters.AddWithValue("@ANABAYIKOD", txtAnaBayiKod.Text);
            cmdGuncelle.Parameters.AddWithValue("@OFFLINELIMIT", txtOfflineLimit.Text);
            cmdGuncelle.Parameters.AddWithValue("@MUSTERIISTASYON", cmbIstasyon.Text);
            cmdGuncelle.Parameters.AddWithValue("@ODEMETUR", cmbOdemeTur.Text);
            cmdGuncelle.Parameters.AddWithValue("@BANKADBSKOD", txtBankaKod.Text);
            cmdGuncelle.Parameters.AddWithValue("@BANKADBSKOD2", txtBankaKod2.Text);
            cmdGuncelle.Parameters.AddWithValue("@SHELLVADE1", txtVade1.Text);
            cmdGuncelle.Parameters.AddWithValue("@SHELLVADE2", txtVade2.Text);
            cmdGuncelle.Parameters.AddWithValue("@KARGOESLESTIRME", txtKargoEslestirme.Text);
            //cmdGuncelle.Parameters.AddWithValue("@SHELLBIZIMMOTORIN", txtShellBindirimMotorin.Text);
            //cmdGuncelle.Parameters.AddWithValue("@SHELLBIZIMBENZIN", txtShellBindirim.Text);
            //cmdGuncelle.Parameters.AddWithValue("@SHELLDIGERMOTORIN", txtShellDindirimMotorin.Text);
            cmdGuncelle.Parameters.AddWithValue("@SHELLDIGERBENZIN", "0");
            cmdGuncelle.Parameters.AddWithValue("@LUKOILBIZIMMOTORIN", txtLukoilBindirimMotorin.Text);
            cmdGuncelle.Parameters.AddWithValue("@LUKOILBIZIMBENZIN", txtLukoilBindirim.Text);
            cmdGuncelle.Parameters.AddWithValue("@LUKOILDIGERMOTORIN", txtLukoilDindirimMotorin.Text);
            cmdGuncelle.Parameters.AddWithValue("@LUKOILDIGERBENZIN", txtLukoilDindirim.Text);
            cmdGuncelle.Parameters.AddWithValue("@TOTALBIZIMMOTORIN", txtTotalBindirimMotorin.Text);
            cmdGuncelle.Parameters.AddWithValue("@TOTALBIZIMBENZIN", txtTotalBindirim.Text);
            cmdGuncelle.Parameters.AddWithValue("@TOTALDIGERMOTORIN", txtTotalDindirimMotorin.Text);
            cmdGuncelle.Parameters.AddWithValue("@TOTALDIGERBENZIN", txtTotalDindirim.Text);
            cmdGuncelle.Parameters.AddWithValue("@SOZLESMEBITIS", Convert.ToDateTime(dtBit.Text));
            cmdGuncelle.Parameters.AddWithValue("@SOZLESMEBASLANGIC", Convert.ToDateTime(dtBas.Text));
            cmdGuncelle.Parameters.AddWithValue("@SATISPERSONEL", cmbSatisEleman.Text);
            cmdGuncelle.Parameters.AddWithValue("@SHELLMUSTERIKOD", txtMusteriKod.Text);
            cmdGuncelle.Parameters.AddWithValue("@ACIKLAMA", txtAciklama.Text);
            cmdGuncelle.Parameters.AddWithValue("@BANKAAD", cmbBankaAd.Text);
            cmdGuncelle.Parameters.AddWithValue("@BANKAAD2", cmbBankaAd2.Text);
            if (chkGenelRapor.Checked == false)
            {
                cmdGuncelle.Parameters.AddWithValue("@GENELRAPOR", "0");
            }
            else
            {
                cmdGuncelle.Parameters.AddWithValue("@GENELRAPOR", "1");
            }
            cmdGuncelle.Parameters.AddWithValue("@SHELLBIZIMMOTORINTL", txtShellBindirimMotorinTl.Text);
            cmdGuncelle.Parameters.AddWithValue("@SHELLBIZIMBENZINTL", txtShellBindirimTl.Text);
            cmdGuncelle.Parameters.AddWithValue("@SHELLDIGERMOTORINTL", txtShellDindirimMotorinTl.Text);
            cmdGuncelle.Parameters.AddWithValue("@SHELLDIGERBENZINTL", txtShellDindirimTl.Text);
            cmdGuncelle.Parameters.AddWithValue("@TOLERANSSURE", txtTolerans.Text);
            cmdGuncelle.Parameters.AddWithValue("@LUKOILANABAYIKOD", txtLukoilAnaBayiKod.Text);
            cmdGuncelle.Parameters.AddWithValue("@LUKOILODEMEVADE1", txtLukoilOdemeVade1.Text);
            cmdGuncelle.Parameters.AddWithValue("@LUKOILODEMEVADE2", txtLukoilOdemeVade2.Text);
            cmdGuncelle.Parameters.AddWithValue("@TOTALANABAYIKOD", txtTotalAnaBayiKod.Text);
            cmdGuncelle.Parameters.AddWithValue("@TOTALODEMEVADE1", txtTotalOdemeVade1.Text);
            cmdGuncelle.Parameters.AddWithValue("@TOTALODEMEVADE2", txtTotalOdemeVade2.Text);
            cmdGuncelle.Parameters.AddWithValue("@TOTALODEMEVADE3", txtTotalOdemeVade3.Text);
            cmdGuncelle.Parameters.AddWithValue("@ANABAYI", rdpBayi.SelectedIndex);
            cmdGuncelle.Parameters.AddWithValue("@SEKTOR", dpSektor.Text);
            cmdGuncelle.Parameters.AddWithValue("@CIKIS", dpCıkıs.Text);
            cmdGuncelle.Parameters.AddWithValue("@PRATIKKARTNO", txtPratıkKartNo.Text);
            connBizim.Open();
            cmdGuncelle.ExecuteNonQuery();
            connBizim.Close();
            KlasorOlustur();
            DosyaYukle();
            RegisterStartupScript("PencereyiKapa", "<script>window.close(); </script>");
        }
        #endregion
        //Response.Redirect("CariKart.aspx");
    }
    private void DosyaYukle()
    {
        if (fpSozlesme.HasFile)
            try
            {
                fpSozlesme.SaveAs("C:\\Dosyalar\\" + Session["CariRef"].ToString() + "\\" + fpSozlesme.FileName);
                #region dosya veritabanına kaydediliyor
                SqlCommand cmdKaydet = new SqlCommand("INSERT INTO TTS_DOSYA (DOSYAYOL,DOSYAAD,CARIKOD,CARIAD,TARIH,DOSYATUR) VALUES (@DOSYAYOL,@DOSYAAD,@CARIKOD,@CARIAD,@TARIH,@DOSYATUR)", connBizim);
                cmdKaydet.Parameters.AddWithValue("@DOSYAYOL", "C:\\Dosyalar\\" + Session["CariRef"].ToString() + "\\" + fpSozlesme.FileName);
                cmdKaydet.Parameters.AddWithValue("@DOSYAAD", fpSozlesme.FileName);
                cmdKaydet.Parameters.AddWithValue("@CARIKOD", Session["CariRef"].ToString());
                cmdKaydet.Parameters.AddWithValue("@CARIAD", txtCariAd.Text);
                cmdKaydet.Parameters.AddWithValue("@TARIH", Convert.ToDateTime(DateTime.Now.ToString().Substring(0, 10)));
                cmdKaydet.Parameters.AddWithValue("@DOSYATUR", rdpSec.SelectedItem.Text);
                connBizim.Open();
                cmdKaydet.ExecuteNonQuery();
                connBizim.Close();
                #endregion
            }
            catch (Exception ex)
            {
                // Label1.Text = "Hata Oluştu: " + ex.Message.ToString();
            }
        else
        {

        }
    }
    private void KlasorOlustur()
    {
        #region klasör yoksa oluşturuluyor
        string[] klasorler = Directory.GetDirectories("C:\\Dosyalar\\");
        //klasörler dizisinin uzunluğuna kadar git
        for (int j = 0; j < klasorler.Length; j++)
        {
            if (klasorler[j].ToString() == "C:\\Dosyalar\\" + Session["CariRef"].ToString() + "")
            {
                // kontrol = 1;
            }
            else
            {

                Directory.CreateDirectory(@"C:\\Dosyalar\\" + Session["CariRef"].ToString() + "");
            }
        }
        #endregion
    }
    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        KlasorOlustur();
        DosyaYukle();
        DosyaCek();
    }
    protected void btnIndir_Click(object sender, EventArgs e)
    {
        DosyaIndir();
    }
    private void DosyaIndir()
    {
        string dosyaAdi = "C:\\Dosyalar\\" + Session["CariRef"].ToString() + "\\" + lstKlasor.SelectedItem.Text + "";
        FileInfo dosya = new FileInfo(dosyaAdi);
        Response.Clear();
        Response.AddHeader("Content-Disposition", "filename=" + lstKlasor.SelectedItem.Text + "");
        Response.AddHeader("Content-Length", dosya.Length.ToString());
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(dosyaAdi);
        Response.End();
    }
    protected void btnSil_Click(object sender, EventArgs e)
    {
        File.Delete("C:\\Dosyalar\\" + Session["CariRef"].ToString() + "\\" + lstKlasor.SelectedItem.Text + "");
        SqlCommand cmdSil = new SqlCommand("DELETE FROM TTS_DOSYA WHERE CARIKOD='" + Session["CariRef"].ToString() + "' AND DOSYAAD='" + lstKlasor.SelectedItem.Text + "'", connBizim);
        connBizim.Open();
        cmdSil.ExecuteNonQuery();
        connBizim.Close();
        DosyaCek();
    }


    private void Sektordropdown()
    {
        SqlDataAdapter adpSektor = new SqlDataAdapter("SELECT FIRMA_SEKTOR FROM SEKTOR", connBizim);
        System.Data.DataTable tblSektor = new System.Data.DataTable();
        adpSektor.Fill(tblSektor);
        for (int i = 0; i < tblSektor.Rows.Count; i++)
        {
            dpSektor.Items.Add(tblSektor.Rows[i][0].ToString());
        }
    }
    private void Cıkısdropdown()
    {
        SqlDataAdapter adpCıkıs = new SqlDataAdapter("SELECT SEBEP FROM CIKIS_SEBEP", connBizim);
        System.Data.DataTable tblCıkıs = new System.Data.DataTable();
        adpCıkıs.Fill(tblCıkıs);
        for (int i = 0; i < tblCıkıs.Rows.Count; i++)
        {
            dpCıkıs.Items.Add(tblCıkıs.Rows[i][0].ToString());
        }
    }
    protected void Button1_Click(object sender, EventArgs e)

    {

        string c1 = Session["CariRef"].ToString();
        Response.Redirect("CariEkstre.aspx");




    }
    protected void Button2_Click(object sender, EventArgs e)

    {

        #region detay satış geliyor
        SqlCommand cmdSorgu = new SqlCommand();
        cmdSorgu.Connection = connBizim;
        cmdSorgu.CommandTimeout = 1800000000;
        cmdSorgu.CommandText = "DETAY_SATIS_2021";
        cmdSorgu.Parameters.AddWithValue("@CARIKOD", Session["CariRef"].ToString());
        cmdSorgu.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adpFirmaKarDiger = new SqlDataAdapter();
        adpFirmaKarDiger.SelectCommand = cmdSorgu;
        System.Data.DataTable tblFirmaKarDiger = new System.Data.DataTable();
        adpFirmaKarDiger.Fill(tblFirmaKarDiger);
        grdDetaySatis.DataSource = tblFirmaKarDiger;
        grdDetaySatis.DataBind();

        for (int i = 0; i < grdDetaySatis.Rows.Count - 1; i++)
        {
            for (int j = 1; j < 14; j++)
            {
                decimal sayi = Convert.ToDecimal(grdDetaySatis.Rows[i].Cells[j].Text);
                grdDetaySatis.Rows[i].Cells[j].Text = sayi.ToString("N");
            }

        }

        for (int j = 1; j < 14; j++)
        {
            decimal sayi = Convert.ToDecimal(grdDetaySatis.Rows[4].Cells[j].Text);
            grdDetaySatis.Rows[4].Cells[j].Text = sayi.ToString("P");
        }



        #endregion


        #region araç bazlı plaka döküm
        SqlCommand cmdPlakaDokum = new SqlCommand();
        cmdPlakaDokum.Connection = connBizim;
        cmdPlakaDokum.CommandTimeout = 1800000000;
        cmdPlakaDokum.CommandText = "ARAC_BAZLI_PLAKA_DOKUM_2021";
        cmdPlakaDokum.Parameters.AddWithValue("@CARIKOD", Session["CariRef"].ToString());
        cmdPlakaDokum.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adpPlakaDokum = new SqlDataAdapter();
        adpPlakaDokum.SelectCommand = cmdPlakaDokum;
        System.Data.DataTable tblPlakaDokum = new System.Data.DataTable();
        adpPlakaDokum.Fill(tblPlakaDokum);
        grdAracBazliPlakaDokum.DataSource = tblPlakaDokum;
        grdAracBazliPlakaDokum.DataBind();

        for (int i = 0; i < grdAracBazliPlakaDokum.Rows.Count; i++)
        {
            for (int j = 1; j < 14; j++)
            {
                decimal sayi = Convert.ToDecimal(grdAracBazliPlakaDokum.Rows[i].Cells[j].Text);
                grdAracBazliPlakaDokum.Rows[i].Cells[j].Text = sayi.ToString("N");
            }

        }

        #endregion

        #region detay karlılık
        SqlCommand cmdDetayKarlilik = new SqlCommand();
        cmdDetayKarlilik.Connection = connBizim;
        cmdDetayKarlilik.CommandTimeout = 1800000000;
        cmdDetayKarlilik.CommandText = "DETAY_KARLILIK_2021";
        cmdDetayKarlilik.Parameters.AddWithValue("@CARIKOD", Session["CariRef"].ToString());
        cmdDetayKarlilik.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adpDetayKarlilik = new SqlDataAdapter();
        adpDetayKarlilik.SelectCommand = cmdDetayKarlilik;
        System.Data.DataTable tblDetayKarlilik = new System.Data.DataTable();
        adpDetayKarlilik.Fill(tblDetayKarlilik);
        grdDetayKarlilik.DataSource = tblDetayKarlilik;
        grdDetayKarlilik.DataBind();

        for (int i = 0; i < grdDetayKarlilik.Rows.Count; i++)
        {
            for (int j = 1; j < 9; j++)
            {
                if (grdDetayKarlilik.Rows[i].Cells[j].Text != "&nbsp;")
                {
                    decimal sayi = Convert.ToDecimal(grdDetayKarlilik.Rows[i].Cells[j].Text);
                    grdDetayKarlilik.Rows[i].Cells[j].Text = sayi.ToString("N");
                }
                else
                {
                    grdDetayKarlilik.Rows[i].Cells[j].Text = "0.00";
                }

            }
            //decimal oran = Convert.ToDecimal(grdDetayKarlilik.Rows[i].Cells[4].Text);
            //grdDetayKarlilik.Rows[i].Cells[4].Text = oran.ToString("P");

        }



        #endregion

    }
    protected void btnSec_Click(object sender, EventArgs e)

    {
        if (cmbYıl.SelectedIndex == 0)
        {


            #region detay satış geliyor
            SqlCommand cmdSorgu = new SqlCommand();
            cmdSorgu.Connection = connBizim;
            cmdSorgu.CommandTimeout = 1800000000;
            cmdSorgu.CommandText = "DETAY_SATIS";
            cmdSorgu.Parameters.AddWithValue("@CARIKOD", Session["CariRef"].ToString());
            cmdSorgu.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adpFirmaKarDiger = new SqlDataAdapter();
            adpFirmaKarDiger.SelectCommand = cmdSorgu;
            System.Data.DataTable tblFirmaKarDiger = new System.Data.DataTable();
            adpFirmaKarDiger.Fill(tblFirmaKarDiger);
            grdDetaySatis.DataSource = tblFirmaKarDiger;
            grdDetaySatis.DataBind();

            for (int i = 0; i < grdDetaySatis.Rows.Count - 1; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    decimal sayi = Convert.ToDecimal(grdDetaySatis.Rows[i].Cells[j].Text);
                    grdDetaySatis.Rows[i].Cells[j].Text = sayi.ToString("N");
                }

            }

            for (int j = 1; j < 14; j++)
            {
                decimal sayi = Convert.ToDecimal(grdDetaySatis.Rows[4].Cells[j].Text);
                grdDetaySatis.Rows[4].Cells[j].Text = sayi.ToString("P");
            }



            #endregion


            #region araç bazlı plaka döküm
            SqlCommand cmdPlakaDokum = new SqlCommand();
            cmdPlakaDokum.Connection = connBizim;
            cmdPlakaDokum.CommandTimeout = 1800000000;
            cmdPlakaDokum.CommandText = "ARAC_BAZLI_PLAKA_DOKUM";
            cmdPlakaDokum.Parameters.AddWithValue("@CARIKOD", Session["CariRef"].ToString());
            cmdPlakaDokum.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adpPlakaDokum = new SqlDataAdapter();
            adpPlakaDokum.SelectCommand = cmdPlakaDokum;
            System.Data.DataTable tblPlakaDokum = new System.Data.DataTable();
            adpPlakaDokum.Fill(tblPlakaDokum);
            grdAracBazliPlakaDokum.DataSource = tblPlakaDokum;
            grdAracBazliPlakaDokum.DataBind();

            for (int i = 0; i < grdAracBazliPlakaDokum.Rows.Count; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    decimal sayi = Convert.ToDecimal(grdAracBazliPlakaDokum.Rows[i].Cells[j].Text);
                    grdAracBazliPlakaDokum.Rows[i].Cells[j].Text = sayi.ToString("N");
                }

            }

            #endregion

           
            SqlCommand cmdDetayKarlilik = new SqlCommand();
            cmdDetayKarlilik.Connection = connBizim;
            cmdDetayKarlilik.CommandTimeout = 1800000000;
            cmdDetayKarlilik.CommandText = "DETAY_KARLILIK";
            cmdDetayKarlilik.Parameters.AddWithValue("@CARIKOD", Session["CariRef"].ToString());
            cmdDetayKarlilik.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adpDetayKarlilik = new SqlDataAdapter();
            adpDetayKarlilik.SelectCommand = cmdDetayKarlilik;
            System.Data.DataTable tblDetayKarlilik = new System.Data.DataTable();
            adpDetayKarlilik.Fill(tblDetayKarlilik);
            grdDetayKarlilik.DataSource = tblDetayKarlilik;
            grdDetayKarlilik.DataBind();

            for (int i = 0; i < grdDetayKarlilik.Rows.Count; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (grdDetayKarlilik.Rows[i].Cells[j].Text != "&nbsp;")
                    {
                        decimal sayi = Convert.ToDecimal(grdDetayKarlilik.Rows[i].Cells[j].Text);
                        grdDetayKarlilik.Rows[i].Cells[j].Text = sayi.ToString("N");
                    }
                    else
                    {
                        grdDetayKarlilik.Rows[i].Cells[j].Text = "0.00";
                    }

                }
                //decimal oran = Convert.ToDecimal(grdDetayKarlilik.Rows[i].Cells[4].Text);
                //grdDetayKarlilik.Rows[i].Cells[4].Text = oran.ToString("P");

            }
        }
        if (cmbYıl.SelectedIndex == 1)
        {
            
            SqlCommand cmdSorgu = new SqlCommand();
            cmdSorgu.Connection = connBizim;
            cmdSorgu.CommandTimeout = 1800000000;
            cmdSorgu.CommandText = "DETAY_SATIS_2021";
            cmdSorgu.Parameters.AddWithValue("@CARIKOD", Session["CariRef"].ToString());
            cmdSorgu.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adpFirmaKarDiger = new SqlDataAdapter();
            adpFirmaKarDiger.SelectCommand = cmdSorgu;
            System.Data.DataTable tblFirmaKarDiger = new System.Data.DataTable();
            adpFirmaKarDiger.Fill(tblFirmaKarDiger);
            grdDetaySatis.DataSource = tblFirmaKarDiger;
            grdDetaySatis.DataBind();

            for (int i = 0; i < grdDetaySatis.Rows.Count - 1; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    decimal sayi = Convert.ToDecimal(grdDetaySatis.Rows[i].Cells[j].Text);
                    grdDetaySatis.Rows[i].Cells[j].Text = sayi.ToString("N");
                }

            }

            for (int j = 1; j < 14; j++)
            {
                decimal sayi = Convert.ToDecimal(grdDetaySatis.Rows[4].Cells[j].Text);
                grdDetaySatis.Rows[4].Cells[j].Text = sayi.ToString("P");
            }



         
            SqlCommand cmdPlakaDokum = new SqlCommand();
            cmdPlakaDokum.Connection = connBizim;
            cmdPlakaDokum.CommandTimeout = 1800000000;
            cmdPlakaDokum.CommandText = "ARAC_BAZLI_PLAKA_DOKUM_2021";
            cmdPlakaDokum.Parameters.AddWithValue("@CARIKOD", Session["CariRef"].ToString());
            cmdPlakaDokum.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adpPlakaDokum = new SqlDataAdapter();
            adpPlakaDokum.SelectCommand = cmdPlakaDokum;
            System.Data.DataTable tblPlakaDokum = new System.Data.DataTable();
            adpPlakaDokum.Fill(tblPlakaDokum);
            grdAracBazliPlakaDokum.DataSource = tblPlakaDokum;
            grdAracBazliPlakaDokum.DataBind();

            for (int i = 0; i < grdAracBazliPlakaDokum.Rows.Count; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    decimal sayi = Convert.ToDecimal(grdAracBazliPlakaDokum.Rows[i].Cells[j].Text);
                    grdAracBazliPlakaDokum.Rows[i].Cells[j].Text = sayi.ToString("N");
                }

            }

       

           
            SqlCommand cmdDetayKarlilik = new SqlCommand();
            cmdDetayKarlilik.Connection = connBizim;
            cmdDetayKarlilik.CommandTimeout = 1800000000;
            cmdDetayKarlilik.CommandText = "DETAY_KARLILIK_2021";
            cmdDetayKarlilik.Parameters.AddWithValue("@CARIKOD", Session["CariRef"].ToString());
            cmdDetayKarlilik.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adpDetayKarlilik = new SqlDataAdapter();
            adpDetayKarlilik.SelectCommand = cmdDetayKarlilik;
            System.Data.DataTable tblDetayKarlilik = new System.Data.DataTable();
            adpDetayKarlilik.Fill(tblDetayKarlilik);
            grdDetayKarlilik.DataSource = tblDetayKarlilik;
            grdDetayKarlilik.DataBind();

            for (int i = 0; i < grdDetayKarlilik.Rows.Count; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (grdDetayKarlilik.Rows[i].Cells[j].Text != "&nbsp;")
                    {
                        decimal sayi = Convert.ToDecimal(grdDetayKarlilik.Rows[i].Cells[j].Text);
                        grdDetayKarlilik.Rows[i].Cells[j].Text = sayi.ToString("N");
                    }
                    else
                    {
                        grdDetayKarlilik.Rows[i].Cells[j].Text = "0.00";
                    }

                }
                //decimal oran = Convert.ToDecimal(grdDetayKarlilik.Rows[i].Cells[4].Text);
                //grdDetayKarlilik.Rows[i].Cells[4].Text = oran.ToString("P");

            }
        }

   

    }
}

