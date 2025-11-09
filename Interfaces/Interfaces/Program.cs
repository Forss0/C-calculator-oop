
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int[] data = { 3, 2, 4, 1, 5 };
        MyArray arr = new MyArray(data);

        arr.Show();
        arr.Show("Вивід масиву з повідомленням:");


        Console.WriteLine("\nМаксимум: " + arr.Max());
        Console.WriteLine("Мінімум: " + arr.Min());
        Console.WriteLine("Середнє: " + arr.Avg());
        Console.WriteLine("Пошук 2: " + arr.Search(2));
        Console.WriteLine("Пошук 100: " + arr.Search(100));

        Console.WriteLine("\nСортування за зростанням:");
        arr.SortAsc();
        arr.Show();

        Console.WriteLine("Сортування за спаданням:");
        arr.SortDesc();
        arr.Show();

        Console.WriteLine("Сортування SortByParam(true):");
        arr.SortByParam(true);
        arr.Show();

        Console.WriteLine("Сортування SortByParam(false):");
        arr.SortByParam(false);
        arr.Show();
    }
}