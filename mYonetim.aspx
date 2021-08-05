<%@ Page Title="" Language="C#" MasterPageFile="~/MobileGenel.master" AutoEventWireup="true" CodeFile="mYonetim.aspx.cs" Inherits="mYonetim" %>

<%@ Register assembly="DevExpress.Web.v21.1, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <div class="hero-unit">Cari Ad
        <br />
        <br />
        <dx:ASPxTextBox ID="txtCariAd" runat="server" Height="38px" Width="100%">
        </dx:ASPxTextBox>
    </div>
    <br />
    <br />
    <dx:ASPxButton ID="btnAra" runat="server" Height="38px" Text="Ara" Width="100%" OnClick="btnAra_Click">
    </dx:ASPxButton>
    <br />
    <asp:GridView ID="grdLimit" CssClass="footable" runat="server" AutoGenerateColumns="false"
        Style="max-width: 500px">
        <Columns>
            <asp:BoundField DataField="MUSTERIAD" HeaderText="MÜŞTERİ AD" />
            <asp:BoundField DataField="ALIMTARIH" HeaderText="ALIM TARİH" />
            <asp:BoundField DataField="BAKIYE" HeaderText="BAKİYE" />
            <asp:BoundField DataField="ALISLAR" HeaderText="ALIŞLAR" />
            <asp:BoundField DataField="TOPLAM" HeaderText="TOPLAM" />
            <asp:BoundField DataField="DBSOFFLINE" HeaderText="DBS OFFLİNE" />
            <asp:BoundField DataField="DBSONLINE" HeaderText="DBS ONLİNE" />
            <asp:BoundField DataField="KALANLIMIT" HeaderText="KALAN LİMİT" />
            <asp:BoundField DataField="DBSTARIH" HeaderText="DBS TARİH" />
        </Columns>
    </asp:GridView>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('[id*=grdLimit]').footable();
        });
    </script>
</asp:Content>

