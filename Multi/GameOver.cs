using UnityEngine;

public class GameOver : MonoBehaviour
{
    public PlayerHealth playerHealth;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth<0)
        {
            anim.SetTrigger("isGameOver");
        } 

    }
}
