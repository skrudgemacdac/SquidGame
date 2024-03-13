using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Doll : MonoBehaviour
{
    float timeOff;
    float timeOn;
    public Player player;
    private Coroutine _mechanic;
    public Image green;
    public Image red;
    public AudioSource song, redLight, greenLight, shot;
    //public Animator animator1;

    public void Start()
    {
        //gameObject.transform.Rotate(0f, 0f, 0f);
        //gameObject.transform.position = new Vector3(257.5f, 1.11f, 427.3f);
        //yield return new WaitForSeconds(5f);
        _mechanic = StartCoroutine(mechanic());
    }

    IEnumerator mechanic()
    {
        while (true)
        {
            timeOff = Random.Range(1f, 5f);
            timeOn = Random.Range(1f, 5f);

            //song.mute = true;
            greenLight.PlayOneShot(greenLight.clip);
            green.gameObject.SetActive(true);
            red.gameObject.SetActive(false);
            gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
            gameObject.transform.position = new Vector3(257.5f, 0, 427.3f);

            yield return new WaitForSeconds(timeOff);

            redLight.PlayOneShot(redLight.clip);
            red.gameObject.SetActive(true);
            green.gameObject.SetActive(false);
            yield return new WaitForSeconds(redLight.clip.length);
            //song.mute = false;
            song.time = 0f;
            gameObject.transform.Rotate(0f, 180f, 0f);
            gameObject.transform.position = new Vector3(257.3f, 0, 421.11f);
            //myAudio.GetComponent<AudioSource>().mute = false;
            while (timeOn > 0.0f)
            {
                if (player._rigidbody.velocity.magnitude > 1)
                {
                    shot.gameObject.SetActive(true);
                    player.Die();
                    yield return new WaitForSeconds(8f);
                    StopCoroutine(_mechanic);
                    SceneManager.LoadScene(0);
                    break;
                }
                timeOn -= Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}