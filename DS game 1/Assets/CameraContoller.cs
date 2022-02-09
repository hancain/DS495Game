using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoller : MonoBehaviour
{
    private Transform player;   // Player reference
    private Vector3 zoffset;    // Z offset - for camera rotation  
    private Vector3 negzoffset; // Negative Z offset 
    private Vector3 xoffset;    // X offset 
    private Vector3 negxoffset; // Negative X offset 
    private Vector3 direction;  // Direction reference 
    private float playerYrot;   // Y rotation of player object 


    // Start is called before the first frame update
    void Start()
    {
        // Get player refernce 
        player = GameObject.Find("Player").transform;

        // Set directional offsets 
        zoffset = new Vector3(0, 1.25f, -2);
        xoffset = new Vector3(-2, 1.25f, 0);
        negzoffset = new Vector3(0, 1.25f, 2);
        negxoffset = new Vector3(2, 1.25f, 0);

    }

    // Update is called once per frame
    void Update()
    {

        // Get player y rotation 
        playerYrot = player.transform.eulerAngles.y;
        // Adjust camera to player rotation 
        transform.rotation = Quaternion.Euler(15, playerYrot, 0);

        // Adjust X and Z positions based on rotation 
        if (playerYrot < 89 && playerYrot > -89)
        {
            direction = player.transform.forward + zoffset;
        }
        else if (playerYrot > 89 && playerYrot < 179)
        {
            direction = player.transform.forward + xoffset;
        }
        else if (playerYrot < -89 && playerYrot > -179 || playerYrot > 269 && playerYrot < 359)
        {
            direction = player.transform.forward + negxoffset;
        }
        else if (playerYrot > 179 || playerYrot < -179)
        {
            direction = player.transform.forward + negzoffset;
        }

        // Transform camera position 
        transform.position = player.transform.position + direction;

    }
}
