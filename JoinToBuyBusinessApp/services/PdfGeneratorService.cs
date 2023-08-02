using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToBuyBusinessApp.services
{
    class PdfGeneratorService
    {
        public object DialogResult { get; private set; }

        public void GeneratePdfWithQRCode(string name, string lastName, string direction, string zip, string groupId, string userId)
        {
            // Create a new PDF document
            Document document = new Document();
            string savePath = "";
            try
            {
                
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFileDialog.FileName = "output.pdf";
                if (saveFileDialog.ShowDialog() == true)
                {

                    savePath = saveFileDialog.FileName;

                    
                }

                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(savePath, FileMode.Create));

                document.Open();

                PdfPTable table = new PdfPTable(2);
                table.WidthPercentage = 100;

                table.AddCell("Name:");
                table.AddCell(name);

                table.AddCell("Email:");
                table.AddCell(lastName);

                table.AddCell("Address:");
                table.AddCell(direction);

                table.AddCell("ZIP Code:");
                table.AddCell(zip);

                table.AddCell("Group ID:");
                table.AddCell(groupId);

                string url = "http://volna.southafricanorth.cloudapp.azure.com:8080/jointobuy/res/v1/grp/completeqr?group_id=" + groupId.ToString() + "&user_id=" + userId.ToString();
                BarcodeQRCode qrcode = new BarcodeQRCode(url, 100, 100, null);

                Image qrImage = qrcode.GetImage();

                PdfPCell qrCell = new PdfPCell(qrImage);
                qrCell.Colspan = 2;
                qrCell.HorizontalAlignment = Element.ALIGN_CENTER;
                qrCell.PaddingTop = 20;
                table.AddCell(qrCell);

                document.Add(table);
            }
            catch (Exception ex)
            {

                Console.WriteLine("An error occurred while generating the PDF: " + ex.Message);
            }
            finally
            {

                document.Close();
                Process.Start(savePath);
            }
        }

    }
}

