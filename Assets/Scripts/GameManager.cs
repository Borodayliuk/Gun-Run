using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _track;

    public static GameManager singleton = new GameManager();
    public bool isGamePlay;
    public int bombPower;
    public int level;
    public int score;
    public int allCoins;
    public int levelCoints;

    [SerializeField] private GameObject _poverText;
    [SerializeField] private GameObject _scoreText;
    [SerializeField] private GameObject _levelText;
    [SerializeField] private GameObject _levelCointsText;
    [SerializeField] private GameObject _allCointsText;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private GameObject _nextButton;
    [SerializeField] private GameObject _menuButton;
    [SerializeField] private GameObject _levelCoinsImg;
    [SerializeField] private GameObject _allCoinsImg;
    

    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else if(singleton != this)
        {
            Destroy(gameObject);
        }
        level = PlayerPrefs.GetInt("Level");
        allCoins = PlayerPrefs.GetInt("Coins");
        LoadLevel();
    }
    private void Start()
    {
        _restartButton.GetComponent<Button>().onClick.AddListener(ClickPlayButton);
        _nextButton.GetComponent<Button>().onClick.AddListener(ClickPlayButton);
        _menuButton.GetComponent<Button>().onClick.AddListener(ClickMenuButton);
    }
    public void Loss()
    {
        isGamePlay = false;
        
        _restartButton.SetActive(true);
        _menuButton.SetActive(true);
    }
    public void Win()
    {
        isGamePlay = false;
        level++;
        allCoins += levelCoints;
        
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.SetInt("Coins", allCoins);
        _allCointsText.SetActive(true);
        _nextButton.SetActive(true);
        _menuButton.SetActive(true);
        _allCoinsImg.SetActive(true);
        _allCointsText.GetComponent<TextMeshProUGUI>().text = "" + allCoins;
    }
    public void LoadLevel()
    {
        levelCoints = 0;
        score = 0;
        bombPower = 1;
        _levelText.GetComponent<TextMeshProUGUI>().text = "Level " + (level +1);
        _restartButton.SetActive(false);
        _allCointsText.SetActive(false);
        _nextButton.SetActive(false);
        _menuButton.SetActive(false);
        _allCoinsImg.SetActive(false);

        _track.GetComponent<TrackController>().LoadStage(level);
        _player.GetComponent<PlayerController>().RestartPlayer();
        isGamePlay = true;

    }
    public void ClickPlayButton()
    {
        LoadLevel();
    }
    public void ClickMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
    private void Update()
    {
        levelCoints = score / 10;
        _scoreText.GetComponent<TextMeshProUGUI>().text = "" + score;
        _poverText.GetComponent<TextMeshProUGUI>().text = "" + bombPower;
        _levelCointsText.GetComponent<TextMeshProUGUI>().text = "" + levelCoints;

    }

}
