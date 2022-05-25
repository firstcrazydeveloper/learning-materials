namespace AnimalsDemo.Abilities
{
    public class Dive : Swim
    {
        public override void Accept(AbilityVisitor visitor)
        {
            base.Accept(visitor);
            visitor.Visit(this);
        }

    }
}