using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSceneChangeScript : MonoBehaviour
{
    // script borrowed from previous assignment.
    [SerializeField] private string sceneName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!string.IsNullOrEmpty(sceneName))
            {
                Debug.Log("Player entered trigger. Changing scene to: " + sceneName);

                if (GameManagerScript.Instance != null)
                {
                    GameManagerScript.Instance.sceneManager.LoadSceneToSpawnPosition(sceneName);
                }
                else
                {
                    Debug.LogError("Game Manager instance is not found!");
                }
            }
        }
    }
}
