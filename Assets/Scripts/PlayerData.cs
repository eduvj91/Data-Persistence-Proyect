using System.IO;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    public string PlayerName;
    public int BestScore;

    private void Awake()
    {
        if (PlayerData.Instance == null)
        {
            PlayerData.Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string Name;
        public int Score;
    }


    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.Name = PlayerName;
        data.Score = BestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/saveFile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.Name;
            BestScore = data.Score;
        }
    }
}

