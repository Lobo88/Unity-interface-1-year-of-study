

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using System;

public class MouseController : MonoBehaviour
{
    

public float jetpackForce = 75.0f;
    public float forwardMovementSpeed = 3.0f;
    public Transform groundCheckTransform;
    public LayerMask groundCheckLayerMask;
    public ParticleSystem jetpack;
    public Texture2D coinIconTexture;
    public AudioClip coinCollectSound;
    public AudioSource jetpackAudio;
    public AudioSource footstepsAudio;
    public ParallaxScroll parallax;
    public Text coinsLabel;
    public GameObject restartDialog;
    public Transform FirePoint;
    public GameObject RocketPrefab;
    public bool ReadyToFire = true;
    public float fireRate = 5F;
    private float nextFire = 0.5F;
    
    public GameObject heart1;
    public GameObject acivHeart1;
    public GameObject heart2;
    public GameObject acivHeart2;
    public GameObject heart3;
    public GameObject acivHeart3;

    private Animator animator;
    private bool grounded;
    private bool dead = false;
    private uint coins = 0;


    public bool move = false;
    public  char  klawisz = 'f';

    void Start () 
    {
        acivHeart1.gameObject.SetActive(false);
        acivHeart2.gameObject.SetActive(false);
        acivHeart3.gameObject.SetActive(false);
        animator = GetComponent<Animator>();
        restartDialog.SetActive(false);
        command cm = new command();
       // cm.wez=('a');
       klawisz=cm.wez;
        //cm.wez = 'a';
    }

    private void Update()
    {
       


        if (Input.GetKeyDown(KeyCode.Space) && Time.time+3.5 > nextFire) 
        {
            
            Shoot();
           
        }
    }
   
        void FixedUpdate ()
    {
       
        // Command buttonU = new FireWeapon();
        bool jetpackActive = ChangeJetpack(move, klawisz);

        // ChangeJetpack( jetpackActive);
        jetpackActive = jetpackActive && !dead;
	    if (jetpackActive) 
	    { 
	        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jetpackForce));
	    }
	    if (!dead) 
	    {
	        Vector2 newVelocity = GetComponent<Rigidbody2D>().velocity;
	        newVelocity.x = forwardMovementSpeed;
	        GetComponent<Rigidbody2D>().velocity = newVelocity;
	    }
  	    UpdateGroundedStatus();
	    AdjustJetpack(jetpackActive);
	    AdjustFootstepsAndJetpackSound(jetpackActive);
	    parallax.offset = transform.position.x;
    } 

    void UpdateGroundedStatus() 
    {
        grounded = Physics2D.OverlapCircle(groundCheckTransform.position, 0.1f, groundCheckLayerMask);
        animator.SetBool("grounded", grounded);
    }

    void AdjustJetpack (bool jetpackActive) 
    {
  	    ParticleSystem.EmissionModule jpEmission = jetpack.emission;
	    jpEmission.enabled = !grounded;
	    jpEmission.rateOverTime = jetpackActive ? 300.0f : 75.0f; 
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.CompareTag("Coins")) 
        {
	        CollectCoin(collider);
        }
        if (collider.gameObject.CompareTag("bomb"))
        {
            getHeart();
          
        }
        else 
        {
            HitByLaser(collider);
	    } 
    }

    void HitByLaser(Collider2D laserCollider) 
    {
        if (!dead) 
        {
            laserCollider.gameObject.GetComponent<AudioSource>().Play();
	    }
	    dead = true;
	    animator.SetBool("dead", true);
        restartDialog.SetActive(true);
    }

    void CollectCoin(Collider2D coinCollider) 
    {
        coins++;
        Destroy(coinCollider.gameObject);
        AudioSource.PlayClipAtPoint(coinCollectSound, transform.position);
        coinsLabel.text = coins.ToString();
    }

    

    
  void AdjustFootstepsAndJetpackSound(bool jetpackActive) 
  {
      footstepsAudio.enabled = !dead && grounded;
      jetpackAudio.enabled =  !dead && !grounded;
	  jetpackAudio.volume = jetpackActive ? 1.0f : 0.5f;        
  }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public bool ChangeJetpack(bool jetpackActive,char znak)
    {
       

        if (znak == 'a') { return jetpackActive = Input.GetKey(KeyCode.A); }
            if (znak == 'b') { return jetpackActive = Input.GetKey(KeyCode.B); }
          else return jetpackActive = jetpackActive = Input.GetButton("Fire1");
        

    }

    void Shoot()
    {
        nextFire = Time.time + fireRate;
        Instantiate(RocketPrefab, FirePoint.position,transform.rotation);
        
        
    }

   void getHeart()
    {
        if (acivHeart3.gameObject.activeSelf == true)
        {
            Destroy(gameObject);
        }

        else
            if (acivHeart2.gameObject.activeSelf == true)
        {
            Destroy(heart3.gameObject);
            acivHeart3.SetActive(true);
        }
        else if
        (acivHeart1.gameObject.activeSelf == true)
        {
            Destroy(heart2.gameObject);
            acivHeart2.SetActive(true);
        }
        else
        {
            Destroy(heart1.gameObject);
            acivHeart1.SetActive(true);
        }
    }
}




