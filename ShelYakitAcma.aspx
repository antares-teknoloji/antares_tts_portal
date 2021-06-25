<%@ Page Title="" Language="C#" MasterPageFile="~/Genel.master" AutoEventWireup="true" CodeFile="ShelYakitAcma.aspx.cs" Inherits="ShelYakitAcma" %>

<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>






<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <dx:ASPxButton ID="ASPxButton1" runat="server" Height="100%" Text="Shel Yakıt Açma" Width="100%" AutoPostBack="False">
    </dx:ASPxButton>
    <br />
    <br />
    <table>
        <tr>
            <td style="width: 65px; height: 42px;">Plaka :</td>
            <td style="width: 190px; height: 42px;">
                <dx:ASPxTextBox ID="txtPlaka" runat="server" Height="26px" Style="margin-left: 2px" Width="170px">
                </dx:ASPxTextBox>
            </td>
            <td style="width: 70px; height: 42px;">Firma Ünvan :</td>
            <td style="width: 190px; height: 42px;">
                <dx:ASPxTextBox ID="txtCariAd" runat="server" Height="26px" Style="margin-left: 2px" Width="170px">
                </dx:ASPxTextBox>
            </td>
            <td style="height: 42px">
                <dx:ASPxButton ID="btnArama" runat="server" Text="Arama" Height="31px" Width="122px" OnClick="btnArama_Click">
                    <BackgroundImage HorizontalPosition="left" ImageUrl="~/image/Search.png" Repeat="NoRepeat" VerticalPosition="center" />
                </dx:ASPxButton>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:GridView ID="grdCari" runat="server" CellPadding="3" OnRowCommand="grdCari_RowCommand" OnRowCreated="grdCari_RowCreated" ShowFooter="True" Style="text-align: center" Width="100%" AllowSorting="True" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CaptionAlign="Right" CellSpacing="1" Font-Size="Small" GridLines="None" OnRowDataBound="grdCari_RowDataBound">
        <Columns>
            <asp:ButtonField CommandName="PLAKA" HeaderText="PLAKA" Text="PLAKA" />
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
    <br />
    <br />
    <br />
    <br />
    <div>
        <div style="width: 100%">

            <asp:Button ID="btnAc" runat="server" Height="45px" Text="Aç" Width="145px" OnClick="btnAc_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnKapat" runat="server" Height="45px" Text="Kapat" Width="145px" OnClick="btnKapat_Click" />

        </div>
    </div>

    <br />
    <div style="width: 100%">
        <div style="float: left; width: 50%;">
            <asp:GridView ID="grdPlaka" runat="server" CellPadding="3" OnRowCommand="grdCari_RowCommand" OnRowCreated="grdCari_RowCreated" ShowFooter="True" Style="text-align: center" Width="100%" AllowSorting="True" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CaptionAlign="Right" CellSpacing="1" Font-Size="Small" GridLines="None" OnRowDataBound="grdCari_RowDataBound">

                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkHeader" runat="server" AutoPostBack="true" OnCheckedChanged="chkHeader_CheckedChanged" Width="5px" Checked="true" />

                        </HeaderTemplate>
                        <ItemTemplate>

                            <asp:CheckBox ID="chkSecim" runat="server" Text="" AutoPostBack="false" Width="5px" Checked="true" />
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
        </div>

        <div style="float: left; width: 40%;">
            <asp:GridView ID="grdPlakaPasif" runat="server" CellPadding="3" OnRowCommand="grdCari_RowCommand" OnRowCreated="grdCari_RowCreated" ShowFooter="True" Style="text-align: center" Width="100%" AllowSorting="True" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CaptionAlign="Right" CellSpacing="1" Font-Size="Small" GridLines="None" OnRowDataBound="grdCari_RowDataBound">

                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkHeaderPasif" runat="server" AutoPostBack="true" OnCheckedChanged="chkHeaderPasif_CheckedChanged" Width="5px" Checked="false" />

                        </HeaderTemplate>
                        <ItemTemplate>

                            <asp:CheckBox ID="chkSecimPasif" runat="server" Text="" AutoPostBack="false" Width="5px" Checked="false" />
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
        </div>
    </div>

    <br />
</asp:Content>

