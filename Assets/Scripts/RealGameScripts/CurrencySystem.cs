using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencySystem : MonoBehaviour
{
    public static CurrencySystem instance;
    public Text floatingText;
    void Awake() => instance = this;

    public Text fertilizerCount;
    public int defaultFertilizer = 5;
    public int currentFertilizer;


    void Start()
    {
        fertilizerCount.text = defaultFertilizer.ToString();
        currentFertilizer = defaultFertilizer;
        floatingText.enabled = false;
    }

    void Update()
    {
        fertilizerCount.text = currentFertilizer.ToString();
    }

    public void GainCurrency(int amount)
    {
        floatingText.enabled = true;
        floatingText.GetComponent<Animator>().SetTrigger("gain");
        StartCoroutine(WaitAnimationGain(amount));        
    }

    IEnumerator WaitAnimationGain(int amount)
    {            
        floatingText.text = "+"+amount;      
        yield return new WaitForSeconds(0.8f);
        currentFertilizer += amount;
    }

    void ResetFertilizerCount()
    {
        currentFertilizer = defaultFertilizer;
        fertilizerCount.text = defaultFertilizer.ToString();
    }

    public bool EnoughCurrency(int val)
    {
        //Check if the val is equal or more than currency
        if (val <= currentFertilizer)
            return true;
        else
            return false;
    }

    public bool Use(int val)
    {
        if (EnoughCurrency(val))
        {
            currentFertilizer -= val;
            return true;
        }
        else
        {
            return false;

        }
    }
}
