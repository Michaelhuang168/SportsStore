using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vic.SportsStore.Domain.Concrete;
using Vic.SportsStore.Domain.Entities;

namespace Vic.SportsStore.DebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new EFDbContext())
            {
                ctx.Products.RemoveRange(ctx.Products);
                ctx.SaveChanges();

                for(int i=0; i<80; i++)
                {
                    var product = new Product() { Name = $"product{i}", Category = "aa" };
                    ctx.Products.Add(product);
                    ctx.SaveChanges();
                }
                
            }

            Console.WriteLine("done!");
            Console.ReadLine();
        }
    }
}
