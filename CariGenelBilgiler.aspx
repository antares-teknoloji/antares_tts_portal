<%@ Page Title="" Language="C#" MasterPageFile="~/Genel.master" AutoEventWireup="true" CodeFile="CariGenelBilgiler.aspx.cs" Inherits="CariGenelBilgiler" %>

<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        body {
    font-family: sans-serif;
    background-color: gainsboro;
    font-weight: bold;
     -moz-border-radius: 50%;
    -webkit-border-radius: 50%;
    border-radius: 50%
}

.text-box {
    margin-left: 44vw;
   margin-top: 42vh;
}
.btn{
    border-radius: 15px;
    color:white;
}
.btn:link,
.btn:visited {
    text-transform: uppercase;
    text-decoration: none;
    padding: 15px 40px;
    display: inline-block;
    transition: all .2s;
    position: absolute;
     -moz-border-radius: 50%;
    -webkit-border-radius: 50%;
    border-radius: 50%
}

.btn:hover {
    transform: translateY(-3px);
    box-shadow: 0 10px 20px rgba(0, 0, 0, 0.2);
}

.btn:active {
    transform: translateY(-1px);
    box-shadow: 0 5px 10px rgba(0, 0, 0, 0.2);
}

.btn-white {
    background-color: #fff;
    color: #777;
}

.btn::after {
    content: "";
    display: inline-block;
    height: 100%;
    width: 100%;
    border-radius: 100px;
    position: absolute;
    top: 0;
    left: 0;
    z-index: -1;
    transition: all .4s;
     -moz-border-radius: 50%;
    -webkit-border-radius: 50%;
    border-radius: 50%
}

.btn-white::after {
    background-color: #fff;
}

.btn:hover::after {
    transform: scaleX(1.4) scaleY(1.6);
    opacity: 0;
}

.btn-animated {
    animation: moveInBottom 5s ease-out;
    animation-fill-mode: backwards;
}

@keyframes moveInBottom {
    0% {
        opacity: 0;
        transform: translateY(30px);
    }

    100% {
        opacity: 1;
        transform: translateY(0px);
    }
}

        .auto-style1 {
            width: 67%;
            height: 74px;
        }

        .auto-style2 {
            width: 190px;
        }
        .auto-style3 {
            margin-left: 0px;
        }

    </style>
    <div style="background-color: #3366CC; font-weight: 700; height: 25px; text-align: center;" aria-checked="undefined" dir="ltr">
        <dx:ASPxButton ID="ASPxButton1" runat="server" Height="100%" Text="Cari Güncelleme" Width="100%" AutoPostBack="False">
        </dx:ASPxButton>
    </div>
    <br />
    <br />
    
    Firma Ünvan :<dx:ASPxTextBox ID="txtCariAd" runat="server" Height="32px" Width="428px" CssClass="dxeCalendar" Enabled="False">
        
    </dx:ASPxTextBox>
    <br />
    <br />
    <table>
       
            <tr>
                <td style="width:20px; height :40px;"></td>
                <td style="height: 42px">
                    <asp:Button ID="btnGuncelle1" runat="server"  Text="Güncelle" AutoPostBack="False" Height="30px" OnClick="btnGuncelle_Click" Width="140px" Enabled="False" CssClass="btn btn-white btn-animate"/>
                </td>                              
          
                 <td style="width:40px; height :40px;"></td>
                <td style="height: 42px">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Height="30px"  Width ="140px"  Text="Cari Ekstre" CssClass="btn btn-white btn-animate"/>
                </td>                         
          
                 <td style="width:40px; height :40px;"></td>
                <td style="height: 42px">
                    <asp:Button ID="ASPxButton2" runat="server" OnClick="Button2_Click" Height="30px"  Width ="140px" Text="Detay Rapor" CssClass="btn btn-white btn-animate"/>
                </td>     
        </table>
    <br />
    <br />
    <div>
        <table>
            <tr>
                <td style="width: 158px">Shell Yakıt Alım Durum </td>
                <td>:</td>
                <td style="width: 231px">
                    <dx:ASPxLabel ID="lblDurum" runat="server" Font-Bold="True" Font-Size="Large" Text="-">
                    </dx:ASPxLabel>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <dx:ASPxCheckBox ID="chkOtomatikSistem" runat="server" Text="Otomatik Limitlendirmeye Dahil Edilsin">
    </dx:ASPxCheckBox>

    <div>
        <dx:ASPxCheckBox ID="chkBakiyeListe" runat="server" Text="Bakiye Listesinde Görüntülenmesin">
        </dx:ASPxCheckBox>
        <dx:ASPxCheckBox ID="chkGenelRapor" runat="server" Text="Genel Raporda Görüntülensin">
        </dx:ASPxCheckBox>
        <br />
    </div>
        <table style="height: 664px; width: 77%; margin-right: 4px; margin-top: 0px;">
            <tr>
                <td style="width: 156px; font-size: large;"><strong>Eşleştirme Alanları</strong></td>
                <td style="width: 2px">&nbsp;</td>
                <td style="width: 175px">&nbsp;</td>
                <td style="width: 141px; font-size: large;"><strong>Cari Limit-Teminat</strong></td>
                <td style="width: 2px">&nbsp;</td>
                <td class="input-xlarge">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 156px">Satış Temsilcisi</td>
                <td style="width: 2px">:</td>
                <td style="width: 175px">
                    <dx:ASPxComboBox ID="cmbSatisEleman" runat="server" Height="28px" Width="180px">
                        <Items>
                            <dx:ListEditItem Text="Volkan Varol" Value="Volkan Varol" />
                            <dx:ListEditItem Text="Melih Beken" Value="Melih Beken" />
                            <dx:ListEditItem Text="Semih Beken" Value="Semih Beken" />            
                            <dx:ListEditItem Text="Cihan Uzun" Value="Cihan Uzun" />                           
                            <dx:ListEditItem Text="Serkan ZeybekOğlu" Value="Serkan ZeybekOğlu" />        
                            <dx:ListEditItem Text ="Orkun Civan" Value="Orkun Civan" />
                            <dx:ListEditItem Text ="Şeniz Ayhan" Value="Şeniz Ayhan" />
                            <dx:ListEditItem Text ="Selim Başdinç" Value="Selim Başdinç" />
                            <dx:ListEditItem Text ="Sena Mert" Value="Sena Mert" />
                        </Items>
                    </dx:ASPxComboBox>
                </td>
                <td style="width: 141px" class="span3">Toplam Limit</td>
                <td style="width: 2px">:</td>
                <td class="input-xlarge">
                    <dx:ASPxTextBox ID="txtTumLimit" runat="server" Height="28px" Width="180px" DisplayFormatString="n">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 156px">Müşteri İstasyon</td>
                <td style="width: 2px">:</td>
                <td style="width: 175px">
                    <dx:ASPxComboBox ID="cmbIstasyon" runat="server" Height="28px" Width="180px">
                        <Items>
                            <dx:ListEditItem Text="SHELL" Value="SHELL" />
                            <dx:ListEditItem Text="LUKOİL" Value="LUKOİL" />
                            <dx:ListEditItem Text="KEMER" Value="KEMER" />
                            <dx:ListEditItem Text="KORKUTELİ" Value="KORKUTELİ" />
                            <dx:ListEditItem Text="TOTAL" Value="TOTAL" />
                            <dx:ListEditItem Text="ATSO RESTAURANT" Value="ATSO RESTAURANT" />
                            <dx:ListEditItem Text="MERKEZ RESTAURANT" Value="MERKEZ RESTAURANT" />
                            <dx:ListEditItem Text="KİRACI" Value="KİRACI" />
                            <dx:ListEditItem Text="CATERING" Value="CATERING" />
                            <dx:ListEditItem Text="OPET" Value="OPET" />
                        </Items>
                    </dx:ASPxComboBox>
                </td>
                <td style="width: 141px" class="span3">Müşteri Offline Limit</td>
                <td style="width: 2px">:</td>
                <td class="input-xlarge">
                    <dx:ASPxTextBox ID="txtOfflineLimit" runat="server" Height="28px" Width="180px" DisplayFormatString="n" Text="0">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 156px; height: 32px;">Ana Cari</td>
                <td style="width: 2px; height: 32px;">:</td>
                <td style="height: 32px; width: 175px;">
                    <dx:ASPxComboBox ID="cmbAnaCari" runat="server" Height="28px" Width="180px">
                        <Items>
                            <dx:ListEditItem Text="-" Value="-" />
                            <dx:ListEditItem Text="ANTPED" Value="ANTPED" />
                            <dx:ListEditItem Text="ANTAŞ" Value="ANTAŞ" />
                            <dx:ListEditItem Text="BİRPA" Value="BİRPA" />
                            <dx:ListEditItem Text="YENİANTALYA" Value="YENİANTALYA" />
                            <dx:ListEditItem Text="ÇAĞMANLAR" Value="ÇAĞMANLAR" />
                            <dx:ListEditItem Text="ORKUNÇELİK" Value="ORKUNÇELİK" />
                            <dx:ListEditItem Text="M.H.T.DERİCİLİK" Value="M.H.T.DERİCİLİK" />
                            <dx:ListEditItem Text="HİLMİ BEKEN" Value="HİLMİ BEKEN" />
                        </Items>
                    </dx:ASPxComboBox>
                </td>
                <td style="width: 141px; height: 32px;">Müşteri Online Limit</td>
                <td style="width: 2px; height: 32px;">:</td>
                <td style="height: 32px; width: 270px;">
                    <dx:ASPxTextBox ID="txtOnlineLimit" runat="server" Height="28px" Width="180px" DisplayFormatString="n" ReadOnly="True" Text="0">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 156px; text-align: left;">Müşteri Shell Kodu</td>
                <td style="width: 2px">:</td>
                <td style="width: 175px">
                    <dx:ASPxTextBox ID="txtMusteriKod" runat="server" Height="28px" Width="180px">
                    </dx:ASPxTextBox>
                </td>
                <td style="width: 141px" class="span3">Müşteri Online Limit 2</td>
                <td style="width: 2px">:</td>
                <td class="input-xlarge">
                    <dx:ASPxTextBox ID="txtOnlineLimit2" runat="server" Height="28px" Width="180px" DisplayFormatString="n" ReadOnly="True" Text="0">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 156px; height: 35px;">Tolerans Süresi</td>
                <td style="width: 2px; height: 35px;">:</td>
                <td style="height: 35px; width: 175px;">

                    <dx:ASPxTextBox ID="txtTolerans" runat="server" Height="28px" Width="180px">
                    </dx:ASPxTextBox>
                </td>
                <td style="border-style: outset; border-color: #000000; width: 141px; height: 35px;">Teminat Türü</td>
                <td style="border-style: outset; border-color: #000000; width: 2px; height: 35px;">:</td>
                <td style="border-style: outset; border-color: #000000; height: 35px; width: 270px;">
                    <dx:ASPxComboBox ID="cmbTeminatTur" runat="server" Height="28px" Width="180px">
                        <Items>
                            <dx:ListEditItem Text="-" Value="-" />
                            <dx:ListEditItem Text="DBS" Value="DBS" />
                            <dx:ListEditItem Text="TEMİNAT MEKTUP" Value="TEMİNAT MEKTUP" />
                            <dx:ListEditItem Text="TEMİNAT ÇEK" Value="TEMİNAT ÇEK" />
                            <dx:ListEditItem Text="TEMİNAT SENET" Value="TEMİNAT SENET" />
                            <dx:ListEditItem Text="ÖN ÖDEME" Value="ÖN ÖDEME" />
                            <dx:ListEditItem Text="REHİN" Value="REHİN" />
                            <dx:ListEditItem Text="KREDİ KARTI PROVİZYON" Value="KREDİ KARTI PROVİZYON" />
                            <dx:ListEditItem Text="TEMİNATSIZ" Value="TEMİNATSIZ" />
                        </Items>
                    </dx:ASPxComboBox>
                </td>
            </tr>
            <tr>
                <td style="width: 156px">Ödeme Türü</td>
                <td style="width: 2px">:</td>
                <td style="width: 175px">

                    <dx:ASPxComboBox ID="cmbOdemeTur" runat="server" Height="28px" Width="180px">
                    </dx:ASPxComboBox>
                </td>
                <td style="border-style: outset; border-color: #000000; width: 141px">Teminat Tutar</td>
                <td style="border-style: outset; border-color: #000000; width: 2px">:</td>
                <td style="border-style: outset; border-color: #000000;" class="input-xlarge">
                    <dx:ASPxTextBox ID="txtTeminatTutar" runat="server" Height="28px" Width="180px" DisplayFormatString="n">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 156px">Sözleşme Başlangıç</td>
                <td style="width: 2px">:</td>
                <td style="width: 175px">
                    <dx:ASPxDateEdit ID="dtBas" runat="server" Date="12/20/2017 15:40:15" Height="19px" Width="180px">
                    </dx:ASPxDateEdit>
                </td>
                <td style="border-style: outset; border-color: #000000; width: 141px">Banka Adı</td>
                <td style="border-style: outset; border-color: #000000; width: 2px">:</td>
                <td style="border-style: outset; border-color: #000000;" class="input-xlarge">
                    <dx:ASPxComboBox ID="cmbBankaAd" runat="server" Height="28px" Width="180px">
                    </dx:ASPxComboBox>
                </td>
            </tr>
            <tr>
                <td style="width: 156px; height: 46px;">Sözleşme Bitiş</td>
                <td style="width: 2px; height: 46px;">:</td>
                <td style="width: 175px; height: 46px;">
                    <dx:ASPxDateEdit ID="dtBit" runat="server" Date="12/20/2017 15:40:21" Width="180px">
                    </dx:ASPxDateEdit>

                </td>
                <td style="border-style: outset; border-color: #000000; width: 141px; height: 46px;">Banka Dbs Kod</td>
                <td style="border-style: outset; border-color: #000000; width: 2px; height: 46px;">:</td>
                <td style="border-style: outset; border-color: #000000; height: 46px; width: 270px;">
                    <dx:ASPxTextBox ID="txtBankaKod" runat="server" Height="28px" Width="180px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 156px">Taahhüt Litre m3</td>
                <td style="width: 2px">:</td>
                <td style="width: 175px">
                    <dx:ASPxTextBox ID="txtTaahhutLitre" runat="server" Height="28px" Width="180px" DisplayFormatString="n">
                    </dx:ASPxTextBox>
                </td>
                <td style="border-style: ridge; border-color: #FFFF00; width: 141px">Teminat Tür 2</td>
                <td style="border-style: ridge; border-color: #FFFF00; width: 2px">:</td>
                <td style="border-style: ridge; border-color: #FFFF00;" class="input-xlarge">
                    <dx:ASPxComboBox ID="cmbTeminatTur2" runat="server" Height="28px">
                        <Items>
                            <dx:ListEditItem Text="-" Value="-" />
                            <dx:ListEditItem Text="DBS" Value="DBS" />
                            <dx:ListEditItem Text="TEMİNAT MEKTUP" Value="TEMİNAT MEKTUP" />
                            <dx:ListEditItem Text="TEMİNAT ÇEK" Value="TEMİNAT ÇEK" />
                            <dx:ListEditItem Text="TEMİNAT SENET" Value="TEMİNAT SENET" />
                            <dx:ListEditItem Text="ÖN ÖDEME" Value="ÖN ÖDEME" />
                            <dx:ListEditItem Text="REHİN" Value="REHİN" />
                        </Items>
                    </dx:ASPxComboBox>
                </td>
            </tr>
            <tr>
                <td style="width: 156px; height: 42px;">Fatura sistemi</td>
                <td style="width: 2px; height: 42px;">:</td>
                <td style="width: 175px; height: 42px;">
                    <dx:ASPxTextBox ID="txtFaturaTur" runat="server" Height="28px" Width="180px" DisplayFormatString="n">
                    </dx:ASPxTextBox>
                    <br />
                </td>
                <td style="border-style: ridge; border-color: #FFFF00; width: 141px; height: 42px;">Teminat Tutar 2</td>
                <td style="border-style: ridge; border-color: #FFFF00; width: 2px; height: 42px;">:</td>
                <td style="border-style: ridge; border-color: #FFFF00; height: 42px; width: 270px;">
                    <dx:ASPxTextBox ID="txtTeminatTutar2" runat="server" Height="28px" Width="180px" DisplayFormatString="n">
                    </dx:ASPxTextBox>
             
                </td>
            </tr>
            <tr>

                <td style="width: 156px; height: 42px;">Kargo Eşleştirme</td>
                <td style="width: 2px; height: 42px;">&nbsp;</td>
                <td style="width: 175px; height: 42px;">
                    <dx:ASPxTextBox ID="txtKargoEslestirme" runat="server" Height="20px" Width="180px">
                    </dx:ASPxTextBox>
                    <br />
                </td>
                <td style="border-style: ridge; border-color: #FFFF00; width: 141px; height: 42px;">Banka Adı 2</td>
                <td style="border-style: ridge; border-color: #FFFF00; width: 2px; height: 42px;">:</td>
                <td style="border-style: ridge; border-color: #FFFF00; height: 42px; width: 270px;">
                    <dx:ASPxComboBox ID="cmbBankaAd2" runat="server" Height="28px" Width="180px">
                    </dx:ASPxComboBox>
                </td>
            </tr>
            <tr>
                    <td style="width: 156px; height: 44px;">Sektör Seçimi</td>
                <td style="width: 2px; height: 44px;">:</td>
                <td style="width: 175px; height: 44px;">
                  <asp:DropDownList ID= "dpSektor" runat="server" Height="46px" Width="180px">
                  </asp:DropDownList>
                </td>
                
                <td style="border-style: ridge; border-color: #FFFF00; width: 141px; text-align: left; height: 42px;">Banka Dbs Kod 2</td>
                <td style="border-style: ridge; border-color: #FFFF00; width: 2px; height: 44px;"></td>
                <td style="border-style: ridge; border-color: #FFFF00; height: 44px; width: 270px;">
                    <dx:ASPxTextBox ID="txtBankaKod2" runat="server" Height="28px" Width="180px">
                    </dx:ASPxTextBox>
                </td>
               </tr>
            <tr>
                 <td style="width: 156px; text-align: left;">Pratik Kart No</td>
                <td style="width: 2px">:</td>
                <td style="width: 175px">
                    <dx:ASPxTextBox ID="txtPratıkKartNo" runat="server" Height="28px" Width="180px">
                    </dx:ASPxTextBox>
                    <br />
                    </td>
           </tr>
            <tr>
            <td style="width: 156px; height: 44px;">Çıkış Sebebi</td>
                <td style="width: 12px; height: 44px;">:</td>
                <td style="width: 175px; height: 44px;">
                  <asp:DropDownList ID= "dpCıkıs" runat="server" Height="46px" Width="180px">
                  </asp:DropDownList>
                   </td>                       
                     </tr>
        </table>
    <br />
    <div style="width: 100%">
        <table>
            <tr>
                <td style="width: 113px">Açıklama :</td>
                <td>
                    <asp:TextBox ID="txtAciklama" runat="server" Height="84px" TextMode="MultiLine" Width="483px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <div>
            &nbsp;&nbsp;&nbsp;
            <asp:RadioButtonList ID="rdpBayi" runat="server" RepeatDirection="Horizontal" Width="483px">
                <asp:ListItem Value="Shell"></asp:ListItem>
                <asp:ListItem Value="Lukoil"></asp:ListItem>
                <asp:ListItem Value="Total"></asp:ListItem>
                <asp:ListItem Value="Opet"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <br />
        <table>

            <tr>
                <td style="width: 249px; font-size: large; height: 42px;"><strong>İndirimler ve Ödemeler</strong></td>
                <td style="width: 9px; height: 42px;"></td>
                <td style="width: 45px; height: 42px;">Bizim İndirim</td>
                <td style="height: 42px">Diğer İndirim</td>
            </tr>

            <tr>
                <td style="height: 42px; width: 249px;">Shell Ana Bayi Kod
                </td>
                <td style="width: 9px; height: 42px;">:
                </td>
                <td style="width: 45px; height: 42px;">

                    <dx:ASPxTextBox ID="txtAnaBayiKod" runat="server" Height="28px" Width="100px" Text="0">
                    </dx:ASPxTextBox>
                </td>
                <td style="height: 42px"></td>
            </tr>


            <tr>
                <td style="border-style: outset; border-color: #000000; height: 42px; width: 249px;">Shell Ödeme Vadesi
                </td>
                <td style="border-style: outset; border-color: #000000; width: 9px">:
                </td>
                <td style="border-style: outset; border-color: #000000; width: 45px">

                    <dx:ASPxTextBox ID="txtVade1" runat="server" Height="28px" Width="100px" Text="0">
                    </dx:ASPxTextBox>
                </td>
                <td style="border-style: outset; border-color: #000000;">

                    <dx:ASPxTextBox ID="txtVade2" runat="server" Height="28px" Width="100px" Text="0">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td style="border-style: outset; border-color: #000000; width: 249px; height: 42px;">Shell Motorin</td>
                <td style="border-style: outset; border-color: #000000; width: 9px; height: 42px;">:</td>
                <td style="border-style: outset; border-color: #000000; width: 45px; height: 42px;">
                    <dx:ASPxTextBox ID="txtShellBindirimMotorinTl" runat="server" Height="28px" Width="100px" Text="0">
                    </dx:ASPxTextBox>
                </td>
                <td style="border-style: outset; border-color: #000000; height: 42px">
                    <dx:ASPxTextBox ID="txtShellDindirimMotorinTl" runat="server" Height="28px" Width="100px" Text="0">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td style="border-style: outset; border-color: #000000; width: 249px">Shell Benzin</td>
                <td style="border-style: outset; border-color: #000000; width: 9px">:</td>
                <td style="border-style: outset; border-color: #000000; width: 45px">
                    <dx:ASPxTextBox ID="txtShellBindirimTl" runat="server" Height="28px" Width="100px" Text="0">
                    </dx:ASPxTextBox>
                </td>
                <td style="border-style: outset; border-color: #000000;">
                    <dx:ASPxTextBox ID="txtShellDindirimTl" runat="server" Height="28px" Width="100px" Text="0">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td style="border-style: ridge; border-color: #FFFF00; height: 47px; width: 249px;">Lukoil Bayi Kod</td>
                <td style="border-style: ridge; border-color: #FFFF00; height: 47px; width: 9px;">:</td>
                <td style="border-style: ridge; border-color: #FFFF00; height: 47px">

                    <dx:ASPxTextBox ID="txtLukoilAnaBayiKod" runat="server" Height="28px" Width="100px" Text="0">
                    </dx:ASPxTextBox>

                </td>
                <td style="border-style: ridge; border-color: #FFFF00; height: 47px; width: 9px; background-color: #FFFFFF;"></td>
            </tr>
            <tr>
                <td style="border-style: ridge; border-color: #FFFF00; height: 47px; width: 249px;">Lukoil Ödeme Vadesi</td>
                <td style="border-style: ridge; border-color: #FFFF00; height: 47px; width: 9px;">:</td>
                <td style="border-style: ridge; border-color: #FFFF00; height: 47px">

                    <dx:ASPxTextBox ID="txtLukoilOdemeVade1" runat="server" Height="28px" Width="100px" Text="0">
                    </dx:ASPxTextBox>

                </td>
                <td style="border-style: ridge; border-color: #FFFF00; height: 47px">

                    <dx:ASPxTextBox ID="txtLukoilOdemeVade2" runat="server" Height="28px" Width="100px" Text="0">
                    </dx:ASPxTextBox>


                </td>

            </tr>
            <tr>
                <td style="border-style: ridge; border-color: #FFFF00; width: 249px">Lukoil Motorin</td>
                <td style="border-style: ridge; border-color: #FFFF00; width: 9px">:</td>
                <td style="border-style: ridge; border-color: #FFFF00; width: 45px">
                    <dx:ASPxTextBox ID="txtLukoilBindirimMotorin" runat="server" Height="28px" Width="100px" Text="0">
                    </dx:ASPxTextBox>
                </td>
                <td style="border-style: ridge; border-color: #FFFF00;">
                    <dx:ASPxTextBox ID="txtLukoilDindirimMotorin" runat="server" Height="28px" Width="100px" Text="0">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr style="border-style: ridge; border-color: #FFFF00;">
                <td style="border-style: ridge; border-color: #FFFF00; width: 249px">Lukoil Benzin</td>
                <td style="border-style: ridge; border-color: #FFFF00; width: 9px">:</td>
                <td style="border-style: ridge; border-color: #FFFF00; width: 45px">
                    <dx:ASPxTextBox ID="txtLukoilBindirim" runat="server" Height="28px" Width="100px" Text="0">
                    </dx:ASPxTextBox>
                </td>
                <td style="border-style: ridge; border-color: #FFFF00;">
                    <dx:ASPxTextBox ID="txtLukoilDindirim" runat="server" Height="28px" Width="100px" Text="0">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td style="border-style: ridge; border-color: #000000; height: 42px; width: 249px;">Total Bayi Kod</td>
                <td style="border-style: ridge; border-color: #000000; height: 42px">:</td>
                <td style="border-style: ridge; border-color: #000000; height: 42px">
                    <dx:ASPxTextBox ID="txtTotalAnaBayiKod" runat="server" Height="28px" Width="100px" Text="0">
                    </dx:ASPxTextBox>
                </td>
                <td style="border-style: ridge; border-color: #000000; height: 42px; background-color: #FFFFFF;"></td>
            </tr>
            <tr>
                <td style="border-style: ridge; border-color: #000000; height: 42px; width: 249px;">Total Ödeme Vadesi</td>
                <td style="border-style: ridge; border-color: #000000; height: 42px">:</td>
                <td style="border-style: ridge; border-color: #000000; height: 42px">
                    <dx:ASPxTextBox ID="txtTotalOdemeVade1" runat="server" Height="28px" Width="100px" Text="0">
                    </dx:ASPxTextBox>
                </td>
                <td style="border-style: ridge; border-color: #000000; height: 42px">
                    <dx:ASPxTextBox ID="txtTotalOdemeVade2" runat="server" Height="28px" Width="100px" Text="0">
                    </dx:ASPxTextBox>
                </td>
                <td style="border-style: ridge; border-color: #000000; height: 42px">
                    <dx:ASPxTextBox ID="txtTotalOdemeVade3" runat="server" Height="28px" Width="100px" Text="0">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td style="border-style: ridge; border-color: #000000; width: 249px">Total Motorin</td>
                <td style="border-style: ridge; border-color: #000000; width: 9px">:</td>
                <td style="border-style: ridge; border-color: #000000; width: 45px">
                    <dx:ASPxTextBox ID="txtTotalBindirimMotorin" runat="server" Height="28px" Width="100px" Text="0">
                    </dx:ASPxTextBox>
                </td>
                <td style="border-style: ridge; border-color: #000000;">
                    <dx:ASPxTextBox ID="txtTotalDindirimMotorin" runat="server" Height="28px" Width="100px" Text="0">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td style="border-style: ridge; border-color: #000000; width: 249px">Total Benzin</td>
                <td style="border-style: ridge; border-color: #000000; width: 9px">:</td>
                <td style="border-style: ridge; border-color: #000000; width: 45px">
                    <dx:ASPxTextBox ID="txtTotalBindirim" runat="server" Height="28px" Width="100px" Text="0">
                    </dx:ASPxTextBox>
                </td>
                <td style="border-style: ridge; border-color: #000000;">
                    <dx:ASPxTextBox ID="txtTotalDindirim" runat="server" Height="28px" Width="100px" Text="0">
                    </dx:ASPxTextBox>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <div>

            <table class="auto-style1">
                <tr>
                    <td style="width: 1259px">
                        <br />
                        <asp:HyperLink ID="btnFirmaLog" runat="server" NavigateUrl="~/FirmaLog.aspx" Target="_blank">Firma Log İşlemleri</asp:HyperLink>
                        <br />
                        <br />
                        <div>
                            <dx:ASPxGridView ID="grdFirmaLog" runat="server" Width="100%">
                            </dx:ASPxGridView>
                        </div>
                    </td>
                    <td></td>
                </tr>
            </table>
            <br />
            <br />

        </div>
        <div>
            <table style="border: thin groove #000000; width: 100%" border="0">
                <tr>
                    <td style="text-align: center; width: 398px; height: 25px;">Firma Belge Yükleme</td>
                    <td style="text-align: center; height: 25px;">Firma Belge İndirme</td>
                </tr>
            </table>
            <table style="border: thin groove #000000; width: 100%" border="1">
                <tr>
                    <td style="height: 103px; width: 200px">
                        <dx:ASPxRadioButtonList ID="rdpSec" runat="server">
                            <Items>
                                <dx:ListEditItem Text="Firma Evrak" Value="Firma Evrak" />
                                <dx:ListEditItem Text="Teminat Belgesi" Value="Teminat Belgesi" />
                                <dx:ListEditItem Text="Plaka Döküm" Value="Plaka Döküm" />
                                <dx:ListEditItem Text="Sözleşme" Value="Sözleşme" />
                            </Items>
                        </dx:ASPxRadioButtonList>
                    </td>
                    <td style="height: 103px; width: 290px;">
                        <asp:FileUpload ID="fpSozlesme" runat="server" />
                        <br />
                        <br />
                        <dx:ASPxButton ID="btnKaydet" runat="server" Text="Kaydet" Height="38px" OnClick="btnKaydet_Click" Width="198px" Enabled="False">
                        </dx:ASPxButton>

                       


                    </td>
                    <td style="width: 152px">
                        <br />
                        <asp:ListBox ID="lstKlasor" runat="server" Height="90px" Width="167px"></asp:ListBox>
                        <br />
                        &nbsp;</td>
                    <td>
                        <dx:ASPxButton ID="btnIndir" runat="server" Text="İndir" Height="38px" OnClick="btnIndir_Click" Width="160px" Enabled="False">
                        </dx:ASPxButton>
                        <asp:Button ID="btnSil" runat="server" Height="37px" Text="Sil" OnClientClick="return confirm('Seçili Dosyayı Silmek İstediğinize Emin Misiniz?');" Width="159px" OnClick="btnSil_Click" Enabled="False" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <br />
        <div>
            <asp:HyperLink ID="btnTeminatMektup" runat="server" NavigateUrl="~/TeminatMektup.aspx">Teminat Mektup Giriş</asp:HyperLink>
        </div>
        <br />
        <br />
        <div>
            <dx:ASPxGridView ID="grdTeminat" runat="server" Width="99%">
            </dx:ASPxGridView>
        </div>
        <br />
        <table style="width: 100%; height: 38px;">
            <tr>
                <td style="width: 38%">&nbsp;</td>
                <td>

        <br />
        <br />
        
                      </td>
                <td></td>
            </tr>
                    </table>
         <br />
         <table style="width: 100%; height: 38px;">
            <tr>
                <td style="width: 400px">&nbsp;</td>
                <td>
                    <dx:ASPxButton ID="btnGuncelle" runat="server" Text="Kaydet"  Height="49px" OnClick="btnGuncelle_Click" Width="143px" Enabled="False">
                    </dx:ASPxButton>
                </td>
               
              <td style="width: 16px">YIL:</td>
                <td class="auto-style2">
                      <dx:ASPxComboBox ID="cmbYıl" runat="server" Height="15px" Width="117px">
                        <Items>
                            <dx:ListEditItem Text="2020" Value="2020" />
                            <dx:ListEditItem Text="2021" Value="2021" />
                        </Items>
                    </dx:ASPxComboBox>
                    </td>         
                <td style="width: -41px"></td>
                    <td>   
                <dx:ASPxButton ID="btnSec" runat="server" Text="Seç" Height="29px" OnClick="btnSec_Click" Width="113px" CssClass="auto-style3">
                    </dx:ASPxButton>
             </td>
                <td></td>
            </tr>
        </table>
        <table style="height: 53px; width: 100%">
            <tr>
                <td style="width: 285px; height: 51px">&nbsp;</td>
            </tr>
        </table>
        <br />
        <div>      
        </div>
        <br />
        <div>               
  <asp:GridView ID="grdDetaySatis" runat="server" CellPadding="4" ShowFooter="True" Style="text-align: right" Width="99%" AllowSorting="True" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CaptionAlign="Right" CellSpacing="2" Font-Size="Small" ForeColor="Black" Height="246px">
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
        </div>
        <br />
         <br />
        <br />
        <br />
        <div>
          
        </div>
        <br />
        <br />
        <div>
    <asp:GridView ID="grdAracBazliPlakaDokum" runat="server" CellPadding="4" ShowFooter="True" Style="text-align: right" Width="99%" AllowSorting="True" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CaptionAlign="Right" CellSpacing="2" Font-Size="Small" ForeColor="Black" Height="212px">

        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
        </div>
        <br />
        <br />
        <br />
    <asp:GridView ID="grdDetayKarlilik" runat="server" CellPadding="4" ShowFooter="True" Style="text-align: right" Width="99%" AllowSorting="True" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CaptionAlign="Right" CellSpacing="2" Font-Size="Small" ForeColor="Black" Height="206px">

        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
        <br />


       
        <br />
        <br />
        <br />
        <br />

    </div>
</asp:Content>
