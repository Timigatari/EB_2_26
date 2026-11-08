using UnityEngine;

//SCRIPT QUE ADMINISTRA LA ECONOMÍA DEL JUEGO (ORO)
public class EconomyManager : MonoBehaviour
{
    #region REFERENCES
    public static EconomyManager Instance;
    private UIManager uiManager;
    #endregion

    #region VARIABLES
    [Header("## ECONOMY MANAGER ##")]
    [Space(5)]

    [Header("CURRENCY")]
    public int currentGold;
    #endregion

    private void Awake()
    {
        Instance = this;
        uiManager = GetComponent<UIManager>();
    }

    //FUNCIÓN QUE PERMITE AGREGAR O QUITAR ORO
    public void AdjustGold(int goldToAdjust)
    {
        currentGold += goldToAdjust;

    }
}
