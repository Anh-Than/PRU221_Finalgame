using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencySystem : MonoBehaviour
{
    public static CurrencySystem instance;
    void Awake() => instance = this;

    public Text fertilizerCount;
    public int defaultFertilizer = 5;
    public int currentFertilizer;


    void Start()
    {
        fertilizerCount.text = defaultFertilizer.ToString();
        currentFertilizer = defaultFertilizer;
    }

    void Update()
    {
        fertilizerCount.text = currentFertilizer.ToString();
    }

    public void GainCurrency(int amount)
    {
        currentFertilizer += amount;
    }

    void ResetFertilizerCount()
    {
        currentFertilizer = defaultFertilizer;
        fertilizerCount.text = defaultFertilizer.ToString();
    }
}
