#region Albahari Tricks
// Example 1
//for (int i = 0; i < 10; i++)
//{
//    new Thread(() =>
//    {
//        Console.WriteLine(i);
//    }).Start();
//}


//for (int i = 0; i < 10; i++)
//{
//    int tmp = i;
//    new Thread(() =>
//    {
//        Console.WriteLine(tmp);
//    }).Start();
//}


//string text = "Salam";

//Thread thread1 = new(() =>
//{
//    Console.WriteLine(text);
//});

//Thread thread2 = new(() =>
//{
//    Console.WriteLine(text);
//});

//thread1.Start();
//thread2.Start();
//text = "Muhammad";
#endregion

// Critical Section - thread-lerin muraciet ede bileceyi
// ortaq resurs
// 
#region Critical Section
//Thread[] threads = new Thread[5];

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i] = new(() =>
//    {
//        for (int j = 0; j < 1000000; j++)
//        {
//            Counter.Count++; //  Counter.Count =  Counter.Count + 1;
//        }
//    });
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Start();
//}
//Console.WriteLine(Counter.Count);

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Join();
//}

//Console.WriteLine(Counter.Count);
#endregion


#region Interlocked
//Thread[] threads = new Thread[5];

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i] = new(() =>
//    {
//        for (int j = 0; j < 1000000; j++)
//        {
//            Interlocked.Increment(ref Counter.Count); //  Counter.Count =  Counter.Count + 1;
//            if (Counter.Count % 2 != 0)
//            {
//                Interlocked.Increment(ref Counter.CountOdd);
//            }
//        }
//    });
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Start();
//}
////Console.WriteLine(Counter.Count);

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Join();
//}

//Console.WriteLine(Counter.Count);
//Console.WriteLine(Counter.CountOdd);
#endregion


#region Monitor
//Thread[] threads = new Thread[5];
//object l = new object();
//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i] = new(() =>
//    {
//        for (int j = 0; j < 1000000; j++)
//        {
//            Monitor.Enter(l);
//            try
//            {
//                Counter.Count++;
//                if (Counter.Count % 2 != 0) Counter.CountOdd++;

//            }
//            finally
//            {
//                Monitor.Exit(l);
//            }

//        }

//    });
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Start();
//}


//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Join();
//}

//Console.WriteLine(Counter.Count);
//Console.WriteLine(Counter.CountOdd);
#endregion

#region lock
//Thread[] threads = new Thread[5];
//object l = new object();
//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i] = new(() =>
//    {
//        for (int j = 0; j < 1000000; j++)
//        {
//            lock (l)
//            {
//                Counter.Count++;
//                if (Counter.Count % 2 != 0) Counter.CountOdd++;
//            }


//        }

//    });
//}

//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Start();
//}


//for (int i = 0; i < threads.Length; i++)
//{
//    threads[i].Join();
//}

//Console.WriteLine(Counter.Count);
//Console.WriteLine(Counter.CountOdd);
#endregion

object l1 = new();
object l2 = new();
Thread thread1 = new(ObliviousMethod);
Thread thread2 = new(BlindMethod);
thread1.Start();
thread2.Start();

void ObliviousMethod()
{
    Console.WriteLine("ObliviousMethod start...");
    lock (l1)
    {
        Thread.Sleep(1000);
        lock (l2)
        {

        }
    }

    Console.WriteLine("ObliviousMethod send...");
}

void BlindMethod()
{
    Console.WriteLine("BlindMethod start...");

    lock (l2)
    {
        Thread.Sleep(1000);
        lock (l1)
        {

        }
    }

    Console.WriteLine("BlindMethod send...");
}

class Counter
{
    public static int Count = 0;
    public static int CountOdd = 0;

}
