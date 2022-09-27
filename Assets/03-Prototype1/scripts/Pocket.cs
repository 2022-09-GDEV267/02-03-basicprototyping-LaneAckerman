using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket : MonoBehaviour
{
	static public bool 	goalMet = false;

	void OnTriggerEnter(Collider other) {
		// when the trigger is hit by something
		// check to see if it's a Projectile 
		if (other.gameObject.tag == "PoolBall") 
        {
			// if so, set goalMet = true
			Goal.goalMet = true;
            GameObject collidedWith = other.gameObject;
            Destroy(collidedWith);
            // also set the alpha of the color of higher opacity
            Material mat = GetComponent<Renderer>().material;
			Color c = mat.color;
			c.a = 1;
			mat.color = c;
		}
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    void OnCollisionEnter(Collision coll)
    {

        // Find out what hit this basket

        GameObject collidedWith = coll.gameObject;

        if (collidedWith.tag == "PoolBall")
        {

            Destroy(collidedWith);

            /*
            int score = int.Parse(scoreGT.text);

            // Add points for catching the apple

            score += 100;

            // Convert the score back to a string and display it

            scoreGT.text = score.ToString();

            // Track the high score

            if (score > HighScore.score)
            {

                HighScore.score = score;

            }
            */

    /*
        }

        if (collidedWith.tag == "AppleSpecial")
        {

            Destroy(collidedWith);

            //int score = int.Parse(scoreGT.text);

            // Add points for catching the apple

            //score += 200;

            // Convert the score back to a string and display it

            //scoreGT.text = score.ToString();

            // Track the high score

            /*if (score > HighScore.score)
            {

                HighScore.score = score;

            }
            

        }
        
    }
    */
}
