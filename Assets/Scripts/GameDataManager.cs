using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance;

    private string PlayerName;
    private int HighScore;
    private string HighScoreHolder;
    public string GetPlayerName() { return PlayerName; }
    public int GetHighScore() { return HighScore; }
    public string GetHighScoreHolder() { return HighScoreHolder; }

    private void Awake()
    {
        
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadName();
        
    }
    public void UpdateName(string inputName)
    {
        PlayerName = inputName;
    }
    public void UpdateHighScore(int score)
    {
        HighScore = score;
    }
    public void UpdateHighScoreHolder(string name)
    {
        HighScoreHolder = name;
    }
    

    [System.Serializable]
    class SaveData
    {
        public string CurrentName;
        public int HighScore;
        public string HighScoreHolder;
    }
    public void SaveName()
    {
        
        SaveData data = new SaveData();
        data.CurrentName = PlayerName;
        //data.HighScore = 0;
        data.HighScore = HighScore;
        data.HighScoreHolder = HighScoreHolder;
        
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
           
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.CurrentName;
            HighScore = data.HighScore;
            HighScoreHolder = data.HighScoreHolder; 
        }
    }
}
