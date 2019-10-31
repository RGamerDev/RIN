using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager manager;

    private void OnTriggerEnter(Collider other)
    {
        manager.ToggleMovement(false);
        FindObjectOfType<GameManager>().Invoke("CompleteLevel", 3f);
    }
}
