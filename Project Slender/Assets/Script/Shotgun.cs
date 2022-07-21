using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public float range = 10;
    private Camera fpsCam;
    private AudioSource aud;
    public AudioClip shootingSound;

    void Start()
    {
        fpsCam = transform.GetComponentInParent<Camera>();
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            RaycastHit hit;
            //aud.clip = shootingSound;
            //aud.Play();
            aud.PlayOneShot(shootingSound);

            Vector3 origin = fpsCam.ViewportToWorldPoint(new Vector3(0,0,0));

            if(Physics.Raycast(origin, fpsCam.transform.forward, out hit, range)){
                if(hit.transform.name == "Morte") {
                    Destroy(hit.transform.gameObject);
                }
            }
        }    
    }
}
