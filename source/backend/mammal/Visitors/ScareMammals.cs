using AnimalsDemo.Classifications;

namespace AnimalsDemo.Visitors
{
    public class ScareMammals : ClassificationVisitor
    {
        private Animal Target { get; }

        public ScareMammals(Animal target)
        {
            this.Target = target;
        }

        public override void Visit(Mammal mammal)
        {
            this.Target.Accept(new ScareAnimal(this.Target));
        }

        public void ScareIt() =>
            this.Target.Accept(this);
    }
}
