<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OtogazShellLpg.aspx.cs" Inherits="Grafik_RAFİNE_KORKUTELİ_OtogazShellLpg" %>

<%@ Register Assembly="DevExpress.XtraCharts.v21.1.Web, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>

<%@ Register assembly="DevExpress.XtraCharts.v21.1, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dxchartsui:WebChartControl ID="WebChartControl1" runat="server" DataSourceID="SqlDataSource1" Height="657px" SeriesDataMember="ISYERI" SideBySideEqualBarWidth="True" Width="1187px">
                <diagramserializable>
                    <cc1:SwiftPlotDiagram>
                        <axisx visibleinpanesserializable="-1">
                            <range sidemarginsenabled="True" />
                        </axisx>
                        <axisy visibleinpanesserializable="-1">
                            <range sidemarginsenabled="True" />
                        </axisy>
                    </cc1:SwiftPlotDiagram>
                </diagramserializable>
<FillStyle><OptionsSerializable>
<cc1:SolidFillOptions></cc1:SolidFillOptions>
</OptionsSerializable>
</FillStyle>

                <seriestemplate argumentdatamember="TARIH" argumentscaletype="DateTime" valuedatamembersserializable="RAFINERIFIYAT">
                    <viewserializable>
                        <cc1:SwiftPlotSeriesView>
                        </cc1:SwiftPlotSeriesView>
                    </viewserializable>
                    <legendpointoptionsserializable>
                        <cc1:PointOptions>
                        </cc1:PointOptions>
                    </legendpointoptionsserializable>
                </seriestemplate>
                <titles>
                    <cc1:ChartTitle Text="OTOGAZ-SHELL AUTOGAZ LPG [RAFİNERİ FİYAT]" />
                </titles>

<CrosshairOptions><CommonLabelPositionSerializable>
<cc1:CrosshairMousePosition></cc1:CrosshairMousePosition>
</CommonLabelPositionSerializable>
</CrosshairOptions>

<ToolTipOptions><ToolTipPositionSerializable>
<cc1:ToolTipMousePosition></cc1:ToolTipMousePosition>
</ToolTipPositionSerializable>
</ToolTipOptions>
            </dxchartsui:WebChartControl>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AKTARIMConnectionString %>" SelectCommand="SELECT [ISYERI], [RAFINERIFIYAT], [TARIH] FROM [YAKIT_KARLILIK] WHERE (([ISYERI] = @ISYERI) AND ([URUNCINS] = @URUNCINS))">
                <SelectParameters>
                    <asp:Parameter DefaultValue="KORKUTELİ" Name="ISYERI" Type="String" />
                    <asp:Parameter DefaultValue="OTOGAZ-SHELL AUTOGAZ LPG" Name="URUNCINS" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
