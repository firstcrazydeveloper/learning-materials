namespace AnimalsDemo.Abilities
{
    public class Walk : Ability
    {
        public override void Accept(AbilityVisitor visitor)
        {
            base.Accept(visitor);
            visitor.Visit(this);
        }
    }
}