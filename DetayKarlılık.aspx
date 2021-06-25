<%@ Page Title="" Language="C#" MasterPageFile="~/Genel.master" AutoEventWireup="true" CodeFile="DetayKarlılık.aspx.cs" Inherits="DetayKarlılık" %>
<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="background-color: #F7F7F7; font-weight: 700; height: 25px; text-align: center;" aria-checked="undefined" dir="ltr">
        <dx:ASPxButton ID="ASPxButton1" runat="server" Height="100%" Text="Cari Hesap Listesi" Width="100%" AutoPostBack="False" >
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
            </tr>
        </table>  
        <br />
        <br />
        <br />   
    </div>     
    <div style="OVERFLOW: auto; HEIGHT: 800px; width: 100%;">  
     <asp:GridView ID="grdCari" runat="server" 
         CellPadding="4" ShowFooter="True" Style="text-align: right;overflow:auto" Width="100%" AllowSorting="True" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CaptionAlign="Right" CellSpacing="2" Font-Size="Small" ForeColor="Black" ShowHeader="true">


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
</asp:Content>
