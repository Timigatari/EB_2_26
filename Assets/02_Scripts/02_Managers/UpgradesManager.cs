using UnityEngine;

//FUNCIÓN QUE ADMINISTRA LAS MEJORAS DEL JUEGO
//YA SEA SUS VALORES BASE COMO SUS NIVELES DE PROGRESIÓN.
public class UpgradesManager : MonoBehaviour
{
    #region REFERENCES
    public static UpgradesManager Instance;
    #endregion

    #region VARIABLES
    [Header("## UPGRADES MANAGER ##")]
    [Space(5)]

    [Header("BASE")]
    public float baseWaterTimeToGrowReduction;
    public int baseGoldPerHarvest;
    public float baseTimeToGrow;

    [Header("LEVELS")]
    public int waterTimeToGrowReductionLevel;
    public int goldPerHarvestLevel;
    public int timeToGrowLevel;

    [Header("FARMER")]
    public GameObject farmerCharacter;
    public GameObject farmerUpgrade;
    #endregion

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {

    }

    //FUNCIÓN QUE PERMITE SUBIR DE NIVEL UNA MEJORA
    public void IncreaseUpgradeLevel(UPGRADE_TYPE upgradeToIncrease)
    {
        switch (upgradeToIncrease)
        {
            case UPGRADE_TYPE.Water:
                waterTimeToGrowReductionLevel++;
                break;

            case UPGRADE_TYPE.Farmer:

                farmerUpgrade.SetActive(false);
                break;
        }
    }

    #region RETURN FUNCTIONS
    //FUNCIÓN QUE DEVUELVE EL VALOR TOTAL DEL TIEMPO QUE SE DEMORA EN CRECER EL CULTIVO (BASE + NIVEL)
    public float TimeToGrow()
    {
        return baseTimeToGrow - (0.1f * timeToGrowLevel);
    }

    //FUNCIÓN QUE DEVUELVE EL TIEMPO TOTAL QUE AUMENTA AL REGAR EL CULTIVO (BASE + NIVEL)
    public float WaterTimeToGrowReduction()
    {
        return baseWaterTimeToGrowReduction + (0.1f * waterTimeToGrowReductionLevel);
    }

    //FUNCIÓN QUE DEVUELVE EL VALOR TOTAL DEL ORO CONSEGUIDO AL COSECHAR (BASE + NIVEL)
    public int GoldPerHarvest()
    {
        return baseGoldPerHarvest;
    }
    #endregion
}
