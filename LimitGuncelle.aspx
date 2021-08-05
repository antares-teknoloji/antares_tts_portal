<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LimitGuncelle.aspx.cs" Inherits="LimitGuncelle" %>

<%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: large;
            color: #FF6600;
        }
        .auto-style2 {
            width: 203px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <br />
        <br />
        <strong><span class="auto-style1">Araç Limit Güncelleme</span></strong></div>
         <div style="width: 795px; border: thin outset #CCCCCC">
    </div>
        <div>
         </br>         
         </br>
        <table style="width: 797px">
            <tr>
                <td class="auto-style2">Plaka<br />
                    <asp:TextBox ID="txtPlaka" runat="server" Width="125px"></asp:TextBox>
&nbsp;
                    <asp:Button ID="btnAra" runat="server" Text="Ara" Width="45px" OnClick="btnAra_Click" />
                </td>
                <td style="text-align: center; color: #FF6600; width: 455px;">
                    <br />
                    <dx:ASPxButton ID="btnIslem" runat="server" Height="30px" Text="İşlemi Başlat" Width="192px" OnClick="btnIslem_Click">
                    </dx:ASPxButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                <td style="width: 29px"></td>
            </tr>
        </table>
         <br/>

            <asp:GridView ID="grdPlaka" runat="server" AllowPaging="True" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black"  PageSize="200" Width="795px">
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" width="20px" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="Gray" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>

    </div>
    </form>
   
</body>
</html>
