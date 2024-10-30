using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Move_Player : MonoBehaviour
{
    public static Move_Player instance; 
    // Player move input // 
    public CharacterController controller;
    public float speed = 5f; 
    public Vector3 moveInput;
    // mouse rotation input //
    public Vector2 mouseInput;
    private float mouseSensitivity = 50f;
    // camera rotation input // 
    public Transform camera1;
    private float xRotation = 0f;
    // gravity // 
    public float gravity = -9.81f;
    public Vector3 velocity;
    public Transform GroundCheck;
    public float checkRadius=0.2f;
    public LayerMask _groundLayer;
    public bool isGrounded;
    // jump // 
    public float jumpHight = 2.0f;
    // bullet prefab //
    public GameObject Bullet_prefab;
    public Transform Gun_point;
    // animation door // 
    //public Animator ani;
   // public Health Health;
    public Slider health_Bar;
    public int health = 200;       // Player's starting health
    public int damagePerSecond = 10; // Damage dealt per second

    private float damageTimer = 0f;  // Timer to keep track of damage intervals
    public float damageInterval = 1f; // Time between damage applications
    public GameObject Retry_panel; // retry function
    public GameObject Pasue_panel; // pasue function
    public bool Player_is_live;
    //Raycast_gun Raycast_gun;
    public TMP_Text score_text;
    public TMP_Text Coin_Text;
    int score = 0;
    public AudioSource audioSource;
    public AudioClip Bullet_Sound;
    public AudioClip Coin_Sound;



     private void Awake()
    {
        makeSingleton();
    }
    private void makeSingleton()
    {
        if(instance == null)
        {
            instance = this ;
        }
        else
        {
           Destroy(instance);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState =  CursorLockMode.Locked;
        Retry_panel.SetActive(false);
        Player_is_live = false;

       
    }

    // Update is called once per frame
    void Update()
    {
        health_Bar.value = health;
        MovePlayer();
        jump_force();
        shoot();
        // gravity function //
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        isGrounded = Physics.CheckSphere(GroundCheck.position,checkRadius,_groundLayer);
        if(isGrounded && velocity.y <=0)
        {
            velocity.y = -2f;
        }
    }
    public void MovePlayer()
    { 
        if(Player_is_live == false)
        {
        //player moving script//
        Vector3 vertical_move = transform.forward * Input.GetAxis("Vertical");
        Vector3 horizontal_move = transform.right * Input.GetAxis("Horizontal");
        moveInput = vertical_move + horizontal_move;
        controller.Move(moveInput*speed*Time.deltaTime);
        // mouse rotation script //
         mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"),Input.GetAxisRaw("Mouse Y")) * mouseSensitivity * Time.deltaTime;
         // mouse and camera rotation //
        xRotation -=  mouseInput.y ;
        xRotation = Mathf.Clamp(xRotation, -70f, 70f);
        transform.localRotation = Quaternion.Euler(0f,transform.localRotation.eulerAngles.y +  mouseInput.x ,0f);
        camera1.localRotation = Quaternion.Euler(xRotation, 0f, 0f); 
       
        }

    }
    //jump force script //
    public void jump_force()
    {
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(gravity*-2f*jumpHight);
        }
    }

    // shooting script //
    public void shoot()
    {
      if(Input.GetMouseButtonDown(0))
       {
        //Gun Sound Audio
        audioSource.PlayOneShot(Bullet_Sound);
        RaycastHit hitInfo;
        if(Physics.Raycast(camera1.position,camera1.forward,out hitInfo,50f))
        {
            if(Vector3.Distance(camera1.position,hitInfo.point) > 2f)
            {
              Gun_point.LookAt(hitInfo.point);
            }
            
        }
        else
        {
            Gun_point.LookAt(camera1.position + (camera1.forward*30f));
        }
          Instantiate(Bullet_prefab,Gun_point.position,Gun_point.rotation);
       }
    }
  

    void OnTriggerStay(Collider other)
    {
        // Check if the object the player is in contact with has the "Enemy" tag
        if (other.gameObject.CompareTag("Enemy"))
        {
            damageTimer += Time.deltaTime; // Increment timer by time elapsed since last frame

            if (damageTimer >= damageInterval)
            {
                TakeDamage(damagePerSecond);
                damageTimer = 0f; // Reset the timer
            }
        }
    }
    void OnTriggerEnter(Collider Collider)
    {
        if(Collider.gameObject.CompareTag("Coin"))
        {
            Debug.Log("Coin collected!");
            score_display();
            Destroy(Collider.gameObject);
            audioSource.PlayOneShot(Coin_Sound);
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player Health: " + health);

        // Check if health has reached 0 or below
        if (health <= 0)
        {
            Die();
        }
    }

      void Die()
    {
        // Code to handle player death
        Debug.Log("Player has died!");
        Retry_panel.SetActive(true);
        Player_is_live = true ;
       // Raycast_gun.death();
        //Destroy(gameObject); // Destroy the player object
       

    }
      public void score_display()
    {
         score++;
         score_text.text = " " + score;
         Coin_Text.text = " / " + score;
         Debug.Log("score");
    }
    // Retry_Button function
    public void Retry_Button()
    {
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // menu Button function
    public void Menu_Button(int sceneID)
    {
     SceneManager.LoadScene(sceneID);
    }
    public void Pasum_Button()
    {
      Pasue_panel.SetActive(true);
      Time.timeScale = 0;
    }
    public void Resume_Button()
    { 
        Pasue_panel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Quit_Button()
    {
     Application.Quit();
    }
}

  
    

