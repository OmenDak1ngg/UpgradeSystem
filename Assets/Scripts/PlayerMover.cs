using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour, IUpgradable
{
    [SerializeField] private float _baseSpeed = 5f;
    [SerializeField] private float _speedUpgradeValue = 0.5f;

    private float _speed;
    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _speed = _baseSpeed;
    }

    public void Move(Vector3 direction)
    {
        _characterController.Move(direction * _speed * Time.deltaTime);
    }

    public void UpgradeByLevel(int level)
    {
        if (level < 0)
            return;

        _speed = _baseSpeed + level * _speedUpgradeValue;
    }
}