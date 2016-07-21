using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MemoryEater
{
    public class Limit
    {
        int limit;

        public Limit(int memory)
        {
            limit = memory;
        }

        public bool IsLimit()
        {
            if (limit < GC.GetTotalMemory(false))
                return true;
            return false;
        }

        public void Error(object mes)
        {
            if (IsLimit())
                Console.WriteLine("{0}", mes);
        }
    }

    public class MemoryEater
    {
        int[] array = new int[1000000];

        public void Method(int i)
        {
            Console.WriteLine(i);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MemoryEater[] mas = new MemoryEater[1000];
            var timer = new Timer(new Limit(1000).Error, "Lost memory", 0, 200);

            // var thread = new Thread(new Limit().Error("Error"));
            for (int i = 0; i < mas.Length; i++)
            {
                new MemoryEater().Method(i);
            }

            Console.ReadKey();
        }
    }
}
