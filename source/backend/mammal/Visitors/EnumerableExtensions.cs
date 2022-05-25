using System;
using System.Collections.Generic;
using AnimalsDemo.Classifications;
using System.Linq;
using AnimalsDemo.Abilities;

namespace AnimalsDemo.Visitors
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<Animal> OfClassification<T>(this IEnumerable<Animal> animals)
            where T : Classification =>
            animals.SelectMany(Filter<T>);

        private static IEnumerable<Animal> Filter<T>(Animal animal) where T: Classification
        {
            ClassificationFilter<T> filter = new ClassificationFilter<T>(animal);
            animal.Accept(filter);
            return filter.Filtered;
        }

        public static void UseAbility<T>(this IEnumerable<Animal> animals, Action<Animal, T> action)
            where T : Ability
        {
            foreach (Animal animal in animals)
            {
                AbilityFilter<T> filter = new AbilityFilter<T>(animal);
                animal.Accept(filter);

                foreach (Tuple<Animal, T> ability in filter.FilteredAbilities)
                    action(ability.Item1, ability.Item2);

            }
        }
    }
}
