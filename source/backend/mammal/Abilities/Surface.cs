namespace AnimalsDemo.Abilities
{
    public class Surface : Swim
    {
        public override void Accept(AbilityVisitor visitor)
        {
            base.Accept(visitor);
            visitor.Visit(this);
        }
    }
}