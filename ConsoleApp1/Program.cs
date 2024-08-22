//Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
Thread thread1 = new Thread(() => {
    for (int i = 0; i < 1000; i++)
    {
        Console.WriteLine($"\tMy Own Thread - Id:({Thread.CurrentThread.ManagedThreadId}) - {i} - IsBackground: {Thread.CurrentThread.IsBackground}");
    }
});
Thread thread2 = new Thread(Some);
//thread1.IsBackground = true;
//thread1.Priority = ThreadPriority.Highest;
//thread2.Priority = ThreadPriority.Lowest;
thread1.Start();
thread2.Start();


for (int i = 0; i < 1000; i++)
{
    Console.WriteLine($"Main Thread - Id:({Thread.CurrentThread.ManagedThreadId} - IsBackground: {Thread.CurrentThread.IsBackground}) - {i}");
}
//thread1.Join();


void Some()
{
    for (int i = 0; i < 1000; i++)
    {
        Console.WriteLine($"\t\tMy Some Thread - Id:({Thread.CurrentThread.ManagedThreadId} - IsBackground: {Thread.CurrentThread.IsBackground}) - {i}");
    }
}



