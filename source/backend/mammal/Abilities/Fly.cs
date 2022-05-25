namespace AnimalsDemo.Abilities
{
    public class Fly : Ability
    {
        public override void Accept(AbilityVisitor visitor)
        {
            base.Accept(visitor);
            visitor.Visit(this);
        }
    }
}