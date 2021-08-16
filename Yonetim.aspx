<%@ Page Title="" Language="C#" MasterPageFile="~/Genel.master" AutoEventWireup="true" CodeFile="Yonetim.aspx.cs" Inherits="Yonetim" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <meta http-equiv="Refresh" content="300;url=Default.aspx" />

    <div style="background-color: #C0C0C0; height: 28px;">
        <dx:ASPxButton ID="ASPxButton13" runat="server" Height="100%" Text="Yönetim" Width="100%" BackColor="#EEEEEE">
        </dx:ASPxButton>
        <div style="text-align: left">
            <br />
            <asp:Button ID="btnCariHesapListesi" runat="server" Text="Cari Hesap Listesi" Font-Names="Time" CssClass="button" BackColor="Silver" Height="61px" Width="267px" ForeColor="Black" OnClick="btnCariHesapListesi_Click" Enabled="False" />
            <asp:Button ID="btnGenelRapor" runat="server" Text="Yönetim Genel Rapor" Font-Names="Time" CssClass="button" BackColor="Silver" Height="61px" Width="267px" ForeColor="Black" OnClick="btnGenelRapor_Click" Enabled="False" />
            <asp:Button ID="btnCariBakiye" runat="server" Text="Cari Bakiye Listesi" Font-Names="Time" CssClass="button" BackColor="Silver" Height="61px" Width="267px" ForeColor="Black" OnClick="btnCariBakiye_Click" Enabled="False" />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
            <br />
            <div style="text-align: center">
                <strong><span style="font-size: x-large; color: #d25400" >Alımı Olmayan Cari Listesi<br />
                </span></strong>
                <br />
            </div>
            <div style="width: auto; border: thin outset #CCCCCC"></div>
            <br />
        </div>
        <div style="width: 100%; text-align: left;">
            <div style="float: left;">
                <dx:ASPxRadioButtonList ID="rdpSure" runat="server" RepeatDirection="Horizontal" Width="400px">
                    <Items>
                        <dx:ListEditItem Text="1 Ay" Value="1 Ay" />
                        <dx:ListEditItem Text="3 Ay" Value="3 Ay" />
                        <dx:ListEditItem Text="6 Ay" Value="6 Ay" />
                    </Items>
                </dx:ASPxRadioButtonList>
            </div>
            <div style="float: left;  height: 38px;">
                <dx:ASPxTextBox ID="txtCariAd" runat="server" Width="232px" Height="40px">
                </dx:ASPxTextBox>
            </div>
            <div style="float: left; width: 20%; height: 37px;">

                <dx:ASPxButton ID="btnCariAra" runat="server" Text="Cari Arama" Height="40px" Width="150px" OnClick="btnCariAra_Click">
                </dx:ASPxButton>

            </div>
        </div>
        <br />
        <dx:ASPxGridView ID="grdCari" runat="server" Width="100%" Theme="Default" Font-Names="Copperplate  ">
            <SettingsBehavior AllowSort="False" />
            <SettingsPager Mode="ShowAllRecords" NumericButtonCount="2" PageSize="5000">
            </SettingsPager>
        </dx:ASPxGridView>
        <br />
        <br />
    </div>
    <%--<table style="width: 100%">
        <tr>
            <td style="width: 77px" height="60px" class="dxeButtonEditSys">&nbsp;</td>
            <td style="width: 3px" height="60px">&nbsp;</td>
            <td style="width: 212px" height="60px">&nbsp;</td>
            <td style="width: 90px" height="60px">&nbsp;</td>
            <td style="width: 4px">&nbsp;</td>
            <td style="width: 199px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="dxeButtonEditSys" style="width: 77px">Cari Ad</td>
            <td style="width: 3px">:</td>
            <td>
                <dx:ASPxTextBox ID="txtCariAd" runat="server" Height="21px" Width="199px">
                </dx:ASPxTextBox>
            </td>
            <td style="width: 90px">
                <dx:ASPxButton ID="btnArama" runat="server" Text="Arama" Height="31px" Width="122px" OnClick="btnArama_Click">
                    <BackgroundImage HorizontalPosition="left" ImageUrl="~/image/Search.png" Repeat="NoRepeat" VerticalPosition="center" />
                </dx:ASPxButton>
            </td>
            <td style="width: 4px">&nbsp;</td>
            <td style="width: 199px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <br />

    <div>
        <dx:ASPxGridView ID="grdLimit" runat="server" Width="100%" OnCustomColumnDisplayText="grdLimit_CustomColumnDisplayText">
        </dx:ASPxGridView>
    </div>--%>
</asp:Content>


