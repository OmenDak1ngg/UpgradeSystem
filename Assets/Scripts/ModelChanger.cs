using UnityEngine;
using UnityEngine.UIElements;
public class ModelChanger : MonoBehaviour, IUpgradable
{
    [SerializeField] private Model[] _models;

    private Model _currentModel;

    private void Awake()
    {
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

        _currentModel.MeshFilter.mesh = matchingModel.MeshFilter.sharedMesh;
        _currentModel.Renderer.material = matchingModel.Renderer.sharedMaterial;
    }
}