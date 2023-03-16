using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneScr : MonoBehaviour
{
    float startTime = 0f;
    public GameObject introText;
    public GameObject introText2;
    public GameObject introText3;
    public GameObject introText4;
    public GameObject introText5;
    public GameObject introText6;
    public GameObject loadingText;
    public bool checkEnd;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        checkEnd = false;
        //SceneManager.LoadScene("MainZone");
    }

    // Update is called once per frame
    void Update()
    {
        startTime += Time.deltaTime;
        introText.SetActive(true);
        if (startTime > 5)
        {
            introText.SetActive(false);
            introText2.SetActive(true);

            if (startTime > 10)
            {
                introText2.SetActive(false);
                introText3.SetActive(true);

                if (startTime > 15)
                {
                    introText3.SetActive(false);
                    introText4.SetActive(true);
                    if (startTime > 20)
                    {
                        introText4.SetActive(false);
                        introText5.SetActive(true);
                        if (startTime > 25)
                        {
                            introText5.SetActive(false);
                            introText6.SetActive(true);
                            if (startTime > 30)
                            {
                                introText6.SetActive(false);
                                loadingText.SetActive(true);
                                SceneManager.LoadScene("MainZone");
                                checkEnd = true;
                            }
                        }
                    }
                }
            }
        }
        if (checkEnd)
        {
            startTime = 0f;
            checkEnd = false;
        }
    }
}
