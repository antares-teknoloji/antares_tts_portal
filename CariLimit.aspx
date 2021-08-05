<%@ Page Title="" Language="C#" MasterPageFile="~/Genel.master" AutoEventWireup="true" CodeFile="CariLimit.aspx.cs" Inherits="CariLimit" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="height: 33px">
        <table>
            <tr>
                <td style="width: 65px">Plaka :</td>
                <td style="width: 190px">
                    <dx:ASPxTextBox ID="txtPlaka" runat="server" Height="26px" Style="margin-left: 2px" Width="170px">
                    </dx:ASPxTextBox>
                </td>
                <td style="width: 70px">Cari Ad :</td>
                <td style="width: 190px">
                    <dx:ASPxTextBox ID="txtCariAd" runat="server" Height="26px" Style="margin-left: 2px" Width="170px">
                    </dx:ASPxTextBox>
                </td>
                <td>
                    <dx:ASPxButton ID="btnArama" runat="server" Text="Arama" Height="31px" Width="122px" OnClick="btnArama_Click">
                        <BackgroundImage HorizontalPosition="left" ImageUrl="~/image/Search.png" Repeat="NoRepeat" VerticalPosition="center" />
                    </dx:ASPxButton>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <dx:ASPxGridView ID="grdCari" runat="server" Width="100%" Theme="PlasticBlue">
        <SettingsPager AlwaysShowPager="True" PageSize="18">
        </SettingsPager>
    </dx:ASPxGridView>
</asp:Content>

