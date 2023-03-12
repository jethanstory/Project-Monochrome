using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuScr : MonoBehaviour
{
    public GameObject invenCanvas;
    public bool activeInven; 
    public Text Txt;
    public GameObject fpsPlayer;

    // Start is called before the first frame update
    void Start()
    {
        activeInven = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CheckInven();
            // Time.timeScale = 0;
            // menuCanvas.SetActive(true);
            // playerHudCanvas.SetActive(false);

            // if (Input.GetKeyDown(KeyCode.Escape))
            // {
            // activeMenu =
            // // Time.timeScale = 1;
            // // menuCanvas.SetActive(false);
            // // playerHudCanvas.SetActive(true);
            // }
            // Txt = GameObject.Find ("").GetComponent<Text> ();
            // Txt.text = "";
        }


    }


    public void CheckInven()
    {
        if (activeInven)
        {
            activeInven = false;
            invenCanvas.SetActive(false);
        }
        else
        {
            activeInven = true;
            invenCanvas.SetActive(true);

        }
    }
}
