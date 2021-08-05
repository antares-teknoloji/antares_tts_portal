<%@ Page Title="" Language="C#" MasterPageFile="~/Genel.master" AutoEventWireup="true" CodeFile="YeniTahsilat.aspx.cs" Inherits="YeniTahsilat" EnableEventValidation="false" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>







<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    

            <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
     <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
     <script type="text/javascript">
         $(document).ready(function () {
            
             $("#<%=txtToDate.ClientID %>").datepicker({ dateFormat: "dd-mm-yy",
monthNames: [ "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık" ],
dayNamesMin: [ "Pa", "Pt", "Sl", "Ça", "Pe", "Cu", "Ct" ],
firstDay:1 });                     
         });
         

    </script>
    
        <style type="text/css">
        body {
    font-family: sans-serif;
    background-color: gainsboro;
    font-weight: bold;
     -moz-border-radius: 50%;
    -webkit-border-radius: 50%;
    border-radius: 50%
}

.text-box {
    margin-left: 44vw;
   margin-top: 42vh;
}
.btn{
    border-radius: 15px;
    color:white;
}
.btn:link,
.btn:visited {
    text-transform: uppercase;
    text-decoration: none;
    padding: 15px 40px;
    display: inline-block;
    transition: all .2s;
    position: absolute;
     -moz-border-radius: 50%;
    -webkit-border-radius: 50%;
    border-radius: 50%
}

.btn:hover {
    transform: translateY(-3px);
    box-shadow: 0 10px 20px rgba(0, 0, 0, 0.2);
}

.btn:active {
    transform: translateY(-1px);
    box-shadow: 0 5px 10px rgba(0, 0, 0, 0.2);
}

.btn-white {
    background-color: #fff;
    color: #777;
}

.btn::after {
    content: "";
    display: inline-block;
    height: 100%;
    width: 100%;
    border-radius: 100px;
    position: absolute;
    top: 0;
    left: 0;
    z-index: -1;
    transition: all .4s;
     -moz-border-radius: 50%;
    -webkit-border-radius: 50%;
    border-radius: 50%
}

.btn-white::after {
    background-color: #fff;
}

.btn:hover::after {
    transform: scaleX(1.4) scaleY(1.6);
    opacity: 0;
}

.btn-animated {
    animation: moveInBottom 5s ease-out;
    animation-fill-mode: backwards;
}

@keyframes moveInBottom {
    0% {
        opacity: 0;
        transform: translateY(30px);
    }

    100% {
        opacity: 1;
        transform: translateY(0px);
    }
}

    </style>
    
    <dx:ASPxButton ID="ASPxButton1" runat="server" Height="100%" Text="Yeni Tahsilat" Width="100%" AutoPostBack="False">
    </dx:ASPxButton>
    <br />
    <br />
    <br />
       
    <table>
        
        <tr>
             <td style="height: 42px">

                 <td style="width:20px"</td>
                 
                 <asp:Button ID="btnSorgula" runat="server" Text="Sorgula" Height="31px" Width="122px" OnClick="btnSorgula_Click" CssClass="btn btn-white btn-animate" />                 
                    </td>    
            <td style="width:20px"</td>
             <td style="height: 42px">
                 <asp:Button  ID="btnGuncelle" runat="server" Text="Güncelle" Height="31px" Width="122px" OnClick="btnGuncelle_Click" CssClass="btn btn-white btn-animate" />                  
                    </td>    
            <td style="width: 20px; height: 42px;">
     <td style="text-align: left;  " class="auto-style1">Firma Ünvan :</td>
                <td style="width: 150px;">
                    
                    <asp:TextBox ID="txtCariAd" runat="server" Height="18px" Style="margin-left: 2px" Width="140px" CssClass="yuvarlak" >
                    </asp:TextBox>
                   <td style="width:20px"</td>
                 <asp:Button ID="btnArama" runat="server" Text="Arama" Height="31px" Width="122px" OnClick="btnArama_Click"  />                 
                    </td>    
             <td style="height: 52px">
                 </td>
             <td style="width: 15px; height: 42px;">
                       <td style="text-align: left;  " class="auto-style1">Yeni Vade :</td>
            <td style="width: 169px">
                <asp:TextBox  ID="txtToDate" runat="server" Height="18px" Width="145px" ></asp:TextBox>
            </td>
                          <td style="height: 42px">
                               
                 
                 <asp:Button ID="btnKaydet" runat="server" Text="Kaydet" Height="31px" Width="122px" OnClick="btnKaydet_Click"  />                 
                    </td>    
               <td style="width: 40px; height: 42px;">
                    <div style="width:20px; height:-20px;"></div>
                    <asp:ImageButton ID="btnExcel" runat="server" Height="30px" ImageUrl="~/image/excel.png" Width="45px" ToolTip="Excel" OnClick="btnExcel_Click" BackColor="Black" />
                    </td>
</tr>        
                    </table>
    
<br/>
   <div>        
    </div>
         
    
    <asp:GridView ID="grdVeri" runat="server" CellPadding="2" ShowFooter="True" Style="text-align: right;overflow:auto" Width= "1200px" AllowSorting="True" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="2px" CaptionAlign="Right" CellSpacing="2" Font-Size="Small" ForeColor="Black"  CssClass="DataGrids"   Font-Names="Optima" border="0"  AllowCustomPaging="false"  OnSorting="grdVeri_Sorting"
     Font-Bold="false" OnRowDataBound="grdVeri_RowDataBound" onselectedindexchanged="grdVeri_SelectedIndexChanged" OnRowCommand="grdVeri_RowCommand" OnRowCreated="grdVeri_RowCreated" PagerStyle-Width="700px" >
 
            <Columns>
                       <asp:ButtonField CommandName="CARİ DETAY" Text="CARİ DETAY" HeaderText="CARİ DETAY" ItemStyle-ForeColor="DarkBlue"></asp:ButtonField>
             
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099"  ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>

   </asp:Content>
 




