using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameoverScore : MonoBehaviour
{
    public TextMeshProUGUI value;
    public Add_Scores score;

    public void Score(int currScore)
    {
        value.text ="Your Score is: " + currScore.ToString();
    }

    private void Start()
    {
        Score(0);
    }

    private void Update()
    {
        int currscore = score.currScore;
        Score(currscore);
    }
}
