using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnomalySoundTriggerScr : MonoBehaviour
{

    public GameObject sound;

    public float reactionTime;
    public GameObject fpsPlayer;



    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent <ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        

        
    }
}
