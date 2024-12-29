using System.Text;

namespace HomeWork_16Kovalenko
{
    internal class Program
    {

        static void Main()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = Encoding.GetEncoding(1251);
            try
            {
                string namefileStart = "VS HomeWork Kovalenko SART.txt";
                string namefileEnd = "VS HomeWork Kovalenko END.txt";

                Console.WriteLine("Введіть шлях до якого потрібно записати текст.\n(файл буде створено автоматично)");
                string pathFilestart = $"{Console.ReadLine()}\\{namefileStart}"; /*{Console.ReadLine()}*/


                if (File.Exists(pathFilestart))
                {
                    WriteText(pathFilestart);
                }
                else
                {
                    File.CreateText(pathFilestart);
                    WriteText(pathFilestart);
                }

                Console.WriteLine("Для копіювання файлу натисніть -ENTER-\n");
                Console.ReadKey();

                Console.WriteLine("Введіть шлях куди потрібно скопіювати текст.\n(файл буде створено автоматично)");
                string pathFileEnd = $"{Console.ReadLine()}\\{namefileEnd}"; /*{Console.ReadLine()}*/
                if (File.Exists(pathFileEnd))
                {
                    CopyText(pathFileEnd, pathFilestart);
                }
                else
                {
                    File.CreateText(pathFileEnd);
                    CopyText(pathFileEnd, pathFilestart);

                }
            }
            catch (Exception ex) { Console.WriteLine($"Дія не може бути виконана через некорректне введеня \n{ex}"); }
        }
        static void WriteText(string pathFileStart)
        {

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = Encoding.GetEncoding(1251);


            Console.WriteLine("\nВведіть текст який буде додано до файлу.");
            StreamWriter streamWriter = new(pathFileStart);
            string? textWrite = Console.ReadLine();
            streamWriter.WriteLine(textWrite);
            streamWriter.Close();
        }
        static void CopyText(string pathFileEnd, string pathFileStart)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = Encoding.GetEncoding(1251);

            StreamReader textRead = new(pathFileStart);
            string? text = textRead.ReadLine();
            string textFile = $"Цей текст скопійовано з попереднього файлу:  {text}";
            textRead.Close();
            StreamWriter streamWriter = new(pathFileEnd);
            streamWriter.WriteLine(textFile);
            streamWriter.Close();


        }

    }
}