 <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Takvim.aspx.cs" Inherits="Takvim" %>

<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v21.1, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>

<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v21.1, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler.Reporting" TagPrefix="dxwschsc" %>

<%@ Register Assembly="DevExpress.Web.v21.1, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.XtraScheduler.v21.1.Core, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraScheduler" tagprefix="cc1" %>
<%@ Register assembly="DevExpress.XtraScheduler.v21.1.Core.Desktop, Version=21.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraScheduler" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>


          
            <dxwschsc:ASPxSchedulerControlPrintAdapter ID="ASPxSchedulerControlPrintAdapter1" runat="server"></dxwschsc:ASPxSchedulerControlPrintAdapter>

            <dxwschs:ASPxScheduler ID="ASPxScheduler1" runat="server" AppointmentDataSourceID="SqlDataSource3" ClientIDMode="AutoID" ResourceDataSourceID="SqlDataSource2" Start="2021-02-11" Width="1194px" Theme="Default">
                <Storage>
                    <Resources>
                        <Mappings Caption="ISYERI" ResourceId="ACIKLAMA" />
                    </Resources>
                </Storage>
<Views>
<DayView><TimeRulers>
<cc1:TimeRuler></cc1:TimeRuler>
</TimeRulers>
</DayView>

<WorkWeekView><TimeRulers>
<cc1:TimeRuler></cc1:TimeRuler>
</TimeRulers>
</WorkWeekView>
</Views>
            </dxwschs:ASPxScheduler>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:AKTARIMConnectionString %>" SelectCommand="SELECT [ISYERI], [ACIKLAMA] FROM [SISTEM_KAYIT]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
