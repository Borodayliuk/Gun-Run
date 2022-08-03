using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PortalPower : MonoBehaviour
{
    public int power;
    [SerializeField] private ParticleSystem _particlePrefab;
    [SerializeField] private GameObject _text;
    private ParticleSystem _particle;

    private void Start()
    {
        _text.GetComponent<TextMeshProUGUI>().text = "POWER" + power;
        _particle = Instantiate(_particlePrefab, transform.position, Quaternion.identity);
        _particle.Stop();
    }




    public void AddPower()
    {
        GetComponent<BoxCollider>().enabled = false;
        _particle.Play();

        if (GameManager.singleton.bombPower + power > 0)
        {
            GameManager.singleton.bombPower += power;
        }
        else
        {
            GameManager.singleton.bombPower = 1;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController player))
        {
            AddPower();
            Destroy(transform.parent.gameObject);
        }
    }

}
