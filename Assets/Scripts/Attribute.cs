using System;
using UnityEngine;

public class Attribute : MonoBehaviour
{
    [SerializeField] private string _name;

    [SerializeField] private float _upgradeMultiplier = 1.2f;
    [SerializeField] private int _currentExpirience = 0;
    [SerializeField] private int _expiritenceToUpgrade = 100;
    [SerializeField] private int _level;
    [SerializeField] private int _addedValue = 10;

    public string Name => _name;
    public int CurrentExpirience => _currentExpirience;
    public int Level => _level;

    public event Action Upgraded;
    
    private void Awake()
    {
        if (_addedValue <= 0)
            throw new ArgumentException(nameof(_addedValue));

        _level = 0;
    }

    public void TryUpgrade()
    {
        _currentExpirience += _addedValue;

        if (_currentExpirience >= _expiritenceToUpgrade)
        {
            int difference = _currentExpirience - _expiritenceToUpgrade;

            _expiritenceToUpgrade = (int)(_expiritenceToUpgrade * _upgradeMultiplier);
            _currentExpirience = difference;
            _level++;

            Upgraded?.Invoke();
        }
    }
}