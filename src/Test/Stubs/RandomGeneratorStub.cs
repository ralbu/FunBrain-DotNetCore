using FunBrainDomain;

namespace Test
{
    internal class RandomGeneratorStub : IRandomGenerator
    {
        private readonly int _randomNumber;

        public RandomGeneratorStub(int randomNumber)
        {
            _randomNumber = randomNumber;
        }

        public int Generate()
        {
            return _randomNumber;
        }
    }
}