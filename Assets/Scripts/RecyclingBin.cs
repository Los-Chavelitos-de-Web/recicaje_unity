using UnityEngine;
using System.Collections;

public class RecyclingBin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            Animator anim = other.GetComponent<Animator>();

            if (player.objPick != null)
            {
                if (this.CompareTag("cReciclar") && player.objPick.CompareTag("objReciclable"))
                {
                    Debug.Log("Objeto reciclable depositado en el contenedor reciclable.");
                    player.objPick = null;
                    anim.SetBool("isTirar", true);
                    player.canMove = false;
                    StartCoroutine(HandlePickup(anim, player));
                }
                else if (this.CompareTag("cNoReciclar") && player.objPick.CompareTag("objNoReciclable"))
                {
                    Debug.Log("Objeto no reciclable depositado en el contenedor no reciclable.");
                    player.objPick = null;
                    anim.SetBool("isTirar", true);
                    player.canMove = false;
                    StartCoroutine(HandlePickup(anim, player));
                }
                else
                {
                    Debug.Log("Tipo de objeto no coincide con el contenedor.");
                }
            }
            else
            {
                Debug.Log("No hay objeto para depositar.");
            }
        }
    }

    private IEnumerator HandlePickup(Animator anim, Player obj) {
        yield return new WaitForSeconds(3);
        anim.SetBool("isTirar", false);
        obj.canMove = true;
    }
}