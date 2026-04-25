using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Model : MonoBehaviour
{
    [SerializeField] private int _level;

    private MeshFilter _meshFilter;
    private MeshRenderer _renderer;

    public int Level => _level;
    public MeshRenderer Renderer => _renderer;
    public MeshFilter MeshFilter => _meshFilter;

    private void Awake()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _renderer = GetComponent<MeshRenderer>();
    }
}