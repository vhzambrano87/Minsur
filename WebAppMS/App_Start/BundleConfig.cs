using System.Configuration;
using System.Web;
using System.Web.Optimization;

namespace WebAppMS
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            string servidor = ConfigurationManager.AppSettings["Servidor"];
            bundles.Add(new StyleBundle(servidor + "content/smartadmin").IncludeDirectory(servidor + "content/css", "*.min.css"));
            //~/
           

            bundles.Add(new ScriptBundle(servidor + "scripts/smartadmin").Include(
                servidor + "scripts/app.config.js",
                servidor + "scripts/plugin/jquery-touch/jquery.ui.touch-punch.min.js",
                servidor + "scripts/bootstrap/bootstrap.min.js",
                servidor + "scripts/notification/SmartNotification.min.js",
                servidor + "scripts/smartwidgets/jarvis.widget.min.js",
                servidor + "scripts/plugin/jquery-validate/jquery.validate.min.js",
                servidor + "scripts/plugin/masked-input/jquery.maskedinput.min.js",
                servidor + "scripts/plugin/select2/select2.min.js",
                servidor + "scripts/plugin/bootstrap-slider/bootstrap-slider.min.js",
                servidor + "scripts/plugin/bootstrap-progressbar/bootstrap-progressbar.min.js",
                servidor + "scripts/plugin/msie-fix/jquery.mb.browser.min.js",
                servidor + "scripts/plugin/fastclick/fastclick.min.js",
                servidor + "scripts/app.min.js"));
               

            bundles.Add(new ScriptBundle(servidor + "scripts/full-calendar").Include(
                servidor + "scripts/plugin/moment/moment.min.js",
                servidor + "scripts/plugin/fullcalendar/jquery.fullcalendar.min.js"
                ));

            bundles.Add(new ScriptBundle(servidor + "scripts/charts").Include(
                servidor + "scripts/plugin/easy-pie-chart/jquery.easy-pie-chart.min.js",
                servidor + "scripts/plugin/sparkline/jquery.sparkline.min.js",
                servidor + "scripts/plugin/morris/morris.min.js",
                servidor + "scripts/plugin/morris/raphael.min.js",
                servidor + "scripts/plugin/flot/jquery.flot.cust.min.js",
                servidor + "scripts/plugin/flot/jquery.flot.resize.min.js",
                servidor + "scripts/plugin/flot/jquery.flot.time.min.js",
                servidor + "scripts/plugin/flot/jquery.flot.fillbetween.min.js",
                servidor + "scripts/plugin/flot/jquery.flot.orderBar.min.js",
                servidor + "scripts/plugin/flot/jquery.flot.pie.min.js",
                servidor + "scripts/plugin/flot/jquery.flot.tooltip.min.js",
                servidor + "scripts/plugin/dygraphs/dygraph-combined.min.js",
                servidor + "scripts/plugin/chartjs/chart.min.js",
                servidor + "scripts/plugin/highChartCore/highcharts-custom.min.js",
                servidor + "scripts/plugin/highchartTable/jquery.highchartTable.min.js"
                ));

            bundles.Add(new ScriptBundle(servidor + "scripts/datatables").Include(
                servidor + "scripts/plugin/datatables/jquery.dataTables.min.js",
                servidor + "scripts/plugin/datatables/dataTables.colVis.min.js",
                servidor + "scripts/plugin/datatables/dataTables.tableTools.min.js",
                servidor + "scripts/plugin/datatables/dataTables.bootstrap.min.js",
                servidor + "scripts/plugin/datatable-responsive/datatables.responsive.min.js"
                ));

            bundles.Add(new ScriptBundle(servidor + "scripts/jq-grid").Include(
                servidor + "scripts/plugin/jqgrid/jquery.jqGrid.min.js",
                servidor + "scripts/plugin/jqgrid/grid.locale-en.min.js"
                ));

            bundles.Add(new ScriptBundle(servidor + "scripts/forms").Include(
                servidor + "scripts/plugin/jquery-form/jquery-form.min.js"
                ));

            bundles.Add(new ScriptBundle(servidor + "scripts/smart-chat").Include(
               servidor + "scripts/smart-chat-ui/smart.chat.ui.min.js",
               servidor + "scripts/smart-chat-ui/smart.chat.manager.min.js"
                ));

            bundles.Add(new ScriptBundle(servidor + "scripts/vector-map").Include(
                servidor + "scripts/plugin/vectormap/jquery-jvectormap-1.2.2.min.js",
                servidor + "scripts/plugin/vectormap/jquery-jvectormap-world-mill-en.js"
                ));

            BundleTable.EnableOptimizations = true;
        }
    }
}