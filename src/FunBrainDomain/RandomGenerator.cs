using System;

namespace FunBrainDomain
{
    public interface IRandomGenerator
    {
        int Generate();
    }

    public class RandomGenerator: IRandomGenerator
    {
        public int Generate()
        {
            var random = new Random().Next(0, 100);
            return random;
        }
    }
}
