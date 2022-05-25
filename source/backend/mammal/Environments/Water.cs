namespace AnimalsDemo.Environments
{
    public class Water : Environment
    {
        public override void Accept(EnvironmentVisitor visitor) =>
            visitor.Visit(this);
    }
}