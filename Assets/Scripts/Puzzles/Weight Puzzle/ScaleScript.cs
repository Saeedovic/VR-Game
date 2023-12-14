using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScaleScript : MonoBehaviour
{
    public TMP_Text weightText; 
    private float totalWeight = 0f;
    public float goalWeight = 16f;
    public Light light2;

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
            weightText.text = totalWeight + " kg"; 
        }
    }

    public void Update()
    {
        if (totalWeight == goalWeight)
        {
            light2.color = Color.green;
            Debug.Log("Weight Passed");
        }

        if(totalWeight > goalWeight || totalWeight < goalWeight)
        {
            light2.color = Color.red;
        }
    }
}
