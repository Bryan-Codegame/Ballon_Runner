using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftX : MonoBehaviour
{
    public float speed;
    private PlayerControllerX playerControllerScript;
    private float leftBound = -10;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    // Update is called once per frame
    void Update()
    {
        // If game is not over, move to the left
        if (!playerControllerScript.gameOver)
        {
            //Aplica la transformación relativa al sistema de coordenadas mundial.
            //Space.World adapta al GameObject en las coordenadas globales para corregir el problema de la rotación en su eje mientras avanza en su traslación, ya que en el anterior runner se veía que hacían el efecto yoyo porque el eje cambiaba en sus coordenadas locales 
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }

        // If object goes off screen that is NOT the background, destroy it
        //Si un objeto pasa de -10 en x se destruyen y también si estos nos tienen un tag llamado "Background"
        if (transform.position.x < leftBound && !gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }

    }
}
