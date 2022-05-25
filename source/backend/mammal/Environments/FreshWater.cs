namespace AnimalsDemo.Environments
{
    public class FreshWater : Water
    {
        public override void Accept(EnvironmentVisitor visitor)
        {
            visitor.Visit((Water) this);
            visitor.Visit(this);
        }
    }
}