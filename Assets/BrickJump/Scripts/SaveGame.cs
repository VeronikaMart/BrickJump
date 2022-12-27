using StackJump.Values;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveGame", menuName = "Scriptable Objects/Controllers/Save Game")]
public class SaveGame : ScriptableObject
{
    [SerializeField] private IntVariable highScore;

    public void OnSave()
    {
        if (!FileSaved())
        {
            Directory.CreateDirectory(Application.persistentDataPath + "brick_game/brick_game_save");
        }

        if (!Directory.Exists(Application.persistentDataPath + "brick_game/brick_game_save/brick_high_score"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "brick_game/brick_game_save/brick_high_score");
        }

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "brick_game/brick_game_save/brick_high_score/brick_save.txt");

        var json = JsonUtility.ToJson(highScore);
        binaryFormatter.Serialize(file, json);
        file.Close();
    }

    public void OnLoad()
    {
        if (!Directory.Exists(Application.persistentDataPath + "brick_game/brick_game_save/brick_high_score"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "brick_game/brick_game_save/brick_high_score");
        }

        BinaryFormatter binaryFormatter = new BinaryFormatter();

        if (File.Exists(Application.persistentDataPath + "brick_game/brick_game_save/brick_high_score/brick_save.txt"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "brick_game/brick_game_save/brick_high_score/brick_save.txt", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)binaryFormatter.Deserialize(file), highScore);
            file.Close();
        }
    }

    private bool FileSaved() =>
        Directory.Exists(Application.persistentDataPath + "brick_game/brick_game_save");
}