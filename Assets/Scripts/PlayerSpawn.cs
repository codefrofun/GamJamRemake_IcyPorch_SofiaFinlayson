using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject player;
    private GameObject clone;
    private int playerCount;
    public int maxPlayerCount;

    public float delayTime = 2f;

    private void Start()
    {
        delayTime = 0f;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            if (playerCount < maxPlayerCount)
            {
                playerCount++;
                Debug.Log("Ive been pressed");
                StartCoroutine(ShowBlockAfterDelay());
                delayTime = 2f;
                
            }
        }
    }

    private IEnumerator ShowBlockAfterDelay()
    {
        yield return new WaitForSeconds(delayTime);
        player = Instantiate(player, transform.position, Quaternion.identity);
    }
}
