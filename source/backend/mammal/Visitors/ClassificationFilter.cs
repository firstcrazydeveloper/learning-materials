using System.Collections.Generic;
using System.Linq;
using AnimalsDemo.Classifications;

namespace AnimalsDemo.Visitors
{
    public class ClassificationFilter<T> : ClassificationVisitor where T : Classification
    {
        private Animal Target { get; }
        public IEnumerable<Animal> Filtered { get; private set; } = 
            Enumerable.Empty<Animal>();

        public ClassificationFilter(Animal target)
        {
            this.Target = target;
        }

        public override void Visit(Classification classification)
        {
            if (classification.GetType() == typeof(T))
                this.Filtered = new[] {this.Target};
        }
    }
}
