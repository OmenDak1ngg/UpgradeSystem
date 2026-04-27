using UnityEngine;

public class ModelChanger : MonoBehaviour, IUpgradable
{
    [SerializeField] private Model[] _models;

    private Model _currentModel;

    private void Awake()
    {
        if (_models == null || _models.Length == 0)
        {
            Debug.LogError("ModelChanger: models array is empty", this);
            enabled = false;
            return;
        }

        _currentModel = _models[0];
    }

    public void UpgradeByLevel(int level)
    {
        Model matchingModel = null;
        int maxModelLevel = -1;

        foreach (var model in _models)
        {
            if (model.Level <= level && model.Level > maxModelLevel)
            {
                maxModelLevel = model.Level;
                matchingModel = model;
            }
        }

        if (matchingModel == null)
            return;

        _currentModel.Filter.sharedMesh = matchingModel.Filter.sharedMesh;
        _currentModel.Renderer.sharedMaterial = matchingModel.Renderer.sharedMaterial;
    }
}