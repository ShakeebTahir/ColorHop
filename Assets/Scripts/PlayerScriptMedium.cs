using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScriptMedium : MonoBehaviour
{
    private Rigidbody2D rb;
    public float fallMultiplier = 1.5f;
    private bool grounded = true;
    private Animator anim;
    private bool firstJump = true;
    private float prevYpos = -1000;
    public bool isDead = false;
    public GameObject gameOverScreen;

    private string jumpChoice;

    private AudioSource jumpingsound;

    public Text scoreText;

    public Button blueButton;

    public Button redButton;

    public Button greenButton;

    void Start()
    {
        jumpingsound = GetComponent<AudioSource>();
        Time.timeScale = 2f;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if(transform.position.y +5f < prevYpos)
        {
            if (!isDead)
            {
                Death();
            }
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
        }
    }

    public void BlueJump()
    {
        blueButton.interactable = false;
        redButton.interactable = false;
        greenButton.interactable = false;
        ColourOneJump();
    }

    public void RedJump()
    {
        blueButton.interactable = false;
        redButton.interactable = false;
        greenButton.interactable = false;
        ColourTwoJump();
    }

    public void GreenJump()
    {
        blueButton.interactable = false;
        redButton.interactable = false;
        greenButton.interactable = false;
        ColourThreeJump();
    }

    public void ColourOneJump()
    {
        jumpChoice = "One";

        firstJump = false;

        if (!grounded)
        {
            return;
        }

        anim.SetTrigger("Jump"); 

        grounded = false;

        StartCoroutine(LongJump());

    }


    public void ColourTwoJump()
    {
        jumpChoice = "Two";

        firstJump = false;

        if (!grounded)
        {
            return;
        }

        anim.SetTrigger("Jump");

        grounded = false;

        StartCoroutine(LongJump());

    }

    public void ColourThreeJump()
    {
        jumpChoice = "Three";

        firstJump = false;

        if (!grounded)
        {
            return;
        }

        anim.SetTrigger("Jump");

        grounded = false;

        StartCoroutine(LongJump());
    }


    IEnumerator LongJump()
    {
        rb.AddForce(new Vector2(0, 9.8f * 29.5f));

        yield return new WaitForSeconds(0.15f);

        rb.AddForce(new Vector2(9.8f * 12f, 0));
    }


    void OnCollisionEnter2D(Collision2D collision)
    {

        blueButton.interactable = true;
        redButton.interactable = true;
        greenButton.interactable = true;

        if(collision.gameObject.tag == "colourOne" & jumpChoice == "One")
        {
            scoreText.text = (int.Parse(scoreText.text) + 1).ToString();
            GameObject cube = collision.gameObject;
            Renderer render = cube.GetComponent<Renderer>();
            render.material.SetColor("_Color", Color.blue);

            prevYpos = transform.position.y;

            grounded = true;
            rb.velocity = Vector3.zero;
            transform.position = new Vector3(collision.gameObject.transform.position.x-0.2f, transform.position.y, transform.position.z);

            if (firstJump)
            {
                return;
            }
            jumpingsound.Play();
            StartCoroutine(FallTile(collision.gameObject));
        }

        else if(collision.gameObject.tag == "colourTwo" & jumpChoice == "Two")
        {
            scoreText.text = (int.Parse(scoreText.text) + 1).ToString();
            GameObject cube = collision.gameObject;
            Renderer render = cube.GetComponent<Renderer>();
            render.material.SetColor("_Color", Color.red);

            prevYpos = transform.position.y;

            grounded = true;
            rb.velocity = Vector3.zero;
            transform.position = new Vector3(collision.gameObject.transform.position.x - 0.2f, transform.position.y, transform.position.z);

            if (firstJump)
            {
                return;
            }
            jumpingsound.Play();
            StartCoroutine(FallTile(collision.gameObject));
        }

        else if (collision.gameObject.tag == "colourThree" & jumpChoice == "Three")
        {
            scoreText.text = (int.Parse(scoreText.text) + 1).ToString();
            GameObject cube = collision.gameObject;
            Renderer render = cube.GetComponent<Renderer>();
            render.material.SetColor("_Color", Color.green);

            prevYpos = transform.position.y;

            grounded = true;
            rb.velocity = Vector3.zero;
            transform.position = new Vector3(collision.gameObject.transform.position.x - 0.2f, transform.position.y, transform.position.z);

            if (firstJump)
            {
                return;
            }
            jumpingsound.Play();
            StartCoroutine(FallTile(collision.gameObject));
        }

        else
        {
            prevYpos = transform.position.y;

            grounded = true;
            rb.velocity = Vector3.zero;
            transform.position = new Vector3(collision.gameObject.transform.position.x - 0.2f, transform.position.y, transform.position.z);

            if (firstJump)
            {
                return;
            }
            blueButton.interactable = false;
            redButton.interactable = false;
            greenButton.interactable = false;
            jumpingsound.Play();
            StartCoroutine(LoseTile(collision.gameObject));
        }

    }

    IEnumerator FallTile(GameObject collision)
    {
        yield return new WaitForSeconds(1f);

        if (collision.gameObject != null)
        {
            collision.AddComponent<Rigidbody2D>();
            Rigidbody2D rbody = collision.GetComponent<Rigidbody2D>();
            rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
   
    IEnumerator LoseTile(GameObject collision)
    {
        yield return new WaitForSeconds(0.01f);

        if (collision.gameObject != null)
        {
            collision.AddComponent<Rigidbody2D>();
            Rigidbody2D rbody = collision.GetComponent<Rigidbody2D>();
            rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    void Death()
    {
        gameOverScreen.SetActive(true);
        isDead = true;
    }

}
