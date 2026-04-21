using UnityEngine;

public class ModelUpgradeHandler : MonoBehaviour
{
    [SerializeField] private ModelChanger _modelChanger;
    [SerializeField] private Attribute _attribute;

    private void OnEnable()
    {
        _attribute.Upgraded += TryChangeModel;
    }

    private void OnDisable()
    {
        _attribute.Upgraded -= TryChangeModel;
    }

    private void TryChangeModel()
    {
        _modelChanger.UpgradeByLevel(_attribute.Level);
    }
}