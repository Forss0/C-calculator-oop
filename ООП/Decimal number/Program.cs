

using System;

struct DecimalNumber
{
    public int Number { get; set; }

    public DecimalNumber(int number)
    {
        Number = number;
    }

    public string ToBinary()
    {
        if (Number == 0) return "0";
        int abs = Math.Abs(Number);
        string body = Convert.ToString(abs, 2);
        return Number < 0 ? "-" + body : body;
    }

    public string ToOctal()
    {
        if (Number == 0) return "0";
        int abs = Math.Abs(Number);
        string body = Convert.ToString(abs, 8);
        return Number < 0 ? "-" + body : body;
    }

    public string ToHex()
    {
        if (Number == 0) return "0";
        int abs = Math.Abs(Number);
        string body = Convert.ToString(abs, 16).ToUpper();
        return Number < 0 ? "-" + body : body;
    }
}

class DecimalNumberDemo
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        while (true)
        {
            Console.WriteLine("\n=== Конвертор десяткового числа ===");
            Console.WriteLine("1. Ввести число і конвертувати");
            Console.WriteLine("2. Ввести кілька чисел (через пробіл або коми)");
            Console.WriteLine("0. Вихід");
            Console.Write("Ваш вибір: ");
            string choice = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(choice))
            {
                Console.WriteLine(" Порожній ввід — спробуйте ще раз.");
                continue;
            }

            if (choice == "0")
            {
                Console.WriteLine("До побачення!");
                break;
            }

            try
            {
                if (choice == "1")
                {
                    int num = ReadSingleInt("Введіть десяткове число: ");
                    PrintConversions(new DecimalNumber(num));
                }
                else if (choice == "2")
                {
                    Console.Write("Введіть числа (наприклад: 12  -1  123): ");
                    string line = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        Console.WriteLine(" Порожній ввід.");
                        continue;
                    }

                    var parts = line.Split(new[] { ' ', '\t', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var p in parts)
                    {
                        if (int.TryParse(p, out int value))
                        {
                            Console.WriteLine($"\nЧисло: {value}");
                            PrintConversions(new DecimalNumber(value));
                        }
                        else
                        {
                            Console.WriteLine($"\n '{p}' — не є коректним цілим числом (ігнорується.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine(" Невірний вибір. Оберіть 1, 2 або 0.");
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine(" Число занадто велике або занадто мале для типу int.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Непередбачена помилка: " + ex.Message);
            }
        }
    }

    // Читає одне ціле число
    static int ReadSingleInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(" Порожній ввід. Спробуйте ще раз.");
                continue;
            }

            input = input.Trim();
            if (int.TryParse(input, out int value))
            {
                return value;
            }
            else
            {
                Console.WriteLine(" Невірний формат. Введіть ціле число (наприклад: 123 або -123).");
            }
        }
    }

    // Виведення результатів конвертації
    static void PrintConversions(DecimalNumber dn)
    {
        Console.WriteLine($"Десяткове: {dn.Number}");
        Console.WriteLine($"Двійкова: {dn.ToBinary()}");
        Console.WriteLine($"Вісімкова: {dn.ToOctal()}");
        Console.WriteLine($"Шістнадцяткова: {dn.ToHex()}");
    }
}
