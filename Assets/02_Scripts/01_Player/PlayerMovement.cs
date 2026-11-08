using UnityEngine;

//SCRIPT QUE CONTROLA EL MOVIMIENTO (POSICIÓN Y ROTACIÓN) TANTO DEL PERSONAJE COMO DE LA CÁMARA
public class PlayerMovement : MonoBehaviour
{
    #region VARIABLES
    [Header("## PLAYER MOVEMENT ##")]
    [Space(5)]

    [Header("INPUTS")]
    private float mouseX, mouseY, keyboardHorizontal, keyboardVertical;

    [Header("CAMERA")]
    public Transform cameraTransform;
    private float verticalRotation;
    [SerializeField] private float mouseSensitivity;

    [Header("MOVEMENT")]
    [SerializeField] private float movementSpeed;
    #endregion

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        GetInputs();
    }

    //FUNCIÓN DESTINADA A OBTENER Y GUARDAR LOS INPUTS DEL MOUSE Y TECLADO
    private void GetInputs()
    {
        mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

        keyboardHorizontal = Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime;
        keyboardVertical = Input.GetAxisRaw("Vertical") * movementSpeed * Time.deltaTime;
    }

    //FUNCIÓN QUE SE ENCARGA DE ROTAR LA CÁMARA Y GESTIONAR LOS CLAMPS
    private void CameraRotation()
    {
        verticalRotation -= mouseY;
        cameraTransform.localEulerAngles = new(verticalRotation, 0, 0);
    }

    //FUNCIÓN QUE SE ENCARGA DE MOVER Y ROTAR AL PLAYER
    private void PlayerMove()
    {
        transform.Rotate(0, mouseX, 0);
    }
}
