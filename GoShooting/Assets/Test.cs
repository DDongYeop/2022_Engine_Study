using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    Image img;

    void Start()
    {
        img = GetComponent<Image>();
        img.color = new Color(1, 1, 1, 0.5f);
        //StartCoroutine(FadeIn(0.01f));
        StartCoroutine("Hello");
        StartCoroutine("Bye");
        Debug.Log("END");
    }

    IEnumerator Hello()
    {
        while (true)
        {
            Debug.Log("Hello");
            yield return new WaitForSeconds(2f);
            Debug.Log("Unreal!");
        }
    }

    IEnumerator Bye()
    {
        while (true)
        {
            Debug.Log("Bye");
            yield return new WaitForSeconds(2f);
            Debug.Log("1¹Ý");
        }
    }

    IEnumerator Bye(float waitTime)
    {
        Color myColor = img.color;

        for(float i =255; i >=0; i--)
        {
            myColor.a = i / 255;
            img.color = myColor;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
