using System;
using System.IO;
using System.Linq;
using AnimalsDemo.Abilities;
using AnimalsDemo.Classifications;
using AnimalsDemo.Visitors;

namespace AnimalsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task 1: Say hello to all mammals
            Console.WriteLine("SAYING HELLO TO FELLOW MAMMALS");
            foreach (Animal animal in Animals.All)
                new LoveMammals(animal).SayHello();
            Console.WriteLine();
            #endregion

            #region Task 2: Say hello to everyone under water
            //Console.WriteLine("SAYING HELLO TO ALL WATER DWELLERS");
            //foreach (Animal animal in Animals.All)
            //    new LoveWaterCreatures(animal).SayHello();
            //Console.WriteLine();
            #endregion

            #region Task 3: Take picture of all flying animals
            //Console.WriteLine("TAKING PICTURES OF FLYING ANIMALS");
            //foreach (Animal animal in Animals.All)
            //    new PictureFlyingCreatures(animal).TakePicture();
            //Console.WriteLine();
            #endregion

            #region Task 4: Tell all mammals to run
            //Console.WriteLine("SCARING AWAY ALL MAMMALS");
            //foreach (Animal animal in Animals.All)
            //    new ScareMammals(animal).ScareIt();
            //Console.WriteLine();
            #endregion

            #region Task 5: Print out all mammals (revisited)
            //string[] mammalNames = Animals.All
            //    .OfClassification<Mammal>()
            //    .Select(animal => animal.Name).ToArray();

            //Console.WriteLine("Mammals: {0}", string.Join(", ", mammalNames));
            //Console.WriteLine();
            #endregion

            #region Task 6: Tell all mammals to run (revisited)
            Animals.All
                .OfClassification<Mammal>()
                .UseAbility<Run>((animal, run) =>
                {
                    Console.WriteLine($"Scaring away {animal.Name}");
                    run.Start();
                });
            #endregion


            Console.ReadLine();
        }
    }
}
