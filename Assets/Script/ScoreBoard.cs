using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int score;
    TMP_Text scoreTest;
     void Start()
    {
        scoreTest = GetComponent<TMP_Text>();
        scoreTest.text = "Start";
        scoreTest.color = Color.blue;
    }
    public void IncreaseScore(int amountToInrease)
    {
        score += amountToInrease;
        scoreTest.text = score.ToString();
        Debug.Log($" score is now {score}");
    }
}
