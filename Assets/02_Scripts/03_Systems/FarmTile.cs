using UnityEngine;

//SCRIPT QUE ADMINISTRA LA ZONA EN EL QUE SE PUEDE PLANTAR, SU ESTADOS E INTERACCIONES CON EL PLAYER Y EL NPC
public class FarmTile : MonoBehaviour
{
    #region REFERENCES
    private MeshRenderer mesh;
    #endregion

    #region VARIABLES
    [Header("## FARMING TILE ##")]
    [Space(5)]

    [Header("STATE")]
    public FARM_TILE_STATE currentState;
    public enum FARM_TILE_STATE
    {
        Unplowed,
        Plowed,
        Planted,
        Grown
    }

    [Header("MATERIALS")]
    [SerializeField] private Material unplowedMat;
    [SerializeField] private Material plowedMat;

    [Header("PREFABS")]
    [SerializeField] private GameObject plantedPropPrefab;
    [SerializeField] private GameObject grownPropPrefab;

    [Header("PROP")]
    [SerializeField] private Transform propSpawnPoint;
    [SerializeField] private GameObject currentProp;

    [Header("PLANT STATE")]
    public float elapsedTimeToFullGrow;

    #endregion

    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        ChangeState(FARM_TILE_STATE.Unplowed);
    }

    private void Update()
    {
        if(currentState == FARM_TILE_STATE.Planted)
        {
            elapsedTimeToFullGrow += Time.deltaTime;
            if(elapsedTimeToFullGrow >= UpgradesManager.Instance.TimeToGrow())
            {
                elapsedTimeToFullGrow = 0;

            }
        }
    }

    //FUNCIÓN QUE SE LLAMA CUANDO SE USA UN ÍTEM SOBRE LA ZONA DE PLANTACIÓN

    public void UseItem(ITEM_TYPE itemToUse)
    {
        switch (itemToUse)
        {
            case ITEM_TYPE.Shovel:
                if(currentState == FARM_TILE_STATE.Unplowed)
                {
                    Plow();
                }
                break;

            case ITEM_TYPE.SeedBag:
                if(currentState == FARM_TILE_STATE.Plowed)
                {

                }
                break;

            case ITEM_TYPE.Water:

                break;
        }
    }

    //FUNCIÓN QUE LLAMA EL NPC CUANDO INTERACTÚA CON LA ZONA DE PLANTACIÓN Y LA HACE AVANZAR
    public void Progress()
    {
        switch (currentState)
        {
            case FARM_TILE_STATE.Unplowed:
                Plow();
                break;

            case FARM_TILE_STATE.Plowed:
                Plant();
                break;

            case FARM_TILE_STATE.Planted:

                break;

            case FARM_TILE_STATE.Grown:

                break;
        }
    }

    //ARAR
    private void Plow()
    {
        ChangeState(FARM_TILE_STATE.Plowed);
    }

    //PLANTAR
    private void Plant()
    {
        currentProp = Instantiate(plantedPropPrefab, propSpawnPoint);

    }

    //REGAR
    private void Water()
    {
        elapsedTimeToFullGrow += UpgradesManager.Instance.WaterTimeToGrowReduction();
    }

    //COSECHAR
    public void Harvest()
    {
        EconomyManager.Instance.AdjustGold(UpgradesManager.Instance.GoldPerHarvest());
        Destroy(currentProp);

    }

    //FUNCIÓN PARA CAMBIAR EL ESTADO ACTUAL DE LA ZONA DE PLANTACIÓN
    public void ChangeState(FARM_TILE_STATE newState)
    {
        switch (newState)
        {
            case FARM_TILE_STATE.Unplowed:
                mesh.material = unplowedMat;
                break;

            case FARM_TILE_STATE.Plowed:
                mesh.material = plowedMat;
                break;

            case FARM_TILE_STATE.Grown:
                Destroy(currentProp);
                currentProp = Instantiate(grownPropPrefab, propSpawnPoint);
                break;
        }

        currentState = newState;
    }
}
