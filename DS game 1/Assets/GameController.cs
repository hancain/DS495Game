using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    private int score = 0;      // Score tracking g 
    private TMP_Text scoreText; // Reference to canvas text 
    private TMP_Text objText;
    private PlayerController pc; // Player controller reference 

    // Start is called before the first frame update
    void Start()
    {
        // Grab references to scoreText, player controller 
        scoreText = GameObject.Find("ScoreLabel").GetComponent<TMP_Text>();
        objText = GameObject.Find("ObjectiveLabel").GetComponent<TMP_Text>();
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update values for score
        score = pc.getScore();

        // Update score text on screen 
        scoreText.text = "Score: " + score;

        // Update text on screen 
        if (score == 0)
        {
            objText.text = "What class did I take first? Left: STA216 Right: DS201";
        }
        else if (score == 1)
        {
            objText.text = "What class did I take after? Left: ART271 Right: DS201";
        }
        else if (score == 2)
        {
            objText.text = "Collect DS202 coin";
        }
        else if (score == 3)
        {
            objText.text = "What class did I take after? Right: DS330 Straight: ART271";
        }
        else if (score == 4)
        {
            objText.text = "What semester did I take DS350? Left: W2022 Right: F2021";
        }
        else if (score == 5)
        {
            objText.text = "Final point! Search the maze for the DS330 coin.";
        }
        else if (score == 6)
        {
            objText.text = "You found all the coins! Go touch the finish stars!";
        }
        else if (score == 100)
        {
            objText.text = "Congrats! Thanks for playing!";
            scoreText.text = "<3";
        }


    }
}
