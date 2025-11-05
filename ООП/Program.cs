using System;

class Money
{
    private int whole; // гривні
    private int coins; // копійки

    public int Whole
    {
        get => whole;
        set
        {
            if (value < 0) throw new ArgumentException("Ціла частина не може бути від’ємною");
            whole = value;
        }
    }

    public int Coins
    {
        get => coins;
        set
        {
            if (value < 0 || value > 99) throw new ArgumentException("Копійки мають бути в межах 0–99");
            coins = value;
        }
    }

    public Money(int whole, int coins)
    {
        Whole = whole;
        Coins = coins;
    }

    public void SetAmount(int whole, int coins)
    {
        Whole = whole;
        Coins = coins;
    }

    public override string ToString()
    {
        return $"{Whole}.{Coins:D2} грн";
    }

    public void Add(Money other)
    {
        int totalCoins = Coins + other.Coins;
        Whole += other.Whole + totalCoins / 100;
        Coins = totalCoins % 100;
    }

    public void Subtract(Money other)
    {
        int totalThis = Whole * 100 + Coins;
        int totalOther = other.Whole * 100 + other.Coins;
        if (totalThis < totalOther)
            throw new InvalidOperationException("Недостатньо грошей");

        int result = totalThis - totalOther;
        Whole = result / 100;
        Coins = result % 100;
    }
}

class Product
{
    public string Name { get; set; }
    public Money Price { get; set; }

    public Product(string name, Money price)
    {
        Name = name;
        Price = price;
    }

    public void IncreasePrice(Money amount)
    {
        Price.Add(amount);
    }

    public void DecreasePrice(Money amount)
    {
        Price.Subtract(amount);
    }

    public void Show()
    {
        Console.WriteLine($"{Name} — ціна: {Price}");
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var apple = new Product("Телефон", new Money(999, 99));

        while (true)
        {
            Console.WriteLine("\n=== Меню ===");
            Console.WriteLine("1. Показати товар");
            Console.WriteLine("2. Підняти ціну");
            Console.WriteLine("3. Знизити ціну");
            Console.WriteLine("0. Вихід");
            Console.Write("Ваш вибір: ");
            string choice = Console.ReadLine();

            if (choice == "0") break;
            switch (choice)
            {
                case "1":
                    apple.Show();
                    break;
                case "2":
                    apple.IncreasePrice(new Money(100, 99));
                    Console.WriteLine("✅ Ціну підвищено");
                    break;
                case "3":
                    apple.DecreasePrice(new Money(0, 99));
                    Console.WriteLine("✅ Ціну знижено");
                    break;
                default:
                    Console.WriteLine("❌ Невірний вибір");
                    break;
            }
        }
    }
}
