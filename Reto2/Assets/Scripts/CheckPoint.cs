using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private BoxCollider2D miCollider;
    // Start is called before the first frame update
    void Start()
    {
        miCollider=GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag=="Jugador"){
            
            miCollider.enabled=false;
            
        }
    }
}
