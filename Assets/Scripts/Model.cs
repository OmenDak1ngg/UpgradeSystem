using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Model : MonoBehaviour
{
    [SerializeField] private int _level;
    [SerializeField] private MeshRenderer _renderer;

    [SerializeField] private MeshFilter _filter;

    public MeshRenderer Renderer => _renderer;
    public MeshFilter Filter => _filter;

    public int Level => _level;
}