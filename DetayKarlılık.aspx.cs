using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DetayKarlılık: System.Web.UI.Page
{
    SqlConnection conn, connBizim;
    SqlDataAdapter adpArama;
    SqlDataAdapter adpCari;
    DataTable tblCari;
    DataTable tblArama;
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
        if (!IsPostBack)
        {
            VeriCek();
        }
    }
    protected void VeriCek()
    {
        adpCari = new SqlDataAdapter("SELECT[SHELL FATURA BİZE KESİLEN] = sum(CAST(SHELEODENEN AS decimal(18, 2))),[HB FATURA MÜŞTERİYE KESİLEN] = sum(CAST(MUSTERIKESILEN AS decimal(18, 2))),[TTS KAR] = sum(CAST(TTSKAR AS decimal(18, 2))),[İSTASYON KAR] = sum(CAST(ISTASYONKAR AS decimal(18, 2))),[KAR] = sum(CAST(KAR AS decimal(18, 2))) FROM BS_KARLILIK  WHERE month(TARIH) = 1 and year(TARIH) = 2020 UNION ALL SELECT [SHELL FATURA BİZE KESİLEN] = sum(CAST(SHELEODENEN AS decimal(18, 2))),[HB FATURA MÜŞTERİYE KESİLEN] = sum(CAST(MUSTERIKESILEN AS decimal(18, 2))),[TTS KAR] = sum(CAST(TTSKAR AS decimal(18, 2))),[İSTASYON KAR] = sum(CAST(ISTASYONKAR AS decimal(18, 2))),[KAR] = sum(CAST(KAR AS decimal(18, 2))) FROM BS_KARLILIK  WHERE month(TARIH) = 2 and year(TARIH) = 2020 UNION ALL SELECT [SHELL FATURA BİZE KESİLEN] = sum(CAST(SHELEODENEN AS decimal(18, 2))),[HB FATURA MÜŞTERİYE KESİLEN] = sum(CAST(MUSTERIKESILEN AS decimal(18, 2))),[TTS KAR] = sum(CAST(TTSKAR AS decimal(18, 2))),[İSTASYON KAR] = sum(CAST(ISTASYONKAR AS decimal(18, 2))),[KAR] = sum(CAST(KAR AS decimal(18, 2))) FROM BS_KARLILIK  WHERE month(TARIH) = 3 and year(TARIH) = 2020 UNION ALL SELECT [SHELL FATURA BİZE KESİLEN] = sum(CAST(SHELEODENEN AS decimal(18, 2))), [HB FATURA MÜŞTERİYE KESİLEN] = sum(CAST(MUSTERIKESILEN AS decimal(18, 2))),[TTS KAR] = sum(CAST(TTSKAR AS decimal(18, 2))),[İSTASYON KAR] = sum(CAST(ISTASYONKAR AS decimal(18, 2))),[KAR] = sum(CAST(KAR AS decimal(18, 2))) FROM BS_KARLILIK  WHERE month(TARIH) = 4 and year(TARIH) = 2020 UNION ALL SELECT [SHELL FATURA BİZE KESİLEN] = sum(CAST(SHELEODENEN AS decimal(18, 2))),[HB FATURA MÜŞTERİYE KESİLEN] = sum(CAST(MUSTERIKESILEN AS decimal(18, 2))),[TTS KAR] = sum(CAST(TTSKAR AS decimal(18, 2))),[İSTASYON KAR] = sum(CAST(ISTASYONKAR AS decimal(18, 2))),[KAR] = sum(CAST(KAR AS decimal(18, 2))) FROM BS_KARLILIK  WHERE month(TARIH) = 5 and year(TARIH) = 2020 UNION ALL SELECT [SHELL FATURA BİZE KESİLEN] = sum(CAST(SHELEODENEN AS decimal(18, 2))),[HB FATURA MÜŞTERİYE KESİLEN] = sum(CAST(MUSTERIKESILEN AS decimal(18, 2))),[TTS KAR] = sum(CAST(TTSKAR AS decimal(18, 2))),[İSTASYON KAR] = sum(CAST(ISTASYONKAR AS decimal(18, 2))),[KAR] = sum(CAST(KAR AS decimal(18, 2))) FROM BS_KARLILIK  WHERE month(TARIH) = 6 and year(TARIH) = 2020 UNION ALL SELECT [SHELL FATURA BİZE KESİLEN] = sum(CAST(SHELEODENEN AS decimal(18, 2))),[HB FATURA MÜŞTERİYE KESİLEN] = sum(CAST(MUSTERIKESILEN AS decimal(18, 2))),[TTS KAR] = sum(CAST(TTSKAR AS decimal(18, 2))),[İSTASYON KAR] = sum(CAST(ISTASYONKAR AS decimal(18, 2))),[UNION ALL SELECT [SHELL FATURA BİZE KESİLEN] = sum(CAST(SHELEODENEN AS decimal(18, 2))),[HB FATURA MÜŞTERİYE KESİLEN] = sum(CAST(MUSTERIKESILEN AS decimal(18, 2))),[TTS KAR] = sum(CAST(TTSKAR AS decimal(18, 2))),[İSTASYON KAR] = sum(CAST(ISTASYONKAR AS decimal(18, 2))),[KAR] = sum(CAST(KAR AS decimal(18, 2))) FROM BS_KARLILIK  WHERE month(TARIH) = 8 and year(TARIH) = 2020", conn);
        tblCari = new DataTable();
        adpCari.Fill(tblCari);
        this.grdCari.DataSource = tblCari;
        this.grdCari.DataBind();

    }

}