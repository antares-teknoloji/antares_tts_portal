<%@ Page Title="" Language="C#" MasterPageFile="~/Genel.master" AutoEventWireup="true" CodeFile="TTSMusteriTablo.aspx.cs" Inherits="TTSMusteriTablo" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    
        
    <div style="background-color: #F7F7F7; font-weight: 700; height: 25px; text-align: center;" aria-checked="undefined" dir="ltr">
        <dx:ASPxButton ID="ASPxButton1" runat="server" Height="100%" Text="Yakıt Takip Tablosu" Width="100%" AutoPostBack="False" >
        </dx:ASPxButton>    
         <table style="width: 200%; height: 130px;">
            <tr>
                <td style="width: 68%">&nbsp;</td>
                <td>
                   
                </td>
                <td></td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <div>
        <table>
            <tr>
                 <td style="width:10px; height :50px;"></td>
                 <td style="height: 42px">
                    <dx:ASPxButton ID="btnSorgula" runat="server" Text="Sorgula" Height="31px" Width="122px" OnClick="btnArama_Click">
                        <BackgroundImage HorizontalPosition="left" Repeat="NoRepeat" VerticalPosition="center" />
                    </dx:ASPxButton>
                     </td>
                <td style="width:10px; height :40px;"></td>
                          <td style="width:50px; height :40px;"></td>
                <td class="auto-style1">SATIŞ PERSONEL :</td>
                <td style="width: 190px; height: 42px;">
                 <dx:ASPxComboBox ID="cmbSatisEleman" runat="server" Height="28px" Width="180px">
                      <%--  <Items>
                            <dx:ListEditItem Text="" Value="" />
                            <dx:ListEditItem Text="Volkan Varol" Value="Volkan Varol" />
                            <dx:ListEditItem Text="Melih Beken" Value="Melih Beken" />
                            <dx:ListEditItem Text="Semih Beken" Value="Semih Beken" />
                            <dx:ListEditItem Text="Mehmet Bekiroğulları" Value="Mehmet" />
                            <dx:ListEditItem Text="Cihan Uzun" Value="Cihan Uzun" />
                            <dx:ListEditItem Text="Batuhan Zencirci" Value="Batuhan Zencirci" />
                            <dx:ListEditItem Text="Serkan ZeybekOğlu" Value="Serkan ZeybekOğlu" />
                            <dx:ListEditItem Text="Hüseyin Bulut" Value="Hüseyin Bulut" />
                            <dx:ListEditItem Text ="Orkun Civan" Value="Orkun Civan" />                            
                        </Items>--%>
                    </dx:ASPxComboBox>
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
                <td style="width:10px; height :40px;"></td>
                <td style="height: 42px">
                    <dx:ASPxButton ID="btnTumsebep" runat="server" Text="Listeden Çıkanlar" Height="31px" Width="122px" OnClick="btnTumsebep_Click">
                        <BackgroundImage HorizontalPosition="left"  Repeat="NoRepeat" VerticalPosition="center" />
                    </dx:ASPxButton>
                
                     </td>
            </tr>
        </table>  
        <br />
        <br />
  
        </div>
      

            <%-- This GHead is added for Store Gridview Header  --%>
    <div style="OVERFLOW: auto; HEIGHT: 550px; width: 100%;">  
    <asp:GridView ID="grdCari" runat="server" CellPadding="2" OnRowCommand="grdCari_RowCommand"  ShowFooter="True" Style="text-align: right" Width="100%" AllowSorting="True" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CaptionAlign="Right" CellSpacing="2" Font-Size="Small"  ForeColor="Black" ShowHeader="true" Font-Names="Optima" OnSorting="grdCari_Sorting" >
        <Columns>
          
                     <asp:ButtonField HeaderText="EKSTRE" Text="EKSTRE" CommandName="EKSTRE" ItemStyle-ForeColor="DarkBlue" />
            <asp:ButtonField CommandName="CARİ DETAY" Text="FİRMA DETAY" HeaderText="CARİ DETAY" ItemStyle-ForeColor="DarkBlue" ></asp:ButtonField>
             
        </Columns>

       <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="#000099" Font-Bold="True" ForeColor="#E7E7FF" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>

       
        </div>        
</asp:Content>




