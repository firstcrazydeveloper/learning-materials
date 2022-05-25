namespace AnimalsDemo.Abilities
{
    public class Swim : Ability
    {
        public override void Accept(AbilityVisitor visitor)
        {
            base.Accept(visitor);
            visitor.Visit(this);
        }
    }
}