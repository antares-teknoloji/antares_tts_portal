<%@ Page Title="" Language="C#" MasterPageFile="~/Genel.master" AutoEventWireup="true" CodeFile="AylıkMusteriAlım.aspx.cs" Inherits="AylıkMusteriAlım" %>
<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>





<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <dx:ASPxButton ID="ASPxButton1" runat="server" Height="100%" Text="Müşteri Karlılık Raporu" Width="100%" AutoPostBack="False">
    </dx:ASPxButton>
    <br />
    <br />
    <br />
    <div>

        <table>
            <tr>
                <td style="width: 65px; height: 42px;">Yıl :</td>
                <td style="width: 190px; height: 42px;">
                    <asp:DropDownList ID="dpYil" runat="server">
                        <asp:ListItem>2020</asp:ListItem>
                        <asp:ListItem>2021</asp:ListItem>
                        <asp:ListItem>2022</asp:ListItem>
                        <asp:ListItem>2023</asp:ListItem>
                        <asp:ListItem>2024</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 70px; height: 42px;">Tür</td>
                <td style="width: 190px; height: 42px;">
                    <asp:DropDownList ID="dpTur" runat="server">
                        <asp:ListItem>TL</asp:ListItem>
                        <asp:ListItem>LİTRE</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="height: 42px">
                    <dx:ASPxButton ID="btnSorgula" runat="server" Text="Sorgula" Height="31px" Width="122px" OnClick="btnSorgula_Click">
                        <BackgroundImage HorizontalPosition="left" ImageUrl="~/image/Search.png" Repeat="NoRepeat" VerticalPosition="center" />
                    </dx:ASPxButton>
                </td>
            </tr>
        </table>

    </div>
    <br />
    <asp:GridView ID="grdVeri" runat="server" CellPadding="4" ShowFooter="True" Style="text-align: right" Width="100%" AllowSorting="True" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CaptionAlign="Right" CellSpacing="2" Font-Size="Small" ForeColor="Black" Font-Names=" Copperplate" OnSorting="grdVeri_Sorting">

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
</asp:Content>

