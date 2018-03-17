using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PostFormatter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                return;
            }
            String fileName = args[0];
            String file = File.ReadAllText(fileName);
            String header = "---\n";
            Console.Write("Enter Title: ");
            String title = Console.ReadLine();
            title = $"title: {title}\n";
            Console.Write("Enter Description: ");
            String description = Console.ReadLine();
            description = $"description: {description}\n";
            Console.Write("Enter Categories(Seperated by spaces): ");
            String[] categories = Console.ReadLine().Split(' ');
            DateTime now = DateTime.Now;
            String date = $"date: {DateTime.Now:yyyy-MM-dd hh:mm:ss}\n";
            header += title;
            header += date;
            header += description;
            if (categories.Length != 0)
            {
                header += "categories:\n";
                foreach (String cat in categories)
                {
                    if (cat.Length != 0)
                        header += $"- {cat}\n";
                }
            }
            header += "---\n";
            String[] urlTitle = { };
            while (urlTitle.Length == 0)
            {
                Console.Write("Enter URL's Title: ");
                urlTitle = Console.ReadLine().Split(' ');
            }
            String outputFileName = $"{DateTime.Now:yyyy-MM-dd}";
            foreach (String word in urlTitle)
            {
                if (word.Length != 0)
                    outputFileName += $"-{word}";
            }
            outputFileName = $"{fileName.Substring(0, fileName.LastIndexOf('\\') + 1)}{outputFileName}.md";
            File.WriteAllText(outputFileName, $"{header}\n{file}");
        }
    }
}
