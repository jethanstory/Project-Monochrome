using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltCheck : MonoBehaviour
{

    public ParticleSystem smoker;
    //public GameObject smokeSource;
    public bool smokeEnabled = true;
    // Start is called before the first frame update
    void Start()
    {
        smoker = GetComponent<ParticleSystem>();
        smokeEnabled = false;
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (smokeEnabled == !true)
    //     {
    //         smoker.Play();
    //     }
 
    //     else
    //     {
            
    //         smoker.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    //     }
 
    // }
    
    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "AnomalyBoltTrigger") //on the object you want to pick up set the tag to be anything, in this case "object"
            {
                if (smokeEnabled == false)
                {
                    //smoker.Play();
                    var emission = smoker.emission;
                    emission.enabled = true;
                }
 
                // else
                // {
                //     var emission = smoker.emission;
                //     emission.enabled = false;
                //     //smoker.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                    
                // }
            }
    }
    private void OnTriggerExit(Collider other)
    {
        //smoker.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        var emission = smoker.emission;
        emission.enabled = false;

    }

}
