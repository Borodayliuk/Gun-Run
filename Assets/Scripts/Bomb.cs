using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float speed;
    [SerializeField] private float _lifeTime;
    public float demage;
    private Rigidbody _rigidbody;
 
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void Start1()
    {
        demage = GameManager.singleton.bombPower;

        DestroyBomb(_lifeTime);
    }
   
    private void Update()
    {
        _rigidbody.velocity = transform.forward * speed;
    }

    public void DestroyBomb(float time)
    {
        StartCoroutine(DestroyForTime(time));
    }
    IEnumerator DestroyForTime(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
        transform.rotation = Quaternion.identity;
        _rigidbody.angularVelocity = Vector3.zero;
        
    }
    public void DestroyNow()
    {
        gameObject.SetActive(false);
        transform.rotation = Quaternion.identity;
        _rigidbody.angularVelocity = Vector3.zero;
    }
}
