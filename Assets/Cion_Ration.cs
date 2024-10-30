using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cion_Ration : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed of rotation
   
    void Update()
    {
        // Rotate the coin around its local Y-axis
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
    }

   
}
