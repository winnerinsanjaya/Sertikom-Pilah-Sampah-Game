using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SampahScript : MonoBehaviour
{

    public string sampahTag;

    //make a kist of the sampah sprites
    public Sprite[] gambarSampah;
    [SerializeField] float speed; 


    //to know when the sampah is dragged
    [HideInInspector] public bool isDragged;

    //to know when the sampah is moved or not
    [HideInInspector] public bool isMoved;


    private void Start()
    {

        //defibe the dragged and moved condition on first
        isDragged = false;
        isMoved = false;

        //randomize the sampah sprite
        int index = Random.Range(0, gambarSampah.Length);
        gameObject.GetComponent<SpriteRenderer>().sprite = gambarSampah[index];
    }


    private void OnMouseDrag()
    {
        // move the object by the position of the cursor
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // set the dragged and moved condition when mouse is on drag
        isDragged = true;
        isMoved = false;
    }

    private void OnMouseUp()
    {

        //set the moved condition when mouse click goes up
        isMoved = true; 
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        //when the sampah after drag and was moved, to avoid collision detected when on drag
        if (isMoved == true)
        {

            //check if the sampah tag is right with the box
            if (collision.tag.Equals(sampahTag))
            {

                //call the benar
                GameManagerScript.Instance.Benar();
                Debug.Log("Benar");
                //play benar sound
                GameManagerScript.Instance.Play("Benar");
                Destroy(gameObject);
            }

            else
            {
                //call the salah
                GameManagerScript.Instance.Salah();
                Debug.Log("Salah");
                //play benar sound
                GameManagerScript.Instance.Play("Salah");
                Destroy(gameObject);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //check if the batas sampah being hitted by the sampah
        if (collision.tag.Equals("BatasSampah"))
        {

            //load the game over scebe
            SceneManager.LoadScene("GameOverScene");
        }
    }

    private void Update()
    {

        //check if the sampah is before dragged
        if (isDragged == false)
        {

            //move the sampah from right to left
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(-11f, transform.position.y), speed * Time.deltaTime); // move the trash within speed multiply second
        }
        
    }
}
