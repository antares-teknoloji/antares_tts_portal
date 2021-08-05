<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AkaryakitTeklifBilgi.aspx.cs" Inherits="AkaryakitTeklifBilgi" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/css1.css" />
    <link rel="stylesheet" type="text/css" href="css/css2.css" />
    <script type="text/javascript" src="js/js1.js"></script>
    <meta name="viewport" content="width=device-width" />
    <meta name="viewport" content="width = device-width, initial-scale = 1.0, minimum-scale = 1.0, maximum-scale = 1.0, user-scalable = no" />
    <script>
        $(function () {
            $('.navbar-ac').click(function () {
                $(this).next('ul').slideToggle(500);
            })
        });
    </script>
    <style>
        .right {
            float: right;
            width: 300px;
            background-color: #b0e0e6;
        }
    </style>
    <style>
        div, ul, li, a {
            display: block;
            margin: 0 0 0 15;
            padding: 0;
        }
        /* Menu */
        .navbar {
            max-width: 1160px;
            margin: 0 auto;
        }

        .navbar-out {
            width: 100%;
            background-color: #34495e;
            overflow: hidden;
        }

        ul.navbar-left {
        }

            ul.navbar-left li {
                float: left;
                list-style: none;
                width: 183px;
            }

                ul.navbar-left li a, ul.navbar-right li a {
                    padding: 15px 20px;
                    text-decoration: none;
                    background-color: #34495e;
                    color: #fff;
                    -webkit-transition: all 0.30s;
                    -moz-transition: all 0.30s;
                    -ms-transition: all 0.30s;
                    -o-transition: all 0.30s;
                    font-family: 'Open Sans', sans-serif;
                }

                    ul.navbar-left li a:hover, ul.navbar-right li a:hover {
                        background-color: #282b2f;
                    }

        .navbar-right {
            display: block;
            float: right;
        }

            .navbar-right li {
                float: left;
            }

        .navbar a i {
            font-size: 22px;
        }

        .navbar-ac {
            background-color: #73A6D8;
            padding: 10px;
            color: #fff;
            font-weight: bold;
            cursor: pointer;
            display: none;
        }

            .navbar-ac:before {
                content: "\f0c9";
                font-family: FontAwesome;
                font-weight: normal;
                font-size: 16px;
            }

        @media (max-width:768px) {
            /*Mobil Uyumlu Menu*/
            .navbar-ac {
                display: block;
            }

            ul.navbar-left {
                display: none;
                float: none;
            }

                ul.navbar-left li, .navbar-right li {
                    float: none;
                }

                    ul.navbar-left li a {
                    }

            .navbar-right {
                float: none;
            }
        }

        @media (min-width:768px) {
            ul.navbar-left, .navbar-right, {
                display: block!important;
            }
        }

        .auto-style1 {
            font-size: x-large;
        }

        .auto-style2 {
            text-align: center;
        }

        .auto-style3 {
            font-size: x-large;
            color: #FF6600;
        }

        .auto-style4 {
            font-size: x-large;
            color: #FF3300;
            text-align: center;
        }

        .auto-style7 {
            height: 25px;
        }

        .auto-style8 {
            width: 3px;
        }

        .auto-style9 {
            height: 30px;
        }

        .auto-style10 {
            height: 29px;
        }

        .dxeTrackBar,
        .dxeIRadioButton,
        .dxeButtonEdit,
        .dxeTextBox,
        .dxeRadioButtonList,
        .dxeCheckBoxList,
        .dxeMemo,
        .dxeListBox,
        .dxeCalendar,
        .dxeColorTable {
            -webkit-tap-highlight-color: rgba(0,0,0,0);
        }

        .dxeTextBox,
        .dxeButtonEdit,
        .dxeIRadioButton,
        .dxeRadioButtonList,
        .dxeCheckBoxList {
            cursor: default;
        }

        .dxeTextBox,
        .dxeMemo {
            background-color: white;
            border: 1px solid #9f9f9f;
        }

        .dxeTextBoxSys,
        .dxeMemoSys {
            border-collapse: separate!important;
        }

        .dxeTextBox .dxeEditArea {
            background-color: white;
        }

        .dxeEditArea {
            font: 12px Tahoma, Geneva, sans-serif;
            border: 1px solid #A0A0A0;
        }

        .dxeEditAreaSys {
            height: 14px;
            line-height: 14px;
            border: 0px!important;
            padding: 0px 1px 0px 0px; /* B146658 */
            background-position: 0 0; /* iOS Safari */
        }

      
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class='header'>
            <div class="auto-style2">
                <strong><span class="auto-style1">Hilmi Beken Akaryakıt Teklif Hazırlama Bilgi Girişi</span></strong>
                <br />
                <br />
            </div>
            <div class='navbar-out'>
                <div class='navbar'>
                    <div class='navbar-ac'>MENU</div>
                    <ul class='navbar-left'>
                        <li><a href='Yonetim.aspx'>Yönetim</a></li>
                    </ul>
                </div>
            </div>
            <br />
        </div>
        <div width="100%" class="auto-style3" style="background-color: #FF6600; text-align: center;">

            <strong style="color: #000000">Shell</strong>
        </div>
        <br />
        <br />
        <div style="float: left">
            <br />
            <table>
                <tr>

                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style4"><strong>Dizel</strong></td>
                </tr>
                <tr>
                    <td>Limit</td>

                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtLimit" runat="server" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Kodu</td>

                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtKod" runat="server" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td>
                        <div style="text-align: center;">
                            <asp:Button ID="btnDizelEkle" runat="server" Text="Ekle" Width="100%" OnClick="btnEkle_Click" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div style="float: left; width: 290px;">
            <br />
            <table style="width: 303px">
                <tr>
                    <td class="auto-style8"></td>
                    <td style="width: 300px">
                        <asp:GridView runat="server" CaptionAlign="Right" CellPadding="3" GridLines="Vertical" ShowFooter="True" BackColor="White" BorderColor="#999999" BorderWidth="1px" BorderStyle="Solid" Font-Size="Small" Width="100%" ID="grdDizel" Style="text-align: left" ForeColor="Black" OnRowCreated="grdDizel_RowCreated">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <FooterStyle BackColor="#CCCCCC"></FooterStyle>

                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White"></HeaderStyle>

                            <PagerStyle HorizontalAlign="Center" BackColor="#999999" ForeColor="Black"></PagerStyle>

                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

                            <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>

                            <SortedAscendingHeaderStyle BackColor="#808080"></SortedAscendingHeaderStyle>

                            <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>

                            <SortedDescendingHeaderStyle BackColor="#383838"></SortedDescendingHeaderStyle>
                        </asp:GridView>

                    </td>
                </tr>
                <tr>
                    <td class="auto-style8"></td>
                    <td>
                        <asp:Button ID="btnSil" runat="server" Text="Sil" Width="100%" OnClick="btnSil_Click" OnClientClick="return confirm('Kaydı Silmek Istediginize Emin Misiniz?');" CommandName="Delete" Sil />
                    </td>
                </tr>
            </table>
        </div>
        <div style="float: left; width: 40px;">
        </div>
        <div style="float: left; width: 297px;">
            <table style="width: 291px; margin-left: 24px">
                <tr>

                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style4"><strong>Benzin</strong></td>
                </tr>
                <tr>
                    <td class="auto-style7">Limit</td>

                    <td class="auto-style7">:</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtBenzinLimit" runat="server" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Kodu</td>

                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtBenzinKod" runat="server" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>İç İskonto</td>

                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtBenzinIcIskonto" runat="server" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Dış İskonto</td>

                    <td>:</td>
                    <td>
                        <asp:TextBox ID="txtBenzinDisIskonto" runat="server" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td>
                        <div style="text-align: center;">
                            <asp:Button ID="btnBenzinEkle" runat="server" Text="Ekle" Width="100%" OnClick="btnBenzinEkle_Click" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div style="float: left; width: 53px;">
        </div>
        <div style="float: left; width: 95px; margin-left: 20px;">
            <br />
            <table style="width: 310px">
                <tr>
                    <td style="width: 310px">
                        <asp:GridView runat="server" CaptionAlign="Right" CellPadding="3" GridLines="Vertical" ShowFooter="True" BackColor="White" BorderColor="#999999" BorderWidth="1px" BorderStyle="Solid" Font-Size="Small" Width="100%" ID="grdBenzin" Style="text-align: left" ForeColor="Black" OnRowCreated="grdDizel_RowCreated">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <FooterStyle BackColor="#CCCCCC"></FooterStyle>

                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White"></HeaderStyle>

                            <PagerStyle HorizontalAlign="Center" BackColor="#999999" ForeColor="Black"></PagerStyle>

                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

                            <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>

                            <SortedAscendingHeaderStyle BackColor="#808080"></SortedAscendingHeaderStyle>

                            <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>

                            <SortedDescendingHeaderStyle BackColor="#383838"></SortedDescendingHeaderStyle>
                        </asp:GridView>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnBenzinSil" runat="server" Text="Sil" Width="100%" OnClick="btnBenzinSil_Click" OnClientClick="return confirm('Kaydı Silmek Istediginize Emin Misiniz?');" CommandName="Delete" Sil />
                    </td>
                </tr>
            </table>

        </div>
        <div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />

        </div>
        <div class='header'>
            <div width="100%" class="auto-style3" style="background-color: #FF6600; text-align: center;">

                <strong style="color: #000000">Total</strong>
            </div>
            <br />
            <br />
            <div style="float: left">
                <br />
                <table>
                    <tr>

                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td class="auto-style4"><strong>Dizel</strong></td>
                    </tr>
                    <tr>
                        <td>Limit</td>

                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtTotalDizelLimit" runat="server" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">Kodu</td>

                        <td class="auto-style10">:</td>
                        <td class="auto-style10">
                            <asp:TextBox ID="txtTotalDizelKod" runat="server" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">İç İskonto</td>

                        <td class="auto-style10">:</td>
                        <td class="auto-style10">
                            <asp:TextBox ID="txtTotalDizelIcIskonto" runat="server" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">Dış İskonto</td>

                        <td class="auto-style10">:</td>
                        <td class="auto-style10">
                            <asp:TextBox ID="txtTotalDizelDisIskonto" runat="server" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style9"></td>
                        <td class="auto-style9"></td>
                        <td class="auto-style9">
                            <div style="text-align: center;">
                                <asp:Button ID="btnTotalDizelEkle" runat="server" Text="Ekle" Width="100%" OnClick="btnTotalDizelEkle_Click" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="float: left; width: 290px;">
                <br />
                <table style="width: 303px">
                    <tr>
                        <td class="auto-style8"></td>
                        <td style="width: 300px">
                            <asp:GridView runat="server" CaptionAlign="Right" CellPadding="3" GridLines="Vertical" ShowFooter="True" BackColor="White" BorderColor="#999999" BorderWidth="1px" BorderStyle="Solid" Font-Size="Small" Width="100%" ID="grdTotalDizel" Style="text-align: left" ForeColor="Black" OnRowCreated="grdDizel_RowCreated">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <FooterStyle BackColor="#CCCCCC"></FooterStyle>

                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White"></HeaderStyle>

                                <PagerStyle HorizontalAlign="Center" BackColor="#999999" ForeColor="Black"></PagerStyle>

                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

                                <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>

                                <SortedAscendingHeaderStyle BackColor="#808080"></SortedAscendingHeaderStyle>

                                <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>

                                <SortedDescendingHeaderStyle BackColor="#383838"></SortedDescendingHeaderStyle>
                            </asp:GridView>

                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8"></td>
                        <td>
                            <asp:Button ID="btnTotalDizelSil" runat="server" Text="Sil" Width="100%" OnClick="btnTotalDizelSil_Click" OnClientClick="return confirm('Kaydı Silmek Istediginize Emin Misiniz?');" CommandName="Delete" Sil />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="float: left; width: 40px;">
            </div>
            <div style="float: left; width: 297px;">
                <table style="width: 291px; margin-left: 24px">
                    <tr>

                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td class="auto-style4"><strong>Benzin</strong></td>
                    </tr>
                    <tr>
                        <td class="auto-style7">Limit</td>

                        <td class="auto-style7">:</td>
                        <td class="auto-style7">
                            <asp:TextBox ID="txtTotalBenzinLimit" runat="server" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Kodu</td>

                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtTotalBenzinKod" runat="server" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>İç İskonto</td>

                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtTotalBenzinIcIskonto" runat="server" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Dış İskonto</td>

                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtTotalBenzinDisIskonto" runat="server" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td>
                            <div style="text-align: center;">
                                <asp:Button ID="btnTotalBenzinEkle" runat="server" Text="Ekle" Width="100%" OnClick="btnTotalBenzinEkle_Click" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="float: left; width: 53px;">
            </div>
            <div style="float: left; width: 95px; margin-left: 20px;">
                <br />
                <table style="width: 310px">
                    <tr>
                        <td style="width: 310px">
                            <asp:GridView runat="server" CaptionAlign="Right" CellPadding="3" GridLines="Vertical" ShowFooter="True" BackColor="White" BorderColor="#999999" BorderWidth="1px" BorderStyle="Solid" Font-Size="Small" Width="100%" ID="grdTotalBenzin" Style="text-align: left" ForeColor="Black" OnRowCreated="grdDizel_RowCreated">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <FooterStyle BackColor="#CCCCCC"></FooterStyle>

                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White"></HeaderStyle>

                                <PagerStyle HorizontalAlign="Center" BackColor="#999999" ForeColor="Black"></PagerStyle>

                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

                                <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>

                                <SortedAscendingHeaderStyle BackColor="#808080"></SortedAscendingHeaderStyle>

                                <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>

                                <SortedDescendingHeaderStyle BackColor="#383838"></SortedDescendingHeaderStyle>
                            </asp:GridView>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnTotalBenzinSil" runat="server" Text="Sil" Width="100%" OnClick="btnTotalBenzinSil_Click" OnClientClick="return confirm('Kaydı Silmek Istediginize Emin Misiniz?');" CommandName="Delete" Sil />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="float: left; width: 190px;">
                <table>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </div>
        </div>
        <div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />

        </div>
        <div class='header'>
            <div width="100%" class="auto-style3" style="background-color: #FF6600; text-align: center;">

                <strong style="color: #000000">Lukoil</strong>
            </div>
            <br />
            <br />
            <div style="float: left">
                <br />
                <table>
                    <tr>

                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td class="auto-style4"><strong>Dizel</strong></td>
                    </tr>
                    <tr>
                        <td>Limit</td>

                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtLukoilDizelLimit" runat="server" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Kodu</td>

                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtLukoilDizelKod" runat="server" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">İç İskonto</td>

                        <td class="auto-style10">:</td>
                        <td class="auto-style10">
                            <asp:TextBox ID="txtLukoilDizelIcIskonto" runat="server" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">Dış İskonto</td>

                        <td class="auto-style10">:</td>
                        <td class="auto-style10">
                            <asp:TextBox ID="txtLukoilDizelDisIskonto" runat="server" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td>
                            <div style="text-align: center;">
                                <asp:Button ID="btnLukoilDizelEkle" runat="server" Text="Ekle" Width="100%" OnClick="btnLukoilDizelEkle_Click" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="float: left; width: 290px;">
                <br />
                <table style="width: 303px">
                    <tr>
                        <td class="auto-style8"></td>
                        <td style="width: 300px">
                            <asp:GridView runat="server" CaptionAlign="Right" CellPadding="3" GridLines="Vertical" ShowFooter="True" BackColor="White" BorderColor="#999999" BorderWidth="1px" BorderStyle="Solid" Font-Size="Small" Width="100%" ID="grdLukoilDizel" Style="text-align: left" ForeColor="Black" OnRowCreated="grdDizel_RowCreated">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <FooterStyle BackColor="#CCCCCC"></FooterStyle>

                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White"></HeaderStyle>

                                <PagerStyle HorizontalAlign="Center" BackColor="#999999" ForeColor="Black"></PagerStyle>

                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

                                <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>

                                <SortedAscendingHeaderStyle BackColor="#808080"></SortedAscendingHeaderStyle>

                                <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>

                                <SortedDescendingHeaderStyle BackColor="#383838"></SortedDescendingHeaderStyle>
                            </asp:GridView>

                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8"></td>
                        <td>
                            <asp:Button ID="btnLukoilDizelSil" runat="server" Text="Sil" Width="100%" OnClick="btnLukoilDizelSil_Click" OnClientClick="return confirm('Kaydı Silmek Istediginize Emin Misiniz?');" CommandName="Delete" Sil />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="float: left; width: 40px;">
            </div>
            <div style="float: left; width: 297px;">
                <table style="width: 291px; margin-left: 24px">
                    <tr>

                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td class="auto-style4"><strong>Benzin</strong></td>
                    </tr>
                    <tr>
                        <td class="auto-style7">Limit</td>

                        <td class="auto-style7">:</td>
                        <td class="auto-style7">
                            <asp:TextBox ID="txtLukoilBenzinLimit" runat="server" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Kodu</td>

                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtLukoilBenzinKod" runat="server" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>İç İskonto</td>

                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtLukoilBenzinIcIskonto" runat="server" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Dış İskonto</td>

                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtLukoilBenzinDisIskonto" runat="server" Font-Bold="True" Font-Size="Medium"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td>
                            <div style="text-align: center;">
                                <asp:Button ID="btnLukoilBenzinEkle" runat="server" Text="Ekle" Width="100%" OnClick="btnLukoilBenzinEkle_Click" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="float: left; width: 53px;">
            </div>
            <div style="float: left; width: 95px; margin-left: 20px;">
                <br />
                <table style="width: 310px">
                    <tr>
                        <td style="width: 310px">
                            <asp:GridView runat="server" CaptionAlign="Right" CellPadding="3" GridLines="Vertical" ShowFooter="True" BackColor="White" BorderColor="#999999" BorderWidth="1px" BorderStyle="Solid" Font-Size="Small" Width="100%" ID="grdLukoilBenzin" Style="text-align: left" ForeColor="Black" OnRowCreated="grdDizel_RowCreated">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <FooterStyle BackColor="#CCCCCC"></FooterStyle>

                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White"></HeaderStyle>

                                <PagerStyle HorizontalAlign="Center" BackColor="#999999" ForeColor="Black"></PagerStyle>

                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

                                <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>

                                <SortedAscendingHeaderStyle BackColor="#808080"></SortedAscendingHeaderStyle>

                                <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>

                                <SortedDescendingHeaderStyle BackColor="#383838"></SortedDescendingHeaderStyle>
                            </asp:GridView>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnLukoilBenzinSil" runat="server" Text="Sil" Width="100%" OnClick="btnLukoilBenzinSil_Click" OnClientClick="return confirm('Kaydı Silmek Istediginize Emin Misiniz?');" CommandName="Delete" Sil />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="float: left; width: 190px;">
                <table>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </div>
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <div>
            <table>
                <tr>
                    <td style="font-size: large;" class="auto-style20">Gider-Kesinti</td>

                </tr>
                <tr>
                    <td class="auto-style25">Shell Katkı Payı</td>
                    <td class="auto-style19">:</td>
                    <td style="width: 192px">
                        <dx:ASPxTextBox ID="txtShellKatkiPayi" runat="server" Height="28px" Width="200px">
                        </dx:ASPxTextBox>
                    </td>


                </tr>
                <tr>
                    <td class="auto-style13">İstasyon Masrafı</td>
                    <td class="auto-style14">:</td>
                    <td class="auto-style15">
                        <dx:ASPxTextBox ID="txtIstasyonGideri" runat="server" Height="28px" Width="200px">
                        </dx:ASPxTextBox>
                    </td>

                </tr>
                <tr>
                    <td class="auto-style25">Shell Kesinti</td>
                    <td class="auto-style19">:</td>
                    <td style="width: 192px">
                        <dx:ASPxTextBox ID="txtShellKesinti" runat="server" Height="28px" Width="200px">
                        </dx:ASPxTextBox>
                    </td>


                </tr>
                <tr>
                    <td class="auto-style25">Kredi Kartı Komisyon</td>
                    <td class="auto-style19">:</td>
                    <td style="width: 192px">
                        <dx:ASPxTextBox ID="txtKrediKartiKomisyon" runat="server" Height="28px" Width="200px">
                        </dx:ASPxTextBox>
                    </td>




                </tr>
                <tr>
                    <td class="auto-style25">Benzin-Dizel Farkı</td>
                    <td class="auto-style19">:</td>
                    <td style="width: 192px">
                        <dx:ASPxTextBox ID="txtBenzinDizelFark" runat="server" Height="28px" Width="200px">
                        </dx:ASPxTextBox>
                    </td>

                </tr>
                <tr>
                    <td class="auto-style25">Ödeme Vade Kesinti</td>
                    <td class="auto-style19">:</td>
                    <td style="width: 192px">
                        <dx:ASPxTextBox ID="txtOdemeVadeKesinti" runat="server" Height="28px" Width="200px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style25"></td>
                    <td></td>
                    <td>
                        <asp:Button ID="btnKaydet" runat="server" Text="Kaydet" Width="200px" OnClick="btnKaydet_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</body>
</html>
