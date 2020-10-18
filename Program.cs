using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Tarefa02
{
    class Program
    {
        static void ConvertPdf(string input)
        {
            StreamReader rdr = new StreamReader(input);
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream("Arquivos/ouput.pdf", FileMode.Create));
            doc.Open();
            doc.Add(new Paragraph(rdr.ReadToEnd()));
            doc.Close();
        }
        static void Main(string[] args)
        {
            //Nome
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();

            //Idade
            Console.Write("Idade: \n");
            int idade = Convert.ToInt32(Console.ReadLine());

            //Sexo
            Console.WriteLine("Sexo: M ou F: ");
            string sexo = Console.ReadLine();
            for (int i = 0; i < 1; i++)
            {
                if (sexo == "M" || sexo == "m")
                {
                    sexo = "Masculino";
                }
                else if (sexo == "F" || sexo == "f")
                {
                    sexo = "Feminino";
                }
                else
                {
                    Console.WriteLine("Digite um opção valida!");
                    sexo = Console.ReadLine();
                    i = -1;
                }
            }

            //Cidade
            Console.WriteLine("Cidade: ");
            string cidade = Console.ReadLine();

            //Endereço
            Console.WriteLine("Endereço: ");
            string endereco = Console.ReadLine();

            //Cria o arquivo .txt com os dados passados pelo usuario
            string writeText = "Nome: " + nome + "\nIdade: " + idade + "\nSexo: " + sexo + "\nCidade: " + cidade + "\nEndereco: " + endereco;
            File.WriteAllText("Arquivos/input.txt", writeText);

            //O arquivo .txt guardado em uma variavel string
            string input = "input.txt";

            //Converte .txt para .pdf
            ConvertPdf(input);
        }
    }
}