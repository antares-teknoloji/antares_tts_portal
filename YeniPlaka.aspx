<%@ Page Title="" Language="C#" MasterPageFile="~/Genel.master" AutoEventWireup="true" CodeFile="YeniPlaka.aspx.cs" Inherits="YeniPlaka" %>


<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div style="background-color: #3366CC; font-weight: 700; height: 25px; text-align: center;" aria-checked="undefined" dir="ltr">
        <dx:aspxbutton ID="ASPxButton1" runat="server" Height="100%" Text="Cari Hesap Listesi" Width="100%" AutoPostBack="False" AllowFocus="False" >
        </dx:aspxbutton>        
    </div>
    <br />

            <dx:ASPxHyperLink ID="hpPlakaListe" runat="server" NavigateUrl="~/PlakaListe.aspx" Text="Plaka Liste" />

    <br />
    <div style="width: 100%">
        <br />
        <br />
        <div>
            <table style="width: 100%">
                <tr>
                    <td style="width: 75px">Cari Ad</td>
                    <td class="dxeButtonEditSys" style="width: 3px">:</td>
                    <td>
                        <dx:ASPxTextBox ID="txtCari" runat="server" Height="34px" Width="221px" AutoPostBack="True" OnTextChanged="txtCariAd_TextChanged">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 75px">Plaka</td>
                    <td class="dxeButtonEditSys" style="width: 3px">:</td>
                    <td>
                        <dx:ASPxTextBox ID="txtPlaka" runat="server" Height="34px" Width="221px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 75px"></td>
                    <td class="dxeButtonEditSys" style="width: 3px"></td>
                    <td>
                        <dx:ASPxButton ID="btnKaydet" runat="server" Height="36px" Text="Kaydet" Width="135px" AllowFocus="False" AutoPostBack="False" OnClick="btnKaydet_Click">
                            <BackgroundImage ImageUrl="~/image/kart.PNG" Repeat="NoRepeat" />
                        </dx:ASPxButton>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        </div>
</asp:Content>

