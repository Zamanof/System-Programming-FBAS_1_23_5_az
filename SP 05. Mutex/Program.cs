// lock/monitor - lock mechanism
// Mutex, Semaphore, SemaphoreSlim - Signaling mechanism


#region Mutex - Mutual exclusion (Internal thread)

//Mutex mutex = new Mutex();
//int numb = 0;
//for (int i = 0; i < 5; i++)
//{
//    Thread thread = new Thread(Count);
//    if (i != 4 && i != 3)
//    {
//        thread.Name = $"{i+1}-ci muəllim";
//    }
//    else thread.Name = $"{i + 1}-cü muəllim";
//    thread.Start();
//}
//Console.ReadKey();

//void Count(object? obj)
//{
//    numb = 1;
//    mutex.WaitOne();
//    for (int i = 0; i < 10; i++)
//    {
//        Console.WriteLine($"{Thread.CurrentThread.Name}: {numb++}");
//    }
//    mutex.ReleaseMutex();
//}

#endregion

#region Mutex - Mutual exclusion(External thread)
//string MutexName = "Matanat A";
//using var mutex = new Mutex(false, MutexName);
//if (!mutex.WaitOne(30000))
//{
//    Console.WriteLine("Other instance is running...");
//    Thread.Sleep(1000);
//    return;
//}
//else
//{
//    Console.WriteLine("My Code is running...");
//    Console.ReadKey();
//    mutex.ReleaseMutex();
//}


#endregion
