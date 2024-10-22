using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 10.0f;
    private float rotationSpeed = 100.0f;
    private Animator animator;
    private Rigidbody rb;

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

        // Calcula el movimiento y la rotación
        Vector3 movement = transform.forward * translationInput * speed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0, rotationInput * rotationSpeed * Time.deltaTime, 0);

        // Mueve el Rigidbody
        rb.MovePosition(rb.position + movement);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}