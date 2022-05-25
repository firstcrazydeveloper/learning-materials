namespace AnimalsDemo.Abilities
{
    public class FullFlight : Fly
    {
        public override void Accept(AbilityVisitor visitor)
        {
            base.Accept(visitor);
            visitor.Visit(this);
        }
    }
}