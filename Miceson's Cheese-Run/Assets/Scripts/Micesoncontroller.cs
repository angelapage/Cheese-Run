using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Micesoncontroller : MonoBehaviour
{
    private Rigidbody2D rd2d;
    public float speed;
    public float timeRemaining = 10;
     private int scoreValue = 0;
    
    public Text timer;
    public Text winText;
    public Text loseText;
    public Text score;
    public Text start;
    public Text time;

    bool gameOver = false;
    public bool timerIsRunning = false;

    public GameObject cloudPrefab;
    
    public AudioClip backgroundSound;
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip foodSound;
    AudioSource audioSource;

    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = "Cheese: " + scoreValue.ToString();
        timerIsRunning = true;
        speed = 0;
        Instantiate (cloudPrefab);
        Invoke("Unfreeze", 2);

        winText.text = "";
        loseText.text = "";

        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        Invoke("playAudio", 2);
        
    }
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
    }

    void Update()
    {
        if (timerIsRunning)
        {  
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            } 

        else
            {
                gameOver = true;
                loseText.text = "Time has run out! Press R to restart";
                Destroy(loseText, 2);
                PlaySound(loseSound);
                speed = 0;
            }

        }
        
         if (Input.GetKey(KeyCode.R))
        {
            if (gameOver == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

         if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Cheese")
        {
            scoreValue += 1;
            score.text = "Cheese: " + scoreValue.ToString();
            PlaySound(foodSound);
            Destroy(collision.collider.gameObject);

         if (scoreValue == 3)
         {
             timerIsRunning = false;
             gameOver = true;
             winText.text = "You Win! Press R to play again! Game made by Angela Page";
             Destroy(winText, 2);
             PlaySound(winSound);
             speed = 0;
         }
        }
    }

     void DisplayTime(float timeToDisplay)
    {
         timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

     public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    void playAudio()
    {
       PlaySound(backgroundSound);
    }

    void Unfreeze()
    {
        speed = 5;
    }
}