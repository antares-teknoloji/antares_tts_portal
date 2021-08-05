<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OtogazShellLpg.aspx.cs" Inherits="Grafik_KARTUTAR_ATSO_OtogazShellLpg" %>

<%@ Register Assembly="DevExpress.XtraCharts.v20.2.Web, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>

<%@ Register assembly="DevExpress.XtraCharts.v20.2, Version=20.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <dxchartsui:WebChartControl ID="WebChartControl1" runat="server" DataSourceID="SqlDataSource1" Height="723px" SeriesDataMember="ISYERI" SideBySideEqualBarWidth="True" Width="1329px">
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
                    <cc1:ChartTitle Text="OTOGAZ-SHELL AUTOGAZ LPG [KAR TUTAR]" />
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AKTARIMConnectionString %>" SelectCommand="SELECT [TARIH], [KARTUTAR], [ISYERI] FROM [YAKIT_KARLILIK] WHERE (([ISYERI] = @ISYERI) AND ([URUNCINS] = @URUNCINS))">
                <SelectParameters>
                    <asp:Parameter DefaultValue="ATSO" Name="ISYERI" Type="String" />
                    <asp:Parameter DefaultValue="OTOGAZ-SHELL AUTOGAZ LPG" Name="URUNCINS" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
