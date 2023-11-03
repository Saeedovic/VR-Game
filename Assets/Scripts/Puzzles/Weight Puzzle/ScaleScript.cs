using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScaleScript : MonoBehaviour
{
    public TMP_Text weightText; 
    private float totalWeight = 0f;
    public float goalWeight = 10f;

    void OnCollisionEnter(Collision collision)
    {
        WeightedObject weightedObject = collision.gameObject.GetComponent<WeightedObject>();
        if (weightedObject != null)
        {
            totalWeight += weightedObject.weight;
            weightText.text = totalWeight + " kg"; 
        }
    }

    void OnCollisionExit(Collision collision)
    {
        WeightedObject weightedObject = collision.gameObject.GetComponent<WeightedObject>();
        if (weightedObject != null)
        {
            totalWeight -= weightedObject.weight;
            weightText.text = totalWeight + " kg"; // Update the weight text
        }
    }

    public void CheckWeight()
    {
        if (totalWeight == goalWeight)
        {
            Debug.Log("Weight Passed");
        }
    }
}
