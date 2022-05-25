namespace AnimalsDemo.Classifications
{
    public abstract class Classification
    {
        public virtual void Accept(ClassificationVisitor visitor) =>
            visitor.Visit(this);
    }
}
