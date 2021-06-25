using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GunSonuKapatilanYakit : System.Web.UI.Page
{
    SqlDataAdapter adpVeri;
    DataTable tblVeri;
    SqlConnection connBizim;
    protected void Page_Load(object sender, EventArgs e)
    {
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
    }

    protected void btnArama_Click(object sender, EventArgs e)
    {
        adpVeri = new SqlDataAdapter("SELECT TCG.CARIAD AS [CARİ AD],TG.LIMIT AS [KALAN LİMİT] FROM TTS_GUNLUK_YAKIT_KAPATMA TG LEFT OUTER JOIN TTSPORTAL_CARIBILGI TCG ON TCG.CARIKOD=TG.CARIKOD  WHERE TG.TARIH=CONVERT(DATETIME,'" + dtTarih.Text + "',104) AND TCG.CARIAD LIKE  ('%" + txtCariAd.Text + "%')", connBizim);
        tblVeri = new DataTable();
        adpVeri.Fill(tblVeri);
        this.grdGunlukKapatma.DataSource = tblVeri;
        this.grdGunlukKapatma.DataBind();
    }
}