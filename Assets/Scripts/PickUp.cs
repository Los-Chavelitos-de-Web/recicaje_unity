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
                obj.canMove = false;

                StartCoroutine(HandlePickup(anim, obj));
            } else {
                Debug.Log("Ya tiene un objeto en la mano");
            }
        }
    }

    private IEnumerator HandlePickup(Animator anim, Player obj) {
        yield return new WaitForSeconds(3);
        anim.SetBool("isRecoger", false);
        obj.canMove = true;
        this.gameObject.SetActive(false);
    }
}