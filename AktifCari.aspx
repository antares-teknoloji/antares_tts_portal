<%@ Page Title="" Language="C#" MasterPageFile="~/Genel.master" AutoEventWireup="true" CodeFile="AktifCari.aspx.cs" Inherits="AktifCari" EnableEventValidation="false" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>







<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
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

    <dx:ASPxButton ID="ASPxButton1" runat="server" Height="100%" Text="Aktif Cari" Width="100%" AutoPostBack="False">
    </dx:ASPxButton>
    <br />
    <br />
    <br />
       
    <table>
        
        <tr>
             <td style="height: 42px">

                 <td style="width:20px"</td>
                 <asp:Button ID="btnShell" runat="server" Text="SHELL" Height="31px" Width="122px" OnClick="btnShell_Click" CssClass="btn btn-white btn-animate" />                 
                    </td>    
            <td style="width:20px"</td>
             <td style="height: 42px">
                 <asp:Button  ID="btnTotal" runat="server" Text="TOTAL" Height="31px" Width="122px" OnClick="btnTotal_Click" CssClass="btn btn-white btn-animate" />                  
                    </td>    
            <td style="width:20px"</td>
             <td style="height: 42px">

                 <asp:Button ID="btnLukoıl" runat="server" Text="Lukoıl" Height="31px" Width="122px" OnClick="btnLukoıl_Click" CssClass="btn btn-white btn-animate" />                   
                    </td>    
            <td style="width:20px"</td>
     <td style="width: 65px; height: 42px;">Firma Ünvan :</td>
                <td style="width: 190px; height: 42px;">
                    <asp:TextBox ID="txtCariAd" runat="server" Height="36px" Style="margin-left: 2px" Width="170px" CssClass="yuvarlak" >
                    </asp:TextBox>
                     <td style="width: 190px; height: 42px;">
                    <div style="width:20px; height:-20px;"></div>
                    <asp:ImageButton ID="btnExcel" runat="server" Height="30px" ImageUrl="~/image/excel.png" Width="45px" ToolTip="Excel" OnClick="btnExcel_Click" BackColor="Black" />
                    </td>
                    
               
</tr>        
                    </table>
    
<br/>
   <div>        
    </div>
    
      
  
                    
    
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AKTARIMConnectionString %>" SelectCommand="SELECT [CARIAD], [SATISPERSONEL], [TEMINATTUTAR] FROM [TTSPORTAL_CARIBILGI]"></asp:SqlDataSource>
                    
     <asp:Panel ID="Panel1" runat="server" Height="800px" Width="1200px"   ScrollBars="Vertical">
    <asp:GridView ID="grdSorgu" runat="server" CellPadding="2" ShowFooter="True" Style="text-align: right;overflow:auto" 
        Width= "100%" AllowSorting="True" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="None" BorderWidth="2px" 
        CaptionAlign="Right" CellSpacing="2" Font-Size="Small" ForeColor="Black"  CssClass="DataGrids" 
         OnItemCommand="dtgMain_OnItemCommand" Font-Names="Optima" border="0" OnSorting="grdSorgu_Sorting" AllowCustomPaging="false" Font-Bold="false" OnRowDataBound="grdVeri_RowDataBound">
  <FooterStyle CssClass="DataGridFooters" />
  <HeaderStyle CssClass="DataGridHeaders" />
         <Columns>
                               
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
         </asp:Panel>
                         
    <br />
</asp:Content>
