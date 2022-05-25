using System.Collections.Generic;
using AnimalsDemo.Abilities;
using AnimalsDemo.Classifications;
using AnimalsDemo.Environments;

namespace AnimalsDemo
{
    public static class Animals
    {
        public static Animal Cow
        {
            get
            {
                Animal cow = new Animal("Cow", new Mammal(), new Ground());
                cow.Add(new Walk());
                cow.Add(new Run());
                return cow;
            }
        }

        public static Animal Horse
        {
            get
            {
                Animal horse = new Animal("Horse", new Mammal(), new Ground());
                horse.Add(new Walk());
                horse.Add(new Run());
                return horse;
            }
        }

        public static Animal Emu
        {
            get
            {
                Animal emu = new Animal("Emu", new Bird(), new Ground());
                emu.Add(new Walk());
                emu.Add(new Run());
                return emu;
            }
        }

        public static Animal Ostrich
        {
            get
            {
                Animal ostrich = new Animal("Ostrich", new Bird(), new Ground());
                ostrich.Add(new Walk());
                ostrich.Add(new Run());
                return ostrich;
            }
        }

        public static Animal Lizard
        {
            get
            {
                Animal lizard = new Animal("Lizard", new Reptile(), new Ground());
                lizard.Add(new Walk());
                lizard.Add(new Run());
                return lizard;
            }
        }

        public static Animal Snail
        {
            get
            {
                Animal snail = new Animal("Snail", new Gastropod(), new Ground());
                snail.Add(new Walk());
                return snail;
            }
        }

        public static Animal Whale
        {
            get
            {
                Animal whale = new Animal("Whale", new Mammal(), new SaltWater());
                whale.Add(new Surface());
                whale.Add(new Dive());
                whale.Add(new Underwater());
                return whale;
            }
        }

        public static Animal Dolphin
        {
            get
            {
                Animal dolphin = new Animal("Dolphin", new Mammal(), new SaltWater());
                dolphin.Add(new Surface());
                dolphin.Add(new Dive());
                dolphin.Add(new Underwater());
                return dolphin;
            }
        }

        public static Animal FlyingFish
        {
            get
            {
                Animal flyingFish = new Animal("Flying fish", new BonyFish(), new SaltWater());
                flyingFish.Add(new Underwater());
                flyingFish.Add(new Glide());
                return flyingFish;
            }
        }

        public static Animal Catfish
        {
            get
            {
                Animal catfish = new Animal("Catfish", new BonyFish(), new FreshWater());
                catfish.Add(new Underwater());
                return catfish;
            }
        }

        public static Animal Salmon
        {
            get
            {
                Animal salmon = new Animal("Salmon", new BonyFish(), new SaltWater());
                salmon.Add(new FreshWater());
                salmon.Add(new Underwater());
                return salmon;
            }
        }

        public static Animal Parrot
        {
            get
            {
                Animal parrot = new Animal("Parrot", new Bird(), new Ground());
                parrot.Add(new Air());
                parrot.Add(new Fly());
                parrot.Add(new Walk());
                return parrot;
            }
        }

        public static Animal Eagle
        {
            get
            {
                Animal eagle = new Animal("Eagle", new Bird(), new Ground());
                eagle.Add(new Air());
                eagle.Add(new Fly());
                return eagle;
            }
        }

        public static Animal FlyingSquirrel
        {
            get
            {
                Animal flyingSquirrel = new Animal("Flying squirrel", new Mammal(), new Ground());
                flyingSquirrel.Add(new Glide());
                flyingSquirrel.Add(new Walk());
                flyingSquirrel.Add(new Run());
                return flyingSquirrel;
            }
        }

        public static Animal Bat
        {
            get
            {
                Animal bat = new Animal("Bat", new Mammal(), new Ground());
                bat.Add(new Air());
                bat.Add(new Fly());
                return bat;
            }
        }

        public static IEnumerable<Animal> All =>
            new[]
            {
                Cow, Horse, Emu, Ostrich, Lizard, Snail, Whale, Dolphin,
                FlyingFish, Catfish, Salmon, Parrot, Eagle, FlyingSquirrel, Bat
            };
    }
}
