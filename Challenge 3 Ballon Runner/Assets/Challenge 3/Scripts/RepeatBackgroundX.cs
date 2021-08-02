using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackgroundX : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;

    private void Start()
    {
        startPos = transform.position; // Establish the default starting position 
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; // Set repeat width to half of the background
        Debug.Log(repeatWidth);
    }

    private void Update()
    {
        // If background moves left by its repeat width, move it back to start position
        //La posición del background es de 45 entonces va restando con la actual en x  45-45 45-44 45-43,= 0, 1, 2, 3, 4, 5.. etc hasta llegar al valor de la mitad del tamaño del background el cual es 56.3 si es mayor o igual a este valor, la posición se reinicia a la inicial es decir que el bakcground avanzaría hasta tener una posición en x de -11.3 ya que 45 - 56.3 da ese valor
        if (startPos.x - transform.position.x >= repeatWidth)
        {
            transform.position = startPos;
        }
    }

 
}


