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
        System.IO.FileInfo file = new System.IO.FileInfo(baseSavePath + "/" + fileName + ".dat");
        // if there is no file create file
        // when there is a file this is ignored
        file.Directory.Create();      
        ReadWrite.WriteToBinaryFile(file.FullName,items);
    }
    // loads file name from file
    public static ItemContainerSaveData LoadItems(string fileName)
    {
        System.IO.FileInfo file = new System.IO.FileInfo(baseSavePath + "/" + fileName + ".dat");
        if (file.Directory.Exists)
        {
            return ReadWrite.ReadFromBinaryFile<ItemContainerSaveData>(baseSavePath + "/" + fileName + ".dat");
        }
        else
        {
            Debug.Log("no savefile found");
            return null;
        }
    }
}