using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Vector3 origin = new Vector3(0f, 1f, -3f);
    public GameObject Player;
    public static bool PlayerFailed = false;
    public static bool PlayerDied = false;
    public List<GameObject> Panels;
    public Text Score;
    public GameObject env;

    public void GameOver()
    {
        Panels[0].SetActive(true);
        Score.text = $"Furthest Distance: {PlayerPrefs.GetFloat("Score").ToString("0")}";
        Time.timeScale = 0f;
        PlayerFailed = false;
    }

    public void CompleteLevel()
    {
        Panels[1].SetActive(true);
        Time.timeScale = 0f;
    }

    public void Respawn()
    {
        if (!PlayerDied)
        {
            Player.GetComponent<Animator>().SetBool("hasFailed", false);
            PlayerPrefs.SetFloat("Score", PlayerPrefs.GetFloat("Score") < Player.transform.position.z + 3 ? Player.transform.position.z + 3 : PlayerPrefs.GetFloat("Score"));
            Player.transform.position = origin;
            env.transform.rotation = SceneManager.GetActiveScene().buildIndex != 2 ? new Quaternion(0f, 0f, 0f, 0f) : new Quaternion(0f, 0f, 180f, 0f);
            Physics.gravity = new Vector3(0f, -9.81f, 0f);
            ToggleMovement(true);
            PlayerFailed = false;
            return;
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    public void LoadSceneAt(int index)
    {
        SceneManager.LoadScene(index);
        Time.timeScale = 1f;
    }

    public void ToggleMovement(bool toggle)
    {
        Player.gameObject.GetComponent<PlayerMovement>().enabled = toggle;
        Player.gameObject.GetComponent<Rigidbody>().useGravity = toggle;
    }

    public void PlaySound(string name)
    {
        if (FindObjectOfType<AudioManager>() != null)
        {
            FindObjectOfType<AudioManager>().Play(name); 
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        Physics.gravity = new Vector3(0f, -9.81f, 0f);
    }

    public void Quit()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
