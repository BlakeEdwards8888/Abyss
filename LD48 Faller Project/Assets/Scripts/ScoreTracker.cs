using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb2d;
    [SerializeField] TextMeshProUGUI myText;
    [SerializeField] Animator niceText;
    float score;
    bool triggered69, triggered420;
    
    // Update is called once per frame
    void Update()
    {
        if (playerRb2d == null) return;
        TrackScore();
    }

    void TriggerNice()
    {
        niceText.SetTrigger("nice");
    }

    private void TrackScore()
    {
        //update the score depending on the total depth the player has fallen
        score -= playerRb2d.velocity.y * Time.deltaTime;

        CheckForNice();

        //set the score text to represent the score
        myText.SetText((int)score + "m");
    }

    private void CheckForNice()
    {
        if (score > 68.9 && score < 69.1 && !triggered69)
        {
            TriggerNice();
            triggered69 = true;
        }
        if (score > 419.9 && score < 420.1 && !triggered420)
        {
            TriggerNice();
            triggered420 = true;
        }
    }
}
