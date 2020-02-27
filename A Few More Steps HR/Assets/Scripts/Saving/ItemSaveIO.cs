using UnityEngine;
using System.IO;

using System.Runtime.Serialization.Formatters.Binary;

public static class ItemSaveIO
{
    private static readonly string baseSavePath;

    static ItemSaveIO()
    {
        baseSavePath = Application.persistentDataPath;
    }
    //saves items to binary file
    public static void SaveItems(ItemContainerSaveData items , string fileName)
    {
        ReadWrite.WriteToBinaryFile(baseSavePath + "/" + fileName + ".dat", items);
    }
    // loads file name from file
    public static ItemContainerSaveData LoadItems(string fileName)
    {
        return ReadWrite.ReadFromBinaryFile<ItemContainerSaveData>(baseSavePath + "/" + fileName + ".dat");
    
    }
}