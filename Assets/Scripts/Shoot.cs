using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private float _interval;
    private float _deltaTime = 0;
    private Quaternion _rotation;
    private void Awake()
    {
        _rotation = Quaternion.identity;
    }
    private void Start()
    {
        _interval = 1f / (float)GetComponent<PlayerController>().planeInfo.bombInSecond;
        print(_interval);
        
    }

    private void Shoots()
    {
        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = transform.position + new Vector3(0, 0, 0.5f);
            
            
            bullet.SetActive(true);
            bullet.GetComponent<Bomb>().Start1();
            
        }
    }
    private void Update()
    {
        if (GameManager.singleton.isGamePlay)
        {
            _deltaTime += Time.deltaTime;
            if (_deltaTime > _interval)
            {
                Shoots();
                _deltaTime = 0;
            }
        }
    }
}
