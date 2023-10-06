using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public InputField playerNameInput;
   //attached through inspector
    public TextMeshProUGUI PlayerNameText;
    public Text HighScoreText;
    public Button SaveButton, PlayButton;
    // Start is called before the first frame update

   
    private void Start()
    {
        
        
        //make the player name text at the beginning.
        PlayerNameText.text = "Player Name: " + GameDataManager.Instance.GetPlayerName();
        //make it so the input text box is pre filled out with the player name.

        playerNameInput.text = GameDataManager.Instance.GetPlayerName();
        if (GameDataManager.Instance.GetHighScore() == 0)
        {
            HighScoreText.text = "No High Score Holder";
        }
        else
        {
            HighScoreText.text = "High Score Holder: " + GameDataManager.Instance.GetHighScoreHolder() + " with " + GameDataManager.Instance.GetHighScore().ToString() + " points";
        }
        SaveButton.onClick.AddListener(UpdatePlayerNameText);
        PlayButton.onClick.AddListener(PlayButtonPressed);

    }
    //update the text on screen to display name.
    public void UpdatePlayerNameText()
    {
        GameDataManager.Instance.UpdateName(playerNameInput.text);
        PlayerNameText.text = "Player Name: " + GameDataManager.Instance.GetPlayerName();
        GameDataManager.Instance.SaveName();

    }
    private void PlayButtonPressed()
    {
        GameDataManager.Instance.UpdateName(playerNameInput.text);
        GameDataManager.Instance.SaveName();
        SceneManager.LoadScene(1);
    }
    public void PlayMainScene()
    {
        SceneManager.LoadScene(1);
        
    }
    
}
