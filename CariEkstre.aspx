<%@ Page Title="" Language="C#" MasterPageFile="~/Genel.master" AutoEventWireup="true" CodeFile="CariEkstre.aspx.cs" Inherits="CariEkstre" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>





<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <meta http-equiv="Refresh" content="240;url=CariKart.aspx" />
    <dx:ASPxButton ID="ASPxButton1" runat="server" Height="100%" Text="Müşteri Yakıt Takip Raporu" Width="100%" AutoPostBack="False">
    </dx:ASPxButton>
    <br />
    <br />
    <br />
    <tr>
                <td style="width: 158px">FİRMA ÜNVAN : </td>             
                <td style="width: 231px">
                    <dx:ASPxLabel ID="lblCariAd" runat="server" Font-Bold="True" Font-Size="Large" Text="-">
                    </dx:ASPxLabel>
                </td>
            </tr>
    <div id="sorgulama" style="width: 100%" class="cont" runat="server">
        <br />
        <br />
        <table id="Table1" style="width: 1000px" runat="server">
            <tr>
                <td style="text-align: left; width: 116px">Başlangıç Tarihi :</td>
                <td style="width: 169px">
                    <dx:ASPxDateEdit ID="dtBaslangic" runat="server">
                    </dx:ASPxDateEdit>
                </td>
                <td style="text-align: left; width: 83px;">Bitiş Tarihi :</td>
                <td style="width: 178px">
                    <dx:ASPxDateEdit ID="dtBitis" runat="server">
                    </dx:ASPxDateEdit>
                </td>
                <td style="width: 172px">
                    <div style="text-align: left">
                        <dx:ASPxButton ID="btnSorgula" runat="server" Height="18px" OnClick="btnSorgula_Click" Text="Sorgula" Width="168px">
                        </dx:ASPxButton>
                    </div>
                </td>
                <td>
                    <asp:ImageButton ID="btnYazdir" runat="server" Height="27px" ImageUrl="~/image/printer.ico" OnClick="btnYazdir_Click" Width="42px" Style="text-align: right" />
                    <asp:ImageButton ID="btnExcel" runat="server" Height="30px" ImageUrl="~/image/excel.png" Width="45px" ToolTip="Excel" OnClick="btnExcel_Click" />
                    <asp:ImageButton ID="btnPdf" runat="server" Height="29px" ImageUrl="~/image/pdf.jpg" Width="40px" ToolTip="Pdf" Style="text-align: right" OnClick="btnPdf_Click" /></td>
            </tr>
        </table>
        <div id="Div1" style="height: 87px" runat="server">
            <table id="Table2" style="width: 1000px" runat="server">
                <tr>
                    <td class="auto-style15">&nbsp;</td>
                    <td id="Td1" runat="server">&nbsp;</td>
                    <td></td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="grdEkstre1" runat="server"></asp:GridView>
   
        <asp:GridView ID="grdEkstre" runat="server" CellPadding="2" ForeColor="#333333" ShowFooter="True" Width="100%" Style="text-align: right">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="Gainsboro" Font-Bold="True" ForeColor="Black" />
            <HeaderStyle BackColor="Gainsboro" Font-Bold="True" ForeColor="ActiveCaptionText" />
            <PagerStyle BackColor="WhiteSmoke" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="WhiteSmoke" ForeColor="#333333" />
            <SelectedRowStyle BackColor="Gainsboro" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="WhiteSmoke" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
    </div>
</asp:Content>

