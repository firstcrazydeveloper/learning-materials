namespace AnimalsDemo.Abilities
{
    public abstract class AbilityVisitor
    {
        public virtual void Visit(Ability ability) { }
        public virtual void Visit(Dive dive) { }
        public virtual void Visit(Fly fly) { }
        public virtual void Visit(FullFlight fly) { }
        public virtual void Visit(Glide glide) { }
        public virtual void Visit(Run run) { }
        public virtual void Visit(Surface surface) { }
        public virtual void Visit(Swim swim) { }
        public virtual void Visit(Underwater underwater) { }
        public virtual void Visit(Walk walk) { }
    }
}
