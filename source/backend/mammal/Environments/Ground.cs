namespace AnimalsDemo.Environments
{
    public class Ground : Environment
    {
        public override void Accept(EnvironmentVisitor visitor) =>
            visitor.Visit(this);
    }
}