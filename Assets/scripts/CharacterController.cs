using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidadMovimiento = 5f;
    public float velocidadSprint = 8f;
    public float gravedad = -9.81f;
    public float fuerzaSalto = 2f;

    [Header("Mira")]
    public Transform camara;
    public float sensibilidadMouse = 100f;
    private float rotacionX = 0f;

    private CharacterController controlador;
    private Vector3 velocidad;
    private bool estaEnSuelo;

    void Start()
    {
        controlador = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor al centro
    }

    void Update()
    {
        Movimiento();
        Rotacion();
    }

    void Movimiento()
    {
        estaEnSuelo = controlador.isGrounded;
        if (estaEnSuelo && velocidad.y < 0)
        {
            velocidad.y = -2f; // Pequeña fuerza hacia abajo para mantener contacto con el suelo
        }

        // Entrada de teclado
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Determina si el jugador está corriendo
        float velocidadActual = Input.GetKey(KeyCode.LeftShift) ? velocidadSprint : velocidadMovimiento;

        // Movimiento en base a la orientación de la cámara
        Vector3 movimiento = transform.right * x + transform.forward * z;
        controlador.Move(movimiento * velocidadActual * Time.deltaTime);

        // Saltar
        if (Input.GetButtonDown("Jump") && estaEnSuelo)
        {
            velocidad.y = Mathf.Sqrt(fuerzaSalto * -2f * gravedad);
        }

        // Aplicar gravedad
        velocidad.y += gravedad * Time.deltaTime;
        controlador.Move(velocidad * Time.deltaTime);
    }

    void Rotacion()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse * Time.deltaTime;

        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f); // Limita la rotación vertical

        camara.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
