// TPL - Task Parallel Library

// Thread -> ThreadPoll -> TPL


Console.WriteLine("Start of Code...");

Task task1 = new Task(() =>
{
    TaskMethod("Task1");
});
Task task2 = new Task(() =>
{
    TaskMethod("Task2");
});

Task task3 = Task.Run(() =>
{
    TaskMethod("Task3");
});

var task4 = Task.Factory.StartNew(() =>
{
    TaskMethod("Task4");
});

Task task5 = new(() =>
{
    TaskMethod("Task5");
},TaskCreationOptions.LongRunning);

task1.Start();
task2.Start();
task5.Start();





Console.ReadKey();
void TaskMethod(string message)
{
    Console.WriteLine($@"Task - {message} is running.
Id = {Thread.CurrentThread.ManagedThreadId}
IsThreadPool = {Thread.CurrentThread.IsThreadPoolThread}
IsBackground = {Thread.CurrentThread.IsBackground}");
}