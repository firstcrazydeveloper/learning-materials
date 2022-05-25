namespace AnimalsDemo.Environments
{
    public abstract class EnvironmentVisitor
    {
        public virtual void Visit(Air air) { }
        public virtual void Visit(FreshWater freshWater) { }
        public virtual void Visit(Ground ground) { }
        public virtual void Visit(SaltWater saltWater) { }
        public virtual void Visit(Water water) { }
    }
}
