using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public int startingHealth = 3;
    public int currentHealth;
    //public Slider healthSlider;
    public Image damageImage;
    //public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColor = new Color (1f, 0f, 0f, 0.1f); //플레이어(빨강, a=100)와 스크립트(검정) 양 쪽에 지정

    //Animator anim;
    //AudioSource playerAudio;
    RigControlTest playerMovement;
    //PlayerShooting playerShooting;
    bool isDead;
    bool damaged;
    public GameObject[] HealthObjs; //목숨이 세 개 이므로 옵젝배열 설정
    void Awake () {
        //anim = GetComponent <Animator> ();
        //playerAudio = GetComponent <AudioSource> ();
        playerMovement = GetComponent<RigControlTest> ();
        //playerShooting = GetComponentInChildren <PlayerShooting> ();
        currentHealth = startingHealth;
        HealthObjs = GameObject.FindGameObjectsWithTag ("HEALTH");
        Debug.Log (HealthObjs);
    }

    void Update () {
        if (damaged) {
            damageImage.color = flashColor;
        } else {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }

    public void TakeDamage (int attackDmg) //Bullet의 TakeDamage의 int amount 변수
    {
        damaged = true;
        currentHealth -= attackDmg;
        //healthSlider.value = currentHealth;
        if (damaged && currentHealth == 2) {
            Destroy (HealthObjs[2], 0f);
            Debug.Log ("체력이 2가 되었습니다");
        } else if (damaged && currentHealth == 1) {
            Destroy (HealthObjs[1], 0f);
            Debug.Log ("체력이 1이 되었습니다");
        } else if (damaged && currentHealth <= 0 && !isDead) {
            Destroy (HealthObjs[0], 0f);
            Debug.Log ("체력이 0이 되었습니다");
            Death ();    
        }
        //playerAudio.Play ();
   
    }

    void Death () {
        isDead = true;

        //playerShooting.DisableEffects ();

        //anim.SetTrigger ("Die");

        // playerAudio.clip = deathClip;
        // playerAudio.Play ();

        playerMovement.enabled = false;
        //playerShooting.enabled = false;
        Debug.Log ("죽어서 움직일 수 없다");
    }

    // public void RestartLevel ()  //어느 클래스인지 찾아볼 것 + 다시하기 버튼 팝업
    // {
    //     SceneManager.LoadScene (0);
    // }
}