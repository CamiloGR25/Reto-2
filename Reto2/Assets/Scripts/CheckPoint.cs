using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col) {
        /*if(col.gameObject.tag=="Jugador"){
            
            Collider2D.enabled(this.gameObject);
            
        }*/
    }
}
