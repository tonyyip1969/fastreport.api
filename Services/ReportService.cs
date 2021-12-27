using FastReport.Export.PdfSimple;

namespace FastReport.Api.Services
{
    public interface IReport
    {
        MemoryStream Generate();
    }

    public class ReportService : IReport
    {
        public MemoryStream Generate()
        {
            var strm = new MemoryStream();
            var report = new Report();
            try
            {
                var templatePath = ".\\Reports\\Sample.frx";
                report.Report.Load(templatePath);
                
                //report.RegisterData(DataSet);

                if (report.Prepare())
                {
                    Export(report, strm);
                }
            }
            finally
            {
                report.Dispose();
            }

            return strm;
        }

        private void Export(Report report, MemoryStream memoryStream)
        {
            var pdfExport = new PDFSimpleExport();
            try
            {
                pdfExport.Export(report, memoryStream);
                memoryStream.Position = 0;
            }
            finally
            {
                pdfExport.Dispose();
            }
        }
    }
}
