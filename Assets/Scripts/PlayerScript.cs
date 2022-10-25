using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour

{
   private Rigidbody2D rd2d;
   public float speed;
   public TextMeshProUGUI score;
   public TextMeshProUGUI winText;
   public GameObject winTextObject;
   public GameObject loseTextObject;
   public TextMeshProUGUI loseText;
   public TextMeshProUGUI lives;
   private int scoreValue = 0;
   private int livesValue = 3;

    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();

        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);

        lives.text = livesValue.ToString();
    }

   
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float verMovement = Input.GetAxis("Vertical");

        rd2d.AddForce(new Vector2(hozMovement * speed, verMovement * speed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
        }

        if(collision.collider.tag == "Enemy")
        {
            livesValue -= 1;
            lives.text = livesValue.ToString();
            Destroy(collision.collider.gameObject);
        }

              if(scoreValue >= 8)
        {
            winTextObject.SetActive(true);
            Destroy(gameObject);
            SoundScript.PlaySound("Cyberpunk Moonlight Sonata");
        }

        if(livesValue <= 0)
        {
            loseTextObject.SetActive(true);
            Destroy(gameObject);
        }

         if (scoreValue == 4) 
        {
            livesValue = 3;
            transform.position = new Vector2(110f, 1.0f);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            if(Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3),ForceMode2D.Impulse);
            }
        }
    }
}