// AutoResetEvent

AutoResetEvent _workEvent = new AutoResetEvent(false);
AutoResetEvent _mainEvent = new AutoResetEvent(false);

// 1. start 
Thread thread = new Thread(() =>
{
    SomeProcess(1);
});
thread.Start();
Console.WriteLine("Waiting SomeProcess");
// 1. End

_workEvent.WaitOne();

// 3. start
Console.WriteLine("Starting Main Process");

for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"Main process - {i}");
    Thread.Sleep(TimeSpan.FromSeconds(1));
}
// 3. end

_mainEvent.Set();


Console.WriteLine("Worker is doing some job");

_workEvent.WaitOne();
// 5. start
Console.WriteLine("Complete");

// 5. end

void SomeProcess(int seconds)
{

    // 2. start
    Console.WriteLine("Starting some process");
    Thread.Sleep(TimeSpan.FromSeconds(seconds));
    Console.WriteLine("Ok");
    // 2. end

    _workEvent.Set();
    
    // 4. start
    Console.WriteLine("Main process is working");
    _mainEvent.WaitOne();
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"Some process - {i}");
        Thread.Sleep(TimeSpan.FromSeconds(seconds));
    }
    Console.WriteLine("Some Process End");
    // 4. end

    _workEvent.Set();
}