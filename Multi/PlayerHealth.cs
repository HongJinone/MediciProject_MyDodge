using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public int startingHealth = 3;
    public int currentHealth;

    public Image damageImage;

    public float flashSpeed = 5f;
    public Color flashColor = new Color (1f, 0f, 0f, 0.1f); 


    PlayerMovement playerMovement;

    bool isDead;
    bool damaged;
    public GameObject[] HealthObjs; 
    Animator anim;
    void Awake () {

        playerMovement = GetComponent<PlayerMovement> ();

        currentHealth = startingHealth;
        HealthObjs = GameObject.FindGameObjectsWithTag ("HEALTH");
        Debug.Log (HealthObjs);
        anim = GetComponent<Animator>();
    }

    void Update () {
        if (damaged) {
            damageImage.color = flashColor;
        } else {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }

    public void TakeDamage (int attackDmg)
    {
        damaged = true;
        currentHealth -= attackDmg;
        //healthSlider.value = currentHealth;
        if (damaged && currentHealth == 2) {
            HealthObjs[2].SetActive(false);
            //Destroy (HealthObjs[2], 0f);
            Debug.Log ("Hp: 3");
        } else if (damaged && currentHealth == 1) {
            HealthObjs[1].SetActive(false); 
            //Destroy (HealthObjs[1], 0f);
            Debug.Log ("Hp: 1");
        } else if (damaged && currentHealth <= 0 && !isDead) {
            HealthObjs[0].SetActive(false);
            //Destroy (HealthObjs[0], 0f);
            Debug.Log ("Hp: 0");
            Death ();    
        }
        //playerAudio.Play ();
   
    }

    void Death () {
        isDead = true;
        anim.SetTrigger("isGameOver");
        
        playerMovement.enabled = false;

        Debug.Log ("I cannot move.");
    }

    void Win(){

    }

}