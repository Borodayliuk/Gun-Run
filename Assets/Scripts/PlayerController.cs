using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class PlaneInfoGame
{
    public int bombInSecond;
    public Material material;
}
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private List<PlaneInfoGame> _planeInfos = new List<PlaneInfoGame>();
    
    private Rigidbody _rigidbody;
    private Vector2 _pointStart;
    private Vector2 _pointEnd;
    private Vector3 _startPosition;
    public PlaneInfoGame planeInfo;
    private void Awake()
    {
        planeInfo = _planeInfos[PlayerPrefs.GetInt("PlaneId")];
        GetComponent<MeshRenderer>().material = planeInfo.material;
        _rigidbody = GetComponent<Rigidbody>();
        _startPosition = transform.position;
    }
    private void Start()
    {
        print(planeInfo.bombInSecond);
    }
    private void FixedUpdate()
    {
        if (GameManager.singleton.isGamePlay)
        {
            Move();
        }
    }
    
    private void Update()
    {
        if (GameManager.singleton.isGamePlay)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _pointStart = Input.mousePosition;
            }
            if (Input.GetMouseButton(0))
            {
                _pointEnd = Input.mousePosition;
                if (Mathf.Sign(_rigidbody.velocity.x) != Mathf.Sign((_pointEnd - _pointStart).x))
                {
                    _rigidbody.velocity = new Vector3(0, _rigidbody.velocity.y, _rigidbody.velocity.z);

                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                _pointStart = Vector2.zero;
                _pointEnd = Vector2.zero;
                _rigidbody.velocity = new Vector3(0, _rigidbody.velocity.y, _rigidbody.velocity.z);
            }
        }
        else
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }
    public void Move()
    {
        if (_pointStart != Vector2.zero && _pointEnd != Vector2.zero)
        {
            transform.position += new Vector3(Mathf.Clamp((_pointEnd - _pointStart).x, -200, 200)/100 * _speed * Time.fixedDeltaTime, 0, 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Finish finish))
        {
            GameManager.singleton.Win();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Block block))
        {
            GameManager.singleton.Loss();
        }
        
    }
    public void RestartPlayer()
    {
        transform.position = _startPosition;
    }

}
