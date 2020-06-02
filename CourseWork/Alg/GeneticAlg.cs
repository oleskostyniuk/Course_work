using labGeneticAlg.Animal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace labGeneticAlg.Alg
{
    public class GeneticAlg
    {
        public int N { get; set; }

        private List<List<myAnimal>> allSolutions;
        public GeneticAlg(List<myAnimal> animals)
        {
            Animals = animals;
            N = animals.Count;
        }

        public List<myAnimal> Animals { get; set; }

        public List<myAnimal> Solve(int Y, double a, int L)
        {
            List<List<myAnimal>> solutionArray = new List<List<myAnimal>>();

            solutionArray = GetRandSolutions();

            for (int i = 0; i < L; i++)
            {
                var Ybest = GetBest(solutionArray, Y);
                var Ynew = newBest(Ybest, a, Y);
                solutionArray = new List<List<myAnimal>>(Ybest);
                solutionArray.AddRange(Ynew);
            }

            var solutions = solutionArray.OrderByDescending(x => CountScore(x)).ToList();
            return solutions[0];
        }

        public List<List<myAnimal>> GetRandSolutions()
        {
            var solutions = new List<List<myAnimal>>();

            for (int i = 0; i < N; i++)
            {
                var tmp = new List<myAnimal>();
                tmp.Add(Animals[i]);
                solutions.Add(tmp);
            }

            return solutions;
        }

        public int CountScore(List<myAnimal> solution)
        {
            return solution.Select(x => x.Rang).Sum();
        }

        public List<List<myAnimal>> GetBest(List<List<myAnimal>> solutionArray, int Y)
        {
            var solutions = solutionArray.OrderByDescending(x => CountScore(x));
            return solutions.Take(Y).ToList();
        }

        public List<List<myAnimal>> newBest(List<List<myAnimal>> Ybest, double a, int Y)
        {
            var population = Breeding(Ybest, a).OrderByDescending(x => CountScore(x)).ToList();
            return population.Take(Y).ToList();
        }

        public List<List<myAnimal>> Breeding(List<List<myAnimal>> animals, double a)
        {
            Random r = new Random();
            var childs = new List<List<myAnimal>>();
            for (int i = 0; i < animals.Count; i+= 2)
            {
                if (i + 1 < animals.Count)
                {
                    var child = Compound(animals[i], animals[i + 1]);
                    if (a < r.NextDouble())
                    {
                        child = Mutation(child);
                    }
                    if (AnimalTask.CheckBoat(child))
                    {
                        childs.Add(child);
                    }
                }
            }
            return childs;
        }

        private List<myAnimal> Compound(List<myAnimal> father, List<myAnimal> mother)
        {
            var solution = new List<myAnimal>(father);
            foreach (var item in mother)
            {
                if (solution.Where(x => x.Id == item.Id).Count() == 0)
                {
                    solution.Add(item);
                }
            }
            return solution;
        }

        public List<myAnimal> Mutation(List<myAnimal> solution)
        {
            Random r = new Random();
            List<myAnimal> animalNotContained = Animals.Where(x => solution.TrueForAll(y => y.Id != x.Id)).ToList();

            var mutatedSolution = new List<myAnimal>(solution);

            mutatedSolution.Add(animalNotContained[r.Next(0, animalNotContained.Count() - 1)]);
            return mutatedSolution;
        }

    }
}
