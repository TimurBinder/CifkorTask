using UnityEngine;
using Zenject;

namespace CifkorTask.Model
{
    public class EnergyAccumulatable : ITickable
    {
        private Energy _energy;
        private int _value;
        private float _delay;
        private float _timer;

        public EnergyAccumulatable(Energy energy, int value, float delay)
        {
            _energy = energy;
            _value = value;
            _delay = delay;
            _timer = 0f;
        }

        public void Tick()
        {
            _timer += Time.deltaTime;

            if (_timer >= _delay)
            {
                _energy.Add(_value);
                _timer = 0f;
            }
        }
    }
}
