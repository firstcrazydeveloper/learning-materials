namespace AnimalsDemo.Abilities
{
    public class Glide : Fly
    {
        public override void Accept(AbilityVisitor visitor)
        {
            base.Accept(visitor);
            visitor.Visit(this);
        }
    }
}