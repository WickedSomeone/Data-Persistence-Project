using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    public Text bestScoreText;
    public Text CurrentPlayerText;
    
    // Start is called before the first frame update
    void Start()
    {
        if (GameDataManager.Instance.GetHighScore() > 0)
        {
            bestScoreText.text = "Best Score: " + GameDataManager.Instance.GetHighScoreHolder() + ": " + GameDataManager.Instance.GetHighScore();
        } else
        {
            bestScoreText.text = "Best Score: No Highscore Yet";
        }
        CurrentPlayerText.text = GameDataManager.Instance.GetPlayerName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
