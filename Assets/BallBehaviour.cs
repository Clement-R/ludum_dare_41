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
        _rb2d.velocity = Vector2.Reflect(_velocity, contact.normal);

        if (collision.gameObject.tag == "Brick")
        {
            Destroy(collision.gameObject);
        }
    }
}