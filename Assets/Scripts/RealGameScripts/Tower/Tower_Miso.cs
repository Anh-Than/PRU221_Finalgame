using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static Assets.Scripts.RealGameScripts.GameSceneEnum;

public class Tower_Miso : Tower
{
    public int GainAmount;
    public float Cooldown;
    public bool isReady;
    public bool isPlayingHappyAnimation;
    public Animator animator;

    protected override void Start()
    {
        isReady = true;
        isPlayingHappyAnimation = false;
    }

    void Update()
    {
        if (!isPlayingHappyAnimation)
        {
            if(isReady)
            {
                animator.Play("MisoIdle");
            }
            if(!isReady)
            {
                animator.Play("MisoTired");
            }
            
        }
    }
    public void GainCurrency()
    {
        if (isReady)
        {
            Debug.Log("Here");
            CurrencySystem.instance.currentFertilizer += GainAmount;
            animator.Play("MisoHappy");
            isPlayingHappyAnimation |= true;
            StartCoroutine(waitAnimationHappy(2));
            isReady = false;
            StartCoroutine(startCooldown());
        }
    }

    public void OnMouseDown()
    {
        GainCurrency();
    }

    IEnumerator startCooldown()
    {
        yield return new WaitForSeconds(Cooldown);
        isReady = true;
    }

    IEnumerator waitAnimationHappy(int time)
    {
        yield return new WaitForSeconds((int)time);
        isPlayingHappyAnimation = false;
    }


}
