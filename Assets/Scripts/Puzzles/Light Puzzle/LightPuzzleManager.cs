using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPuzzleManager : MonoBehaviour
{
    public Lighters[] lights;

    void Start()
    {
        
        lights = new Lighters[4];

        
        lights[0] = GameObject.Find("Light1").GetComponent<Lighters>();
        lights[1] = GameObject.Find("Light2").GetComponent<Lighters>();
        lights[2] = GameObject.Find("Light3").GetComponent<Lighters>();
        lights[3] = GameObject.Find("Light4").GetComponent<Lighters>();
    }

    public void ButtonAction1()
    {
        
        lights[3].isOn = !lights[3].isOn;
        lights[0].isOn = !lights[0].isOn;
    }

    public void ButtonAction2()
    {
        foreach (Lighters light in lights)
        {
            light.isOn = false;
        }
    }
    public void ButtonAction3()
    {
        
        lights[2].isOn = !lights[2].isOn;
    }
    public void ButtonAction4()
    {
        
        lights[1].isOn = !lights[3].isOn;
    }



    void Update()
    {
        
        bool allOn = true;
        foreach (Lighters light in lights)
        {
            if (!light.isOn)
            {
                allOn = false;
                break;
            }
        }

        
        if (allOn)
        {
            Debug.Log("DOOR OPENED");
        }
    }
}