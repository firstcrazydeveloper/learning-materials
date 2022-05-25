namespace AnimalsDemo.Environments
{
    public abstract class Environment
    {
        public abstract void Accept(EnvironmentVisitor visitor);
    }
}
