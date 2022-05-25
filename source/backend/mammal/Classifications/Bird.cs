namespace AnimalsDemo.Classifications
{
    public class Bird : Classification
    {
        public override void Accept(ClassificationVisitor visitor)
        {
            base.Accept(visitor);
            visitor.Visit(this);
        }
    }
}