using System;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    private readonly KeyCode ShowUpgradesKey = KeyCode.Escape;

    public event Action ClickedShowUpgrades;   

    private void Update()
    {
        if (Input.GetKeyDown(ShowUpgradesKey))
            ClickedShowUpgrades?.Invoke();
    }
}