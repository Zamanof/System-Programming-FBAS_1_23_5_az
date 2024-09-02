// 

var grandFatherTask = new Task<int>(() =>
{
    var fatherTask = Task.Factory.StartNew(() =>
    {
        var grandsonTask = Task.Factory.StartNew(() =>
        {
            TaskMethod("Grandson Task", 8);
        }, TaskCreationOptions.AttachedToParent);
        TaskMethod("Father Task", 5);
    }, TaskCreationOptions.AttachedToParent);
    return TaskMethod("Grandfather Task", 3);
});

grandFatherTask.Start();
Console.WriteLine(grandFatherTask.Result);
Console.WriteLine("End");



int TaskMethod(string message, int second)
{
    Console.WriteLine($@"Task - {message} is running. Id = {Thread.CurrentThread.ManagedThreadId} IsThreadPool = {Thread.CurrentThread.IsThreadPoolThread} IsBackground = {Thread.CurrentThread.IsBackground}");
    Thread.Sleep(second * 1000);
    Console.WriteLine($@"Task - {message} is end");
    return second * 10;
}