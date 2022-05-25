namespace AnimalsDemo.Environments
{
    public class SaltWater : Water
    {
        public override void Accept(EnvironmentVisitor visitor)
        {
            visitor.Visit((Water)this);
            visitor.Visit(this);
        }
    }
}