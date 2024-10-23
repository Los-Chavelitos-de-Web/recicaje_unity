using UnityEngine;

public class Player : MonoBehaviour
{
    public bool canMove = true;
    public GameObject objPick;
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
        if (!canMove) return;

        float translationInput = Input.GetAxis("Vertical");
        float rotationInput = Input.GetAxis("Horizontal");

        animator.SetFloat("MovX", rotationInput);
        animator.SetFloat("MovY", translationInput);

        Vector3 movement = transform.forward * translationInput * speed * Time.deltaTime;

        if (!Physics.Raycast(transform.position, movement.normalized, movement.magnitude))
        {
            rb.MovePosition(rb.position + movement);
        }

        Quaternion turnRotation = Quaternion.Euler(0, rotationInput * rotationSpeed * Time.deltaTime, 0);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}