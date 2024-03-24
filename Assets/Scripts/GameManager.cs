using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string PlayerName;
    
    public string HighScorePlayerName = "--";
    public int HighScore = 0;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }
    
    [System.Serializable]
    class SerializableSaveData 
    {
        public string PlayerName;
        public string HighScorePlayerName;
        public int HighScore = 0;
    }

    public void SaveData ()
    {
        SerializableSaveData data = new SerializableSaveData();
        data.PlayerName = PlayerName;
        data.HighScorePlayerName = HighScorePlayerName;
        data.HighScore = HighScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData ()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SerializableSaveData data = JsonUtility.FromJson<SerializableSaveData>(json);
            PlayerName = data.PlayerName;
            HighScorePlayerName = data.HighScorePlayerName;
            HighScore = data.HighScore;
        }
    }
}
