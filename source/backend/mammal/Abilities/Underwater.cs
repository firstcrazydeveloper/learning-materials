namespace AnimalsDemo.Abilities
{
    public class Underwater : Swim
    {
        public override void Accept(AbilityVisitor visitor)
        {
            base.Accept(visitor);
            visitor.Visit(this);
        }
    }
}