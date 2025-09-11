using TMPro;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float timer;
    public float gameTimeLimit = 30f;
    public float timeLeft;
    public TextMeshProUGUI myText;
    public GameObject myPlayer;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        myText.text = timeLeft.ToString();
    }
   
}
