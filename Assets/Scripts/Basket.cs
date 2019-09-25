using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;

    void Start()
    {
        // Find a reference to the ScoreCounter GameObject
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        //Get the text component of that GameObject
        scoreGT = scoreGO.GetComponent<Text>();
        //Set the starting number of points to 0
        scoreGT.text = "0";
    }
    void Update()
    {
        //Get the current screen pos of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;

        //The Camera's z position sets how far to push the mouse i
        mousePos2D.z = -Camera.main.transform.position.z;

        //Convert the point from 2D screen space into 3D Game World
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //move the x position of this Basket to the x position of
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        //find out what hit the basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);

            //Parse the text of the scoreGT into an int
            int score = int.Parse(scoreGT.text);
            //Add points for catching the apple
            score += 100;
            //Convert the score back to a string and display it
            scoreGT.text = score.ToString();
            //Track the high score
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
