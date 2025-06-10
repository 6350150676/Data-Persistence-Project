using UnityEngine;
using System.IO;

[System.Serializable]
class SaveData
{
    public int HighScore;
    public string HighScorePlayerName;
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string playerName;

    public int highScore;
    public string highScorePlayerName;

    private string SavePath => Application.persistentDataPath + "/savefile.json";

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadGame();  // Load saved high score on startup
    }

    public void TrySetNewHighScore(int score)
    {
        if (score > highScore)
        {
            highScore = score;
            highScorePlayerName = playerName;
            SaveGame();
        }
    }

    private void SaveGame()
    {
        SaveData data = new SaveData
        {
            HighScore = highScore,
            HighScorePlayerName = highScorePlayerName
        };

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(SavePath, json);
    }

    private void LoadGame()
    {
        if (File.Exists(SavePath))
        {
            string json = File.ReadAllText(SavePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.HighScore;
            highScorePlayerName = data.HighScorePlayerName;
        }
        else
        {
            highScore = 0;
            highScorePlayerName = "None";
        }
    }
}
