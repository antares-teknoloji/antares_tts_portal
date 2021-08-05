<%@ Page Title="" Language="C#" MasterPageFile="~/Genel.master" AutoEventWireup="true" CodeFile="YakitTakip.aspx.cs" Inherits="YakitTakip" %>

<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>





<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="jquery-1.4.1.min.js"></script>
            <script language="javascript" >
                $(document).ready(function () {
                    var gridHeader = $('#<%=grdVeri.ClientID%>').clone(true); // Here Clone Copy of Gridview with style
                    $(gridHeader).find("tr:gt(0)").remove(); // Here remove all rows except first row (header row)
                    $('#<%=grdVeri.ClientID%> tr th').each(function (i) {
                        // Here Set Width of each th from gridview to new table(clone table) th 
                        $("th:nth-child(" + (i + 1) + ")", gridHeader).css('width', ($(this).width()).toString() + "px");
                    });
                    $("#GHead").append(gridHeader);
                    $('#GHead').css('position', 'absolute');
                    $('#GHead').css('top', $('#<%=grdVeri.ClientID%>').offset().top);
            
                });

            </script>
     <style type="text/css">
       .header
        {
            
            position: relative;
            top:expression(this.offsetParent.scrollTop);
            z-index:1;
            padding:0;

            margin-top:-30px;
           
            
        }
.yuvarlak
{
border:1px solid black;
width:100px;
height:100px;
 border-radius: 50px;
-moz-border-radius: 50px;
-webkit-border-radius: 50px;
}
.button {
  
 
  text-align: center;
  cursor: pointer;
  outline: none;
  color: black;
  background-color: #cacaca;
  border: none;
  border-radius: 15px;
  box-shadow: 0 4px #999;
}

.button:hover {background-color:#adadad ; }

.button:active {
  background-color:darkgray;
  box-shadow: 0 5px #666;
  transform: translateY(4px);
}
         </style>
    <dx:ASPxButton ID="ASPxButton1" runat="server" Height="100%" Text="Müşteri Yakıt Takip Raporu" Width="100%" AutoPostBack="False">
    </dx:ASPxButton>
    <br />
    <br />
    <br />
    <div>

        <table>
            <tr>
                <td style="width: 65px; height: 42px;">Tarih :</td>
                <td style="width: 190px; height: 42px;">
                    <dx:ASPxDateEdit ID="dtTarih" runat="server" Width="187px">
                    </dx:ASPxDateEdit>        
                </td>
                  
                <td style="width: 65px; height: 42px;">Firma Ünvan :</td>
                <td style="width: 190px; height: 42px;">
                    <asp:TextBox ID="txtCariAd" runat="server" Height="36px" Style="margin-left: 2px" Width="170px" CssClass="yuvarlak" >

                    </asp:TextBox>
                </td>
                <td style="height: 42px">
                    <dx:ASPxButton ID="btnArama" runat="server" Text="Arama" Height="31px" Width="122px" OnClick="btnArama_Click">
                        <BackgroundImage HorizontalPosition="left" ImageUrl="~/image/Search.png" Repeat="NoRepeat" VerticalPosition="center" />
                    </dx:ASPxButton>
                </td>
            </tr>
        </table>

    </div>
    <br />
    <br />
   
       
        
    

                    
    <div style="OVERFLOW: auto; HEIGHT:550px; width: 100%;">  
    <asp:GridView ID="grdVeri" runat="server" CellPadding="2" OnRowCommand="grdCari_RowCommand" OnRowCreated="grdCari_RowCreated" ShowFooter="True" Style="text-align: right" Width="100%" AllowSorting="True" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CaptionAlign="Right" CellSpacing="2" Font-Size="Small" OnRowDataBound="grdCari_RowDataBound" ForeColor="Black" ShowHeader="true" Font-Names="Copperplate "  OnSorting="grdCari_Sorting"  >
        <Columns>
            <asp:ButtonField HeaderText="EKSTRE" Text="EKSTRE" CommandName="EKSTRE" ItemStyle-ForeColor="DarkBlue" />
            <asp:ButtonField CommandName="CARİ DETAY" Text="CARİ DETAY" HeaderText="CARİ DETAY" ItemStyle-ForeColor="DarkBlue" ></asp:ButtonField>
           
                                
        </Columns>

        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="#000099" Font-Bold="True" CssClass="header" Font-Size="Small" ForeColor="White"/>
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

