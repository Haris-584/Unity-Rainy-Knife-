using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{

    private Animator anim;
    private SpriteRenderer sr;
    private float speed = 3f;
    private float min_X = -2.7f;
    private float max_X = 2.7f;

    public Text timer_text;
    private int timer;
    

    void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }


    void Start()
    {
        Time.timeScale = 1f;
        StartCoroutine(Counttime());
        timer = 0;
    }

    void PlayBounds()
    {
        Vector3 temp = transform.position;

        if (temp.x > max_X)
        {
            temp.x = max_X;
        }else if(temp.x < min_X){
            temp.x = min_X;
        }
            transform.position = temp;
    }
    
    // Update is called once per frame
    void Update()
    {
        Move();
        PlayBounds();
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 temp = transform.position;
        if(h>0)
        {
            temp.x += speed * Time.deltaTime;
            sr.flipX = false;
            anim.SetBool("walk", true);

        }
        else if (h < 0)
        {
            temp.x -= speed * Time.deltaTime;
            sr.flipX = true;
            anim.SetBool("walk", true);
        }
        else if (h == 0)
        {
            anim.SetBool("walk", false);
        }
        transform.position = temp;
    }

    IEnumerator Counttime()
    {
        yield return new WaitForSeconds(1f);

        timer++;

        timer_text.text = "Timer :" + timer;

        StartCoroutine(Counttime());
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2f);

        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);


    }

    void OnTriggerEnter2D(Collider2D target){
        if(target.tag == "Knife"){
            Time.timeScale = 0f;
            StartCoroutine(RestartGame());
        }
    }
}
 