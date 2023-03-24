using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] int rotateSpeed;

    [SerializeField] AnimationCurve myCurve;


    [SerializeField] Animator _anim;

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

        _anim.Play("CoinGain");
        DontDestroyOnLoad(_anim.gameObject);

        GameManager.inst.IncrementScore();


        Destroy(gameObject);
    }

    void Awake()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        _anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        transform.Rotate(0,rotateSpeed,0, Space.World);
        transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);
    }
}
