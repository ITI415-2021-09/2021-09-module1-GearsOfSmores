using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;
    public int score;

    private void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter"); // Find a reference to the ScoreCounter GameObject

        scoreGT = scoreGO.GetComponent<Text>(); // Get the Text Component of that GameObject

        scoreGT.text = "0"; // Set the starting number of the points to O
    }
   
    void Update()
    {

        Vector3 mousePos2d = Input.mousePosition;

        mousePos2d.z = -Camera.main.transform.position.x;
        Vector3 mousePos3d = Camera.main.ScreenToWorldPoint(mousePos2d);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3d.x;
        this.transform.position = pos;

        
    }



    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);

            // Parse the text of the scoreGt into an int
            score = int.Parse(scoreGT.text);

            // Add points for catching the apple
            score += 100;

            // Convert the score back to a string and display it
            scoreGT.text = score.ToString();
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }


        }


    }



}





