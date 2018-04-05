using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AtsWebsite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //using (var db = new BloggingContext())
            //{
            //    // Create and save a new Blog 
            //    Console.Write("Enter a name for a new Blog: ");
            //    var name = Console.ReadLine();

            //    var blog = new Blog { Name = name };
            //    db.Blogs.Add(blog);
            //    db.SaveChanges();

            //    // Display all Blogs from the database 
            //    var query = from b in db.Blogs
            //                orderby b.Name
            //                select b;

            //    Console.WriteLine("All blogs in the database:");
            //    foreach (var item in query)
            //    {
            //        Console.WriteLine(item.Name);
            //    }

            //    Console.WriteLine("Press any key to exit...");
            //    Console.ReadKey();
            //}


            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
