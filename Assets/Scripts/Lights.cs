using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    private Color[] colours = new Color[6];
    public Light controllerLight;
    public float time;
    public float repeatRate;
    // Start is called before the first frame update
    void Start()
    {
        colours[0]=Color.blue;
        colours[1]=Color.cyan;
        colours[2]=Color.green;
        colours[3]=Color.magenta;
        colours[4]=Color.red;
        colours[5]=Color.yellow;

        InvokeRepeating("ChangeColour", time, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeColour()
    {
        controllerLight.color = colours[Random.Range(0, colours.Length -1)];
    }
}
