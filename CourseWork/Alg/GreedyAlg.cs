using labGeneticAlg.Animal;
using System;
using System.Collections.Generic;
using System.Text;

namespace labGeneticAlg.Alg
{
    public class GreedyAlg
    {
        public GreedyAlg(List<myAnimal> animals)
        {
            Animals = animals;
        }

        public List<myAnimal> Animals { get; set; }

        public List<myAnimal> Solve()
        {
            List<myAnimal> boat = new List<myAnimal>();
            var priorityQueue = new PriorityQueue(Animals);

            while (priorityQueue.Animals.Count != 0)
            {
                var animal = priorityQueue.GetMax();
                var newBoat = new List<myAnimal>(boat);
                newBoat.Add(animal);
                if (AnimalTask.CheckBoat(newBoat))
                {
                    boat = newBoat;
                }
            }
            return boat;
        }
    }
}
