namespace AnimalsDemo.Classifications
{
    public class Gastropod : Classification
    {
        public override void Accept(ClassificationVisitor visitor)
        {
            base.Accept(visitor);
            visitor.Visit(this);
        }
    }
}