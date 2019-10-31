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

    //private IEnumerator PopHeart()
    //{
    //    Hearts[index].GetComponent<Animator>().SetBool("hasFailed", true);

    //    yield return new WaitForSeconds(0.15f);

    //    while (Hearts[index].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 1 || Hearts[index].GetComponent<Animator>().IsInTransition(0))
    //    {
    //        yield return null;
    //    }

    //    Hearts[index].GetComponent<Animator>().SetBool("hasFailed", false);
        
    //    yield return new WaitForSeconds(0.15f);

    //    Hearts[index].SetActive(false);
        
    //}
}
