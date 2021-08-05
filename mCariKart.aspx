<%@ Page Title="" Language="C#" MasterPageFile="~/MobileGenel.master" AutoEventWireup="true" CodeFile="mCariKart.aspx.cs" Inherits="mCariKart" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <div class="hero-unit">
        Cari Ad
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
    <asp:GridView ID="grdCari" CssClass="footable" runat="server" AutoGenerateColumns="false"
        Style="max-width: 500px" OnRowCommand="grdCari_RowCommand">
        <Columns>
            <asp:ButtonField HeaderText="BİLGİ GÜNCELLE" Text="BİLGİ GÜNCELLE"  CommandName="BİLGİ GÜNCELLE" />
            <asp:BoundField DataField="CARİ KOD" HeaderText="CARİ KOD" />
            <asp:BoundField DataField="CARİ AD" HeaderText="CARİ AD" />
            <asp:BoundField DataField="MÜŞTERİ LİMİT" HeaderText="MÜŞTERİ LİMİT" />
            <asp:BoundField DataField="ÖDEME TÜR" HeaderText="ÖDEME TÜR" />
            <asp:BoundField DataField="BANKA KODU" HeaderText="BANKA KODU" />
            <asp:BoundField DataField="VADE" HeaderText="VADE" />
            <asp:BoundField DataField="TELEFON" HeaderText="TELEFON" />
            <asp:BoundField DataField="FİLO KODU" HeaderText="FİLO KODU" />
        </Columns>
    </asp:GridView>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('[id*=grdCari]').footable();
        });
    </script>
</asp:Content>

