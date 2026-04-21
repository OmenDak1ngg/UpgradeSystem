using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour, IUpgradable
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedUpgradeValue = 0.5f;

    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void Move(Vector3 direction)
    {
        _characterController.Move(direction * _speed * Time.deltaTime);
    }

    public void UpgradeByLevel(int level)
    {
        if(level <= 0)
            throw new ArgumentException(nameof(level));

        _speed = level * _speedUpgradeValue;
    }
}