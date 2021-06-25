using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mCariGenelBilgiler : System.Web.UI.Page
{
    SqlConnection conn, connBizim;
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        if (!IsPostBack)
        {
            VeriCek();
            TahsilatTur();
        }
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
        SqlCommand cmdVeriCek = new SqlCommand("SELECT CL.DEFINITION_ AS [CARİ AD],BANKACCOUNTS5 AS [BİZİM İNDİRİM],EDINO AS [DİĞER İNDİRİM],BANKIBANS4 AS [TOTAL B İNDİRİM],BANKIBANS5 AS [TOTAL D İNDİRİM],BANKBICS1 AS [LUKOIL B İNDİRİM],BANKBICS2 AS [LUKOIL D İNDİRİM],SPECODE2 AS [ANA BAYİ KODU],DBSLIMIT2 AS [MÜŞTERİ LİMİT],BANKNAMES6 AS [İSTASYON],SPECODE3 AS [ÖDEME TÜR],BANKNAMES1 AS [VADE] ,INCHARGE AS [YETKİLİ],TELNRS1 AS [TELEFON],BANKACCOUNTS6 AS ANACARI,BANKIBANS7 AS [BİTİŞ TARİH],BANKIBANS6 AS [BAŞLANGIÇ TARİH],BANKACCOUNTS4 AS [TAAHHÜT M3],BANKNAMES7 AS [MÜŞTERİ KOD],BANKIBANS3 AS [BANKA BAYİ KOD],PY.DEFINITION_ AS [ÖDEME PLANI],BANKACCOUNTS7 AS [BAKİYE LİSTE],BANKACCOUNTS3 AS [TEMİNAT TÜR],DBSLIMIT3,DBSLIMIT4 AS [TEMİNAT TUTAR]  FROM LG_316_CLCARD CL LEFT OUTER JOIN LG_316_PAYPLANS PY ON PY.LOGICALREF=CL.PAYMENTREF WHERE CL.CODE= '" + Session["CariRef"].ToString() + "'", conn);
        conn.Open();
        SqlDataReader rdrVeriCek = cmdVeriCek.ExecuteReader();
        while (rdrVeriCek.Read())
        {
            txtCariAd.Text = rdrVeriCek[0].ToString();
            txtShellBindirim.Text = rdrVeriCek[1].ToString();
            txtShellDindirim.Text = rdrVeriCek[2].ToString();
            txtTotalBindirim.Text = rdrVeriCek[3].ToString();
            txtTotalDindirim.Text = rdrVeriCek[4].ToString();
            txtLukoilBindirim.Text = rdrVeriCek[5].ToString();
            txtLukoilDindirim.Text = rdrVeriCek[6].ToString();
            txtTaahhutLitre.Text = rdrVeriCek[17].ToString();
            txtMusteriLimit.Text = rdrVeriCek[8].ToString();
            cmbIstasyon.Text = rdrVeriCek[9].ToString();
            cmbOdemeTur.Text = rdrVeriCek[10].ToString();
            txtOdemePlan.Text = rdrVeriCek[20].ToString();
            txtMusteriKod.Text = rdrVeriCek[18].ToString();
            txtBankaKod.Text = rdrVeriCek[19].ToString();
            txtVade.Text = rdrVeriCek[11].ToString();
            cmbAnaCari.Text = rdrVeriCek[14].ToString();
            txtAnaBayiKod.Text = rdrVeriCek[7].ToString();
            cmbTeminatTur.Text = rdrVeriCek[22].ToString();
            if (rdrVeriCek[15] != "")
            {
                dtBas.Value = Convert.ToDateTime(rdrVeriCek[16]);
                dtBit.Value = Convert.ToDateTime(rdrVeriCek[15]);
            }
            if (rdrVeriCek[21].ToString() == "H")
            { chkBakiyeListe.Checked = true; }
            else
            { chkBakiyeListe.Checked = false; }
            if (rdrVeriCek[23].ToString() == "1")
            {
                txtShellYakitDurum.Text = "Kapalı";
            }
            else
            {
                txtShellYakitDurum.Text = "Açık";
            }
            txtTeminatTutar.Text = rdrVeriCek[24].ToString();
        }
        conn.Close();
    }
    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        
        SqlCommand cmdGuncelle = new SqlCommand("UPDATE LG_316_CLCARD SET BANKACCOUNTS5=@SHELLBINDIRIM,EDINO=@SHELLDINDIRIM,BANKIBANS4=@TOTALBINDIRIM,BANKIBANS5=@TOTALDINDIRIM,BANKBICS1=@LUKOILBINDIRIM,BANKBICS2=@LUKOILDINDIRIM,SPECODE2=@ANABAYIKOD,DBSLIMIT2=@MUSTERILIMIT,BANKNAMES6=@ISTASYON,SPECODE3=@ODEMETUR,BANKNAMES1=@VADE,BANKACCOUNTS6=@ANACARI,BANKIBANS7=@BITTAR,BANKIBANS6=@BASTAR,BANKACCOUNTS4=@TAAHHUTLT,BANKNAMES7=@MUSTERIKOD,BANKIBANS3=@BANKAKOD,BANKACCOUNTS7=@BAKIYELISTE,BANKACCOUNTS3=@TEMINATTUR,DBSLIMIT4=@TEMINATTUTAR WHERE CODE='" + Session["CariRef"].ToString() + "'", conn);
        cmdGuncelle.Parameters.AddWithValue("@SHELLBINDIRIM", txtShellBindirim.Text);
        cmdGuncelle.Parameters.AddWithValue("@SHELLDINDIRIM", txtShellDindirim.Text);
        cmdGuncelle.Parameters.AddWithValue("@TOTALBINDIRIM", txtTotalBindirim.Text);
        cmdGuncelle.Parameters.AddWithValue("@TOTALDINDIRIM", txtTotalDindirim.Text);
        cmdGuncelle.Parameters.AddWithValue("@LUKOILBINDIRIM", txtLukoilBindirim.Text);
        cmdGuncelle.Parameters.AddWithValue("@LUKOILDINDIRIM", txtLukoilDindirim.Text);
        cmdGuncelle.Parameters.AddWithValue("@ANABAYIKOD", txtAnaBayiKod.Text);
        cmdGuncelle.Parameters.AddWithValue("@MUSTERILIMIT", txtMusteriLimit.Text);
        cmdGuncelle.Parameters.AddWithValue("@ISTASYON", cmbIstasyon.Text);
        cmdGuncelle.Parameters.AddWithValue("@ODEMETUR", cmbOdemeTur.Text);
        cmdGuncelle.Parameters.AddWithValue("@VADE", txtVade.Text);
        cmdGuncelle.Parameters.AddWithValue("@ANACARI", cmbAnaCari.Text);
        cmdGuncelle.Parameters.AddWithValue("@BITTAR", dtBit.Text);
        cmdGuncelle.Parameters.AddWithValue("@BASTAR", dtBas.Text);
        cmdGuncelle.Parameters.AddWithValue("@TAAHHUTLT", txtTaahhutLitre.Text);
        cmdGuncelle.Parameters.AddWithValue("@MUSTERIKOD", txtMusteriKod.Text);
        cmdGuncelle.Parameters.AddWithValue("@BANKAKOD", txtBankaKod.Text);
        cmdGuncelle.Parameters.AddWithValue("@TEMINATTUR", cmbTeminatTur.Text);
        if (chkBakiyeListe.Checked == true)
        { cmdGuncelle.Parameters.AddWithValue("@BAKIYELISTE", "H"); }
        else
        {
            cmdGuncelle.Parameters.AddWithValue("@BAKIYELISTE", "");
        }
        cmdGuncelle.Parameters.AddWithValue("@TEMINATTUTAR", txtTeminatTutar.Text);
        conn.Open();
        cmdGuncelle.ExecuteNonQuery();
        conn.Close();       
        RegisterStartupScript("PencereyiKapa", "<script>window.close(); </script>"); 
    }
}
