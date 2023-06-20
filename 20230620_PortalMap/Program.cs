using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230620_PortalMap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("게임 시작");

            Map myMap = new Map();
            myMap.MapBoard();
        }
    }
}
