using UnityEngine;

public class UpgradeButtonHandler : MonoBehaviour
{
    [SerializeField] private UpgradeButton _button;
    [SerializeField] private Attribute _attribute;
    [SerializeField] private CanvasAttribute _canvas;

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
        _attribute.TryUpgrade();
        _canvas.UpdateExpirience(_attribute.CurrentExpirience);
        _canvas.UpdateLevel(_attribute.Level);
    }
}
