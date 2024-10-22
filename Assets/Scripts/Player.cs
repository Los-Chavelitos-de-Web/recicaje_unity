using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 10.0f;
    private float rotationSpeed = 100.0f;
    private Animator animator;
    private Rigidbody rb;
    public GameObject objPick;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float translationInput = Input.GetAxis("Vertical");
        float rotationInput = Input.GetAxis("Horizontal");

        animator.SetFloat("MovX", rotationInput);
        animator.SetFloat("MovY", translationInput);

        Vector3 movement = transform.forward * translationInput * speed * Time.deltaTime;

        // Comprobar colisión con raycasting
        if (!Physics.Raycast(transform.position, movement.normalized, movement.magnitude))
        {
            // Mover el Rigidbody solo si no hay colisión
            rb.MovePosition(rb.position + movement);
        }

        Quaternion turnRotation = Quaternion.Euler(0, rotationInput * rotationSpeed * Time.deltaTime, 0);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}