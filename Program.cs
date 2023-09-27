using System;
using System.IO;
using System.Text;

class Program
{    
    
    static int numberCombination = 1; 
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        string inputFileName = "input.txt";
        string outputFileName = "output.txt";;

        try
        {
            string[] lines = File.ReadAllLines(inputFileName);

            if (lines.Length < 3)
            {
                Console.WriteLine("Nespravny vstupni format.");
                return;
            }

            int sloupce = int.Parse(lines[0]);
            int radky = int.Parse(lines[1]);
            int otvory = int.Parse(lines[2]);

            StringBuilder sb = new StringBuilder();
            GenerateCombinations(sb, sloupce, radky, otvory);


            File.WriteAllText(outputFileName, sb.ToString());

            Console.WriteLine("Hotovo Vysledky se ulozi do " + outputFileName);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }

    static void GenerateCombinations(StringBuilder sb, int sloupce, int radky, int otvory)
    {
        int celkemOtvoru = sloupce * radky;
        int[] kombinace = new int[celkemOtvoru];

        Generate(sb, kombinace, 0, otvory, celkemOtvoru, sloupce, radky);
    }

    static void Generate(StringBuilder sb, int[] kombinace, int pozice, int otvory, int celkemOtvoru, int sloupce, int radky)
    {
        if (otvory == 0)
        {
            PrintCombination(sb, kombinace, sloupce, radky);
            return;
        }

        if (pozice >= celkemOtvoru)
        {
            return;
        }

        // Generovani kombinaci s označenými otvory
        kombinace[pozice] = 1;
        Generate(sb, kombinace, pozice + 1, otvory - 1, celkemOtvoru, sloupce, radky);

        // Generování kombinaci s neoznacenymi dirami
        kombinace[pozice] = 0;
        Generate(sb, kombinace, pozice + 1, otvory, celkemOtvoru, sloupce, radky);
    }


    static void PrintCombination(StringBuilder sb, int[] kombinace, int sloupce, int radky)
    {
        int counter = 1;
        


        sb.AppendLine($"Cislo combo: {numberCombination}");

        for (int i = 0; i < radky; i++)
            {
                for (int j = 0; j < sloupce; j++)
                {
                    sb.Append("| " + (kombinace[i * sloupce + j] == 1 ? "█" : counter.ToString()) + " |");

                    if (j < sloupce - 1)
                    {
                        sb.Append(' ');
                    }

                    counter++;
                }
                sb.AppendLine();
            }
            numberCombination++;
            sb.AppendLine(); // Jednotlive kombinace oddelte prazdnym radkem
        }
}
