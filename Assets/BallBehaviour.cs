using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {

    private Rigidbody2D _rb2d;
    private Vector2 _velocity;

	void Start ()
    {
        _rb2d = GetComponent<Rigidbody2D>();

        _rb2d.AddForce(new Vector2(5f, 10f), ForceMode2D.Impulse);
    }

    private void LateUpdate()
    {
        _velocity = _rb2d.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // _velocity *= 1.2f;
        ContactPoint2D contact = collision.contacts[0];

        // print(contact.normal);

        _rb2d.velocity = Vector2.Reflect(_velocity, contact.normal);

        if(collision.gameObject.tag == "Paddle")
        {
            if (transform.position.x > collision.gameObject.transform.position.x)
            {
                _rb2d.velocity = new Vector2(Mathf.Abs(_rb2d.velocity.x), _rb2d.velocity.y);
            }
            else
            {
                _rb2d.velocity = new Vector2(-Mathf.Abs(_rb2d.velocity.x), _rb2d.velocity.y);
            }
        }
        
        //Vector3 normal = collision.contacts[0].normal;
        //Vector3 vel = _rb2d.velocity;
        //print(Vector3.Angle(vel, -normal));

            if (collision.gameObject.tag == "Brick")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "BottomWall")
        {
            Destroy(gameObject);
        }
    }
}