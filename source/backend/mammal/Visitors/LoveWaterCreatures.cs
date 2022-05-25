using System;
using AnimalsDemo.Environments;

namespace AnimalsDemo.Visitors
{
    public class LoveWaterCreatures : EnvironmentVisitor
    {
        private Animal Target { get; }

        public LoveWaterCreatures(Animal target)
        {
            this.Target = target;
        }

        public override void Visit(Water water) =>
            Console.WriteLine($"Hello {this.Target.Name}");

        public void SayHello() =>
            this.Target.Accept(this);
    }
}
