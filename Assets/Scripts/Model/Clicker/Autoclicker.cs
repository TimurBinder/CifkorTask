using UnityEngine;
using Zenject;

namespace CifkorTask.Model
{
    public class Autoclicker : ITickable
    {
        private Clicker _clicker;
        private float _delay;
        private float _timer;

        public Autoclicker(Clicker clicker, float delay)
        {
            _clicker = clicker;
            _delay = delay;
        }

        public void Tick()
        {
            _timer += Time.deltaTime;

            if (_timer >= _delay)
            {
                _clicker.TryClick();
                _timer = 0;
            }
        }
    }
}
