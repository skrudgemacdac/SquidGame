using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Light : MonoBehaviour
{
    public Image image1;
    public Image image2;
    public Transform lightPos;
    float timeOff;
    float timeOn;

    void Start()
    {
        Instantiate(image1, lightPos.position, transform.rotation);
    }

    //IEnumerator mechanic()
    //{
    //    while (true)
    //    {
    //        timeOff = Random.Range(1f, 5f);
    //        timeOn = Random.Range(1f, 3f);
    //        yield return new WaitForSeconds(timeOn);

    //        yield return new WaitForSeconds(0.5f);


    //        yield return new WaitForSeconds(timeOff);

    //    }
    //}
}
