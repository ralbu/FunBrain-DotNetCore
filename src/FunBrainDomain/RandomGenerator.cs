using System;

namespace FunBrainDomain
{
    public interface IRandomGenerator
    {
        int Generate(int maxGenerator);
    }

    public class RandomGenerator: IRandomGenerator
    {
        public int Generate(int maxGenerator)
        {
            var random = new Random().Next(0, maxGenerator);
            return random;
        }
    }
}
