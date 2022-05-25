using System;

namespace AnimalsDemo.Abilities
{
    public class Run : Ability
    {
        public void Start()
        {
            Console.WriteLine("Animal says: Now I'm running.");
        }

        public override void Accept(AbilityVisitor visitor)
        {
            base.Accept(visitor);
            visitor.Visit(this);
        }
    }
}