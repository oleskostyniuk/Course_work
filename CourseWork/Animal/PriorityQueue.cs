using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace labGeneticAlg.Animal
{
    public class PriorityQueue
    {
        public PriorityQueue(List<myAnimal> animals)
        {
            Animals = new List<myAnimal>(animals);
        }

        public List<myAnimal> Animals { get; set; }

        public myAnimal GetMax()
        {
            var maxRang = Animals.Max(x => x.Rang);
            var animal = Animals.Where(x => x.Rang == maxRang).FirstOrDefault();
            if (animal == null)
            {
                throw new Exception("Fail");
            }
            Animals.Remove(animal);
            return animal;
        }
    }
}
