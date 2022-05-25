using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // A obj1 = new A();
            Console.WriteLine("Start when A=new A()");
            A obj = new A();
            obj.MyData();
            obj.MyDataTest();
            obj.MyDataTestSini();
            Console.WriteLine("End Start when A=new A()");

            Console.WriteLine("Start when A=new B()");
            A objB = new B();
            objB.MyData();
            objB.MyDataTest();
            objB.MyDataTestSini();
            

            Console.WriteLine("End Start when B=new B()");

            Console.WriteLine("Start when A=new B()");
            B objc = new B();
            objc.MyData();
            objc.MyDataTest();
            objc.MyDataTestSini();
            objc.SayHi();

            Console.WriteLine("End Start when A=new A()");
            // B obj2 = new B();
            //B j = new A();

            string[] d = { "s", "s", "s" };
            int f = d.Length;
            string g = "fg";
            int v = 8;
            // test(ref g, ref v);
            //FizzBuzzGame();
            Console.WriteLine("abc".GetType());
            Console.ReadKey();
        }

        public static void test(ref string s, ref int r)
        {
            s = "sd";
            r = 7;

        }

        public static void FizzBuzzGame()
        {
            bool isthreeDivided = true;
            bool isFiveDivided = true;

            int three = 3;
            int five = 5;

            while (isthreeDivided || isFiveDivided)
            {
                if (three <= 100)
                {
                    Console.WriteLine("Fizz");
                    three += 3;
                }
                else
                {
                    isthreeDivided = false;
                }

                if (five <= 100)
                {
                    Console.WriteLine("Buzz");
                    five += 5;
                }
                else
                {
                    isFiveDivided = false;
                }
            }


        }
    }

    public class A
    {
        int d;
        public virtual string Name { get; }
        public A()
        {
            d = 5;
            Console.WriteLine("Calling A Constructor");
            first = "Abhishek";
            last = "Sahil";

        }
        public void Swap(A a)
        {
            a.first = "Sini";
            a.last = "Amit";
        }
        public string first = "";
        public string last = "";

        public void MyDataTest()
        {
            Console.WriteLine("A MyDataTest");
        }

        public virtual void MyData()
        {
            Console.WriteLine("A My data - Virtual");
        }



        public void MyDataTestSini()
        {
            Console.WriteLine("A MyDataTestSini");
        }
    }

    public class B : A
    {
        int g;
        public B()
        {
            g = 10;
            Console.WriteLine("Calling B Constructor");
        }



        public void MyDataTest()
        {
            Console.WriteLine("B MyDataTest");
        }

        public override void MyData()
        {
            Console.WriteLine("B My data - Override");
        }

        public new void MyDataTestSini()
        {
            Console.WriteLine("B MyDataTestSini - New");
        }

        public void SayHi()
        {
            Console.WriteLine("B Say Hi");
        }
    }
}
