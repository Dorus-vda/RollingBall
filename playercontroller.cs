using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    private Rigidbody rigidbody;
    public float speed;
    public Text countText;
    public Text winText;
    public bool isGrounded;
    public float jumpVelocity;

    private void Awake()
    {
        rigidbody = transform.GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float movehorizontal = Input.GetAxis("Horizontal");
        float movevertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(movehorizontal, 0.0f, movevertical);

        rb.AddForce(movement * speed);

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rigidbody.velocity = Vector3.up * jumpVelocity;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            winText.text = "You win!";
        }
    }
}
