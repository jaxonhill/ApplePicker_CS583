using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public TextMeshProUGUI gt;

    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // Find a reference to the ScoreCounter GameObject
        gt = scoreGO.GetComponent<TextMeshProUGUI>();
        // Get the Text Component of that GameObject
        gt.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        // Get current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;

        // The Camera's Z position sets how far to push the mouse into 3D
        mousePos2D.z = -Camera.main.transform.position.z;

        // Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Move the x position of this Basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);

            // Parse the text of the score into an int
            int score = int.Parse(gt.text);
            // Add points for catching the apple
            score += 100;
            // Convert the score back to a string and display it
            gt.text = score.ToString();

            // Track the High Score
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
