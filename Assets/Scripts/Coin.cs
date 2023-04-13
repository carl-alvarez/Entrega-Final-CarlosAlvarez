using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] int rotateSpeed;

    [SerializeField] AnimationCurve myCurve;

    [SerializeField] Animator _anim;

    public AudioSource coinSound;

    public Renderer rend;// cambié el simple destroy por desactivar el renderer asi puedo escuchar el sonido cuando agarro las monedas, con el destroy de una no lo escucho pues no da el tiempo



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Obstacle>() != null)
        {
            
            Destroy(gameObject);
            return;
        }

       if (other.gameObject.name != "Player")
       {
            return;
       }

       if(other.gameObject.name == "Player")
        {
            coinSound.enabled = true;
            _anim.SetTrigger("chocar");
            GameManager.inst.IncrementScore();
            other.gameObject.GetComponent<PlayerMovement>().saltoActivo = false;
            rend.enabled = false;


            Destroy(gameObject, 0.48f);
        }
        
        //DontDestroyOnLoad(_anim.gameObject);
                
    }
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        coinSound = gameObject.GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        _anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        transform.Rotate(0,rotateSpeed,0, Space.World);
        transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);
    }
}
