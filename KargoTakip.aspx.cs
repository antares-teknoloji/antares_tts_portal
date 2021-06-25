using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class KargoTakip : System.Web.UI.Page
{
    SqlCommand cmdKaydet;
    SqlDataAdapter adpCari, adpKontrol;
    DataTable tblCari, tblKontrol;
    SqlConnection conn, connBizim;
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
        connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
    }
    protected void btnSorgula_Click(object sender, EventArgs e)
    {
        if (fpDosya.HasFile)//Kullanıcı fpDosya ile bir dosya seçmiş ise işlemleri gerçekleştir.
        {              
            DataTable tblVeri = new DataTable();
            DataSet ds = new DataSet();
            tblVeri.Columns.Add("TARIH");
            tblVeri.Columns.Add("TAKIPNO");
            tblVeri.Columns.Add("CARIAD");
            string dosyayolu = fpDosya.PostedFile.FileName;
            string klasor = "C:\\excel\\";
            fpDosya.SaveAs(klasor + fpDosya.FileName);
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + klasor + dosyayolu + ";Extended Properties=Excel 12.0;";
            OleDbConnection objConn = new OleDbConnection(connectionString);
            objConn.Open();
            String sorgu = "SELECT * FROM [Sheet1$]";
            OleDbCommand objCmdSelect = new OleDbCommand(sorgu, objConn);
            OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
            objAdapter1.SelectCommand = objCmdSelect;
            objAdapter1.Fill(ds, "ExcelData");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i][1].ToString().Length > 9)
                {
                    if (ds.Tables[0].Rows[i][1].ToString().Substring(0, 10).Replace(":", "").TrimEnd().TrimStart() == dtTarih.Text)
                    {
                        //tblVeri.Rows.Add();
                        tblVeri.Columns["TARIH"].DefaultValue = ds.Tables[0].Rows[i][1].ToString().Substring(0, 10).Replace(":", "").TrimEnd().TrimStart();
                        tblVeri.Columns["TAKIPNO"].DefaultValue = ds.Tables[0].Rows[i][3].ToString() + ds.Tables[0].Rows[i][4].ToString();
                        tblVeri.Columns["CARIAD"].DefaultValue = ds.Tables[0].Rows[i][19].ToString();
                        tblVeri.Rows.Add(ds.Tables[0].Rows[i][1].ToString().Substring(0, 10).Replace(":", "").TrimEnd().TrimStart());
                    }
                }
            }
            grdKayit.DataSource = tblVeri;
            grdKayit.DataBind();
            objConn.Close();
        }
    }
    protected void btnGonder_Click(object sender, EventArgs e)
    {
        #region kayıt kontrol
        adpKontrol = new SqlDataAdapter("SELECT * FROM KARGO_TAKIP WHERE TARIH=CONVERT(DATETIME,'" + dtTarih.Text + "',104)", connBizim);
        tblKontrol = new DataTable();
        adpKontrol.Fill(tblKontrol);
        #endregion
        if (tblKontrol.Rows.Count == 0)
        {
            for (int i = 0; i < grdKayit.PageCount; i++)
            {
                #region kaydediliyor
                #region cari bulunuyor
                adpCari = new SqlDataAdapter("SELECT CODE,DEFINITION_,DSPSENDEMAILADDR FROM LG_316_CLCARD WHERE INCHARGE3='" + grdKayit.GetRowValues(i, "CARIAD") + "'", conn);
                tblCari = new DataTable();
                adpCari.Fill(tblCari);
                #endregion
                if (tblCari.Rows.Count > 0)
                {
                    cmdKaydet = new SqlCommand("INSERT INTO KARGO_TAKIP (TARIH,TAKIPNO,CARIAD,CARIKOD,MAIL)" +
                        " VALUES (@TARIH,@TAKIPNO,@CARIAD,@CARIKOD,@MAIL)", connBizim);
                    cmdKaydet.Parameters.AddWithValue("@TARIH", Convert.ToDateTime(grdKayit.GetRowValues(i, "TARIH")));
                    cmdKaydet.Parameters.AddWithValue("@TAKIPNO", grdKayit.GetRowValues(i, "TAKIPNO"));
                    cmdKaydet.Parameters.AddWithValue("@CARIAD", tblCari.Rows[0][1].ToString());
                    cmdKaydet.Parameters.AddWithValue("@CARIKOD", tblCari.Rows[0][0].ToString());
                    cmdKaydet.Parameters.AddWithValue("@MAIL", tblCari.Rows[0][2].ToString());
                    if (connBizim.State == ConnectionState.Closed)
                    { connBizim.Open(); }
                    cmdKaydet.ExecuteNonQuery();
                    if (connBizim.State == ConnectionState.Open)
                    { connBizim.Close(); }
                }
                else
                {
                    cmdKaydet = new SqlCommand("INSERT INTO KARGO_TAKIP (TARIH,TAKIPNO,CARIAD,CARIKOD,MAIL) " +
                        "VALUES (@TARIH,@TAKIPNO,@CARIAD,@CARIKOD,@MAIL)", connBizim);
                    cmdKaydet.Parameters.AddWithValue("@TARIH", Convert.ToDateTime(grdKayit.GetRowValues(i, "TARIH")));
                    cmdKaydet.Parameters.AddWithValue("@TAKIPNO", grdKayit.GetRowValues(i, "TAKIPNO"));
                    cmdKaydet.Parameters.AddWithValue("@CARIAD", "boş");
                    cmdKaydet.Parameters.AddWithValue("@CARIKOD", "boş");
                    cmdKaydet.Parameters.AddWithValue("@MAIL", "");
                    if (connBizim.State == ConnectionState.Closed)
                    { connBizim.Open(); }
                    cmdKaydet.ExecuteNonQuery();
                    if (connBizim.State == ConnectionState.Open)
                    { connBizim.Close(); }
                }
                #endregion
                if (tblCari.Rows[0][2].ToString() != "")
                {
                    #region mail atılıyor
                    System.Net.Mail.MailMessage msj = new System.Net.Mail.MailMessage();
                    SmtpClient sc = new SmtpClient();
                    sc.Credentials = new System.Net.NetworkCredential("tts@hilmibeken.com", "123456!");
                    //ALICI EKLENİYOR
                    msj.To.Add("bilgiislem@hilmibeken.com");
                    //GÖNDEREN EKLENİYOR
                    msj.From = new System.Net.Mail.MailAddress("tts@hilmibeken.com", "HİLMİ BEKEN OTOMATİK MAİL", Encoding.UTF8);
                    msj.Subject = "Kargo Takip Bilgisi";
                    msj.SubjectEncoding = Encoding.UTF8;
                    msj.BodyEncoding = Encoding.UTF8;
                    msj.IsBodyHtml = true;
                    msj.Body = "Hilmi Beken Otomatik Mail Sistemi İle Gönderilmiştir." + "<br/>" + " <br/>" + " Sayın " + "      " + tblCari.Rows[0][1].ToString() + "; " + "<br/>" + "<br/>" + " Siparişi verilen cihazınız kargoya verilmiştir.Aşağıdaki linkten   " + grdKayit.GetRowValues(i, "TAKIPNO") + " takip numarası  ile kargo durumu ile ilgili sorgulama yapabilirsiniz.  " + "<br/>" + " " + "<br/>" + "<br/>" + "http://www.mngkargo.com.tr/tr/" + "<br/>" + "<br/>" + " Cihazlar Kullanım güvenliğinden dolayı kapalı olarak gelmektedir.Cihazların açılması için destek@hilmibeken.com mail adresine dönüş yapabilir veya 02424433015 numaralı telefondan ulaşabilirsiniz " + "<br/>" + "<br/>" + "İyi Günler Dileriz.";
                    sc.Port = 587;
                    sc.Host = "smtp.yandex.com.tr"; // Host Adresi    
                    sc.EnableSsl = true;
                    sc.Send(msj);
                    msj.Dispose();
                    //    }
                    //}
                    #endregion
                }
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('İşlem Tamamlanmıştır');</script>");
            Response.Redirect("KargoTakip.aspx");
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Seçmiş olduğunuz tarihte kayıtlar bulunmaktadır');</script>");
        }
    }
}