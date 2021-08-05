<%@ Page Language="C#" AutoEventWireup="true" CodeFile="m.Default.aspx.cs" Inherits="m_default" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Tts Portal</title>
    <link rel="stylesheet" type="text/css" href="css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="css/bootstrap-responsive.css" />
    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <script type="text/javascript" src="js/bootstrap.js"></script>
    <style type="text/css">
        .auto-style1 {
            width: 876px;
            height: 153px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- HERO UNIT -->
        <div class="hero-unit">
            <br />
            <div style="width: 100%">
                <img alt="" class="auto-style1" src="img/hb%20logo%20birleşik.jpg" />
            </div>
            <br />
            <br />

            <h2 class="text-center">Kullanıcı Giriş Paneli</h2>

            <div class="text-center" style="font-size: x-large; text-decoration: underline;">
                <br />
                Kullanıcı Ad
            <br />
                <br />
                <asp:TextBox ID="txtKullaniciAd" runat="server" Height="88px" Width="100%" Font-Size="XX-Large"></asp:TextBox>
                <br />
                Parola
                <br />
                <br />
                <asp:TextBox ID="txtParola" runat="server" Height="88px" Width="100%" Font-Size="XX-Large"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btnGiris" runat="server" Height="88px" Text="Giriş" Width="100%" OnClick="btnGiris_Click" Font-Size="X-Large" />
                <br />

            </div>
        </div>
        <!-- HERO UNIT SONU -->

    </form>
</body>
</html>
