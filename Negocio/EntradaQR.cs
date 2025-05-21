using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Xml.Linq;


namespace Negocio
{
    public class EntradaQR
    {
        public byte[] GenerarCodigoQR(string texto)
        {
            QRCodeGenerator qrGenerado = new QRCodeGenerator();
            QRCodeData qrData = qrGenerado.CreateQrCode(texto, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrData);

            Bitmap bitmap = qrCode.GetGraphic(10);
            MemoryStream ms = new MemoryStream();
            
            bitmap.Save(ms, ImageFormat.Png);
            return ms.ToArray();
            

        }

        public byte[] GenerarPDF(string nombre, string fecha, string lugar, string direccion, string codigo)
        {
            MemoryStream ms = new MemoryStream();
            Document doc = new Document(PageSize.A4);

            PdfWriter.GetInstance(doc, ms);
            doc.Open();

            //Estilos
            iTextSharp.text.Font fuenteMarca = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 30);
            iTextSharp.text.Font fuenteTexto = FontFactory.GetFont(FontFactory.HELVETICA, 14);

            //Titulo de Marca            
            doc.Add(new Paragraph("TU ENTRADA", fuenteMarca) { Alignment = Element.ALIGN_CENTER });

            doc.Add(new Paragraph("\n")); // Espacio

            //Qr
            byte[] byteQR = GenerarCodigoQR(codigo);
            iTextSharp.text.Image imageQr = iTextSharp.text.Image.GetInstance(byteQR);
            imageQr.ScaleAbsolute(150f, 150f);
            imageQr.Alignment = Element.ALIGN_CENTER;
            doc.Add(imageQr);                       

            doc.Add(new Paragraph("\n"));

            //Titulo del evento
            doc.Add(new Paragraph("EVENTO: \n", fuenteTexto));
            doc.Add(new Paragraph(nombre, fuenteTexto) { Alignment = Element.ALIGN_LEFT });

            doc.Add(new Paragraph("\n"));

            //Fecha del evento
            doc.Add(new Paragraph("FECHA EVENTO: \n", fuenteTexto));
            doc.Add(new Paragraph(fecha, fuenteTexto) { Alignment = Element.ALIGN_LEFT });

            doc.Add(new Paragraph("\n"));

            //Lugar del evento
            doc.Add(new Paragraph("LUGAR: \n", fuenteTexto));
            doc.Add(new Paragraph(lugar, fuenteTexto) { Alignment = Element.ALIGN_LEFT });

            doc.Add(new Paragraph("\n"));

            //Direccion del evento
            doc.Add(new Paragraph("DIRECCION: \n", fuenteTexto));
            doc.Add(new Paragraph(direccion, fuenteTexto) { Alignment = Element.ALIGN_LEFT });

            doc.Close();

            return ms.ToArray();
        }
    }
}
