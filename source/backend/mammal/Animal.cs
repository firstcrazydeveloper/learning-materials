using System.Collections.Generic;
using AnimalsDemo.Abilities;
using AnimalsDemo.Classifications;
using AnimalsDemo.Environments;

namespace AnimalsDemo
{
    public class Animal
    {
        public string Name { get; private set; }

        private Classification Classification { get; }
        private IList<Environment> Environments { get; }
        private IList<Ability> Abilities { get; } = new List<Ability>();

        public Animal(string name, Classification classification, 
                      Environment primaryEnvironment)
        {
            this.Name = name;
            this.Classification = classification;
            this.Environments = new List<Environment>() {primaryEnvironment};
        }

        public void Add(Environment environment)
        {
            this.Environments.Add(environment);
        }

        public void Add(Ability ability)
        {
            this.Abilities.Add(ability);
        }

        public void Accept(ClassificationVisitor visitor) =>
            this.Classification.Accept(visitor);

        public void Accept(EnvironmentVisitor visitor)
        {
            foreach (Environment environ in this.Environments)
                environ.Accept(visitor);
        }

        public void Accept(AbilityVisitor visitor)
        {
            foreach (Ability ability in this.Abilities)
                ability.Accept(visitor);
        }
    }
}
