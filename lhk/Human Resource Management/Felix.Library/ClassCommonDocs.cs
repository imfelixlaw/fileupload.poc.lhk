using System;
using System.Data;
using System.Drawing;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Felix.Library.Common.Docs
{
    public class CommonPDFDocs
    {
        private static bool _PDFInit = false;
        private static string _PDFFileName = null;
        private Document _PDF = new Document(PageSize.A4);

        /// <summary>
        /// create object
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="title"></param>
        /// <param name="subject"></param>
        public CommonPDFDocs(string filename, string title = null, string subject = null)
        {
            try
            {
                if (string.IsNullOrEmpty(filename)) { throw new Exception("PDF Filename is empty"); }
                _PDFFileName = filename;
                PdfWriter.GetInstance(_PDF, new FileStream(_PDFFileName, FileMode.Create));
                _PDF.Open();
                if (!string.IsNullOrEmpty(title)) { _PDF.AddTitle(title); }
                if (!string.IsNullOrEmpty(subject)) { _PDF.AddSubject(subject); }
                if (!string.IsNullOrEmpty(title)) { _PDF.AddTitle(title); }
                _PDF.AddCreator("FelixLib.PDFDoc");
                _PDF.AddAuthor("FelixLib.PDFDoc.LHK");
                _PDFInit = true;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Create PDF Table
        /// </summary>
        /// <param name="RawDT"></param>
        /// <returns></returns>
        public PdfPTable DataTable(DataTable RawDT)
        {
            try
            {
                PdfPTable PTable = new PdfPTable(RawDT.Columns.Count);
                foreach (DataColumn col in RawDT.Columns) { PTable.AddCell(col.ColumnName); }
                PTable.HeaderRows = 1;
                foreach (DataRow row in RawDT.Rows) { foreach (object cell in row.ItemArray) { PTable.AddCell(FormatPhrase(cell.ToString())); } }
                return PTable;
            }
            catch { return null; }
        }

        /// <summary>
        /// formating the parse
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static Phrase FormatPhrase(string value)
        {
            return new Phrase(value, FontFactory.GetFont(FontFactory.HELVETICA, 8));
        }

        /// <summary>
        /// write text
        /// </summary>
        /// <param name="text"></param>
        public void Write(string text)
        {
            try
            {
                if (!_PDFInit) { throw new Exception("PDF Class not initialized."); }
                _PDF.Add(new Paragraph(text));
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// write table
        /// </summary>
        /// <param name="table"></param>
        public void Write(DataTable table)
        {
            try
            {
                if (!_PDFInit) { throw new Exception("PDF Class not initialized."); }
                _PDF.Add(DataTable(table));
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// save pdf created
        /// </summary>
        public void SaveFile()
        {
            try
            {
                if (!_PDFInit) { throw new Exception("PDF Class not initialized."); }
                _PDF.Close();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
