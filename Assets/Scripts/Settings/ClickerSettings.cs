using UnityEngine;

[CreateAssetMenu(fileName = "ClickerSettings", menuName = "Settings/Clicker")]
public class ClickerSettings : ScriptableObject
{
    [field: Header("Click Settings")]
    [field: SerializeField] public int StartScore { get; private set; }
    [field: SerializeField] public int Reward { get; private set; }
    [field: SerializeField] public float AutoclickDelay { get; private set; }

    [field: Header("Energy Settings")]
    [field: SerializeField] public int MaxEnergy { get; private set; }
    [field: SerializeField] public int ExpendableEnergy { get; private set; }
    [field: SerializeField] public int AccumulatableEnergy { get; private set; }
    [field: SerializeField] public float AccumulateEnergyDelay { get; private set; }
}
