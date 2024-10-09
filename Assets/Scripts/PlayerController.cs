using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private Animator animator;
    [SerializeField]private BoxCollider2D boxCollider;
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private Vector2 boxColInitSize;
    private Vector2 boxColInitOffset;
    public bool isGrounded;
    // Start is called before the first frame update
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        boxColInitSize = boxCollider.size;
        boxColInitOffset = boxCollider.offset;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        //float VerticalInput = Input.GetAxis("Jump");
        MoveCharacter(horizontal);
        animator.SetFloat("Speed",Mathf.Abs(horizontal));

        if(horizontal < 0){
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else{
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            PlayJumpAnimation();
        }
        
        if(Input.GetKeyDown(KeyCode.LeftControl)){
            crouch(true);
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl)){
            crouch(false);
        }
        
        
    }

    private void MoveCharacter(float horizontal){
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

    }
    public void PlayJumpAnimation()
    {
        isGrounded = false;
        animator.SetTrigger( "Jump" );
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        
    }
    private void OnCollisionEnter2D(Collision2D collision){

        if(collision.gameObject.CompareTag("Ground")){
            Debug.Log("grounded");
            isGrounded = true;
            
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    void crouch(bool isCrouching)
    {
        if( isCrouching == true )
        {
            float offX = 0.0228312f;     
            float offY = 0.5942023f;     

            float sizeX = 0.6379263f;     
            float sizeY = 0.6379263f;     

            boxCollider.size = new Vector2( sizeX, sizeY );   
            boxCollider.offset = new Vector2( offX, offY );   
        }

        else
        {
            
            boxCollider.size = boxColInitSize;
            boxCollider.offset = boxColInitOffset;
        }
        animator.SetBool("Crouch", isCrouching);
    
    }
}
