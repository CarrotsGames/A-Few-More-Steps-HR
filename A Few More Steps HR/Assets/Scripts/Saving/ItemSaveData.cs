using System;

[Serializable]
public class ItemsaveData
{
    public string itemID;
    public int amount;

    public ItemsaveData(string id)
    {
        itemID = id;
    }

}
[Serializable]
public class ItemContainerSaveData
{
    public ItemsaveData[] SavedSlots;
    public ItemContainerSaveData(int numItems)
    {
        SavedSlots = new ItemsaveData[numItems];
    }
}
