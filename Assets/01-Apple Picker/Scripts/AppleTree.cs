using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class AppleTree : MonoBehaviour
{

    [Header("Set in Inspector")]

    // Prefab for instantiating apples

    public GameObject applePrefab;


    // Prefab for instantiating special apples

    public GameObject appleSpecialPrefab;



    // Speed at which the AppleTree moves

    public float speed = 1f;



    // Distance where AppleTree turns around

    public float leftAndRightEdge = 10f;



    // Chance that the AppleTree will change directions

    public float chanceToChangeDirections = 0.1f;



    // Rate at which Apples will be instantiated

    public float secondsBetweenAppleDrops = 1f;

    // Chance to drop AppleSpecial

    public float chanceForSpecialDrop = 0.01f;



    void Start()
    {

        // Dropping apples every second

        Invoke("DropApple", 2f);                                      

    }



    void DropApple()
    {                                                  

        GameObject apple = Instantiate<GameObject>(applePrefab);      

        apple.transform.position = transform.position;                  

        Invoke("DropApple", secondsBetweenAppleDrops);                

    }


    void DropAppleSpecial()
    {

        GameObject appleSpecial = Instantiate<GameObject>(appleSpecialPrefab);

        appleSpecial.transform.position = transform.position;

        //Invoke("DropApple", secondsBetweenAppleDrops);

    }


    void Update()
    {

        // Basic Movement

        Vector3 pos = transform.position;                  

        pos.x += speed * Time.deltaTime;                   

        transform.position = pos;                          



        // Changing Direction
        if (pos.x < -leftAndRightEdge)
        {                             

            speed = Mathf.Abs(speed); // Move right                    

        }
        else if (pos.x > leftAndRightEdge)
        {                       

            speed = -Mathf.Abs(speed); // Move left                    

        }
        
    }

    void FixedUpdate()
    {

        // Changing Direction Randomly is now time-based because of FixedUpdate()

        if (Random.value < chanceToChangeDirections)
        {                     

            speed *= -1; // Change direction

        }

        if (Random.value < chanceForSpecialDrop)
        {
            Invoke("DropAppleSpecial", 2f);
        }

    }


}