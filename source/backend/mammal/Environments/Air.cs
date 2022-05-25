namespace AnimalsDemo.Environments
{
    public class Air : Environment
    {
        public override void Accept(EnvironmentVisitor visitor) =>
            visitor.Visit(this);
    }
}