<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MotorinFuelsave.aspx.cs" Inherits="Grafik_KARTUTAR_DÖŞEMEALTI_MotorinFuelsave" %>

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
            <dxchartsui:WebChartControl ID="WebChartControl1" runat="server" DataSourceID="SqlDataSource1" Height="674px" SeriesDataMember="ISYERI" SideBySideEqualBarWidth="True" Width="1396px">
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

                <seriesserializable>
                    <cc1:Series Name="Series 1">
                        <viewserializable>
                            <cc1:SideBySideBarSeriesView>
                            </cc1:SideBySideBarSeriesView>
                        </viewserializable>
                        <labelserializable>
                            <cc1:SideBySideBarSeriesLabel LineVisible="True">
                                <fillstyle>
                                    <optionsserializable>
                                        <cc1:SolidFillOptions />
                                    </optionsserializable>
                                </fillstyle>
                                <pointoptionsserializable>
                                    <cc1:PointOptions>
                                    </cc1:PointOptions>
                                </pointoptionsserializable>
                            </cc1:SideBySideBarSeriesLabel>
                        </labelserializable>
                        <legendpointoptionsserializable>
                            <cc1:PointOptions>
                            </cc1:PointOptions>
                        </legendpointoptionsserializable>
                    </cc1:Series>
                    <cc1:Series Name="Series 2">
                        <viewserializable>
                            <cc1:SideBySideBarSeriesView>
                            </cc1:SideBySideBarSeriesView>
                        </viewserializable>
                        <labelserializable>
                            <cc1:SideBySideBarSeriesLabel LineVisible="True">
                                <fillstyle>
                                    <optionsserializable>
                                        <cc1:SolidFillOptions />
                                    </optionsserializable>
                                </fillstyle>
                                <pointoptionsserializable>
                                    <cc1:PointOptions>
                                    </cc1:PointOptions>
                                </pointoptionsserializable>
                            </cc1:SideBySideBarSeriesLabel>
                        </labelserializable>
                        <legendpointoptionsserializable>
                            <cc1:PointOptions>
                            </cc1:PointOptions>
                        </legendpointoptionsserializable>
                    </cc1:Series>
                </seriesserializable>
                <seriestemplate argumentdatamember="TARIH" argumentscaletype="DateTime" valuedatamembersserializable="KARTUTAR">
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
                    <cc1:ChartTitle Text="KURŞUNSUZ BENZİN 95 OKTAN  V POWER [KAR TUTAR]" />
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

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AKTARIMConnectionString %>" SelectCommand="SELECT [TARIH], [ISYERI], [KARTUTAR] FROM [YAKIT_KARLILIK] WHERE (([URUNCINS] = @URUNCINS) AND ([ISYERI] = @ISYERI))">
                <SelectParameters>
                    <asp:Parameter DefaultValue="KURŞUNSUZ BENZİN 95 OKTAN  V POWER" Name="URUNCINS" Type="String" />
                    <asp:Parameter DefaultValue="DÖŞEMEALTI" Name="ISYERI" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>

        </div>
    </form>
</body>
</html>
