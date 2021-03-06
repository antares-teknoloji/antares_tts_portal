<%@ Page Title="" Language="C#" MasterPageFile="~/MobileGenel.master" AutoEventWireup="true" CodeFile="mCariGenelBilgiler.aspx.cs" Inherits="mCariGenelBilgiler" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="hero-unit">
        <table style="width: 339px">
            <tr>
                <td>
                    <dx:ASPxCheckBox ID="chkBakiyeListe" runat="server" Height="40px" Text="Bakiye Listesinde Görüntülenmesin" Width="252px">
                    </dx:ASPxCheckBox>
                </td>                
            </tr>
            <tr>
                <td style="text-align: center">Shell Yakıt Durum</td>
            </tr>
            <tr>
                <td >
                    <dx:ASPxTextBox ID="txtShellYakitDurum" runat="server" Height="38px" Width="100%">
                    </dx:ASPxTextBox>
                </td>               
            </tr>           
            <tr>
                <td  style="text-align: center">Cari Ad</td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxTextBox ID="txtCariAd" runat="server" Height="38px" Width="100%">
                    </dx:ASPxTextBox>
                </td>              
            </tr>
              <tr>
                <td  style="text-align: center">Taahhüt Litre</td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxTextBox ID="txtTaahhutLitre" runat="server" Height="38px" Width="100%">
                    </dx:ASPxTextBox>
                </td>              
            </tr>
              <tr>
                <td  style="text-align: center">Shell Bizim İndirim</td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxTextBox ID="txtShellBindirim" runat="server" Height="38px" Width="100%">
                    </dx:ASPxTextBox>
                </td>              
            </tr>
            <tr>
                <td  style="text-align: center">Shell Diğer İndirim</td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxTextBox ID="txtShellDindirim" runat="server" Height="38px" Width="100%">
                    </dx:ASPxTextBox>
                </td>              
            </tr>
             <tr>
                <td  style="text-align: center">Lukoil Bizim İndirim</td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxTextBox ID="txtLukoilBindirim" runat="server" Height="38px" Width="100%">
                    </dx:ASPxTextBox>
                </td>              
            </tr>
             <tr>
                <td  style="text-align: center">Lukoil Diğer İndirim</td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxTextBox ID="txtLukoilDindirim" runat="server" Height="38px" Width="100%">
                    </dx:ASPxTextBox>
                </td>              
            </tr>
             <tr>
                <td  style="text-align: center">Total Bizim İndirim</td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxTextBox ID="txtTotalBindirim" runat="server" Height="38px" Width="100%">
                    </dx:ASPxTextBox>
                </td>              
            </tr>
            <tr>
                <td  style="text-align: center">Total Diğer İndirim</td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxTextBox ID="txtTotalDindirim" runat="server" Height="38px" Width="100%">
                    </dx:ASPxTextBox>
                </td>              
            </tr>
            <tr>
                <td  style="text-align: center">Ana Bayi Kod</td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxTextBox ID="txtAnaBayiKod" runat="server" Height="38px" Width="100%">
                    </dx:ASPxTextBox>
                </td>              
            </tr>
            <tr>
                <td  style="text-align: center">Müşteri Limit</td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxTextBox ID="txtMusteriLimit" runat="server" Height="38px" Width="100%">
                    </dx:ASPxTextBox>
                </td>              
            </tr>
            <tr>
                <td  style="text-align: center">Müşteri İstasyon</td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxComboBox ID="cmbIstasyon" runat="server" Height="37px" ValueType="System.String" Width="100%">
                        <Items>
                            <dx:ListEditItem Text="SHELL" Value="SHELL" />
                            <dx:ListEditItem Text="LUKOİL" Value="LUKOİL" />
                            <dx:ListEditItem Text="KEMER" Value="KEMER" />
                            <dx:ListEditItem Text="KORKUTELİ" Value="KORKUTELİ" />
                            <dx:ListEditItem Text="TOTAL" Value="TOTAL" />
                            <dx:ListEditItem Text="ATSO RESTAURANT" Value="ATSO RESTAURANT" />
                            <dx:ListEditItem Text="MERKEZ RESTAURANT" Value="MERKEZ RESTAURANT" />
                            <dx:ListEditItem Text="KİRACI" Value="KİRACI" />
                        </Items>
                    </dx:ASPxComboBox>
                </td>              
            </tr>
             <tr>
                <td  style="text-align: center">Ödeme Tür</td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxComboBox ID="cmbOdemeTur" runat="server" Height="37px" ValueType="System.String" Width="100%">
                    </dx:ASPxComboBox>
                </td>              
            </tr>
              <tr>
                <td  style="text-align: center">Ödeme Planı</td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxTextBox ID="txtOdemePlan" runat="server" Height="38px" Width="100%">
                    </dx:ASPxTextBox>
                </td>              
            </tr>
              <tr>
                <td  style="text-align: center">Müşteri Kodu</td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxTextBox ID="txtMusteriKod" runat="server" Height="38px" Width="100%">
                    </dx:ASPxTextBox>
                </td>              
            </tr>
              <tr>
                <td  style="text-align: center">Banka Bayi Kod</td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxTextBox ID="txtBankaKod" runat="server" Height="38px" Width="100%">
                    </dx:ASPxTextBox>
                </td>              
            </tr>
              <tr>
                <td  style="text-align: center">Vade</td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxTextBox ID="txtVade" runat="server" Height="38px" Width="100%">
                    </dx:ASPxTextBox>
                </td>              
            </tr>
             <tr>
                <td  style="text-align: center">Ana Cari</td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxComboBox ID="cmbAnaCari" runat="server" Height="37px" ValueType="System.String" Width="100%">
                        <Items>
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
            </tr>
             <tr>
                <td  style="text-align: center">Teminat Tür</td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxComboBox ID="cmbTeminatTur" runat="server" Height="37px" ValueType="System.String" Width="100%">
                        <Items>
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
                <td  style="text-align: center">Teminat Tutar</td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxTextBox ID="txtTeminatTutar" runat="server" Height="38px" Width="100%">
                    </dx:ASPxTextBox>
                </td>              
            </tr>
             <tr>
                <td  style="text-align: center">Sözleşme Başlangıç</td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxDateEdit ID="dtBas" runat="server" Height="35px" Width="100%">
                    </dx:ASPxDateEdit>
                </td>              
            </tr>
             <tr>
                <td  style="text-align: center">Sözleşme Bitiş</td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxDateEdit ID="dtBit" runat="server" Height="35px" Width="100%">
                    </dx:ASPxDateEdit>
                </td>              
            </tr>
        </table>
        <br />
        <br />

    </div>
    <dx:ASPxButton ID="btnKaydet" runat="server" Height="43px" Text="Kaydet" Width="100%" OnClick="btnKaydet_Click">
    </dx:ASPxButton>
</asp:Content>

