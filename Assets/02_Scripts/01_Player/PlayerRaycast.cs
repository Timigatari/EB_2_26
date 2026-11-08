using UnityEngine;

//SCRIPT QUE CONTROLA EL RAYCAST DEL JUGADOR. PERMITE IDENTIFICAR Y GUARDAR LA REFERENCIA DE LO QUE ESTAMOS TOCANDO CON EL RAYO
public class PlayerRaycast : MonoBehaviour
{
    #region REFERENCES
    public static PlayerRaycast Instance;
    private PlayerMovement playerMovement;
    #endregion

    #region VARIABLES
    [Header("## PLAYER RAYCAST ##")]
    [Space(5)]

    [Header("RAYCAST")]
    [SerializeField] private float raycastDistance;
    public Transform hittingTransform;
    #endregion

    private void Awake()
    {
        Instance = this;
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {

    }

    //FUNCIÓN DESTINADA A LANZAR UN RAYO Y GUARDAR LO QUE ESTÁ TOCANDO
    private void HandleRaycast()
    {
        Debug.DrawRay(playerMovement.cameraTransform.position, playerMovement.cameraTransform.forward * raycastDistance, Color.magenta);
        if (Physics.Raycast(playerMovement.cameraTransform.position, playerMovement.cameraTransform.forward, out RaycastHit hit, raycastDistance))
        {

        }
        else
        {
            hittingTransform = null;
        }
    }
}
