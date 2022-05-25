using System;
using AnimalsDemo.Abilities;

namespace AnimalsDemo.Visitors
{
    public class ScareAnimal : AbilityVisitor
    {
        private Animal Target { get; }

        public ScareAnimal(Animal target)
        {
            this.Target = target;
        }

        public override void Visit(Run run)
        {
            Console.WriteLine($"Scaring {this.Target.Name}");
            run.Start();
        }
    }
}
