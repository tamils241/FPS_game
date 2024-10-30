using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manage : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip click;
    public AudioClip hower;
    
    public void OnClickButton()
    {
      Audio.PlayOneShot(click);
    }
    public void OnhowerButton()
    {
      Audio.PlayOneShot(hower);
    }
}
