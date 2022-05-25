using System;
using AnimalsDemo.Classifications;

namespace AnimalsDemo.Visitors
{
    public class LoveMammals : ClassificationVisitor
    {
        private Animal Target { get; }

        public LoveMammals(Animal target)
        {
            this.Target = target;
        }

        public override void Visit(Mammal mammal)
        {
            Console.WriteLine($"Hello {this.Target.Name}");
        }

        public void SayHello() =>
            this.Target.Accept(this);
    }
}
