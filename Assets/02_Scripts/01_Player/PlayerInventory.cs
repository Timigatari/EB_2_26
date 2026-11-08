using UnityEngine;

//SCRIPT DESTINADO A ADMINISTRAR TANTO EL INVENTARIO DEL JUGADOR COMO EL QUE SE GRAFICA EN LA UI
public class PlayerInventory : MonoBehaviour
{
    #region VARIABLES
    [Header("## PLAYER INVENTORY ##")]
    [Space(5)]

    [Header("INVENTORY")]
    public ItemScriptable[] itemInventory;
    #endregion

    private void Start()
    {

    }

    //FUNCIÓN QUE PERMITE AÑADIR ITEMS AL INVENTARIO Y ACTUALIZAR LA UI RESPECTIVA.
    public void AddItemToInventory(Item itemToAdd)
    {
        for (int i = 0; i < itemInventory.Length; i++)
        {
            if(itemInventory[i] == null)
            {
                itemInventory[i] = itemToAdd.itemScriptable;
                UIManager.Instance.uiInventory[i].sprite = itemToAdd.itemScriptable.itemIcon;
                Destroy(itemToAdd.gameObject);
                break;
            }
        }
    }
}
