using UnityEngine; // Ottaa kayttoon Unityn perustoiminnot, kuten MonoBehaviour, Transform ja Debug.
using UnityEngine.InputSystem; // Ottaa kayttoon Unityn uuden Input Systemin luokat, kuten InputAction.

[RequireComponent(typeof(Rigidbody))]
// Maaritellaan julkinen (public) luokka nimelta PlayerController.
// Luokka perii (:) MonoBehaviour-luokan, jolloin se voidaan liittaa GameObjectiin komponentiksi
public class PlayerJump : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpForce = 6f;
    public float groundCheckDistance = 1.1f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);
        
        if (SpacePressed() && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool SpacePressed()
    {
        return Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame;
    }
}