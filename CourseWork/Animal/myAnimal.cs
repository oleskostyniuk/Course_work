using System;
using System.Collections.Generic;
using System.Text;

namespace labGeneticAlg.Animal
{
    [Serializable]
    public class myAnimal
    {
        public int Rang { get ; set ; }
        public string Name { get ; set ; }
        public List<int> Copobility { get; set; }
        public int Id { get; set; }

    }
}
