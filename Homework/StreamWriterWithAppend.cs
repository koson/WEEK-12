using System;
using System.IO; // for StreamWriter
class Program
{
    static void Main(string[] args)
    {
        StreamWriter w = new StreamWriter("hello.txt", true);
        w.WriteLine("Hello World!");
        w.Close();
    }
}
