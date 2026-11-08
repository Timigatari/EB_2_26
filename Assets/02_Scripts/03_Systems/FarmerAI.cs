using UnityEngine;
using UnityEngine.AI;

//SCRIPT QUE ADMINISTRA EL COMPORTAMIENTO DEL NPC.
//EL COMPORTAMIENTO SE BASA EN CAMINAR DE UNA ZONA DE PLANTACIÓN EN OTRA PARA IRLAS HACIENDO PROGRESAR.
//CUANDO LLEGA A UNA ZONA, SE DETIENE PARA VOLVER A IDLE E IR A OTRA ZONA.
public class FarmerAI : MonoBehaviour
{
    #region REFERENCES
    private Animator anim;
    private NavMeshAgent agent;
    #endregion

    #region VARIABLES
    [Header("## FARMER AI ##")]
    [Space(5)]

    [Header("STATES")]
    [SerializeField] public AI_STATE currentState;
    public enum AI_STATE
    {
        Idle,
        Walking
    }

    [Header("IDLE STATE")]
    [SerializeField] private float idleTime;
    private float elapsedIdleTime;

    [Header("WALKING STATE")]
    [SerializeField] private FarmTile[] farmTiles;
    private FarmTile currentFarmTime;
    #endregion

    private void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        ChangeState(AI_STATE.Idle);
    }

    private void Update()
    {

    }

    //FUNCIÓN QUE SE ENCARGA DE DETERMINAR QUÉ HACE EL GRANJERO EN CADA ESTADO
    private void HandleState()
    {
        switch (currentState)
        {
            case AI_STATE.Idle:
                elapsedIdleTime += Time.deltaTime;
                if (elapsedIdleTime >= idleTime)
                {
                    elapsedIdleTime = 0;

                }
                break;

            case AI_STATE.Walking:
                if (agent.remainingDistance <= agent.stoppingDistance)
                {

                    ChangeState(AI_STATE.Idle);
                }
                break;
        }
    }

    private void ChangeState(AI_STATE newState)
    {
        switch (newState)
        {
            case AI_STATE.Idle:

                break;

            case AI_STATE.Walking:
                anim.SetBool("isWalking", true);
                currentFarmTime = farmTiles[Random.Range(0, farmTiles.Length)];

                break;
        }

        currentState = newState;
    }
}
