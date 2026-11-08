using UnityEngine;

//SCRIPT QUE CONTROLA EL TIPO Y COSTO DE LA MEJORA
// **PISTA** AQUÍ NO HABRÍA QUE CAMBIAR NADA
public class Upgrade : MonoBehaviour
{
    #region VARIABLES
    [Header("## UPGRADE ##")]
    [Space(5)]
    public UPGRADE_TYPE upgradeType;
    public int upgradeCost;
    #endregion
}

public enum UPGRADE_TYPE
{
    Water,
    Gold,
    Grow,
    Farmer
}
