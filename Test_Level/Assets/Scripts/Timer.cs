using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeStart = 50f;
    public Text timerText;
    public Player player;
    public AudioSource shot;
    private Coroutine _count;

    void Start()
    {
        timerText.text = timeStart.ToString();
        _count = StartCoroutine(count());
    }

    void Update()
    {
        timeStart -= Time.deltaTime;
        timerText.text = Mathf.Round(timeStart).ToString();
    }

    IEnumerator count() 
    {
        while (true)
        {
            if (timeStart <= 0)
            {
                shot.gameObject.SetActive(true);
                timerText.gameObject.SetActive(false);
                player.Die();
                yield return new WaitForSeconds(8f);
                StopCoroutine(_count);
                SceneManager.LoadScene(0);
                break;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
