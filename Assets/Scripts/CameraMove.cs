using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private Vector3 _offsize;
    private void Awake()
    {
        _offsize =  _target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, _target.position.z - _offsize.z);
    }
}
