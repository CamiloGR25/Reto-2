using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frutas : MonoBehaviour
{
    private AudioSource audio;
    
    void Start()
    {
        audio=GetComponent<AudioSource>();
    }
 
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag=="Jugador"){
            audio.Play();
            Destroy(this.gameObject, 0.15f);
            
        }
    }
}
