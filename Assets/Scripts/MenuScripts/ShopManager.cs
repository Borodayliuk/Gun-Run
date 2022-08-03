using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    [SerializeField] private GameObject _menuCanvas;
    [SerializeField] private GameObject _shopCanvas;

    [SerializeField] private GameObject _byButton;
    [SerializeField] private GameObject _leftButton;
    [SerializeField] private GameObject _rightButton;
    [SerializeField] private GameObject _backButton;
    [SerializeField] private GameObject _priceText;
    [SerializeField] private GameObject _priceImg;

    [SerializeField] private GameObject _coinsImg;
    [SerializeField] private GameObject _coinsText;
    [SerializeField] private GameObject _selectedImg;
    [SerializeField] private GameObject _infoText;

    [SerializeField] private GameObject _plane;

    private PlaneInfo _planeInfo;

    private void Start()
    {
        _planeInfo = _plane.GetComponent<PlaneShop>().GetPlane();
        _byButton.GetComponent<Button>().onClick.AddListener(ClickBy);
        _leftButton.GetComponent<Button>().onClick.AddListener(ClickLeft);
        _rightButton.GetComponent<Button>().onClick.AddListener(ClickRight);
        _backButton.GetComponent<Button>().onClick.AddListener(ClickBack);

    }

    private void Update()
    {
        _coinsText.GetComponent<TextMeshProUGUI>().text = "" + PlayerPrefs.GetInt("Coins");
        _priceText.GetComponent<TextMeshProUGUI>().text = "" + _planeInfo.price;
        _infoText.GetComponent<TextMeshProUGUI>().text = "" + _planeInfo.bombInSecond + " bombs/second";
        if (_planeInfo.id <= PlayerPrefs.GetInt("PlaneId"))
        {
            _byButton.SetActive(false);
            _priceImg.SetActive(false);
            _priceText.SetActive(false);
        }
        else
        {
            _byButton.SetActive(true);
            _priceImg.SetActive(true);
            _priceText.SetActive(true);
        }
        if (_planeInfo.id == PlayerPrefs.GetInt("PlaneId"))
        {
            _selectedImg.SetActive(true);
        }
        else
        {
            _selectedImg.SetActive(false);
        }
    }

    public void ClickBy()
    {
        if (PlayerPrefs.GetInt("Coins") >= _planeInfo.price)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - _planeInfo.price);
            PlayerPrefs.SetInt("PlaneId", _planeInfo.id);
        }
    }
    public void ClickBack()
    {
        _shopCanvas.SetActive(false);
        _plane.SetActive(false);
        _menuCanvas.SetActive(true);
    }
    public void ClickLeft()
    {
        _plane.GetComponent<PlaneShop>().Back();
        _planeInfo = _plane.GetComponent<PlaneShop>().GetPlane();
    }
    public void ClickRight()
    {
        _plane.GetComponent<PlaneShop>().Next();
        _planeInfo = _plane.GetComponent<PlaneShop>().GetPlane();
    }
}
