<%@ Page Title="" Language="C#" MasterPageFile="~/Genel.master" AutoEventWireup="true" CodeFile="CariBakiye.aspx.cs" Inherits="CariBakiye" %>

<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <dx:ASPxButton ID="ASPxButton1" runat="server" Height="100%" Text="Cari Bakiye Listesi" Width="100%" AutoPostBack="False">
    </dx:ASPxButton>
    <br />
    <table>
        <tr>
            <td style="width: 65px">
            <asp:Button ID="btnSorgula" runat="server" Text="Yeni Liste Çek" CssClass="button" BackColor="Silver" Height="61px" Width="267px" ForeColor="Black" OnClick="btnCariHesapListesi_Click" />
            </td>
            <td style="width: 190px">
            <asp:Button ID="btnListeCek" runat="server" Text="Kaydedilen Liste Çek" CssClass="button" BackColor="Silver" Height="61px" Width="267px" ForeColor="Black" OnClick="btnCariHesapListesi_Click" />
            </td>
            <td style="width: 70px">
            <asp:Button ID="btnKaydet" runat="server" Text="Yeni Liste Kaydet" CssClass="button" BackColor="Silver" Height="61px" Width="267px" ForeColor="Black" OnClick="btnCariHesapListesi_Click" />
            </td>
            <td style="width: 190px">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <br />
    <asp:GridView ID="grdCari" runat="server" CellPadding="3" ShowFooter="True" Style="text-align: left" Width="100%" AllowSorting="True" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CaptionAlign="Right" CellSpacing="1" Font-Size="Small" GridLines="None" OnSorting="grdCari_Sorting" OnRowCommand="grdCari_RowCommand">
        <Columns>
            <asp:ButtonField HeaderText="DETAY" Text="DETAY" CommandName="DETAY" />
        </Columns>
        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#594B9C" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#33276A" />
    </asp:GridView>
    <br />
</asp:Content>

