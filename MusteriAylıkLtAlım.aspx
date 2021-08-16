<%@ Page Title="" Language="C#" MasterPageFile="~/Genel.master" AutoEventWireup="true" CodeFile="MusteriAylıkLtAlım.aspx.cs" Inherits="MusteriAylıkLtAlım" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>






<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <dx:ASPxButton ID="ASPxButton1" runat="server" Height="100%" Text="Müşteri Aylık Alım Raporu" Width="100%" AutoPostBack="False">
    </dx:ASPxButton>
    <br />
    <br />
    <br />
    <div>

        <table>
            <tr>
                <td style="width: 65px; height: 42px;">Yıl :</td>
                <td style="width: 100px; height: 42px;">
                    <asp:DropDownList ID="dpYil" runat="server">
                        <asp:ListItem>2021</asp:ListItem>
                        <asp:ListItem>2020</asp:ListItem>                   
                    </asp:DropDownList>
                </td>

                <td style="height: 22px">
                    <dx:ASPxButton ID="btnSorgula" runat="server" Text="Sorgula" Height="31px" Width="122px" OnClick="btnSorgula_Click">
                        <BackgroundImage HorizontalPosition="left"  Repeat="NoRepeat" VerticalPosition="center" />
                    </dx:ASPxButton>
                </td>
                <td style="width:50px;" </td>
                                <td style="width: 70px; height: 42px;">Firma Ünvan :</td>
                <td style="width: 190px; height: 42px;">
                    <dx:ASPxTextBox ID="txtCariAd" runat="server" Height="26px" Style="margin-left: 2px" Width="170px">
                    </dx:ASPxTextBox>
           
                     </td>

                 <td style="width:10px;" </td>
                 <td class="auto-style1">SATIŞ PERSONEL :</td>
                <td style="width: 190px; height: 42px;">
                 <dx:ASPxComboBox ID="cmbSatisEleman" runat="server" Height="28px" Width="180px">
                      <Items>
                            <dx:ListEditItem Text="" Value="" />
                            <dx:ListEditItem Text="Volkan Varol" Value="Volkan Varol" />
                            <dx:ListEditItem Text="Melih Beken" Value="Melih Beken" />
                            <dx:ListEditItem Text="Semih Beken" Value="Semih Beken" />     
                            <dx:ListEditItem Text="Serkan ZeybekOğlu" Value="Serkan ZeybekOğlu" />
                            <dx:ListEditItem Text="Cihan Uzun" Value="Cihan Uzun" />
                            <dx:ListEditItem Text ="Selim Başdinç" Value="Selim Başdinç" />                      
                            <dx:ListEditItem Text ="Orkun Civan" Value="Orkun Civan" />     
                            <dx:ListEditItem Text ="Sena Mert" Value="Sena Mert" />  
                            <dx:ListEditItem Text ="Şeniz Ayhan" Value="Şeniz Ayhan" /> 
                            <dx:ListEditItem Text="Mehmet Bekiroğulları" Value="Mehmet" />                   
                            <dx:ListEditItem Text="Batuhan Zencirci" Value="Batuhan Zencirci" />                        
                            <dx:ListEditItem Text="Hüseyin Bulut" Value="Hüseyin Bulut" />
                        </Items>
                    </dx:ASPxComboBox>
                </td>
                <td style="width:10px;" </td>
                                <td style="height: 42px">
                    <dx:ASPxButton ID="btnArama" runat="server" Text="Arama" Height="31px" Width="122px" OnClick="btnArama_Click">
                        <BackgroundImage HorizontalPosition="left" ImageUrl="~/image/Search.png" Repeat="NoRepeat" VerticalPosition="center" />
                    </dx:ASPxButton>
                    </td>

            </tr>
        </table>

    </div>
    <br />
    <asp:GridView ID="grdVeri" runat="server" CellPadding="2" ShowFooter="True" Style="text-align: right;" AllowSorting="True" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="2px" CaptionAlign="Right" CellSpacing="2" Font-Size="Small" ForeColor="Black"  CssClass="DataGrids"   Font-Names="Optima"  AllowCustomPaging="false"  OnSorting="grdVeri_Sorting" OnRowDataBound="grdVeri_RowDataBound" OnRowCommand="grdVeri_RowCommand"
     Font-Bold="false" Height="361px" Width="3212px" >
           <Columns>
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
</asp:Content>

