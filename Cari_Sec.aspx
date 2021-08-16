<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cari_Sec.aspx.cs" Inherits="Cari_Sec" %>

<%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>



<%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 33px;
        }
        .auto-style2 {
            width: 61px;
        }
        .auto-style3 {
            width: 155px;
        }
    </style>
     <meta http-equiv="Refresh" content="240;url=Yönetim.aspx" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            <table>
                <tr>                  
                    <td>  
                        Cari Ad                     
                    </td>
                     <td>:</td>
                     <td>
                         <dx:ASPxTextBox ID="txtCariAd" runat="server" Height="29px" Width="186px">
                         </dx:ASPxTextBox>
                    </td>   
                    <td class="auto-style1">&nbsp;</td>                 
                     <td>  
                         Cari Kod                     
                    </td>
                     <td>:</td>
                     <td>
                         <dx:ASPxTextBox ID="txtCariKod" runat="server" Height="29px" Width="191px">
                         </dx:ASPxTextBox>
                    </td>  
                    <td class="auto-style2"></td>
                    <td>
                        <dx:ASPxButton ID="btnAra" runat="server" Height="34px" OnClick="btnAra_Click" Text="Ara" Width="123px">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/image/Search.png" Repeat="NoRepeat" VerticalPosition="center" />
                        </dx:ASPxButton>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <div>
            <asp:GridView ID="grdCari" runat="server" Height="248px" Width="904px" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" GridLines="None" CellSpacing="1" OnRowCreated="grdPlaka_RowCreated">
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
            <br />
            <dx:ASPxButton ID="btnSec" runat="server" Height="65px" Text="Seç" Width="114px">
                <BackgroundImage HorizontalPosition="left" ImageUrl="~/img/icons/Purse.ico" Repeat="NoRepeat" VerticalPosition="center" />
            </dx:ASPxButton>
            <br />

        </div>
    </form>
</body>
</html>
