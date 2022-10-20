using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(ParticleSystem))]
public class BoltCheck : MonoBehaviour
{

    public GameObject smoker;
    //public GameObject smokeSource;
    public bool smokeEnabled;
    public GameObject sound;

    // Start is called before the first frame update
    void Start()
    {
        //smoker = GetComponent<ParticleSystem>();
        //smoker.Stop();

        //smoker.GetComponent <ParticleSystem>().Stop();
        gameObject.GetComponent <ParticleSystem>().Stop();
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
                //if (smokeEnabled == false)
                //{
                    //smoker.Play();
                    //var emission = smoker.emission;
                    //ParticleSystem.EmissionModule emission = smoker.emission;
                    //smoker.emission.enabled = true;
                    //smoker.GetComponent<ParticleSystem>().enableEmission = true;
                    //smokeEnabled = true;
                    
                    //smoker.Play();
                    other.gameObject.GetComponent <ParticleSystem>().Play();
                    //smoker.GetComponent <ParticleSystem>().Play();
                    sound.SetActive(true);

                    //ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
                    //em.enabled = true;
                //}
 
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
        if(other.gameObject.tag == "AnomalyBoltTrigger") //on the object you want to pick up set the tag to be anything, in this case "object"
            {
        //smoker.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        //var emission = smoker.emission;
        //ParticleSystem.EmissionModule emission = smoker.emission;
        //smokeEnabled = false;
        //smoker.emission.enabled = false;
        //smoker.GetComponent<ParticleSystem>().enableEmission = false;

        //smoker.GetComponent <ParticleSystem>().Stop();
                other.gameObject.GetComponent <ParticleSystem>().Stop();
            

        //sound.SetActive(false);

        //ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
        //em.enabled = false;

        //smoker.Stop();
            }

    }

}
