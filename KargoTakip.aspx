﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Genel.master" AutoEventWireup="true" CodeFile="KargoTakip.aspx.cs" Inherits="KargoTakip" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
         <meta http-equiv="Refresh" content="300;url=Default.aspx" />
    <div style="background-color: #3366CC; font-weight: 700; height: 25px; text-align: center;" aria-checked="undefined" dir="ltr">
        <dx:ASPxButton ID="ASPxButton1" runat="server" Height="100%" Text="Kargo Takip" Width="100%" AutoPostBack="False">
        </dx:ASPxButton>
    </div>
    <br />
    <br />
    <div>
        <table>
            <tr>
                <td style="width: 74px">Tarih</td>
                <td>:</td>
                <td>
                    <dx:ASPxDateEdit ID="dtTarih" runat="server">
                    </dx:ASPxDateEdit>
                </td>
                <td style="width: 43px"></td>
                <td>
                    <asp:FileUpload ID="fpDosya" runat="server" />
                </td>
                <td style="width: 36px"></td>
                <td>
                    <dx:ASPxButton ID="btnSorgula" runat="server" Text="Sorgula" Width="129px" OnClick="btnSorgula_Click" AutoPostBack="False">
                    </dx:ASPxButton>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
    </div>
    <div>
        <dx:ASPxGridView ID="grdKayit" runat="server" Width="539px">
        </dx:ASPxGridView>
        <br />
        <br />
        <br />
                    <dx:ASPxButton ID="btnGonder" runat="server" Text="Gönder" Width="129px" OnClick="btnGonder_Click" AutoPostBack="False">
                    </dx:ASPxButton>
        <br />
    </div>
</asp:Content>

