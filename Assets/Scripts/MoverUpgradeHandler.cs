using UnityEngine;

public class MoverUpgradeHandler : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private Attribute _attribute;

    private void OnEnable()
    {
        _attribute.Upgraded += UpdateSpeed;
    }

    private void OnDisable()
    {
        _attribute.Upgraded -= UpdateSpeed;
    }

    private void UpdateSpeed()
    {
        _mover.UpgradeByLevel(_attribute.Level);
    }
}
