<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeminatDegistir.aspx.cs" Inherits="TeminatDegistir" %>

<%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="background-color: #CCCCCC">
     <meta http-equiv="Refresh" content="300;url=Default.aspx" />
        <table width="100%">
            <tr style="height: 42px">
                <td style="width: 210px;"><strong>Cari Ünvan</strong></td>
                <td style="width: 4px">:</td>
                <td>
                    <dx:ASPxTextBox ID="txtCari" runat="server" Height="28px" style="margin-bottom: 0px" Width="302px" OnTextChanged="txtCari_TextChanged" AutoCompleteType="Enabled" AutoPostBack="True">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr style="height: 42px">
                <td style="width: 210px"><strong>Banka Adı</strong></td>
                <td style="width: 4px">:</td>
                <td>
                    <dx:ASPxTextBox ID="txtBanka" runat="server" Height="28px" style="margin-bottom: 0px" Width="302px" OnTextChanged="txtBanka_TextChanged" AutoPostBack="True">
                    </dx:ASPxTextBox>
                </td>
            </tr>
             <tr style="height: 42px">
                <td style="width: 210px"><strong>Evrak No</strong></td>
                <td style="width: 4px">:</td>
                <td>
                    <dx:ASPxTextBox ID="txtEvrak" runat="server"  Height="28px" Width="302px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
             <tr style="height: 42px">
                <td style="width: 210px"><strong>Vade Tarihi</strong></td>
                <td style="width: 4px">:</td>
                <td>
                    <dx:ASPxDateEdit ID="dtTarih" runat="server" Height="28px" Width="302px">
                    </dx:ASPxDateEdit>
                </td>
            </tr>
              <tr style="height: 42px">
                <td style="width: 210px"><strong>Tutar</strong></td>
                <td style="width: 4px">:</td>
                <td>
                    <dx:ASPxTextBox ID="txtTutar" runat="server" Height="28px" Width="302px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
             <tr style="height: 42px">
                <td style="width: 210px"><strong>Açıklama</strong></td>
                <td style="width: 4px">:</td>
                <td>
                    <dx:ASPxMemo ID="txtAciklama" runat="server" Height="90px" Width="515px">
                    </dx:ASPxMemo>
                </td>
            </tr>
            <tr style="height: 42px">
                <td style="width: 210px">&nbsp;</td>
                <td style="width: 4px"></td>
                <td>
                    <br />
                    <br />
                      <dx:ASPxButton ID="btnDegistir" runat="server" BackColor="#E4E4E4" Height="37px" Text="Değiştir" Width="213px" OnClick="btnDegistir_Click" AllowFocus="False" AutoPostBack="False">
            </dx:ASPxButton>
                   
                </td>
            </tr>
        </table>                  
    
    </div>
    </form>
</body>
</html>
