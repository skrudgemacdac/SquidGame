using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Winning : MonoBehaviour
{
    public Player player;
    public Image winImage;
    public Coroutine _win;

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            _win = StartCoroutine(win());
        }
    }

    IEnumerator win() 
    {
        while (true) 
        {
            winImage.gameObject.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            StopCoroutine(_win);
            SceneManager.LoadScene(0);
            break;
        }
    }
}
