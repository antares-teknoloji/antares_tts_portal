<%@ Page Title="" Language="C#" MasterPageFile="~/Genel.master" AutoEventWireup="true" CodeFile="KargoBilgileri.aspx.cs" Inherits="KargoBilgileri" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                    &nbsp;</td>
                <td style="width: 36px"></td>
                <td>
                    <dx:ASPxButton ID="btnSorgula" runat="server" Text="Sorgula" Width="129px" OnClick="btnSorgula_Click">
                    </dx:ASPxButton>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <dx:ASPxGridView ID="grdKargoBilgi" runat="server" Width="539px">
        </dx:ASPxGridView>
    </div>
    <br />
    <br />
    <br />
                <br />
    <br />
    <asp:Button ID="btnSil" runat="server" Height="37px" OnClick="btnSil_Click"  OnClientClick="return confirm('Seçili Tarihteki Kayıtları Silmek Istediginize Emin Misiniz?');" Text="Sil" Width="398px" />
    <br />
    <br />
</asp:Content>

