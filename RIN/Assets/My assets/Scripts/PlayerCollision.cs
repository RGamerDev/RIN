using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    GameManager game;
    AudioManager audiom;

    private void Start()
    {
        game = FindObjectOfType<GameManager>();
        audiom = FindObjectOfType<AudioManager>();
        GameManager.PlayerFailed = false;
        GameManager.PlayerDied = false;
    }

    private void Update()
    {
        if (!GameManager.PlayerFailed)
        {
            if (transform.position.y < -2)
            {
                FindObjectOfType<ScoreAndHealth>().LoseHealth();
                game.Invoke("Respawn", 1f);
                GameManager.PlayerFailed = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            if (!GameManager.PlayerFailed)
            {
                GetComponent<Animator>().SetBool("hasFailed", true);
                game.ToggleMovement(false);
                if (audiom != null)
                {
                    audiom.Play("Collision");
                }
                FindObjectOfType<ScoreAndHealth>().LoseHealth();
                game.Invoke("Respawn", 2f);
                GameManager.PlayerFailed = true;
            }
        }
    }
}
