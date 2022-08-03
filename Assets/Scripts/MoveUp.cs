using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody _rigitbody;
    private void Awake()
    {
        GameManager.singleton.isGamePlay = true;
        _rigitbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (GameManager.singleton.isGamePlay)
        {
            
            _rigitbody.velocity = -transform.up * _speed;
        }
    }


}
