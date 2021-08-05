<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YakitBloke.aspx.cs" Inherits="YakitBloke" %>

<%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 191px;
            height: 29px;
            text-align: center;
        }
        .auto-style2 {
            height: 29px;
        }
        .auto-style3 {
            width: 173px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <table>
                <tr>
                    <td class="auto-style2">
                        <asp:CheckBox ID="chkSec" runat="server" AutoPostBack="True" OnCheckedChanged="chkSec_CheckedChanged" OnDataBinding="Page_Load" Text="Tümünü Seç" />
                    </td>
                    <td class="auto-style1">
                        Offline Limit</td>
                    <td class="auto-style3">Online Limit</td>
                    <td class="auto-style2">
                        <dx:ASPxButton ID="btnIslem" runat="server" Text="İşlem Yap" Width="178px" OnClick="btnIslem_Click" Height="25px">
                        </dx:ASPxButton>
                    </td>
                    <td class="auto-style2"></td>
                </tr>
                <tr>
                    <td></td>
                    <td style="text-align: center">
                        <dx:ASPxLabel ID="lblOfflineLimit" runat="server" Text="-">
                        </dx:ASPxLabel>
                    </td>
                    <td class="auto-style3">
                        <dx:ASPxLabel ID="lblOnlineLimit" runat="server" Text="-">
                        </dx:ASPxLabel>
                    </td>
                </tr>
            </table>
            <br />
        </div>
        <div>
            <asp:GridView ID="grdPlaka" runat="server" Height="248px" Width="904px" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" GridLines="None" CellSpacing="1" OnRowCreated="grdPlaka_RowCreated">
                <Columns>
                    <asp:TemplateField HeaderText="Seç">
                        <EditItemTemplate>
                            <asp:CheckBox ID="chkSecim" runat="server" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSecim" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
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

        </div>
    </form>
</body>
</html>
