using UnityEngine;

[CreateAssetMenu]
public class ItemDatabase : ScriptableObject
{
    [SerializeField] GameObject[] items;

    public GameObject GetItemReference(string itemID)
    {
        foreach(GameObject go in items)
        {
            if(go.name == itemID)
            {
                return go;
            }
        }
        return null;
    }

    public GameObject GetItemCopy(string itemID)
    {
        GameObject item = GetItemReference(itemID);
        if (item == null) return null;
        return item;
    }
}
