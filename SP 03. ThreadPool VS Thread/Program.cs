using System.Diagnostics;

//int operationCount = 500;
//var watch = new Stopwatch();

//watch.Start();
//UseThread(operationCount);
//watch.Stop();
//Console.WriteLine($"Milliseconds: {watch.ElapsedMilliseconds}");
//watch.Reset();


//watch.Start();
//UseThreadPool(operationCount);
//watch.Stop();
//Console.WriteLine($"Milliseconds: {watch.ElapsedMilliseconds}");
//void UseThread(int operationCount)
//{
//    using (var count = new CountdownEvent(operationCount))
//    {
//        Console.WriteLine("Threads...");
//        for (int i = 0; i < operationCount; i++)
//        {
//            var thread = new Thread(() =>
//            {
//                //Thread.Sleep(10);
//                //Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");
//                count.Signal();
//            });
//            thread.Start();
//        }
//        count.Wait();
//        Console.WriteLine();
//    }
//}

//void UseThreadPool(int operationCount)
//{
//    List<int> threadsIds = new();
//    using (var count = new CountdownEvent(operationCount))
//    {
//        Console.WriteLine("ThreadPool...");
//        for (int i = 0; i < operationCount; i++)
//        {
//            ThreadPool.QueueUserWorkItem(o =>
//            {
//                //Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");
//                Thread.Sleep(1);
//                if (!threadsIds.Contains(Thread.CurrentThread.ManagedThreadId))
//                {
//                    threadsIds.Add(Thread.CurrentThread.ManagedThreadId);
//                }
//                count.Signal();
//            });
//        }
//        count.Wait();
//        Console.WriteLine(threadsIds.Count);
//    }
//}
