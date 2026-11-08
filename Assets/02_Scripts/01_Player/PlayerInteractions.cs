using UnityEngine;

// SCRIPT DESTINADO A CONTROLAR LAS INTERACCIONES DEL JUGADOR, YA SEA AL PRESIONAR LA TECLA F PARA AGARRAR ITEMS, COMPRAR MEJORAS O CULTIVAR
// TAMBIÉN SE ENCARGA DE USAR LOS BOTÓNES 1,2,3 PARA USAR LOS ITEMS DEL INVENTARIO
public class PlayerInteractions : MonoBehaviour
{
    #region REFERENCES
    private PlayerInventory playerInventory;
    private PlayerRaycast playerRaycast;
    #endregion

    private void Awake()
    {
        playerInventory = GetComponent<PlayerInventory>();
        playerRaycast = GetComponent<PlayerRaycast>();
    }

    private void Update()
    {

    }

    //FUNCIÓN DESTINADA A LEER LOS INPUTS DEL TECLADO PARA INTERACTUAR Y USAR ITEMS
    private void HandleInputs()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TryToInteract();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TryUseItem(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TryUseItem(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TryUseItem(2);
        }
    }

    //FUNCIÓN QUE INTENTA INTERACTUAR EN BASE A QUÉ TIPO DE OBJETO ESTAMOS APUNTANDO (SOLO SI ES QUE ESTAMOS APUNTANDO A UN ITEM, A LA ZONA PARA PLANTAR O A UNA MEJORA)
    private void TryToInteract()
    {
        if (playerRaycast.hittingTransform)
        {
            if (playerRaycast.hittingTransform.GetComponent<Item>())
            {

            }
            else if (playerRaycast.hittingTransform.GetComponent<Upgrade>())
            {
                if (EconomyManager.Instance.currentGold >= playerRaycast.hittingTransform.GetComponent<Upgrade>().upgradeCost)
                {

                    UpgradesManager.Instance.IncreaseUpgradeLevel(playerRaycast.hittingTransform.GetComponent<Upgrade>().upgradeType);
                }
            }
            else if(playerRaycast.hittingTransform.GetComponent<FarmTile>())
            {

            }
        }
    }

    //FUNCIÓN QUE INTENTA USAR UN OBJETO DEL INVENTARIO BASADO EL UN NÚMERO (SOLO SE PUEDE USAR EL OBJETO SI ES QUE TENEMOS DICHO ESPACIO (IDNEX) ASIGNADO CON ALGÚN ITEM) Y ESTAMOS APUNTANDO A UN FARM TILE
    private void TryUseItem(int itemIndex)
    {

    }
}
