using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static int waitingCustomers = 0;
    static int waitingRoom = 3;
    static SemaphoreSlim customer = new SemaphoreSlim(0);
    static SemaphoreSlim barber = new SemaphoreSlim(0);
    static object door = new object();

    static void BarberShop()
    {
        while (true)
        {
            customer.Wait();

            lock (door)
            {
                waitingCustomers--;
                Console.WriteLine("Barber is ready, waiting customers: " + waitingCustomers);
            }
            barber.Release();
            Console.WriteLine("Barber is making haircut...");
            Thread.Sleep(5000);
        }
    }
    static void Customer(int iD)
    {
        if (waitingCustomers < waitingRoom)
        {
            waitingCustomers++;
            Console.WriteLine($"Customer {iD} is waiting, total waiting: {waitingCustomers}");
            customer.Release();
            barber.Wait();
            Console.WriteLine($"Customer {iD} is getting haircut");
        }
        else
        {
            Console.WriteLine($"Waiting room is full, customer {iD} leaves");
        }
    }
    static void Main()
    {
        Random random = new Random();
        Thread barberShop = new Thread(BarberShop);
        barberShop.Start();
        for (int iD = 1; iD < 10; iD++)
        {
            Thread.Sleep(random.Next(2000));
            new Thread(() => Customer(iD)).Start();
        }
    }
}