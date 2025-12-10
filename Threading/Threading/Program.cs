

using System;
using System.Threading;

class SleepingBarber
{
    static int maxSeats = 5;
    static int waiting = 0;

    static SemaphoreSlim barber = new SemaphoreSlim(0, 5);
    static SemaphoreSlim customer = new SemaphoreSlim(0, 5);
    static object lockObj = new object();

    static void Barber()
    {
        while (true)
        {
            Console.WriteLine("Перукар спить – немає клієнтів");
            barber.Wait();

            Console.WriteLine("Перукар стриже клієнта...");
            Thread.Sleep(2000);

            Console.WriteLine("Стрижка завершена");
            customer.Release();
        }
    }

    static void Customer(object id)
    {
        int clientId = (int)id;

        lock (lockObj)
        {
            if (waiting < maxSeats)
            {
                waiting++;
                Console.WriteLine($"Клієнт {clientId} зайшов. Очікують: {waiting}");
                barber.Release();
            }
            else
            {
                Console.WriteLine($"Клієнт {clientId} пішов — немає місць");
                return;
            }
        }

        customer.Wait();

        lock (lockObj) waiting--;
        Console.WriteLine($"Клієнт {clientId} пострижений і пішов");
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        new Thread(Barber).Start();

        int id = 1;
        Random r = new Random();

        while (true)
        {
            new Thread(Customer).Start(id++);
            Thread.Sleep(r.Next(500, 1500));
        }
    }
}
