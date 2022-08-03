using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int level;
    [SerializeField] private GameObject text;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Bomb bomb))
        {
            if (level - GameManager.singleton.bombPower > 0)
            {
                GameManager.singleton.score += GameManager.singleton.bombPower;
            }
            else
            {
                GameManager.singleton.score += level;
            }
            level-=GameManager.singleton.bombPower;
            bomb.GetComponent<Bomb>().DestroyNow();
        }
       
    }
    private void Update()
    {

        text.GetComponent<TextMeshProUGUI>().SetText(level.ToString());
        if (level <= 0)
        {
            Destroy(gameObject);
        }
    }
}
