<%@ Page Title="" Language="C#" MasterPageFile="~/Genel.master" AutoEventWireup="true" CodeFile="YakitKarlilikAnaliz.aspx.cs"Inherits="YakitKarlilikAnaliz" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>







<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <meta http-equiv="Refresh" content="300;url=Default.aspx" />
    <script src="jquery-1.4.1.min.js"></script>
            <script language="javascript" >
                $(document).ready(function () {
                    var gridHeader = $('#<%=grdSorgu.ClientID%>').clone(true); // Here Clone Copy of Gridview with style
                    $(gridHeader).find("tr:gt(0)").remove(); // Here remove all rows except first row (header row)
                    $('#<%=grdSorgu.ClientID%> tr th').each(function (i) {
                        // Here Set Width of each th from gridview to new table(clone table) th 
                        $("th:nth-child(" + (i + 1) + ")", gridHeader).css('width', ($(this).width()).toString() + "px");
                    });
                    $("#GHead").append(gridHeader);
                    $('#GHead').css('position', 'absolute');
                    $('#GHead').css('top', $('#<%=grdSorgu.ClientID%>').offset().top);
            
                });

            </script>


    <dx:ASPxButton ID="ASPxButton1" runat="server" Height="100%" Text="Karlılık Analizi" Width="100%" AutoPostBack="False">
    </dx:ASPxButton>
    <br />
    <br />
    <br />
    <table>
        
           <tr style="height:10px">
            <td class="auto-style1" aria-orientation="horizontal" aria-selected="false" style="width: 70px; height:30px;">İstasyon:</td>
                <td style="width: 175px; height: 44px;">
                  <asp:DropDownList ID= "dpIsyeri" runat="server" Height="46px" Width="218px">
                  </asp:DropDownList>
                </td>
               <td style="width:10px; height :40px;"></td>
                <td style="height: 20px">
                    <dx:ASPxButton ID="btnSorgula" runat="server" Text="Sorgula" Height="31px" Width="122px" OnClick="Sorgu">
                        <BackgroundImage HorizontalPosition="left" Repeat="NoRepeat" VerticalPosition="center" />
                    </dx:ASPxButton>
                   </td>
               <td style="width:10px; height :40px;"></td>
                <td style="height: 42px">
                    <dx:ASPxButton ID="btnTumu" runat="server" Text="Tümü" Height="31px" Width="122px" OnClick="btnSorgula1_Click">
                        <BackgroundImage HorizontalPosition="left"  Repeat="NoRepeat" VerticalPosition="center" />
                    </dx:ASPxButton>
                </td>
               <td style="width:20px; height :40px;"></td>
               
            <td class="auto-style1" aria-orientation="horizontal" aria-selected="false" style="width: 10px; height:30px;"></td>
                <td style="width: 175px; height: 44px;">
                  <asp:DropDownList ID= "dpİs" runat="server" Height="46px" Width="218px">
                  </asp:DropDownList>
                </td> 

           <td style="width:20px; height :40px;"></td>
               
            <td class="auto-style1" aria-orientation="horizontal" aria-selected="false" style="width: 10px; height:30px;">:</td>
                <td style="width: 175px; height: 44px;">
                  <asp:DropDownList ID= "dpGrafik" runat="server" Height="46px" Width="218px">
                  </asp:DropDownList>
                </td>
            <td style="width:20px; height :40px;"></td>
                <td style="height: 42px">
                    <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Seç" Height="31px" Width="122px" OnClick="btnSorgula2_Click">
                        <BackgroundImage HorizontalPosition="left"  Repeat="NoRepeat" VerticalPosition="center" />
                    </dx:ASPxButton>
                </td>

            </tr>
      </table>
<br/>
   <div>  
        <br/>
    </div>
   
    
                
                    <div id="GHead"></div> 
                    <%-- This GHead is added for Store Gridview Header  --%>
                    
 <div style="OVERFLOW: auto; HEIGHT: 700px; width:auto;">  
    <asp:GridView ID="grdSorgu" runat="server" CellPadding="4" ShowFooter="True" Style="text-align: right;overflow:auto" Width="100%" AllowSorting="True" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="2px" CaptionAlign="Right" CellSpacing="2" Font-Size="Small" ForeColor="Black" AutoGenerateColumns="false" CssClass="DataGrids" GridLines="Both" OnItemCommand="dtgMain_OnItemCommand" Font-Names="Optima" border="0">
  <FooterStyle CssClass="DataGridFooters" />
  <HeaderStyle CssClass="DataGridHeaders" />
         <Columns>
                                <asp:BoundField HeaderText="TARİH" DataField="TARİH" > <ItemStyle Width="100" /> <HeaderStyle Width="100" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="İŞYERİ" DataField="İŞYERİ" > <ItemStyle CssClass="left" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="ÜRÜN CİNSİ" DataField="ÜRÜN CİNSİ" > <ItemStyle CssClass="left" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="RAFİNERİ FİYAT" DataField="RAFİNERİ FİYAT" > <ItemStyle CssClass="left" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="ALIŞ FİYAT" DataField="ALIŞ FİYAT" >
                                <ItemStyle CssClass="left" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="SATIŞ FİYAT" DataField="SATIŞ FİYAT" >
                                <ItemStyle CssClass="left" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="KAR TUTAR" DataField="KAR TUTAR" >
                                <ItemStyle CssClass="left" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="KAR YÜZDESİ" DataField="KAR YÜZDESİ" >
                                <ItemStyle CssClass="left" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="KARMARJI" DataField="KARMARJI" >
                                <ItemStyle CssClass="left" />
                                </asp:BoundField>
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
     </div>                 

    <br />
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            height: 44px;
            width: 174px;
        }
        .auto-style2 {
            height: 44px;
            width: 93px;
        }
    </style>
</asp:Content>

