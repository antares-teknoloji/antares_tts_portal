<%@ Page Title="" Language="C#" MasterPageFile="~/Genel.master" AutoEventWireup="true"
    CodeFile="SanalPosOdeme.aspx.cs" Inherits="SanalPosOdeme" %>



<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtFromDate.ClientID %>").datepicker({
                dateFormat: "dd-mm-yy",
                monthNames: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"],
                dayNamesMin: ["Pa", "Pt", "Sl", "Ça", "Pe", "Cu", "Ct"],
                firstDay: 1
            });
            $("#<%=txtToDate.ClientID %>").datepicker({
                dateFormat: "dd-mm-yy",
                monthNames: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"],
                dayNamesMin: ["Pa", "Pt", "Sl", "Ça", "Pe", "Cu", "Ct"],
                firstDay: 1
            });
        });

    </script>

    <style type="text/css">
        .auto-style1 {
            width: 127px;
        }

        .auto-style4 {
            width: 94px;
        }

        .auto-style5 {
            margin-left: 29px;
        }

        .auto-style6 {
            width: 56px;
        }

        .header {
            position: relative;
            top: expression(this.offsetParent.scrollTop);
            z-index: 1;
            padding: 0;
            margin-top: -30px;
        }
        .auto-style7 {
            width: 75px;
        }
        .auto-style8 {
            width: 645px;
        }
        .auto-style9 {
            width: 385px;
        }
        .auto-style10 {
            width: 190px;
        }
        .auto-style11 {
            width: 160px;
        }
        .auto-style12 {
            width: 100px;
        }
    </style>
  <meta http-equiv="Refresh" content="300;url=Default.aspx" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container">
        <div>
        </div>
        <div style="font-weight: 700; font-size: large; color: #0055C4">
            <br />

            TEB Sanal Pos Gelen Ödemeler
            <br />
            <div style="border: thin outset #CCCCCC"></div>
        </div>
        <br />


        <br />

        <table>
            <tr>
                <td style="text-align: left;" class="auto-style1">Başlangıç Tarihi :</td>
                <td style="width: 169px">
                    <asp:TextBox ID="txtFromDate" runat="server" Height="18px" Width="145px"></asp:TextBox>
                </td>
                <td style="text-align: left;" class="auto-style4">Bitiş Tarihi :</td>
                <td style="width: 150px">
                    <asp:TextBox ID="txtToDate" runat="server" Height="17px" Width="132px" CssClass="auto-style5"></asp:TextBox>
                </td>
                <td style="text-align: left;" class="auto-style6">Firma:</td>
                <td style="width: 169px">
                    <asp:TextBox ID="txtCarıAd" runat="server" Height="18px" Width="141px"></asp:TextBox>
                </td>

                <td style="width: 150px">
                    <div style="text-align: left">
                        <asp:Button ID="ASPxButton1" runat="server" Height="27px" OnClick="SorguCek" Text="Sorgula" Width="168px"></asp:Button>
                    </div>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <table>
            <tr>
                <td style="text-align: left;" class="auto-style1">
                    &nbsp;</td>







            </tr>
        </table>
        <div>
            <br />
        </div>
        <div>
            <br />
            <div style="background-color: #000099; height: 30px; width: 1000px; margin: 0; padding: 0">
                <table cellspacing="0" cellpadding="0" rules="all" border="1" id="tblHeader"
                    style="font-family: Arial; text-align: right; font-size: 10pt; width: 900px; color: white; border-collapse: collapse; height: 100%;">
                    <tr>
                        <td style="text-align: center" class="auto-style7">AKTAR</td>
                        <td style="text-align: center" class="auto-style10">CARİKOD</td>
                        <td style="text-align: center" class="auto-style8">CARİ AD</td>
                        <td style="text-align: center" class="auto-style9">SİPARİŞ NO</td>
                        <td style="text-align: center" class="auto-style11">TARİH</td>
                        <td style="text-align: center" class="auto-style12">TUTAR</td>
                        <td style="width: 270px; text-align: center">DURUM</td>
                    </tr>
                </table>
            </div>


            <asp:Panel ID="Panel1" runat="server" Height="500px" Width="1000px" ScrollBars="Vertical">

                <asp:GridView ID="grdPos" runat="server" CellPadding="4" ShowFooter="True" Style="text-align: right" Width="100%" AllowSorting="True" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CaptionAlign="Right" CellSpacing="2" Font-Size="Small" ForeColor="Black" ShowHeader="False" OnRowCommand="grdPos_RowCommand">

                    <Columns>
                      <asp:ButtonField HeaderText="AKTAR" Text="AKTAR"  CommandName="AKTAR" ItemStyle-ForeColor="#000035" ItemStyle-Font-Bold="true" ItemStyle-Font-Names="Helvetica"  HeaderStyle-Width="120" />
                    </Columns>

                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="#000099" Font-Bold="True" ForeColor="White" CssClass="header" />
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
        </div>
    </div>
</asp:Content>
