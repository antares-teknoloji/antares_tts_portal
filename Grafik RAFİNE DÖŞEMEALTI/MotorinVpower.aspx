<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MotorinVpower.aspx.cs" Inherits="Grafik_RAFİNE_DÖŞEMEALTI_MotorinVpower" %>

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
    
        <dxchartsui:WebChartControl ID="WebChartControl1" runat="server" DataSourceID="SqlDataSource1" Height="666px" SeriesDataMember="ISYERI" SideBySideEqualBarWidth="True" Width="1307px">
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

<SeriesTemplate argumentdatamember="TARIH" valuedatamembersserializable="RAFINERIFIYAT" labelsvisibility="True"><ViewSerializable>
    <cc1:SwiftPlotSeriesView>
    </cc1:SwiftPlotSeriesView>
</ViewSerializable>
<LegendPointOptionsSerializable>
<cc1:PointOptions></cc1:PointOptions>
</LegendPointOptionsSerializable>
</SeriesTemplate>

            <titles>
                <cc1:ChartTitle Text="MOTORİN-SHELL V-POWER  NITRO+ DIESEL [RAFİNERİ FİYAT]" />
                <cc1:ChartTitle Alignment="Near" Dock="Right" Font="Times New Roman, 8pt" Text="RAFİNERİ FİYAT" />
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

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AKTARIMConnectionString %>" SelectCommand="SELECT [TARIH], [RAFINERIFIYAT], [ISYERI] FROM [YAKIT_KARLILIK] WHERE (([ISYERI] = @ISYERI) AND ([TARIH] &gt;= @TARIH) AND ([URUNCINS] = @URUNCINS))">
            <SelectParameters>
                <asp:Parameter DefaultValue="DÖŞEMEALTI" Name="ISYERI" Type="String" />
                <asp:Parameter DefaultValue="2020-01-01 00:00:00.000" Name="TARIH" Type="DateTime" />
                <asp:Parameter DefaultValue="MOTORİN-SHELL V-POWER  NITRO+ DIESEL" Name="URUNCINS" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>

    </div>
    </form>
</body>
</html>
