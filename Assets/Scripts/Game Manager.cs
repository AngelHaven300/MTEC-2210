using TMPro;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public float timer;
    public float gameTimeLimit = 30f;
    public float timeLeft;
    public GameObject myPlayer;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOver;
    
    

    WASDcontroller playerScript;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myPlayer = GameObject.FindWithTag("Player");
        playerScript = myPlayer.GetComponent<WASDcontroller>();
        myPlayer.SetActive(true);
        gameOver.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timeLeft = gameTimeLimit - timer;

        if (timeLeft <= 0)
        {
            EndGame();
        }
        timerText.text = timeLeft.ToString();

        int dScore = playerScript.destroyedCount;
        scoreText.text = dScore.ToString();

      

    }
    void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime;
    }

    public void EndGame()
    {
        Destroy(myPlayer);
        Debug.Log("Game Over");
        gameOver.enabled = true;
    }
}
