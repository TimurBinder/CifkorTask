using System;

namespace CifkorTask.Model
{
    public class Score : IChangeable
    {
        private int _value;

        public event Action Changed;

        public Score(int value) 
        { 
            _value = value;
        }

        public int Value => _value;

        public void Add(int value) 
        { 
            if (value < 0) 
                throw new ArgumentOutOfRangeException(nameof(value));

            _value += value;
            Changed?.Invoke();
        }
    }
}
