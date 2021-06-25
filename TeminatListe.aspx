<%@ Page Title="" Language="C#" MasterPageFile="~/Genel.master" AutoEventWireup="true" CodeFile="TeminatListe.aspx.cs" Inherits="TeminatListe" %>

<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>









<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">    
    <div style="background-color: #3366CC; font-weight: 700; height: 25px; text-align: center;" aria-checked="undefined" dir="ltr">
        <dx:ASPxButton ID="ASPxButton1" runat="server" Height="100%" Text="Teminat Mektupları" Width="100%" AutoPostBack="False">
        </dx:ASPxButton>
    </div>
    <br />
    <br />
    <div>
        <table style="height: 34px; width: 759px">
            <tr>
                <td class="auto-style2" style="width: 44px"></td>
                <td class="auto-style1" style="width: 42px">Firma</td>
                <td style="width: 3px">:</td>
                <td class="auto-style3" style="width: 214px">
                    <dx:ASPxTextBox ID="txtCari" runat="server" Height="28px" Width="216px">
                    </dx:ASPxTextBox>
                </td>
                <td class="auto-style2" style="width: 77px">Evrak No</td>
                <td style="width: 5px">:</td>
                <td class="auto-style2" style="width: 217px">
                    <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Height="28px" Width="216px">
                    </dx:ASPxTextBox>
                </td>
                <td></td>
                <td>
                    <dx:ASPxButton ID="btnAra" runat="server" Height="32px" Text="Arama" Width="128px">
                        <BackgroundImage HorizontalPosition="left" ImageUrl="~/image/Search.png" Repeat="NoRepeat" VerticalPosition="center" />
                    </dx:ASPxButton>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <div>
        <asp:GridView ID="grdTeminat" runat="server" CellPadding="3" OnRowCommand="grdTeminat_RowCommand" OnRowCreated="grdTeminat_RowCreated" ShowFooter="True" Style="text-align: center" Width="100%" AllowSorting="True" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CaptionAlign="Right" CellSpacing="1" Font-Size="Small" GridLines="None" OnPageIndexChanging="grdTeminat_PageIndexChanging" OnRowDataBound="grdTeminat_RowDataBound" OnRowDeleting="grdTeminat_RowDeleting">
            <Columns>
                <asp:TemplateField ItemStyle-Width="60" HeaderText="Sil">
                    <ItemTemplate>
                        <asp:LinkButton ID="lblSil" runat="server" OnClientClick="return confirm('Kaydı Silmek Istediginize Emin Misiniz?');" CommandName="Delete">Sil</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:ButtonField HeaderText="Değiştir" Text="Değiştir" CommandName="Degistir" />
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
    </div>
</asp:Content>

