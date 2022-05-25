namespace AnimalsDemo.Abilities
{
    public abstract class Ability
    {
        public virtual void Accept(AbilityVisitor visitor) =>
            visitor.Visit(this);
    }
}
