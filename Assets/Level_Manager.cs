using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level_Manager : MonoBehaviour
{
   
    public TMP_Text Level_Display_Text;
    public GameObject Level_1;
    public GameObject Level_2;
    public GameObject Level_3;
    public GameObject Level_4;
    public GameObject Level_5;

    // Start is called before the first frame update
    void Start()
    {
        Level_1.SetActive(true);
        Level_Display_Text.text = "LEVEL 1";
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] Enemy_Count = GameObject.FindGameObjectsWithTag("Enemy");

        // Check if Level 1 is active and no enemies are left in Level 1
        if (Level_1.activeSelf && Enemy_Count.Length == 0)
        {
            Level_1.SetActive(false);   // Deactivate Level 1
            Level_Display_Text.text = "LEVEL 2"; // Level 2 Text Display
            Level_2.SetActive(true);    // Activate Level 2
            Debug.Log("Level_2 activated");
        }
        // Check if Level 2 is active and no enemies are left in Level 2
        else if (Level_2.activeSelf && Enemy_Count.Length == 0)
        {
            Level_2.SetActive(false);   // Deactivate Level 2
            Level_Display_Text.text = "LEVEL 3"; // Level 3 Text Display
            Level_3.SetActive(true);    // Activate Level 3
            Debug.Log("Level_3 activated");
        }
        else if (Level_3.activeSelf && Enemy_Count.Length == 0)
        {
            Level_3.SetActive(false);   // Deactivate Level 3
            Level_Display_Text.text = "LEVEL 4"; // Level 4 Text Display
            Level_4.SetActive(true);    // Activate Level 4
            Debug.Log("Level_4 activated");
        }
        else if (Level_4.activeSelf && Enemy_Count.Length == 0)
        {
            Level_4.SetActive(false);   // Deactivate Level 4
            Level_Display_Text.text = "LEVEL 5"; // Level 5 Text Display
            Level_5.SetActive(true);    // Activate Level 5
            Debug.Log("Level_5 activated");
        }
        else
        {
            Debug.Log("Please kill all enemies to advance.");
        }
    }
}
