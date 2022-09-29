using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreIncrease : MonoBehaviour
{

    public Text scoreGT;

    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");

        // Get the Text Component of that GameObject

        scoreGT = scoreGO.GetComponent<Text>();

        // Set the starting number of points to 0

        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreUp()
    {
        int score = int.Parse(scoreGT.text);

        // Add points for catching the apple

        score += 1;

        // Convert the score back to a string and display it

        scoreGT.text = score.ToString();
    }
}
