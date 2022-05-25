using System;
using AnimalsDemo.Abilities;

namespace AnimalsDemo.Visitors
{
    public class PictureFlyingCreatures: AbilityVisitor
    {
        private Animal Target { get; }
        private Animal RecognizedTarget { get; set; }

        public PictureFlyingCreatures(Animal target)
        {
            this.Target = target;
        }

        public override void Visit(Fly fly)
        {
            this.RecognizedTarget = this.Target;
        }

        public void TakePicture()
        {
            this.Target.Accept(this);
            if (this.RecognizedTarget != null)
                Console.WriteLine($"Taking picture of {this.RecognizedTarget.Name}");
        }
    }
}
