using TMPro;
using UnityEngine;
using UnityEngine.UI;

//SCRIPT QUE ADMINISTRA TODA LA INTERFAZ DE USUARIO DEL JUEGO
//YA SEA LO QUE OCURRE AL APUNTAR ITEMS, MEJORAS, ZONAS DE PLANTACIÓN, ACTUALIZAR EL ORO Y ALMACENAR LAS REFERENCIAS A LA UI DEL INVENTARIO
public class UIManager : MonoBehaviour
{
    #region REFERENCES
    public static UIManager Instance;
    private EconomyManager economyManager;
    #endregion

    #region VARIABLES
    [Header("## UI MANAGER ##")]
    [Space(5)]

    [Header("INVENTORY UI")]
    public Image[] uiInventory;

    [Header("INFO UI")]
    [SerializeField] private CanvasGroup infoUI;
    [SerializeField] private TextMeshProUGUI infoText;

    [Header("GOLD UI")]
    [SerializeField] private TextMeshProUGUI goldText;
    #endregion

    private void Awake()
    {
        Instance = this;
        economyManager = GetComponent<EconomyManager>();    
    }

    private void Start()
    {

    }

    private void Update()
    {
        RefreshInfoUI();
    }

    //FUNCIÓN QUE ADMINISTRA EL PANEL DE INFORMACIÓN DEL JUEGO.
    //TIENE COMPORTAMIENTOS DISTINTOS BASADOS EN SI ESTAMOS APUNTANDO A UNA ZONA DE PLANTACIÓN, A UN ITEM O A UNA MEJORA
    // ** NUEVO ** infoUI es un CanvasGroup. Permite de manera optimizada prender y apagar la ui. el aplfa = 1 es el equivalente a SetActive(true) y el 0 es SetActive(false)
    // ** NUEVO ** "<br>" es equivalente a hacer un Enter.
    // ** NUEVO ** ".ToString("F1")" permite traspasar un valor a un string pero manteniendo solo un decimal (por eso el 1 del F. Si fuera F2, serían dos decimales)
    private void RefreshInfoUI()
    {
        if (PlayerRaycast.Instance.hittingTransform)
        {
            infoUI.alpha = 1;
            if (PlayerRaycast.Instance.hittingTransform.GetComponent<Item>())
            {
                infoText.text = $"ITEM: {PlayerRaycast.Instance.hittingTransform.GetComponent<Item>().itemScriptable.itemType}";
            }
            else if (PlayerRaycast.Instance.hittingTransform.GetComponent<Upgrade>())
            {
                infoText.text = $"UPGRADE: {PlayerRaycast.Instance.hittingTransform.GetComponent<Upgrade>().upgradeType}<br>COST: $??";
                switch (PlayerRaycast.Instance.hittingTransform.GetComponent<Upgrade>().upgradeType)
                {
                    case UPGRADE_TYPE.Farmer:

                        break;

                    case UPGRADE_TYPE.Water:
                        infoText.text += $"<br>LEVEL: {UpgradesManager.Instance.waterTimeToGrowReductionLevel}";
                        break;
                }
            }
            else if (PlayerRaycast.Instance.hittingTransform.GetComponent<FarmTile>())
            {
                infoText.text = $"STATE: {PlayerRaycast.Instance.hittingTransform.GetComponent<FarmTile>().currentState}<br>TIME: {PlayerRaycast.Instance.hittingTransform.GetComponent<FarmTile>().elapsedTimeToFullGrow.ToString("F1")} / ??";
            }
            else
            {

            }
        }
        else
        {

        }
    }

    //FUNCIÓN QUE ACTUALIZA LA UI DEL ORO
    public void RefreshGoldUI()
    {
        goldText.text = $"GOLD: $??";
    }
}
