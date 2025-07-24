using System;

namespace CifkorTask.Model
{
    public class Clicker
    {
        private Score _currency;
        private Energy _energy;
        private int _reward;
        private int _amountEnergy;

        public event Action Clicked;

        public Clicker(
            Score currency, 
            Energy energy, 
            int reward, 
            int amountEnergy
            )
        {
            _currency = currency;
            _energy = energy;
            _reward = reward;
            _amountEnergy = amountEnergy;
        }

        public bool TryClick()
        {
            if (_energy.TryReduce(_amountEnergy) == false)
                return false;

            _currency.Add(_reward);
            Clicked?.Invoke();
            return true;
        }
    }
}
