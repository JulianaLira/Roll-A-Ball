using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed; 
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
	count = 0;
	SetCountText();
	winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //move com as teclas do teclado.
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);  //adiciona força usando o rigidbody(corpo rigido) para o objeto se mover.

    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
	if (other.gameObject.CompareTag("Pick Up"))
	{
		other.gameObject.SetActive(false);
		count = count + 1;
		SetCountText();
	}
    }

    void SetCountText()
    {
	countText.text = "Count: " + count.ToString();
	if (count >= 12)
	{
	   winText.text = "You Win!";
	}
    }
}
