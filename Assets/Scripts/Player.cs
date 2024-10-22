using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 10.0f;
    private float rotationSpeed = 100.0f;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
        animator.SetFloat("MovX", rotation);
        animator.SetFloat("MovY", translation);
    }
}
