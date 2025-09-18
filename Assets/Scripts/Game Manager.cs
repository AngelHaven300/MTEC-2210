using TMPro;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float timer;
    public float gameTimeLimit = 30f;
    public float timeLeft;
    public TextMeshProUGUI timerText;
    public GameObject myPlayer;
    public TextMeshProUGUI scoreText;

    WASDcontroller playerScript;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myPlayer = GameObject.FindWithTag("Player");
        playerScript = myPlayer.GetComponent<WASDcontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timeLeft = gameTimeLimit - timer;

        if (timeLeft <= 0)
        {
            Destroy(myPlayer);
            Debug.Log("Game Over");
        }
        timerText.text = timeLeft.ToString();

        int dScore = playerScript.destroyedCount;
        scoreText.text = dScore.ToString();
    }
    void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime;
    }
}
