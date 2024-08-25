//ThreadPool.GetAvailableThreads(out int workerCount, out int complCount);
//Console.WriteLine(workerCount);
//Console.WriteLine(complCount);

Console.WriteLine("Main method start...");

ThreadPool.QueueUserWorkItem(AsyncOperations, "Salam Aleykum");
ThreadPool.QueueUserWorkItem(o => SomeOperations());


Console.WriteLine($"Main method thread id: {Thread.CurrentThread.ManagedThreadId}");
Console.WriteLine($"Main method thread isBackground: {Thread.CurrentThread.IsBackground}");
Console.WriteLine($"Main method thread isThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");

Console.ReadKey();
Console.WriteLine("Main method End...");


void AsyncOperations(object state)
{
    Console.WriteLine("\tAsyncOperations method start...");
    //Thread.Sleep(1000);
    Console.WriteLine($"\tState: {state}");
    Console.WriteLine($"\tAsyncOperations thread id: {Thread.CurrentThread.ManagedThreadId}");
    Console.WriteLine($"\tAsyncOperations thread isBackground: {Thread.CurrentThread.IsBackground}");
    Console.WriteLine($"\tAsyncOperations thread isThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");
    Console.WriteLine("\tAsyncOperations method end...");
}


void SomeOperations()
{
    Console.WriteLine("\tSomeOperations method start...");
    //Thread.Sleep(1000);
    Console.WriteLine($"\tSomeOperations thread id: {Thread.CurrentThread.ManagedThreadId}");
    Console.WriteLine($"\tSomeOperations thread isBackground: {Thread.CurrentThread.IsBackground}");
    Console.WriteLine($"\tSomeOperations thread isThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");
    Console.WriteLine("\tSomeOperations method end...");
}
