using System;

namespace FunBrainDomain
{
    public interface IRandomGenerator
    {
        int Generate(int maxGenerator);
    }

    public class RandomGenerator: IRandomGenerator
    {
        private const int _maxNo = 100;

        public RandomGenerator()
        {
        }

        public int Generate(int maxGenerator)
        {
//            var rnd = Calculate(_maxNo);
            var random = new Random().Next(0, maxGenerator);
            return random;
        }
    }
}
