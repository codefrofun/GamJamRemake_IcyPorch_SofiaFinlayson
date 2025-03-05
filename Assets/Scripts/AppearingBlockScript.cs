using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearingBlockScript : MonoBehaviour
{
    public GameObject block;
    public float delayTime = 1f;

    private void Start()
    {
        block.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player is found");
            StartCoroutine(ShowBlockAfterDelay());
        }
    }

    private IEnumerator ShowBlockAfterDelay()
    {
        yield return new WaitForSeconds(delayTime);
        block.SetActive(true);
    }
}
