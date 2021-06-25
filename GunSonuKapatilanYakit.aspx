<%@ Page Title="" Language="C#" MasterPageFile="~/Genel.master" AutoEventWireup="true" CodeFile="GunSonuKapatilanYakit.aspx.cs" Inherits="GunSonuKapatilanYakit" %>

<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<script runat="server">


</script>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 42px;
            width: 100px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <dx:ASPxButton ID="ASPxButton1" runat="server" Height="100%" Text="Gün Sonu Yakıt Kapatma" Width="100%" AutoPostBack="False">
    </dx:ASPxButton>

    <table>
        <tr>
            <td style="width: 65px; height: 42px;">Tarih :</td>
            <td style="width: 190px; height: 42px;">
                <dx:ASPxDateEdit ID="dtTarih" runat="server" Width="187px">
                </dx:ASPxDateEdit>
            </td>

            <td class="auto-style1">Firma Ünvan :</td>
            <td style="width: 190px; height: 42px;">
                <asp:TextBox ID="txtCariAd" runat="server" Height="23px" Style="margin-left: 2px" Width="170px" CssClass="yuvarlak"></asp:TextBox>
            </td>
            <td style="height: 42px">
                <dx:ASPxButton ID="btnArama" runat="server" Text="Arama" Height="31px" Width="122px" OnClick="btnArama_Click">
                    <BackgroundImage HorizontalPosition="left" ImageUrl="~/image/Search.png" Repeat="NoRepeat" VerticalPosition="center" />
                </dx:ASPxButton>
            </td>
        </tr>
    </table>
    <br />
    <br />

    <div style="overflow: auto; height: 550px; width: 100%;">
        <asp:GridView ID="grdGunlukKapatma" runat="server" CellPadding="2" ShowFooter="True" Style="text-align: right" Width="100%" AllowSorting="True" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CaptionAlign="Right" CellSpacing="2" Font-Size="Small" ForeColor="Black" Font-Names="Copperplate">

            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="#000099" Font-Bold="True" CssClass="header" Font-Size="Small" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

