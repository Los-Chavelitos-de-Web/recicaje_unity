using System.Collections;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            Player obj = other.GetComponent<Player>();
            Animator anim = other.GetComponent<Animator>();

            if (obj.objPick == null) {
                obj.objPick = this.gameObject;
                anim.SetBool("isRecoger", true);

                StartCoroutine(changeState(anim));
            } else {
                Debug.Log("Ya tiene un objeto en la mano");
            }
        }
    }

    private IEnumerator changeState(Animator anim)
    {
        yield return new WaitForSeconds(3);
        anim.SetBool("isRecoger", false);
        this.gameObject.SetActive(false);
    }
}