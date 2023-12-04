using System;
using System.Data;
using System.Drawing;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace FYP.Library.Docs
{
    class PDFCreate
    {
        private static bool _PDFInit = false;
        private static string _PDFFileName = null;
        private Document _PDF = new Document(PageSize.A4);

        public PDFCreate(string filename, string title = null, string subject = null)
        {
            try
            {
                if (string.IsNullOrEmpty(filename)) { throw new Exception("PDF Filename is empty"); }
                _PDFFileName = filename;
                PdfWriter.GetInstance(_PDF, new FileStream(_PDFFileName, FileMode.Create));
                _PDF.Open();
                if (!string.IsNullOrEmpty(title)) { _PDF.AddTitle(title); }
                if (!string.IsNullOrEmpty(subject)) { _PDF.AddSubject(subject); }
                _PDF.AddCreator("FYP.PDFDoc");
                _PDF.AddAuthor("FYP.PDFDoc");
                _PDFInit = true;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public PdfPTable DataTable(DataTable RawDT)
        {
            try
            {
                PdfPTable PTable = new PdfPTable(RawDT.Columns.Count);
                foreach (DataColumn col in RawDT.Columns)
                {
                    PTable.AddCell(col.ColumnName);
                }
                PTable.HeaderRows = 1;

                foreach (DataRow row in RawDT.Rows)
                {
                    foreach (object cell in row.ItemArray)
                    {
                        PTable.AddCell(FormatPhrase(cell.ToString()));
                    }
                }
                return PTable;
            }
            catch { return null; }
        }

        private static Phrase FormatPhrase(string value)
        {
            try
            {
                return new Phrase(value, FontFactory.GetFont(FontFactory.HELVETICA, 8));
            }
            catch { return null; }
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
