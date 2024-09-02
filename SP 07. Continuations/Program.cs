// Continuations

#region Single Wait
//var firstTask = new Task<int>(()=> TaskMethod("FirstTask", 3));
//firstTask.Start();

//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"Main thread - {i}");
//    Thread.Sleep(1000);
//}

//firstTask.Wait();

//Console.WriteLine("End of code");
#endregion

#region Wait All
//var firstTask = new Task<int>(() => TaskMethod("FirstTask", 3));
//var secondTask = new Task<int>(() => TaskMethod("SecondTask", 3));
//firstTask.Start();
//secondTask.Start();

//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"Main thread - {i}");
//    Thread.Sleep(100);
//}

//Task.WaitAll(firstTask, secondTask);

//Console.WriteLine("End of code");
#endregion

#region Wait Any
//var firstTask = new Task<int>(() => TaskMethod("FirstTask", 3));
//var secondTask = new Task<int>(() => TaskMethod("SecondTask", 7));
//firstTask.Start();
//secondTask.Start();

//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"Main thread - {i}");
//    Thread.Sleep(100);
//}

//Task.WaitAny(firstTask, secondTask);

//Console.WriteLine("End of code");
#endregion

#region ContinueWith OnlyRanToCompletation
//var firstTask = new Task<int>(() => TaskMethod("FirstTask", 3));
//var secondTask = new Task<int>(() => TaskMethod("SecondTask", 5));

//firstTask.ContinueWith((t) =>
//{
//    Console.WriteLine($@"Task Result = {t.Result} . Id = {Thread.CurrentThread.ManagedThreadId} IsThreadPool = {Thread.CurrentThread.IsThreadPoolThread} IsBackground = {Thread.CurrentThread.IsBackground}");
//}, TaskContinuationOptions.OnlyOnRanToCompletion);
// secondTask.ContinueWith((t) =>
//{
//    OtherMethod();
//}, TaskContinuationOptions.NotOnCanceled | TaskContinuationOptions.NotOnFaulted);
//firstTask.Start();
//secondTask.Start();

//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"Main thread - {i}");
//}
//Task.WaitAll(firstTask, secondTask);
//Console.WriteLine("End of program");

//Console.ReadKey();

#endregion

#region ContinueWith OnlyOnFaulted
//try
//{
//    var firstTask = new Task<int>(() => TaskMethod("FirstTask", 3));

//    firstTask.ContinueWith((t) =>
//    {
//        OtherMethod();
//    }, TaskContinuationOptions.OnlyOnFaulted);

//    firstTask.Start();


//    for (int i = 0; i < 10; i++)
//    {
//        Console.WriteLine($"Main thread - {i}");
//    }
//    firstTask.Wait();
//    Console.WriteLine("End of program");
//    Console.ReadKey();

//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}
#endregion

#region ContinueWith with Thread
//var firstTask = new Task<int>(() => TaskMethod("FirstTask", 3));


//firstTask.ContinueWith((t) =>
//{
//    Console.WriteLine($@"Task Result = {t.Result} . Id = {Thread.CurrentThread.ManagedThreadId} IsThreadPool = {Thread.CurrentThread.IsThreadPoolThread} IsBackground = {Thread.CurrentThread.IsBackground}");
//}, TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.LongRunning);

//firstTask.Start();


//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"Main thread - {i}");
//}
//firstTask.Wait();
//Console.WriteLine("End of program");

//Console.ReadKey();
#endregion

#region ContinueWith ExecuteSynchronously
//var firstTask = new Task<int>(() => TaskMethod("FirstTask", 3));


//firstTask.ContinueWith((t) =>
//{
//    Console.WriteLine($@"Task Result = {t.Result} . Id = {Thread.CurrentThread.ManagedThreadId} IsThreadPool = {Thread.CurrentThread.IsThreadPoolThread} IsBackground = {Thread.CurrentThread.IsBackground}");
//}, TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.ExecuteSynchronously);

//firstTask.Start();


//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"Main thread - {i}");
//}
//firstTask.Wait();
//Console.WriteLine("End of program");

//Console.ReadKey();
#endregion

#region Task.Status
//  Created
//  WaitingForActivation
//  WaitingToRun
//  Running
//  WaitingForChildrenToComplete
//  RanToCompletion
//  Canceled
//  Faulted

//var firstTask = new Task<int>(() => TaskMethod("FirstTask", 3));

//try
//{
//    Console.WriteLine(firstTask.Status);
//    firstTask.Start();
//    while (true)
//    {
//        Console.WriteLine(firstTask.Status);
//        Thread.Sleep(100);
//        if (firstTask.IsCompleted) break;

//    }
//    firstTask.Wait();
//    Console.WriteLine(firstTask.Status); 
//}
//catch (Exception)
//{
//    Console.WriteLine(firstTask.Status);
//}
#endregion

#region Continuation
//var firstTask = new Task<int>(() => TaskMethod("FirstTask", 3));

//try
//{
//    firstTask.Start();

//    while (true)
//    {
//        if (firstTask.Status == TaskStatus.RanToCompletion)
//        {
//            Task.Run(() =>
//            {
//                Console.WriteLine($@"Task Result = {firstTask.Result} . Id = {Thread.CurrentThread.ManagedThreadId} IsThreadPool = {Thread.CurrentThread.IsThreadPoolThread} IsBackground = {Thread.CurrentThread.IsBackground}");
//            });
//            break;
//        }
//        else if (firstTask.IsFaulted)
//        {
//            Task.Run(OtherMethod);
//            break;
//        }

//    }
//    firstTask.Wait();

//}
//catch (Exception)
//{

//}
#endregion

var firstTask = new Task<int>(() => TaskMethod("FirstTask", 3));
var secondTask = new Task<int>(() => TaskMethod("SecondTask", 3));


int TaskMethod(string message, int second)
{
    Console.WriteLine($@"Task - {message} is running. Id = {Thread.CurrentThread.ManagedThreadId} IsThreadPool = {Thread.CurrentThread.IsThreadPoolThread} IsBackground = {Thread.CurrentThread.IsBackground}");
    Thread.Sleep(second * 1000);
    throw new Exception("Dunya daqiler ay qaaa!!!");
    Console.WriteLine($@"Task - {message} is end");
    return second * 10;
}

void OtherMethod()
{
    Console.WriteLine("Other Method is running");
    Console.WriteLine($@"Id = {Thread.CurrentThread.ManagedThreadId} IsThreadPool = {Thread.CurrentThread.IsThreadPoolThread} IsBackground = {Thread.CurrentThread.IsBackground}");
    Console.WriteLine("Other Method End");

}