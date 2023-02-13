namespace Game.tests
{
    public class AttackCalculatorMock : AttackCalculator
    {
        private readonly int _random;

        public AttackCalculatorMock(int random)
        {
            _random = random;
        }

        protected override int GetRandom()
        {
            return _random;
        }
    }
}