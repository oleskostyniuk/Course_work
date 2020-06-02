using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace labGeneticAlg.Animal
{
    public static class AnimalTask
    {
        public static myAnimal CreateAnimal(string name, int rang, int id, List<int> copobility)
        {
            var animal = new myAnimal() { Copobility = copobility, Name = name, Rang = rang, Id = id };
            return animal;
        }

        public static bool CheckBoat(List<myAnimal> animals)
        {
            foreach (var item in animals)
            {
                if (animals.Where(x => x.Copobility[item.Id] == 0 && x.Id != item.Id).Count() != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
