using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RadiationBarrierScr : MonoBehaviour
{
    public GameObject radiationMedium;
    public GameObject radiationHigh;
    public GameObject radiationLow;

    //public GameObject deathCanvas;
    public GameObject warningCanvas;

    public float deathTime;
    bool inLethal = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inLethal){
            deathTime += Time.deltaTime;
        }

        if (deathTime > 7)
        {
            //deathCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("GameOverRadiation");
            Debug.Log("HIT");
        }
    }
    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "RadiationFatal") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            radiationHigh.SetActive(true);
            inLethal = true;
            warningCanvas.SetActive(true);
        }

        if(other.gameObject.tag == "RadiationMedium") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            radiationMedium.SetActive(true);
        }
        if(other.gameObject.tag == "RadiationLow") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            radiationLow.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "RadiationFatal") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            radiationHigh.SetActive(false);
            deathTime = 0f;
            inLethal = false;
            warningCanvas.SetActive(false);
        }

        if(other.gameObject.tag == "RadiationMedium") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            radiationMedium.SetActive(false);
        }
        if(other.gameObject.tag == "RadiationLow") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            radiationLow.SetActive(false);
        }
    }
}
