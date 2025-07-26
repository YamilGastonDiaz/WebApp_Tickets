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
        public string GenerarCodigoQR(string texto, string nombreArchivo, string rutaBase)
        {
            string carpetaQR = Path.Combine(rutaBase, "QRs");

            if (!Directory.Exists(carpetaQR))
                Directory.CreateDirectory(carpetaQR);

            string rutaQR = Path.Combine(carpetaQR, nombreArchivo + ".png");

            QRCodeGenerator qrGenerado = new QRCodeGenerator();
            QRCodeData qrData = qrGenerado.CreateQrCode(texto, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrData);

            using (Bitmap bitmap = qrCode.GetGraphic(10))
            {
                bitmap.Save(rutaQR, ImageFormat.Png);
            }

            return rutaQR;
        }
        public string GenerarPDF(string nombre, string fecha, string lugar, string direccion, string codigo, string rutaBase)
        {
            string carpetaPDF = Path.Combine(rutaBase, "PDFs");

            if (!Directory.Exists(carpetaPDF))
                Directory.CreateDirectory(carpetaPDF);

            string rutaQR = GenerarCodigoQR(codigo, "QR_" + codigo, rutaBase);
            string rutaPDF = Path.Combine(carpetaPDF, $"Entrada_{codigo}.pdf");

            using (FileStream fs = new FileStream(rutaPDF, FileMode.Create, FileAccess.Write))
            {
                iTextSharp.text.Rectangle ticketSize = new iTextSharp.text.Rectangle(250f, 600f);
                Document doc = new Document(ticketSize);
                PdfWriter.GetInstance(doc, fs);
                doc.Open();

                iTextSharp.text.Font fuenteMarca = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20);
                iTextSharp.text.Font fuenteCodigo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 15);
                iTextSharp.text.Font fuenteDescripcion = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                iTextSharp.text.Font fuenteTexto = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                iTextSharp.text.Font fuenteLetraChica = FontFactory.GetFont(FontFactory.HELVETICA, 6);

                doc.Add(new Paragraph("TU ENTRADA", fuenteMarca) { Alignment = Element.ALIGN_CENTER });

                iTextSharp.text.Image imageQr = iTextSharp.text.Image.GetInstance(rutaQR);
                imageQr.ScaleAbsolute(150f, 150f);
                imageQr.Alignment = Element.ALIGN_CENTER;
                doc.Add(imageQr);

                doc.Add(new Paragraph(codigo, fuenteCodigo) { Alignment = Element.ALIGN_CENTER });

                doc.Add(new Paragraph("EVENTO: \n", fuenteDescripcion));
                doc.Add(new Paragraph(nombre, fuenteTexto));

                doc.Add(new Paragraph("FECHA EVENTO: \n", fuenteDescripcion));
                doc.Add(new Paragraph(fecha, fuenteTexto));

                doc.Add(new Paragraph("LUGAR: \n", fuenteDescripcion));
                doc.Add(new Paragraph(lugar, fuenteTexto));

                doc.Add(new Paragraph("DIRECCION: \n", fuenteDescripcion));
                doc.Add(new Paragraph(direccion, fuenteTexto));

                doc.Add(new Paragraph("\nEl adquirente del presente ticket ha suscrito a los términos y condiciones de TUMARCA, motivo por el cual no podrá alegar desconocimiento de los mismos. Cualquier reclamo deberá ser ejercido exclusivamente ante el Organizador", fuenteLetraChica));

                doc.Close();
            }

            return rutaPDF;
        }
    }
}