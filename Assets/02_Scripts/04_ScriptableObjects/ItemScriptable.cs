using UnityEngine;

//SCRIPTABLE OBJECT QUE GUARDA LA INFORMACIÓN DE CADA ITEM
[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObjects/Item")]
public class ItemScriptable : ScriptableObject
{
    public ITEM_TYPE itemType;
    public Sprite itemIcon;    
}

public enum ITEM_TYPE
{
    Shovel,
    SeedBag,
    Water
}
