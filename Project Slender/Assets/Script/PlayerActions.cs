using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerActions : MonoBehaviour
{
    public int objsQt = 0;
    public GameObject feddbackPanel;
    public GameObject ShotgunPlayer;
    public GameObject lanterna;
    bool on = false;
    public int hp = 3; // Vida do Player
    // Start is called before the first frame update
    void Start()
    {
        feddbackPanel.SetActive(false);
        ShotgunPlayer.SetActive(false);
        lanterna.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        estaLigado();
    }

    public void estaLigado()
    {
        if (Input.GetKey(KeyCode.C) && !on)
        {
            lanterna.SetActive(true);
            on = true;
        }else if(Input.GetKey(KeyCode.C) && on)
        {
            lanterna.SetActive(false);
            on = false;
        }
    }  
 

    //Dano
    public void TakeDamage(int damage) {
        hp -= damage;
        if(hp <= 0) {
            SceneManager.LoadScene("GameOver");
        }
    }

    // Pegar a caveira
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Collectible"){
            SlenderBehaviour.enemySpeed ++;
            SlenderBehaviour.playerStopView --;
            objsQt ++;
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "Gun"){
            feddbackPanel.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Gun"){
            feddbackPanel.SetActive(false);
        }
    }

    void OnTriggerStay(Collider other) {
        if(other.gameObject.tag == "Gun"){
            if(Input.GetKey(KeyCode.E)){
                Destroy(other.gameObject);
                feddbackPanel.SetActive(false);
                ShotgunPlayer.SetActive(true);

            }
        }    
    }
}
