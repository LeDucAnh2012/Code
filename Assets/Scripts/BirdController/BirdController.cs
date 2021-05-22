using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdController : MonoBehaviour
{
   
    public float boundFore;

    public float flag = 0;
    public int Score = 0;

    public static BirdController instance;

    private Rigidbody2D myBody;
    private Animator anim;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip flyClip, pingClip, diedClip;


    private bool isAlive;
    private bool diedFlap;
    // Start is called before the first frame update

    void Awake()
    {
        isAlive = true;
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _MakeInstance();
    }

    void _MakeInstance()
    {
        if (instance == null)
            instance = this;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        _BirdMoveMent();
    }
    void _BirdMoveMent()
    {
        if (isAlive)
        {
            if (diedFlap)
            {
                diedFlap = false;
                myBody.velocity = new Vector2(myBody.velocity.x, boundFore);
                audioSource.PlayOneShot(flyClip);
            }
        }
        //if (Input.GetMouseButtonDown(0))
        //{
        //    myBody.velocity = new Vector2(myBody.velocity.x,boundFore);
        //    audioSource.PlayOneShot(flyClip);
        //}
        if(myBody.velocity.y > 0)
        {
            float x = 0;
            x = Mathf.Lerp(0, 90, myBody.velocity.y / 6);
            transform.rotation = Quaternion.Euler(0, 0, x);
        }else if(myBody.velocity.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            float x = 0;
            x = Mathf.Lerp(0, -90, -myBody.velocity.y / 6);
            transform.rotation = Quaternion.Euler(0, 0, x);
        }
    }
    public void FlapButton()
    {
        diedFlap = true;
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "PipeHolder")
        {
            Score++;
            if(GamePlayController.instance != null)
            {
                GamePlayController.instance._SetScore(Score);
            }
            audioSource.PlayOneShot(pingClip);
        }
    }
    int m = 1;
    void OnCollisionEnter2D(Collision2D target)
    {
        
        if(target.gameObject.tag == "Pipe" || target.gameObject.tag == "Ground")
        {
            
            flag = 1;
            if(m == 1)
            audioSource.PlayOneShot(diedClip);
            anim.SetTrigger("Died");
            m = 0;
            
        }
    }
    
}
