using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb2d;
    public SpriteRenderer sr;
    public GameObject[] lifeImages;
    public GameObject[] starImages;
    public DoorController doorcontroller;
    public GameObject player;
    public GameObject helper;

    public AudioSource[] SE;

    public bool helpMode = false;
    
   // public bool easyFlag = false;
    public bool showed = false;

    public float horizonSpeed, verticalSpeed;
    new Vector3 currentPosition;
    // float gravity = -2;
    public bool isjump = false;
    bool isWalking = false;
    bool notrightwall = true, notleftwall = true;
    bool record = true;
    // bool falling = true;
    int MaxHp;

    int extraHp = 2;
    int CurrentHp=5;
    int MaxStar;
    public int CurrentStar;
    // Start is called before the first frame update
    void Start()
    {
        helper = GameObject.Find("window");
        helper.GetComponent<SpriteRenderer>().color = new Color (1,1,1,0);
        //helper window initialization
        SE = this.GetComponents<AudioSource>();

        easyTest();
        
        player = GameObject.FindGameObjectWithTag("player");
        rb2d = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        sr = this.GetComponent<SpriteRenderer>();
        MaxHp = lifeImages.Length;
        CurrentHp = lifeImages.Length;
        MaxStar = starImages.Length;
        CurrentStar = 0;
        for(int i=0;i<starImages.Length; i++) starImages[i].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        verticalSpeed = rb2d.velocity.y + rb2d.gravityScale * Time.deltaTime;

        Check_falling_lost_hp();

        Anitmation_control();

        Check_player_input();

        rb2d.velocity = new Vector2 (horizonSpeed, verticalSpeed);

        hepWinControll ();
        deadOrNot();

        if (Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene("menu");
        }
    }
    
    private void easyTest (){
        if (easyFlag.easyMode == true){
            GameObject.Find("heart2").GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
            GameObject.Find("heart2 (1)").GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
        }
        else{
            GameObject.Find("heart2").GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
            GameObject.Find("heart2 (1)").GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
        }
    }

    private void deadOrNot (){
        if (CurrentHp <= 0){
            SceneManager.LoadScene("GameOver");
        }
    }

    private void hepWinControll (){
       // Debug.Log(helpMode);
        if (showed == true){
            helper.GetComponent<SpriteRenderer>().color = new Color (1,1,1,1);
            //appear
            if (Input.GetKeyDown(KeyCode.Return)){
                SE[4].Play();
            showed =false;
            }
        }
        else if (showed == false){
            helper.GetComponent<SpriteRenderer>().color = new Color (1,1,1,0);
        }
        if (helpMode == true){
            showed = true;
            helpMode = false;
        }
        
        if (Input.GetKeyDown(KeyCode.Return)){
            SE[4].Play();
            showed=false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "leftwall") {
            // Debug.Log(verticalSpeed);
            notleftwall = false;
        }
        else if (collision.gameObject.tag == "rightwall") {
            // Debug.Log(verticalSpeed);
            notrightwall = false;
        }
        else if (collision.gameObject.tag == "help" && showed == false) {
            SE[4].Play();
                helpMode = true;
        }

    }

    private void OnCollisionStay2D(Collision2D collision){
        if (collision.gameObject.tag == "leftwall") {
        }
        else if (collision.gameObject.tag == "rightwall") {
        }
        /*
        else if (collision.gameObject.tag == "help" && showed == false) {
                helpMode = true;
        }*/
    }

    private void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.tag == "leftwall") {
            // Debug.Log(verticalSpeed);
            notleftwall = true;
        }
        else if (collision.gameObject.tag == "rightwall") {
            // Debug.Log(verticalSpeed);
            notrightwall = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "LostHp") {
            if (easyFlag.easyMode == true && extraHp>0){
                extraHp--;
                SE[1].Play();
                if (extraHp == 1){
                    GameObject.Find("heart2 (1)").GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
                }
                else{
                    GameObject.Find("heart2").GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
                }
            }
            else{
                CurrentHp--;
                lifeImages[CurrentHp].SetActive(false);
                Destroy(collision.gameObject);
                SE[1].Play();
            }
        }
        else if (collision.gameObject.tag == "monster")
        {
            if (easyFlag.easyMode == true && extraHp>0){
                extraHp--;
                SE[1].Play();
                if (extraHp == 1){
                    GameObject.Find("heart2 (1)").GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
                }
                else{
                    GameObject.Find("heart2").GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
                }
            }
            else{
                CurrentHp--;
                lifeImages[CurrentHp].SetActive(false);
                SE[1].Play();
            }
            
        }
        else if (collision.gameObject.tag == "star"){
            SE[0].Play();
        }

    }

    private void Check_falling_lost_hp(){
        if(verticalSpeed < 0){ //開始掉落
            // print("falling");
            record = false;
        }

        if(!isjump && record){ //著地時紀錄位置
            currentPosition = player.transform.position; //離地時的位置
            // print("recorded");
        }

        if(verticalSpeed >= 0 && !record){
            if(currentPosition.y - player.transform.position.y > 10){ //掉落高度y相差10以上扣血
                if (easyFlag.easyMode == true && extraHp>0){
                    SE[1].Play();
                    extraHp--;
                    if (extraHp == 1){
                        GameObject.Find("heart2 (1)").GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
                    }
                    else{
                     GameObject.Find("heart2").GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
                    }
                }
                else{
                    CurrentHp--;
                    lifeImages[CurrentHp].SetActive(false);
                    SE[1].Play();
                }
            }
            record = true;
        }
    }

    private void Anitmation_control(){
        if(isWalking && !isjump){ 
            animator.SetInteger("Status", 1); //walk
        }
        else if(!isWalking && !isjump)
        {            
            animator.SetInteger("Status", 0); //idle
        }
    }

    private void Check_player_input(){
        if(Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Space)){ //jump
            if(!isjump){
                verticalSpeed = 10;
            }
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && doorcontroller.dooropen==true){
            //load.scene()
            Debug.Log("You win!");
        }

        if(Input.GetKey(KeyCode.LeftArrow) && notleftwall){
            if(!sr.flipX){ //false表示往右看
                sr.flipX = true;
            }
            isWalking = true;
            horizonSpeed = -3;
        }
        else if(Input.GetKey(KeyCode.RightArrow)  && notrightwall){
            if(sr.flipX){ //true表示往左看
                sr.flipX = false;
            }
            isWalking = true;
            horizonSpeed = 3;
        }
        else{
            isWalking = false;
            horizonSpeed = 0;
        }
    }
}
