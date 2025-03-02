using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingBlockScript : MonoBehaviour
{
    public bool isDestroyed = false;

    //public GameObject breakEffect;      with particle system?

    //public AudioClip breakSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BreakBlock();
        }
    }

    void BreakBlock()
    {
        if (isDestroyed) return; // Won't break block if already broken

        isDestroyed = true;

        Destroy(gameObject);

        Debug.Log("Block destroyed!");
    }
}