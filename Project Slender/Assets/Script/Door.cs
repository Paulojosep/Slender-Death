using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isOpen = false;
    
	void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player" && !isOpen){
            int objts = other.gameObject.GetComponent<PlayerActions>().objsQt;
            if(objts >= 8){
                transform.parent.GetComponent<Animation>().Play();
                isOpen = true;
            }
            Debug.Log("Door");
        }
    }
}
