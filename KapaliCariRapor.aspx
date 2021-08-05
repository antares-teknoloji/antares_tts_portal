<%@ Page Title="" Language="C#" MasterPageFile="~/Genel.master" AutoEventWireup="true" CodeFile="KapaliCariRapor.aspx.cs" Inherits="KapaliCariRapor" EnableEventValidation="false"%>



<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>







<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="background-color: #3366CC; font-weight: 700; height: 25px; text-align: center;" aria-checked="undefined" dir="ltr">
        <dx:ASPxButton ID="ASPxButton1" runat="server" Height="100%" Text="Teminat Mektupları" Width="100%" AutoPostBack="False">
        </dx:ASPxButton>
    </div>
    <br />
    <br />
    <div>
        <table style="height: 34px; width: 759px">
            <tr>
                <td class="auto-style2" style="width: 44px"></td>
                <td class="auto-style1" style="width: 42px">Cari</td>
                <td style="width: 3px">:</td>
                <td class="auto-style3" style="width: 214px">
                    <dx:ASPxTextBox ID="txtCari" runat="server" Height="28px" Width="216px">
                    </dx:ASPxTextBox>
                </td>
                <td class="auto-style2" style="width: 77px">&nbsp;</td>
                <td style="width: 5px">&nbsp;</td>
                <td class="auto-style2" style="width: 217px">
                    <dx:ASPxButton ID="btnAra" runat="server" Height="36px" Text="Arama" Width="132px" OnClick="btnAra_Click">
                        <backgroundimage horizontalposition="left" imageurl="~/image/Search.png" repeat="NoRepeat" verticalposition="center" />
                    </dx:ASPxButton>
                </td>
                <td style="width: 149px">
                    <asp:ImageButton ID="btnYazdir" runat="server" Height="27px" ImageUrl="~/image/printer.ico" OnClick="btnYazdir_Click" Style="text-align: right" Width="42px" />
                    <asp:ImageButton ID="btnExcel" runat="server" Height="30px" ImageUrl="~/image/excel.png" OnClick="btnExcel_Click" ToolTip="Excel" Width="45px" />
                    <asp:ImageButton ID="btnPdf" runat="server" Height="29px" ImageUrl="~/image/pdf.jpg" OnClick="btnPdf_Click" Style="text-align: right" ToolTip="Pdf" Width="40px" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    <br />
    <div>
        <asp:Button ID="btnAc" runat="server" Text="Aç" OnClientClick="return confirm('Seçili Carilerin Yakıt Alımını Açmak İstediğinize Emin Misiniz?');" BackColor="#999999" Font-Bold="True" Font-Overline="False" Font-Strikeout="False" Height="45px" OnClick="btnAc_Click" Width="136px" />
    </div>
    <br />
    <div>
        <asp:GridView ID="grdKapatilacak" runat="server" CellPadding="3" ShowFooter="True" Style="text-align: left" Width="100%" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CaptionAlign="Right" CellSpacing="1" Font-Size="Small" GridLines="None" OnPageIndexChanging="grdKapatilacak_PageIndexChanging" OnRowCreated="grdKapatilacak_RowCreated">
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
    </div>
</asp:Content>

