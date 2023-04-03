using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

namespace _24_3_Proj
{
    internal class AsyncFile
    {
        async Task<int> a()
        {
            int number = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Executing method(a)");
                    number++;
                }
            });

            Console.WriteLine("In a");
            // await Task.Delay(3000);
            Console.WriteLine("End a");
            return number;
        }

        async Task b()
        {
            Console.WriteLine("In b");
            // await Task.Delay(5000);
            Console.WriteLine("End b");
        }

        async Task c(int number)
        {
            Console.WriteLine("Number from method(A): " + number);
            Console.WriteLine("In c");
            await Task.Delay(5000);
            Console.WriteLine("End c");
        }


        public static async Task Main(string[] args)
        {
            {
                int failed = 0;
                var tasks = new List<Task>();
                String[] urls = { "www.adatum.com", "www.cohovineyard.com",
                        "www.cohowinery.com", "www.northwindtraders.com",
                        "www.contoso.com" };

                foreach (var value in urls)
                {
                    var url = value;
                    tasks.Add(Task.Run(() =>
                    {
                        var png = new Ping();
                        try
                        {
                            var reply = png.Send(url);
                            if (!(reply.Status == IPStatus.Success))
                            {
                                Interlocked.Increment(ref failed);
                                throw new TimeoutException("Unable to reach " + url + ".");
                            }
                        }
                        catch (PingException)
                        {
                            Interlocked.Increment(ref failed);
                            throw;
                        }
                    }));
                }
                Task t = Task.WhenAll(tasks.ToArray());
                try
                {
                    await t;
                }
                catch { }
                Console.WriteLine(t.Status);
                Console.WriteLine(TaskStatus.Faulted);
                Console.WriteLine(TaskStatus.RanToCompletion);
                if (t.Status == TaskStatus.RanToCompletion)
                    Console.WriteLine("All ping attempts succeeded.");
                else if (t.Status == TaskStatus.Faulted)
                    Console.WriteLine("{0} ping attempts failed", failed);
            }

        }
    }
}


