namespace AnimalsDemo.Classifications
{
    public class Mammal : Classification
    {
        public override void Accept(ClassificationVisitor visitor)
        {
            base.Accept(visitor);
            visitor.Visit(this);
        }
    }
}