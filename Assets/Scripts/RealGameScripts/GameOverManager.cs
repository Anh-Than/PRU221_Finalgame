using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject disowned;
    public GameObject[] Uis;

    float defaultR;
    int i;
    float fadeMargin = 0.01f;
    float interval = 0.02f;
    
    void Start()
    {
        defaultR = 0.2f;
        gameOverPanel.SetActive(false);
        i = 1;
        foreach (var obj in Uis)
        {
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Debug.Log("Here");
            gameOverPanel.SetActive(true);
            disowned.SetActive(false);
            StartCoroutine(PanelFadeIn());
            StartCoroutine(ShowFunctionPanel());
        }
    }

    IEnumerator PanelFadeIn()
    {
        if(i < (1/fadeMargin))
        {
            i++;
            gameOverPanel.GetComponent<Image>().color = new Color(0, 0, 0, defaultR + (fadeMargin * i));
            yield return new WaitForSeconds(interval);
            StartCoroutine(PanelFadeIn());
        }     
    }

    IEnumerator ShowFunctionPanel()
    {
        yield return new WaitForSeconds(3);
        foreach (var obj in Uis)
        {
            obj.SetActive(true);
        }
    }
}
