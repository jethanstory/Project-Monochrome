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

    public float invenTime;

    public bool isOnTest = false;

    // Start is called before the first frame update
    void Start()
    {
        activeInven = false;
    }

    // Update is called once per frame
    void Update() //void FixedUpdate()
    {
        CheckInvenAdv();
        // if (Input.GetKeyDown(KeyCode.Tab))
        // {
        //     isOnTest = true;
        //     CheckInven();





        //     // Time.timeScale = 0;
        //     // menuCanvas.SetActive(true);
        //     // playerHudCanvas.SetActive(false);

        //     // if (Input.GetKeyDown(KeyCode.Escape))
        //     // {
        //     // activeMenu =
        //     // // Time.timeScale = 1;
        //     // // menuCanvas.SetActive(false);
        //     // // playerHudCanvas.SetActive(true);
        //     // }
        //     // Txt = GameObject.Find ("").GetComponent<Text> ();
        //     // Txt.text = "";
        // }

        // else if (isOnTest && Input.anyKey)
        // {
        //     invenCanvas.SetActive(false);
        //     isOnTest = false;
        // }



    }


    public void CheckInven()
    {
        if (activeInven)
        {
            activeInven = false;
            invenCanvas.SetActive(false);
            fpsPlayer.GetComponent<GamePauseScr>().enabled = true;
        }
        else
        {
            activeInven = true;
            invenCanvas.SetActive(true);
            fpsPlayer.GetComponent<GamePauseScr>().enabled = false;

        }
    }

    public void CheckInvenAdv()
    {
        //if (activeInven && Input.anyKey)
        if (activeInven)
        {
            invenTime += Time.deltaTime;
            if (invenTime > 1)
            {
                activeInven = false;
                invenCanvas.SetActive(false);
                fpsPlayer.GetComponent<GamePauseScr>().enabled = true;
            }

        }
        else if (!activeInven && Input.GetKeyDown(KeyCode.Tab))
        {
            invenTime = 0f;
            activeInven = true;
            invenCanvas.SetActive(true);
            fpsPlayer.GetComponent<GamePauseScr>().enabled = false;

        }
    }
}
