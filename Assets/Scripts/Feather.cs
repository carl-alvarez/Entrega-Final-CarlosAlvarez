using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feather : MonoBehaviour
{
    
    [SerializeField] int rotateSpeed;

    [SerializeField] AnimationCurve myCurve;

    public AudioSource featherSound;

    public Transform size; //no pude usar el mismo método de desactivar renderer con esta pluma por que asumo es un objeto creado de manera diferente en blender y al meterle el componente renderer no me lo desactivaba, asi que elegí cambiarle el tamaño a 0 para conseguir el efecto similar

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {            
            Destroy(gameObject);
            return;
        }

        if (other.gameObject.name != "Player")
        {
            return;
        }

        if (other.gameObject.name == "Player") 
        {
            featherSound.enabled = true;
            other.gameObject.GetComponent<PlayerMovement>().saltoActivo = true;
            other.gameObject.GetComponent<PlayerMovement>().JumpReset();
            size.localScale = new Vector3(0,0,0);

            Destroy(gameObject, 1f);
        }
        

    }

    void Start()
    {
        size = GetComponent<Transform>();
        
        featherSound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
        transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);
    }
}
