using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Click.Models
{
    //Модель для хранения байтов файла
    public class ImagefileData : IDisposable
    {
        //Данные файла
        private byte[] imageData;
        //Поток для чтения хранящихся данных
        private MemoryStream imageMemoryStream;
        //Свойство-посредник между потоком источником и imageData
        public Stream imageStream
        {
            get
            {
                imageMemoryStream?.Close();
                imageMemoryStream = new MemoryStream(imageData);
                return imageMemoryStream;
            }
            set
            {
                using (var bufferStream = new MemoryStream())
                {
                    value.CopyTo(bufferStream);
                    imageData = bufferStream.ToArray();
                    value.Close(); //disposing original source
                }
            }
        }
        
        public string imageType { get; set; }
        public string imageName { get; set; } 
        public long imageSize { get; set; }
        
        public void Dispose()
        {
            imageMemoryStream?.Close();
        }
    }
}
