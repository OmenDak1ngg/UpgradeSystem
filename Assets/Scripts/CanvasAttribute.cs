using TMPro;
using UnityEngine;
public class CanvasAttribute : MonoBehaviour
{
    [SerializeField] private UserInput _userInput;
    [SerializeField] private Attribute _attribute;

    [SerializeField] private TextMeshProUGUI _TMPAttributeName;
    [SerializeField] private TextMeshProUGUI _TMPCurrentExpirience;
    [SerializeField] private TextMeshProUGUI _TMPCurrentLevel;

    private Canvas _canvas;

    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
        _canvas.enabled = false;
        _TMPAttributeName.text = _attribute.Name;
        UpdateExpirience(_attribute.CurrentExpirience);
        UpdateLevel(_attribute.Level);
    }

    private void OnEnable()
    {
        _userInput.ClickedShowUpgrades += ChangeState;
    }

    private void OnDisable()
    {
        _userInput.ClickedShowUpgrades -= ChangeState;
    }

    private void ChangeState()
    {
        if (_canvas.enabled == false)
            _canvas.enabled = true;
        else
            _canvas.enabled = false;
    }

    public void UpdateExpirience(int value)
    {
        _TMPCurrentExpirience.text = value.ToString();
    }

    public void UpdateLevel(int value)
    {
        _TMPCurrentLevel.text = value.ToString();
    }
}