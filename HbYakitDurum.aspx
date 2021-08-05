<%@ Page Title="" Language="C#" MasterPageFile="~/Genel.master" AutoEventWireup="true" CodeFile="HbYakitDurum.aspx.cs" Inherits="HbYakitDurum" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>








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
                <td class="auto-style1" style="width: 42px">Cari</td>
                <td style="width: 3px">:</td>
                <td class="auto-style3" style="width: 214px">
                    <dx:ASPxTextBox ID="txtCari" runat="server" Height="28px" Width="216px">
                    </dx:ASPxTextBox>
                </td>
                <td class="auto-style2" style="width: 77px">&nbsp;</td>
                <td style="width: 5px">&nbsp;</td>
                <td class="auto-style2" style="width: 217px">
                    <dx:ASPxButton ID="btnAra" runat="server" Height="32px" Text="Arama" Width="128px" OnClick="btnAra_Click">
                        <BackgroundImage HorizontalPosition="left" ImageUrl="~/image/Search.png" Repeat="NoRepeat" VerticalPosition="center" />
                    </dx:ASPxButton>
                </td>
                <td></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <br />
    <div>
        <table style="width: 100%" align="center">
            <tr>
                <td>
                    <dx:ASPxButton ID="btnKapat" runat="server" Height="48px" HorizontalAlign="Right" Text="Kapat" Width="98px" OnClick="btnKapat_Click">
                        <BackgroundImage HorizontalPosition="left" ImageUrl="~/image/1314189427_button_cancel.png" Repeat="NoRepeat" VerticalPosition="bottom" />
                    </dx:ASPxButton>
                </td>
                <td>
                    <dx:ASPxButton ID="btnAc" runat="server" Height="48px" HorizontalAlign="Right" Text="Aç" Width="98px" OnClick="btnAc_Click">
                        <BackgroundImage HorizontalPosition="left" ImageUrl="~/image/1314189415_accepted_48.png" Repeat="NoRepeat" VerticalPosition="bottom" />
                    </dx:ASPxButton>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <dx:ASPxSplitter ID="ASPxSplitter1" runat="server" Height="1000px">
            <Panes>
                <dx:SplitterPane>
                    <ContentCollection>
                        <dx:SplitterContentControl runat="server" SupportsDisabledAttribute="True">
                            <div style="OVERFLOW: auto; HEIGHT: 1000px">
                                <asp:GridView ID="grdAcik" runat="server" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CaptionAlign="Right" CellPadding="3" CellSpacing="1" Font-Size="Small" GridLines="None" ShowFooter="True" Style="text-align: left" Width="100%">
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

                        </dx:SplitterContentControl>
                    </ContentCollection>
                </dx:SplitterPane>
                <dx:SplitterPane>
                    <ContentCollection>
                        <dx:SplitterContentControl runat="server" SupportsDisabledAttribute="True">
                            <div style="OVERFLOW: auto; HEIGHT: 1000px">
                                <asp:GridView ID="grdKapali" runat="server" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CaptionAlign="Right" CellPadding="3" CellSpacing="1" Font-Size="Small" GridLines="None" ShowFooter="True" Style="text-align: left" Width="100%">
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
                        </dx:SplitterContentControl>
                    </ContentCollection>
                </dx:SplitterPane>
            </Panes>
        </dx:ASPxSplitter>
    </div>
    <br />
    <br />
    <br />
</asp:Content>

