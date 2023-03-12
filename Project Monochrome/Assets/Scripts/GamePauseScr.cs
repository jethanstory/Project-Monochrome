using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseScr : MonoBehaviour
{
    public GameObject menuCanvas;
    public bool activeMenu; 
    public Text Txt;
    public Text Txt2;
    public GameObject fpsPlayer;
    public GameObject invenCanvas;

    // Start is called before the first frame update
    void Start()
    {
        activeMenu = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            checkMenu();
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


            // Txt = GameObject.Find ("FlareNumber").GetComponent<Text> ();
            // Txt.text = " ";
            // Txt2 = GameObject.Find ("BoltsNumber").GetComponent<Text> ();
            // Txt2.text = " ";
        }


    }


    public void checkMenu()
    {
        if (activeMenu)
        {
            activeMenu = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            menuCanvas.SetActive(false);
            fpsPlayer.GetComponent<InventoryMenuScr>().enabled = true;
            
        }
        else
        {
            // Txt = GameObject.Find ("BoltsNumber").GetComponent<Text> ();
            // Txt.text = fpsPlayer.GetComponent<BoltPickupThrow>().boltCount.ToString();
            activeMenu = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            menuCanvas.SetActive(true);
            //invenCanvas.SetActive(false);
            fpsPlayer.GetComponent<InventoryMenuScr>().enabled = false;
            // Txt = GameObject.Find ("FlareNumber").GetComponent<Text> ();
            // Txt.text = " ";
            // Txt2 = GameObject.Find ("BoltsNumber").GetComponent<Text> ();
            // Txt2.text = " ";

        }
    }
}
