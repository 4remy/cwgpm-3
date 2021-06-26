using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Schwer.ItemSystem;

[System.Serializable]
public class SchwerSaveData 
{
    [SerializeField] private SerializableInventory inventory;

    // Construct new save data.
    public SchwerSaveData()
    {
        inventory = new SerializableInventory();
    }

    // Construct save data from an Inventory.
    public SchwerSaveData(Schwer.ItemSystem.Inventory inventory)
    {
        this.inventory = inventory.Serialize();
    }

    // Load save data 
    public void Load(out Schwer.ItemSystem.Inventory inventory, ItemDatabase itemDB)
    {
        inventory = this.inventory.Deserialize(itemDB);
    }
}

public static class SaveReadWriter
{
    // Returns save data from the file at the specified location (if possible).
    public static SchwerSaveData ReadSaveDataFile(string filePath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(filePath, FileMode.Open))
        {
            try
            {
                return formatter.Deserialize(stream) as SchwerSaveData;
            }
            catch (System.Runtime.Serialization.SerializationException e)
            {
                Debug.Log("File at: " + filePath + " is incompatible. " + e);
            }
        }
        return null;
    }

    // Writes the save data to a file at the specified location.
    public static void WriteSaveDataFile(SchwerSaveData saveData, string filePath)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(filePath, FileMode.Create))
        {
            formatter.Serialize(stream, saveData);
        }
    }
}
