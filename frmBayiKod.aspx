<%@ Page Title="" Language="C#" MasterPageFile="~/Genel.master" AutoEventWireup="true" CodeFile="frmBayiKod.aspx.cs" Inherits="frmBayiKod" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 357px;
        }

        .auto-style2 {
            margin-right: 0;
        }

        .auto-style3 {
            height: 42px;
        }

        .auto-style4 {
            height: 42px;
            width: 422px;
        }

        .auto-style5 {
            width: 422px;
        }

        .auto-style6 {
            height: 42px;
            text-align: right;
        }

        .auto-style7 {
            height: 42px;
            width: 422px;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <meta http-equiv="Refresh" content="300;url=Default.aspx" />
    <p>
        <dx:ASPxButton ID="ASPxButton1" runat="server" Height="100%" Text="Bayi Kod" Width="100%" AutoPostBack="False">
        </dx:ASPxButton>
    </p>

    <table>
        <tr>
            <td class="auto-style6">&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Müşteri Ad :" Font-Bold="True"></asp:Label>
                <asp:TextBox ID="txtMusteriAd" runat="server" Width="163px" Font-Bold="True"></asp:TextBox>
            </td>
            <td class="auto-style7">
                <asp:Label ID="Label5" runat="server" Text="Shell Müşteri Kod :" Font-Bold="True"></asp:Label>
                <asp:TextBox ID="txtMusteriKod" runat="server" Width="163px" Font-Bold="True"></asp:TextBox>
            </td>
            <td class="auto-style3">&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td>&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSorgula" runat="server" Height="38px" OnClick="btnSorgula_Click" Text="Sorgula" Width="292px" Font-Bold="True" />
            </td>


        </tr>
    </table>
    <br />
    <br />
    <table>
        <tr>
            <td class="auto-style3">&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Kod Değiştirme :" Font-Bold="True"></asp:Label>
                <asp:TextBox ID="txtKod" runat="server" Width="163px" Font-Bold="True"></asp:TextBox>
            </td>
            <td class="auto-style4"></td>
            <td class="auto-style3">&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Taşınacak Kod :" Font-Bold="True"></asp:Label>
                <asp:TextBox ID="txtYeniKod" runat="server" Width="163px" Font-Bold="True" CssClass="auto-style2" Height="20px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDegistir" runat="server" Height="38px" OnClick="btnDegistir_Click" Text="Ana Kod Değiştir" Width="292px" Font-Bold="True" />
            </td>
            <td class="auto-style5"></td>
            <td>&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnTasi" runat="server" Height="38px" OnClick="btnTasi_Click" Text="Taşı" Width="292px" Font-Bold="True" />
            </td>
        </tr>
    </table>

    <br />



    <div>

        <table>
            <tr>
                <td class="auto-style1">
                    <asp:ListBox ID="lstMusteriKod" runat="server" Height="609px" Width="308px" AutoPostBack="True" OnSelectedIndexChanged="lstMusteriKod_SelectedIndexChanged"></asp:ListBox>
                </td>
                <td class="auto-style1">
                    <asp:ListBox ID="lstKodlar" runat="server" Height="609px" Width="308px" AutoPostBack="True" OnSelectedIndexChanged="lstKodlar_SelectedIndexChanged"></asp:ListBox>
                </td>
                <td>
                    <asp:ListBox ID="lstFirmalar" runat="server" Height="609px" Width="308px" OnSelectedIndexChanged="lstKodlar_SelectedIndexChanged"></asp:ListBox>
                </td>
                <td>
                    <asp:Button ID="btnTumSol" runat="server" Text="&lt;&lt;" Width="68px" OnClick="btnTumSol_Click" />
                    <br />
                    <asp:Button ID="btnSol" runat="server" Text="&lt;" Width="68px" OnClick="btnSol_Click" />
                    <br />
                    <asp:Button ID="btnSag" runat="server" Text="&gt;" Width="68px" OnClick="btnSag_Click" AutoPostback="false" />
                    <br />
                    <asp:Button ID="btnTumSag" runat="server" Text="&gt;&gt;" Width="68px" OnClick="btnTumSag_Click" />
                </td>
                <td>
                    <asp:ListBox ID="lstTasinacakFirmalar" runat="server" Height="609px" Width="308px" OnSelectedIndexChanged="lstKodlar_SelectedIndexChanged"></asp:ListBox>
                </td>
            </tr>
        </table>






    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

