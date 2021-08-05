<%@ Page Title="" Language="C#" MasterPageFile="~/Genel.master" AutoEventWireup="true" CodeFile="CariKart.aspx.cs" Inherits="CariKart" %>

<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head 
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/bootstrap.min.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<style type="text/css">
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
</head>
    </html>

    <div style="background-color: #3366CC; font-weight: 700; height: 25px; text-align: center;" aria-checked="undefined" dir="ltr" border-radius: 5px; webkit-border-radius: 5px; moz-border-radius: 5px;>
        <asp:Button ID="ASPxButton1" runat="server" Height="100%" Text="Cari Hesap Listesi" Width="100%" AutoPostBack="False" CssClass="yuvarlak" Font-Names="Time" BackColor="#e2e2e2" />
              
    </div>
    <br />
    <br />
    <div border-radius: 5px; webkit-border-radius: 5px; moz-border-radius: 5px;>
        
        <table>
            <tr>
               
                <td style="width: 10px";> </td>
                <td style="width: 70px; height: 42px;"> Plaka :</td>
                <td style="width: 170px; height: 42px;">
                    <asp:TextBox ID="txtPlaka" runat="server" Height="26px" Style="margin-left: 2px" Width="170px" Font-Bold="true" CssClass="yuvarlak" ></asp:TextBox>
                     <td style="width: 20px";> </td>
                </td>
                <td style="width: 70px; height: 42px;">Firma Ünvan :</td>
                <td style="width: 170px; height: 42px;">
                    <asp:TextBox ID="txtCariAd" runat="server" Height="26px" Style="margin-left: 2px" Width="170px" Font-Bold="true" CssClass=""></asp:TextBox>         
                </td>      
                <td style="width: 70px; height:42px;" ;> </td>
                  <td style="width: 170px; height: 42px;">
              <asp:Button ID="btnArama" runat="server"  Height="35px" Width="120px" OnClick="btnArama_Click" CssClass="button" Text="Arama" Font-Bold="true" ForeColor="Black"/>          
                   
                </td>
            </tr>
        </table>  
        <br />
        <br />
        <br />   
    </div>     
    <div style="OVERFLOW: auto; HEIGHT: 800px; width: 100%;">  
    <asp:GridView ID="grdCari" runat="server" CellPadding="3" OnRowCommand="grdCari_RowCommand" OnRowCreated="grdCari_RowCreated" ShowFooter="True" style="text-align: center" Width="100%" AllowSorting="True" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CaptionAlign="Right" CellSpacing="1" Font-Size="Small" GridLines="None" OnPageIndexChanging="grdCari_PageIndexChanging" Font-Names="Monaco" OnRowDataBound="grdCari_RowDataBound">
       
        <Columns>
            <asp:ButtonField HeaderText="PLAKA GÜNCELLE" Text="PLAKA GÜNCELLE" CommandName="PLAKA GÜNCELLE" ItemStyle-ForeColor="#000035" ItemStyle-Font-Bold="true" ItemStyle-Font-Names="Helvetica" />
            <asp:ButtonField HeaderText="LİMİT GÜNCELLE" Text="LİMİT GÜNCELLE" CommandName="LİMİT GÜNCELLE" ItemStyle-ForeColor="#000035" ItemStyle-Font-Bold="true" ItemStyle-Font-Names="Helvetica" />
            <asp:ButtonField HeaderText="YAKIT BLOKE" Text="YAKIT BLOKE" CommandName="YAKIT BLOKE" ItemStyle-ForeColor="#000035" ItemStyle-Font-Bold="true" ItemStyle-Font-Names="Helvetica" />
            <asp:ButtonField HeaderText="BİLGİ GÜNCELLE" Text="BİLGİ GÜNCELLE"  CommandName="BİLGİ GÜNCELLE" ItemStyle-ForeColor="#000035" ItemStyle-Font-Bold="true" ItemStyle-Font-Names="Helvetica"  />
            
        </Columns>

        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
        <HeaderStyle BackColor="#000066" Font-Bold="True" ForeColor="#E7E7FF" />
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

