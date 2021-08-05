<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KursunsuzFuelsave.aspx.cs" Inherits="Grafik_RAFİNE_DÖŞEMEALTI_KursunsuzFuelsave" %>

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
        <dxchartsui:WebChartControl ID="WebChartControl1" runat="server" DataSourceID="SqlDataSource1" Height="723px" SeriesDataMember="ISYERI" SideBySideEqualBarWidth="True" Width="1405px" BackColor="White">
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
<FillStyle fillmode="Gradient"><OptionsSerializable>
    <cc1:RectangleGradientFillOptions GradientMode="LeftToRight" />
</OptionsSerializable>
</FillStyle>

<SeriesTemplate argumentdatamember="TARIH" valuedatamembersserializable="RAFINERIFIYAT" argumentscaletype="DateTime" datafiltersconjunctionmode="Or" labelsvisibility="True"><ViewSerializable>
    
<cc1:SwiftPlotSeriesView></cc1:SwiftPlotSeriesView></ViewSerializable>
<LegendPointOptionsSerializable>
<cc1:PointOptions></cc1:PointOptions>
</LegendPointOptionsSerializable>
</SeriesTemplate>

            <titles>
                <cc1:ChartTitle Font="Times New Roman, 18pt" Text="KURŞUNSUZ BENZİN 95 OKTAN-SHELL FUELSAVE [RAFİNERİ FİYAT]" TextColor="Black" />
                <cc1:ChartTitle Alignment="Near" Dock="Right" Font="Times New Roman, 8pt" Indent="0" Text="RAFİNERİ FİYAT" WordWrap="True" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AKTARIMConnectionString %>" SelectCommand="SELECT [TARIH], [ISYERI], [RAFINERIFIYAT] FROM [YAKIT_KARLILIK] WHERE (([URUNCINS] = @URUNCINS) AND ([ISYERI] = @ISYERI))">
            <SelectParameters>
                <asp:Parameter DefaultValue="KURŞUNSUZ BENZİN 95 OKTAN-SHELL FUELSAVE" Name="URUNCINS" Type="String" />
                <asp:Parameter DefaultValue="DÖŞEMEALTI" Name="ISYERI" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
