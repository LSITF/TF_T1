using System.Drawing;
using ExpertPdf.HtmlToPdf;

namespace ConApp_VS2k8
{
    public class PdfGenerator
    {
        public static PdfConverter GetPdfConverter()
        {
            PdfConverter pdfConverter = new PdfConverter();

            // set if the generated PDF contains selectable text or an embedded image - default value is true
            pdfConverter.PdfDocumentOptions.GenerateSelectablePdf = true;

            //set the PDF page size 
            pdfConverter.PdfDocumentOptions.PdfPageSize = (PdfPageSize.A4);
            // set the PDF compression level
            pdfConverter.PdfDocumentOptions.PdfCompressionLevel = (PdfCompressionLevel.Normal);
            // set the PDF page orientation (portrait or landscape)
            pdfConverter.PdfDocumentOptions.PdfPageOrientation = (PDFPageOrientation.Portrait);
            //set the PDF standard used to generate the PDF document
            pdfConverter.PdfStandardSubset = PdfStandardSubset.Pdf_A_1b;
            // show or hide header and footer
            pdfConverter.PdfDocumentOptions.ShowHeader = true;
            pdfConverter.PdfDocumentOptions.ShowFooter = true;
            //set the PDF document margins
            pdfConverter.PdfDocumentOptions.LeftMargin = 5;
            pdfConverter.PdfDocumentOptions.RightMargin = 5;
            pdfConverter.PdfDocumentOptions.TopMargin = 5;
            pdfConverter.PdfDocumentOptions.BottomMargin = 5;
            // set if the HTTP links are enabled in the generated PDF
            pdfConverter.PdfDocumentOptions.LiveUrlsEnabled = true;
            // set if the HTML content is resized if necessary to fit the PDF page width - default is true
            pdfConverter.PdfDocumentOptions.FitWidth = true;
            // set if the PDF page should be automatically resized to the size of the HTML content when FitWidth is false
            pdfConverter.PdfDocumentOptions.AutoSizePdfPage = true;
            //embed the true type fonts in the generated PDF document
            pdfConverter.PdfDocumentOptions.EmbedFonts = true;
            // compress the images in PDF with JPEG to reduce the PDF document size - default is true
            pdfConverter.PdfDocumentOptions.JpegCompressionEnabled = true;
            // set if the JavaScript is enabled during conversion 
            pdfConverter.ScriptsEnabled = pdfConverter.ScriptsEnabledInImage = true;

            pdfConverter.LicenseKey = "po2Xhp6GlJWehpOIloaVl4iXlIifn5+f";

            #region footer options

            pdfConverter.PdfFooterOptions.FooterBackColor = Color.White;
            pdfConverter.PdfFooterOptions.FooterHeight = 15;
            pdfConverter.PdfFooterOptions.DrawFooterLine = true;
            pdfConverter.PdfFooterOptions.PageNumberText = "Page";
            pdfConverter.PdfFooterOptions.PageNumberTextColor = Color.Black;
            pdfConverter.PdfFooterOptions.PageNumberTextFontName = "Arial";
            pdfConverter.PdfFooterOptions.PageNumberTextFontSize = 12;
            pdfConverter.PdfFooterOptions.PageNumberYLocation = 0;
            pdfConverter.PdfFooterOptions.ShowPageNumber = true;
            pdfConverter.PdfFooterOptions.ShowOnEvenPages = true;
            pdfConverter.PdfFooterOptions.ShowOnOddPages = true;

            #endregion footer options

            #region header options

            pdfConverter.PdfHeaderOptions.HeaderBackColor = Color.White;
            pdfConverter.PdfHeaderOptions.HeaderHeight = 20;
            pdfConverter.PdfHeaderOptions.HeaderTextColor = Color.Black;
            pdfConverter.PdfHeaderOptions.HeaderTextFontName = "Arial";
            pdfConverter.PdfHeaderOptions.HeaderTextFontSize = 12;
            pdfConverter.PdfHeaderOptions.HeaderTextYLocation = 0;
            pdfConverter.PdfHeaderOptions.DrawHeaderLine = true;
            pdfConverter.PdfHeaderOptions.ShowOnEvenPages = true;
            pdfConverter.PdfHeaderOptions.ShowOnOddPages = true;

            #endregion header options

            // set if the converter should try to avoid breaking the images between PDF pages
            pdfConverter.AvoidImageBreak = true;

            return pdfConverter;
        }
    }
}
