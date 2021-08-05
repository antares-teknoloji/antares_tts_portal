<%@ Page Title="" Language="C#" MasterPageFile="~/Genel.master" AutoEventWireup="true" CodeFile="PlakaListe.aspx.cs" Inherits="PlakaListe" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="background-color: #3366CC; font-weight: 700; height: 25px; text-align: center;" aria-checked="undefined" dir="ltr">
        <dx:ASPxButton ID="ASPxButton1" runat="server" Height="100%" Text="Cari Hesap Listesi" Width="100%" AutoPostBack="False">
        </dx:ASPxButton>
    </div>
    <br />
    <br />
    <div>
        <table>
            <tr>
                <td style="width: 65px">Plaka :</td>
                <td style="width: 190px">
                    <dx:ASPxTextBox ID="txtPlaka" runat="server" Height="26px" Style="margin-left: 2px" Width="170px">
                    </dx:ASPxTextBox>
                </td>
                <td style="width: 70px">
                    <dx:ASPxButton ID="btnArama" runat="server" Text="Arama" Height="31px" Width="122px" OnClick="btnArama_Click">
                        <BackgroundImage HorizontalPosition="left" ImageUrl="~/image/Search.png" Repeat="NoRepeat" VerticalPosition="center" />
                    </dx:ASPxButton>
                </td>
                <td style="width: 190px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
        </div>
        <br />
        <table>
            <tr>
                <td>Plaka&nbsp; :
                        <dx:ASPxTextBox ID="txtPlakaKaydet" runat="server" Height="34px" Width="221px">
                        </dx:ASPxTextBox>
                    <br />
                    <br />
                        <dx:ASPxButton ID="btnKaydet" runat="server" Height="36px" Text="Kaydet" Width="221px" AllowFocus="False" AutoPostBack="False" OnClick="btnKaydet_Click">
                            <BackgroundImage ImageUrl="~/image/kart.PNG" Repeat="NoRepeat" />
                        </dx:ASPxButton>

                    &nbsp;</td>
                <td>
                    <asp:GridView ID="grdPlaka" runat="server" CellPadding="3" OnRowCommand="grdPlaka_RowCommand" OnRowCreated="grdPlaka_RowCreated" ShowFooter="True" Style="text-align: center" Width="213%" AllowSorting="True" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CaptionAlign="Right" CellSpacing="1" Font-Size="Small" GridLines="None" OnPageIndexChanging="grdPlaka_PageIndexChanging" OnRowDataBound="grdPlaka_RowDataBound" OnRowDeleting="grdPlaka_RowDeleting" AllowPaging="True">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="60" HeaderText="Sil">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lblSil" runat="server" OnClientClick="return confirm('Kaydı Silmek Istediginize Emin Misiniz?');" CommandName="Delete">Sil</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#594B9C" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#33276A" />
                    </asp:GridView>
                </td>
            </tr>
        </table>

        <br />
    </div>
</asp:Content>

