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
        float translationInput = Input.GetAxis("Vertical");
        float rotationInput = Input.GetAxis("Horizontal");

        animator.SetFloat("MovX", rotationInput);
        animator.SetFloat("MovY", translationInput);

        float translation = translationInput * speed * Time.deltaTime;
        float rotation = rotationInput * rotationSpeed * Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
    }

}
