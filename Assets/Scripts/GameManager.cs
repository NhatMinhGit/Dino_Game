using TMPro;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
//Singleton dùng để quản lý các thông số của các thuộc tính
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float initialGameSpeed = 7f;
    public float gameSpeedIncrease = 0f;
    public float gameSpeed { get; private set; }

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiscoreText;
    public TextMeshProUGUI gameOverText;
    public Button retryButton;
    public Button playButton;
    private Player player;
    private Spawner spawner;


    private float score;

    private void Awake()
    {
        if (Instance != null) {
            DestroyImmediate(gameObject);
        } else {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this) {
            Instance = null;
        }
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();

        playButton.gameObject.SetActive(true);
    }

    public void NewGame()
    {
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();

        foreach (var obstacle in obstacles) {
            Destroy(obstacle.gameObject);
        }

        score = 0f;
        gameSpeed = initialGameSpeed;
        enabled = true;
        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        
        UpdateHiscore();
    }

    public void PlayGame()
    {
        NewGame();
        playButton.gameObject.SetActive(false);
    }

    public void Retry()
    {
        NewGame();
        retryButton.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        gameSpeed = 0f;
        enabled = false;

        player.gameObject.SetActive(false);//deactive
        spawner.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);//active
        retryButton.gameObject.SetActive(true);
        
        UpdateHiscore();
    }
   

    

    

    
    private void Update()
    {
        
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();

        foreach (var obstacle in obstacles)
        {
            if (player.transform.position.x > obstacle.transform.position.x)
            {
                score += 3 * Time.deltaTime;
            }
        }
        UpdateHiscore();
        scoreText.text = Mathf.FloorToInt(score).ToString("D4"); 
    }

    private void UpdateHiscore()
    {
        float hiscore = PlayerPrefs.GetFloat("hsiscore", 0); //khai báo một biến có thể lưu trữ và có giá trị mặc định = 0 (và được lưu trữ dưới dạng tag name)
        
        if (score > hiscore) // nếu điểmht > điểm cao
        {
            hiscore = score; // điểm cao = điểm ht
            PlayerPrefs.SetFloat("hsiscore", hiscore); // lưu giá trị điểm cao
        }
        Debug.Log(hiscore);
        hiscoreText.text = Mathf.FloorToInt(hiscore).ToString("D4"); 
    }

}
