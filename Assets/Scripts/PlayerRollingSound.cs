using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRollingSound : MonoBehaviour
{
    [SerializeField] LayerMask groundMask;

    public AudioSource rollingSound;

    
    [SerializeField] Rigidbody rb;

    public float height;

    
    // Start is called before the first frame update
    void Start()
    {
        height = GetComponent<Collider>().bounds.size.y;
        rollingSound = gameObject.GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (TouchGround())
        {
            rollingSound.enabled = true;

        }
        else
        { 
            rollingSound.enabled=false;
        }
              
            
    }

    public bool TouchGround ()
    {
        if (Physics.Raycast(transform.position, Vector3.down, height , groundMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
   
}
