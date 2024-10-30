using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Script : MonoBehaviour
{
    public GameObject level1;  // Reference to the Level 1 GameObject
    public GameObject level2;  // Reference to the Level 2 GameObject
    public GameObject level3;  // Reference to the Level 3 GameObject
    private int currentLevel = 1;  // Tracks the current level

 private void Start()
    {
        // Initialize by activating Level 1 and deactivating the others
        SetActiveLevel(1);
    }

    // Method to activate a specific level and deactivate others
    public void SetActiveLevel(int level)
    {
        currentLevel = level;

        if (level1 != null) level1.SetActive(level == 1);
        if (level2 != null) level2.SetActive(level == 2);
        if (level3 != null) level3.SetActive(level == 3);
    }

    // Method to transition to the next level
    public void NextLevel()
    {
        if (currentLevel == 1)
        {
            SetActiveLevel(2);  // Transition from Level 1 to Level 2
        }
        else if (currentLevel == 2)
        {
            SetActiveLevel(3);  // Transition from Level 2 to Level 3
        }
        else if (currentLevel == 3)
        {
            Debug.Log("You have completed all levels!"); // Placeholder for game end or restart
        }
    }
}   