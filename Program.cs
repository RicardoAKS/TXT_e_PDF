using System;
using System.IO;
using System.Drawing;
using Spire.Pdf;
using Spire.Pdf.Graphics;



namespace Tarefa02
{
    class Program
    {
        static void Main(string[] args)
        {
            //Nome
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();

            //Idade
            Console.Write("Idade: \n");
            int idade = System.Convert.ToInt32(Console.ReadLine());

            //Sexo
            Console.WriteLine("Masculino ou Feminino: ");
            string sexo = Console.ReadLine();

            //Cidade
            Console.WriteLine("Cidade: ");
            string cidade = Console.ReadLine();

            //Endereço
            Console.WriteLine("Endereço: ");
            string endereco = Console.ReadLine();

            string writeText = "Nome: " + nome + "\nIdade: " + idade + "\nSexo: " + sexo + "\nCidade: " + cidade + "\nEndereco: " + endereco;
            File.WriteAllText("input.txt", writeText);

            string readText = File.ReadAllText("input.txt"); 
            Console.WriteLine(readText);

            string text = File.ReadAllText("input.txt");
            PdfDocument doc = new PdfDocument();
            PdfSection section = doc.Sections.Add();
            PdfPageBase page = section.Pages.Add();
            PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 11);
            PdfStringFormat format = new PdfStringFormat();
            format.LineSpacing = 20f;
            PdfBrush brush = PdfBrushes.Black;
            PdfTextWidget textWidget = new PdfTextWidget(text, font, brush);
            float y = 0;
            PdfTextLayout textLayout = new PdfTextLayout();
            textLayout.Break = PdfLayoutBreakType.FitPage;
            textLayout.Layout = PdfLayoutType.Paginate;
            RectangleF bounds = new RectangleF(new PointF(0, y), page.Canvas.ClientSize);
            textWidget.StringFormat = format;
            textWidget.Draw(page, bounds, textLayout);
            doc.SaveToFile("TxtToPDf.pdf", FileFormat.PDF);
        }
    }
}