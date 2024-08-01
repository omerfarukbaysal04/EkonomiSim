using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadManager : MonoBehaviour
{
    private string saveFilePath;

    private void Awake()
    {
        saveFilePath = Application.persistentDataPath + "/gamedata.save";
    }

    public void SaveGame(GameData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(saveFilePath, FileMode.Create))
        {
            formatter.Serialize(stream, data);
        }
    }

    public GameData LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(saveFilePath, FileMode.Open))
            {
                return (GameData)formatter.Deserialize(stream);
            }
        }
        else
        {
            Debug.LogError("Save file not found");
            return null;
        }
    }
}


