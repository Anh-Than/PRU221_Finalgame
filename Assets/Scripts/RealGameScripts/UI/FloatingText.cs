using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    public void SetActiveFalse()
    {
        gameObject.GetComponent<Text>().enabled = false;
    }

}
