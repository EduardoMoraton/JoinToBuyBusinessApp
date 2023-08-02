using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JoinToBuyBusinessApp.services
{
    class ImgUtils
    {
        public string OpenImage()
        {
            string base64Image = null;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos PNG (*.png)|*.png";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                byte[] imageBytes = File.ReadAllBytes(filePath);
                base64Image = Convert.ToBase64String(imageBytes);
            }

            return base64Image;
        }

        public string DownloadAndConvertToBase64(string imageUrl)
        {
            string base64Image = null;

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] imageBytes = webClient.DownloadData(imageUrl);
                    base64Image = Convert.ToBase64String(imageBytes);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al descargar la imagen: " + ex.Message);
            }

            return base64Image;
        }


    }
}
