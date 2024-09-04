﻿// Thread -> Thread -> Task -> syntax sugar + love = async await


Console.WriteLine($"Main method start in thread {Thread.CurrentThread.ManagedThreadId}");   // 1
//SomeMethod();
//SomeMethodAsync();
Console.WriteLine($"Main method end in thread {Thread.CurrentThread.ManagedThreadId}");     // 1
Console.ReadKey();

//void SomeMethod()
//{
//    Console.WriteLine($"Some method start in thread {Thread.CurrentThread.ManagedThreadId}"); // 1
//    Task.Run(() =>
//    {
//        Console.WriteLine($"Some method task start in thread {Thread.CurrentThread.ManagedThreadId}");
//        Thread.Sleep(1000);
//        Console.WriteLine($"Some method task end in thread {Thread.CurrentThread.ManagedThreadId}");
//    });

//    Console.WriteLine($"Some method end in thread {Thread.CurrentThread.ManagedThreadId}"); //1
//}

async void SomeMethodAsync()
{

    Console.WriteLine($"SomeMethodAsync start in thread {Thread.CurrentThread.ManagedThreadId}"); // 1 // 

    await Task.Run(() =>
    {
        Console.WriteLine($"SomeMethodAsync task start in thread {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(1000);
        Console.WriteLine($"SomeMethodAsync task end in thread {Thread.CurrentThread.ManagedThreadId}");
    });
    Console.WriteLine($"SomeMethodAsync end in thread {Thread.CurrentThread.ManagedThreadId}"); // 1 // 
}
