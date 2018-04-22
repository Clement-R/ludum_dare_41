using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehaviour : MonoBehaviour {

    public float speed = 5f;

    private Rigidbody2D _rb2d;

    void Start ()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }
	
	void Update ()
    {
        _rb2d.velocity = Vector2.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rb2d.velocity = new Vector2(-speed, 0f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _rb2d.velocity = new Vector2(speed, 0f);
        }
    }
}
