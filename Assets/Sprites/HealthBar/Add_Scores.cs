using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Add_Scores : MonoBehaviour
{
    public int currScore = 0;
    public TextMeshProUGUI value;

    [SerializeField] GameObject hidden_spawn;
    [SerializeField] GameObject hidden_spawn_2;
    [SerializeField] GameObject hidden_Gun;
    [SerializeField] GameObject NewGun;

    public void AddScore()
    {
        currScore++;
        value.text = currScore.ToString();
        if(currScore == 15)
        {
            hidden_spawn.SetActive(true);
            hidden_Gun.SetActive(true);
            NewGun.SetActive(true);
            Time.timeScale = 0;
        }

        if (currScore == 50)
        {
            hidden_spawn_2.SetActive(true);
        }
    }

    private void Start()
    {
        currScore = -1;
        AddScore();
    }
}
