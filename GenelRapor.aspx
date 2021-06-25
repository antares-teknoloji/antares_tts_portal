<%@ Page Title="Yönetim Genel Rapor" Language="C#" MasterPageFile="~/Genel.master" AutoEventWireup="true" CodeFile="GenelRapor.aspx.cs" Inherits="GenelRapor" %>

<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="background-color: #3366CC; font-weight: 700; height: 25px; text-align: center;" aria-checked="undefined" dir="ltr">
        <dx:ASPxButton ID="ASPxButton1" runat="server" Height="100%" Text="Yönetim Genel Rapor" Width="100%" AutoPostBack="False">
        </dx:ASPxButton>
    </div>
    <br />
    <br />
    <div>
        <strong><span style="font-size: large">Genel Toplam Kar</span><span style="font-size: x-large"> :&nbsp;
        <asp:Label ID="lblGenelToplamKar" runat="server" Text="-"></asp:Label>
        </span></strong>
    </div>
    <br />
    <br />
    <br />
    <div>
        <table>
            <tr>
                <td style="width: 65px">Plaka :</td>
                <td style="width: 190px">
                    <dx:ASPxTextBox ID="txtPlaka" runat="server" Height="26px" Style="margin-left: 2px" Width="170px">
                    </dx:ASPxTextBox>
                </td>
                <td style="width: 70px">Cari Ad :</td>
                <td style="width: 190px">
                    <dx:ASPxTextBox ID="txtCariAd" runat="server" Height="26px" Style="margin-left: 2px" Width="170px">
                    </dx:ASPxTextBox>
                </td>
                <td>
                    <dx:ASPxButton ID="btnArama" runat="server" Text="Arama" Height="31px" Width="122px" OnClick="btnArama_Click">
                        <BackgroundImage HorizontalPosition="left" ImageUrl="~/image/Search.png" Repeat="NoRepeat" VerticalPosition="center" />
                    </dx:ASPxButton>
                </td>
            </tr>
        </table>
        <br />
        <br />

        <asp:GridView ID="grdCari" CssClass="footable" runat="server" AutoGenerateColumns="false"
            Style="max-width: 100%">
            <Columns>
                <asp:BoundField DataField="FİRMA" HeaderText="FİRMA" />
                <asp:BoundField DataField="OCAK SHELE ÖDENEN" HeaderText="OCAK SHELE ÖDENEN" />
                <asp:BoundField DataField="OCAK MÜŞTERİYE KESİLEN" HeaderText="OCAK MÜŞTERİYE KESİLEN" />
                <asp:BoundField DataField="OCAK KAR" HeaderText="OCAK KAR" />
                 <asp:BoundField DataField="ŞUBAT SHELE ÖDENEN" HeaderText="ŞUBAT SHELE ÖDENEN" />
                <asp:BoundField DataField="ŞUBAT MÜŞTERİYE KESİLEN" HeaderText="ŞUBAT MÜŞTERİYE KESİLEN" />
                <asp:BoundField DataField="ŞUBAT KAR" HeaderText="ŞUBAT KAR" />
                <asp:BoundField DataField="TOPLAM SHELE ÖDENEN" HeaderText="TOPLAM SHELE ÖDENEN" />
                <asp:BoundField DataField="TOPLAM MÜŞTERİYE KESİLEN" HeaderText="TOPLAM MÜŞTERİYE KESİLEN" />
                <asp:BoundField DataField="TOPLAM İSTASYON KAR" HeaderText="TOPLAM İSTASYON KAR" />
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css"
            rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
        <script type="text/javascript">
            $(function () {
                $('[id*=grdCari]').footable();
            });
        </script>
        <br />
    </div>
</asp:Content>

