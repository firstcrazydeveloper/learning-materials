namespace AnimalsDemo.Classifications
{
    public abstract class ClassificationVisitor
    {
        public virtual void Visit(Classification classification) { }
        public virtual void Visit(Mammal mammal) { }
        public virtual void Visit(Bird bird) { }
        public virtual void Visit(BonyFish fish) { }
        public virtual void Visit(Reptile reptile) { }
        public virtual void Visit(Gastropod gastropod) { }
    }
}
