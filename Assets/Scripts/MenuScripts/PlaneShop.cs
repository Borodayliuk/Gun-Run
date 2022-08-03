using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class PlaneInfo
{
    public int id;
    public int price;
    public int bombInSecond;
    public Material material;
}
public class PlaneShop : MonoBehaviour
{
    
    [SerializeField] private List<PlaneInfo> _planesInfo = new List<PlaneInfo>();
    private MeshRenderer _mesh;
    private int _materialNumber;
    void Start()
    {
        _mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Next()
    {
        if (_materialNumber + 1 < _planesInfo.Count)
        {
            _materialNumber++;
        }
        else
        {
            _materialNumber = 0;
        }
        _mesh.material = _planesInfo[_materialNumber].material;
    }
    public void Back()
    {
        if (_materialNumber - 1 > 0)
        {
            _materialNumber--;
        }
        else
        {
            _materialNumber = _planesInfo.Count - 1;
        }
        _mesh.material = _planesInfo[_materialNumber].material;
    }
    public PlaneInfo GetPlane()
    {
        return _planesInfo[_materialNumber];
    }
}
