using System;

namespace CifkorTask.Model
{
    public class Energy : IChangeable
    {
        private int _maxValue;
        private int _value;

        public event Action Changed;

        public Energy(int value, int maxValue)
        {
            _value = value;
            _maxValue = maxValue;
        }

        public int Value => _value;
        public int MaxValue => _maxValue;

        public void Add(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _value += value;

            if (_value > _maxValue)
                _value = _maxValue;

            Changed?.Invoke();
        }

        public bool TryReduce(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            if (_value < value)
                return false;

            _value -= value;
            Changed?.Invoke();
            return true;
        }
    }
}
