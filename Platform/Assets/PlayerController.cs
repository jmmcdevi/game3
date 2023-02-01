using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.Space;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode moveLeft = KeyCode.A;
    public float speed = 10.0f;
    private Rigidbody2D rb;
    private bool onGround = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Reset(){
        rb.velocity = Vector2.zero;
        transform.position = new Vector2(-6.19f, -0.95f);
    }

    public void OnCollisionEnter2D(Collision2D col){
        if(col.collider.CompareTag("Coin")){
            Destroy(col.gameObject);
            Application.Quit();
        }
        else if(col.collider.CompareTag("Wall")){
            Reset();
        }
    }

    public void OnCollisionStay2D(Collision2D col){
        if(col.collider.CompareTag("Ground")){
            if(onGround==false){
                GetComponent<AudioSource>().Play();
            }
            onGround = true;
        }
    }

    public void OnCollisionExit2D(Collision2D col){
        if(col.collider.CompareTag("Ground")){
            onGround = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
          var vel = rb.velocity;
        if(Input.GetKey(moveUp)){
            if(onGround==true){
                vel.y = speed;
            }
            
        }
        else if(Input.GetKey(moveLeft)){
            vel.x = -speed/2;
        }
        else if(Input.GetKey(moveRight)){
            vel.x = speed/2;
        }
        else{
            vel.x=0;
        }
        rb.velocity = vel;
        

    }
}
