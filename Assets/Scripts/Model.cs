using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Model : MonoBehaviour
{
    [SerializeField] private int _level;
    [SerializeField] private MeshFilter _meshFilter;
    [SerializeField] private MeshRenderer _renderer;

    public int Level => _level;
    public MeshRenderer Renderer => _renderer;
    public MeshFilter MeshFilter => _meshFilter;
}