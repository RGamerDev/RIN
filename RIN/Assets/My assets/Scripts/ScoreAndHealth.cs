using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAndHealth : MonoBehaviour
{
    public GameObject Player;
    public Text Distance;
    public List<GameObject> Hearts;
    int index = 0;

    // Update is called once per frame
    void Update()
    {
        Distance.text = $"Distance: {(Player.transform.position.z + 3).ToString("0")}";
    }

    public void LoseHealth()
    {
        if (index < Hearts.Count - 1)
        {
            //StartCoroutine("PopHeart");
            Hearts[index].SetActive(false);
            index++;
            return;
        }

        GameManager.PlayerDied = true;
        FindObjectOfType<GameManager>().GameOver();
    }

}
