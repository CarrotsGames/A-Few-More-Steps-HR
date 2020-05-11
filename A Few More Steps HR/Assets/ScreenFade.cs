using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScreenFade : MonoBehaviour
{
 
    private IEnumerator coroutine;
    public  bool fadeOut;
    public string nextScene;
    // Start is called before the first frame update
    private void Start()
    {
   
        Image image = GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = 2;
        image.color = tempColor;
        BeginFadeIn();
    }
   
    public void BeginFadeIn()
    {
        coroutine = FadeIn();
        StartCoroutine(FadeIn());
        StartCoroutine(Stop());
    }
    public void BeginFadeOut()
    {
        coroutine = FadeIn();
        StartCoroutine(FadeOut());
        StartCoroutine(NewLevel());
    }
    public void BeginCutscene()
    {
        coroutine = CutsceneFade();
        StartCoroutine(CutsceneFade());
    }
    public void EndCutsceneFade()
    {
        StopCoroutine(CutsceneFade());

        coroutine = CutsceneFadeEnd();
        StartCoroutine(CutsceneFadeEnd());

    }

    IEnumerator CutsceneFade()
    {

        while (true) // you can put there some other condition
        {
            Image image = GetComponent<Image>();
            var tempColor = image.color;
            tempColor.a = 2;
            image.color += tempColor * Time.deltaTime * 3;
            yield return new WaitForSeconds(0);

        }


    }
    IEnumerator CutsceneFadeEnd()
    {

        while (true) // you can put there some other condition
        {
            Image image = GetComponent<Image>();
         
            var tempColor = image.color;
            tempColor.a = 2;
         
            image.color -= tempColor * Time.deltaTime * 6;
            yield return new WaitForSeconds(0);
        }


    }
    // Tints the screen to white
    public IEnumerator FadeIn()
    {
        while (true) // you can put there some other condition
        {
            Image image = GetComponent<Image>();
            var tempColor = image.color;
            tempColor.a = 2;
            image.color -= tempColor * Time.deltaTime;
            yield return new WaitForSeconds(0);
            
        }
    }
    // Tints the screen to black

    public IEnumerator FadeOut()
    {
        while (true) // you can put there some other condition
        {
            Image image = GetComponent<Image>();
            var tempColor = image.color;
            tempColor.a = 2;
            image.color += tempColor * Time.deltaTime;
            yield return new WaitForSeconds(0);

        }
    }
    public IEnumerator Stop()
    {
        yield return new WaitForSeconds(1);
        StopAllCoroutines();

    }
    public IEnumerator NewLevel()
    {
        yield return new WaitForSeconds(1);
        StopAllCoroutines();
         
        SceneManager.LoadScene(nextScene);
    }
}
 
