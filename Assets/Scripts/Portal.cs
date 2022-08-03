using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public int countBomb;
    public float angleShoot;
    [SerializeField] private GameObject _text;

    private float _firstAngle;
    private float _angle;
    private Vector3 _position;
    private void Start()
    {
        _firstAngle = -angleShoot / 2;
        _angle = angleShoot / (countBomb - 1);
        _text.GetComponent<TextMeshProUGUI>().text = "X " + countBomb;
    }
    private void Shoots(Bomb bomb)
    {
        _position = bomb.transform.position;
        
        for (int i = 0; i < countBomb; i++)
        {
            GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
            if (bullet != null)
            {
                bullet.transform.position = _position + new Vector3(0, 0, 0.5f);
                bullet.GetComponent<Rigidbody>().velocity = Vector3.zero;
                bullet.transform.rotation = Quaternion.Euler(0, _firstAngle + _angle * i, 0);
                bullet.SetActive(true);
                bullet.GetComponent<Bomb>().Start1();
                print(i + ": " + bullet.transform.rotation);
                
            }
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.TryGetComponent(out Bomb bomb))
        {
            Shoots(bomb);
        }
    }
}
