using UnityEngine;

public class UpgradeButtonHandler : MonoBehaviour
{
    [SerializeField] private UpgradeButton _button;
    [SerializeField] private CharacterAttributes _attributes;
    [SerializeField] private AttributeType _attributeType;

    private void OnEnable()
    {
        _button.Clicked += AddValueToSystem;
    }

    private void OnDisable()
    {
        _button.Clicked -= AddValueToSystem;
    }

    private void AddValueToSystem()
    {
        _attributes.AddExperience(_attributeType);
        _attributes.TryUpgrade(_attributeType);
    }
}