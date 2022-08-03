using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _menuCanvas;
    [SerializeField] private GameObject _shopCanvas;

    [SerializeField] private GameObject _playButton;
    [SerializeField] private GameObject _shopButton;
    [SerializeField] private GameObject _soungButton;
    [SerializeField] private GameObject _coinsImg;
    [SerializeField] private GameObject _coinsText;
    [SerializeField] private GameObject _levelText;

    [SerializeField] private GameObject _plane;
   
    private void Start()
    {
        _menuCanvas.SetActive(true);
        _shopCanvas.SetActive(false);
        _plane.SetActive(false);
        _playButton.GetComponent<Button>().onClick.AddListener(ClickPlay);
        _shopButton.GetComponent<Button>().onClick.AddListener(ClickShop);
        _soungButton.GetComponent<Button>().onClick.AddListener(ClickSound);
    }
    private void Update()
    {
        _coinsText.GetComponent<TextMeshProUGUI>().text = "" + PlayerPrefs.GetInt("Coins");
        _levelText.GetComponent<TextMeshProUGUI>().text = "Level " + (PlayerPrefs.GetInt("Level") + 1);
    }


    public void ClickShop()
    {
        _menuCanvas.SetActive(false);
        _shopCanvas.SetActive(true);
        _plane.SetActive(true);
    }

    public void ClickPlay()
    {
        SceneManager.LoadScene("Game");
    }

    public void ClickSound()
    {

    }
    public void ResetData()
    {
        PlayerPrefs.SetInt("PlaneId", 0);
        PlayerPrefs.SetInt("Level", 0);
        PlayerPrefs.SetInt("Coins", 0);
    }
}
