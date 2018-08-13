using UnityEngine;

public class CharacterCtrl : MonoBehaviour {

    public float speed = 20f;
    private Rigidbody2D rb;
    private SpriteRenderer SR;
   

    private bool faceRight = true;
    public int sprite_type = 0;
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        SR = GetComponentInChildren<SpriteRenderer>();
	}
	void Awake(){
        Messenger.AddListener(GameEvent.TYPE_CHECK,OnTypeCheck);
        Messenger.AddListener(GameEvent.GOLD_CHECK,OnGoldCheck);
    }
    void OnDestroy(){
        Messenger.RemoveListener(GameEvent.TYPE_CHECK,OnTypeCheck);
        Messenger.RemoveListener(GameEvent.GOLD_CHECK,OnGoldCheck);
    }
    void OnTypeCheck(){
        if (sprite_type == 0) {
            SR.sprite = Resources.Load("HatJump",typeof(Sprite)) as Sprite;
            sprite_type = 1;
        }
        else if (sprite_type == 1) {
            SR.sprite = Resources.Load("Jump11",typeof(Sprite)) as Sprite;
            sprite_type = 0;
        }
    }
    void OnGoldCheck(){
        if (sprite_type == 1) {
            SR.sprite = Resources.Load("GoldenJump",typeof(Sprite)) as Sprite;
            sprite_type = 2;
        }
        else if (sprite_type == 2){
            SR.sprite = Resources.Load("HatJump",typeof(Sprite)) as Sprite;
            sprite_type = 1;
        }
    }
	void Update () {
        float moveX = Input.GetAxis("Horizontal");
        rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime);
        //rb.MoveRotation(rb.rotation + moveX * speed *100* Time.deltaTime);
        if (moveX < 0 && !faceRight) {
            flip();
        }
        else if (moveX > 0 && faceRight) {
            flip();
        }
        
        
	}

    void flip() {
        faceRight = !faceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
