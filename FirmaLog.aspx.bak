<%@ Page Title="" Language="C#" MasterPageFile="~/Genel.master" AutoEventWireup="true" CodeFile="FirmaLog.aspx.cs" Inherits="FirmaLog" %>

<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <dx:ASPxButton ID="ASPxButton1" runat="server" Height="100%" Text="Firma Log Giriş" Width="100%" AutoPostBack="False">
    </dx:ASPxButton>
    <div style="background-color: #EEEEEE">
        <br />
        <br />
        <table style="width: 100%; height: 191px;">
            <tr style="height: 42px">
                <td style="width: 210px;"><strong>Cari Ünvan</strong></td>
                <td style="width: 4px">:</td>
                <td>
                    <dx:ASPxTextBox ID="txtCari" runat="server" AutoPostBack="True" Height="28px" Style="margin-bottom: 0px" Width="508px">
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
            <tr>
                <td style="width: 110px; height: 42px;">&nbsp;</td>
                <td style="width: 4px; height: 42px;"></td>
                <td style="height: 42px">
                    <br />
                    <br />
                    <dx:ASPxButton ID="btnEkle" runat="server" BackColor="#E4E4E4" Height="37px" OnClick="btnEkle_Click" Text="Ekle" Width="213px">
                    </dx:ASPxButton>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <div style="OVERFLOW: auto; width: 100%;">
            <asp:GridView ID="grdFirmaLog" runat="server" CellPadding="4" ShowFooter="True" Style="text-align: left" Width="100%" AllowSorting="True" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CaptionAlign="Right" Font-Size="Small" GridLines="Horizontal" OnRowDeleting="grdFirmaLog_RowDeleting" OnRowCreated="grdFirmaLog_RowCreated">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="60" HeaderText="Sil">
                        <ItemTemplate>
                            <asp:LinkButton ID="lblSil" runat="server" OnClientClick="return confirm('Kaydı Silmek Istediginize Emin Misiniz?');" CommandName="Delete">Sil</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="60px"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
        </div>
        <br />
        <br />
        <br />
        <br />
    </div>
</asp:Content>

