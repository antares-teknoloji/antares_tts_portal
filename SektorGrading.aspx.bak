<%@ Page Title="" Language="C#" MasterPageFile="~/Genel.master" AutoEventWireup="true" CodeFile="SektorGrading.aspx.cs" Inherits="SektorGrading" %>
<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>






<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <dx:ASPxButton ID="ASPxButton1" runat="server" Height="100%" Text="Sektör Firma Kar" Width="100%" AutoPostBack="False">
    </dx:ASPxButton>
    <br />
    <br />
    <br />
    <div>

        <table>
            <tr>
                
                    <td style="width: 106px; height: 44px;">Sektör Seçimi</td>
                <td style="width: 2px; height: 44px;">:</td>
                <td style="width: 195px; height: 44px;">
                  <asp:DropDownList ID= "dpSektor" runat="server" Height="46px" Width="218px">
                  </asp:DropDownList>
                </td>
                <td style="width:10px; height :40px;"></td>
                <td style="height: 42px">
                    <dx:ASPxButton ID="btnSorgula" runat="server" Text="Firma Bilgileri" Height="31px" Width="122px" OnClick="btnSorgula_Click">
                        <BackgroundImage HorizontalPosition="left"  Repeat="NoRepeat" VerticalPosition="center" />
                    </dx:ASPxButton>
                   </td>
                <td style="width:10px; height :40px;"></td>
                <td style="height: 42px">
                    <dx:ASPxButton ID="btnTumu" runat="server" Text="Tümü" Height="31px" Width="122px" OnClick="btnSorgula1_Click">
                        <BackgroundImage HorizontalPosition="left"  Repeat="NoRepeat" VerticalPosition="center" />
                    </dx:ASPxButton>
                </td>
                   <td style="width: 70px;"></td>
                     <td style="height: 42px">
                    <asp:TextBox ID="txtCariAd" runat="server" Height="18px" Style="margin-left: 2px" Width="140px" CssClass="yuvarlak" >
                    </asp:TextBox>
                         </td>
                   <td style="width:30px">
                 <asp:Button ID="btnArama" runat="server" Text="Arama" Height="31px" Width="122px" OnClick="btnArama_Click"  />                 
                    </td>    
            </tr>
        </table>

    </div>
    <br />

     <asp:Panel ID="Panel1" runat="server" Height="900px" Width="1250px"   ScrollBars="Vertical">
    <asp:GridView ID="grdSek" runat="server" CellPadding="4" ShowFooter="True" Style="text-align: right" Width="100%" AllowSorting="True" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CaptionAlign="Right" CellSpacing="2" Font-Size="Small" ForeColor="Black" OnRowCommand="grdSek_RowCommand"  >
         <Columns>
                      
                     <asp:ButtonField HeaderText="EKSTRE" Text="EKSTRE" CommandName="EKSTRE" ItemStyle-ForeColor="DarkBlue"/>
            <asp:ButtonField CommandName="CARİ DETAY" Text="CARİ DETAY" HeaderText="CARİ DETAY" ItemStyle-ForeColor="DarkBlue"></asp:ButtonField>
        </Columns>

        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />

        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
         </asp:Panel>
    <br />
      
</asp:Content>


    