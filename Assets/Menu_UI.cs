using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_UI : MonoBehaviour
{
    public GameObject Volume_panel;
    private AudioSource Audio;
    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play_Button(int sceneID)
    {

     SceneManager.LoadScene(sceneID);
    }
     public void settings_Button()
    {
      Volume_panel.SetActive(true);
    }
     public void Beak_Button(int sceneID)
    {
      SceneManager.LoadScene(sceneID);
      //Volume_panel.SetActive(false);
    }
     public void Quit_Button()
    {
     Application.Quit();
    }
}
