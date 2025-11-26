
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum StoreType
{
    Food,
    Household,
    Clothes,
    Shoes
}

public class Store : IDisposable
{
    public string Name { get; set; }
    public string Address { get; set; }
    public StoreType Type { get; set; }

    private bool disposed = false;

    public Store(string name, string address, StoreType type)
    {
        Name = name;
        Address = address;
        Type = type;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Магазин: {Name}, Адреса: {Address}, Тип: {Type}");
    }

    // Реалізація IDisposable
    public void Dispose()
    {
        if (!disposed)
        {
            Console.WriteLine("Store.Dispose() викликано.");
            disposed = true;
            GC.SuppressFinalize(this);
        }
    }

    // Деструктор (для завдання 3)
    ~Store()
    {
        Console.WriteLine("Деструктор Store викликано.");
    }
}
