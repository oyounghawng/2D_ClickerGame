using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveSystem : MonoBehaviour
{
    private JellyController controller;
    private Rigidbody2D rigidBody2D;
    private Vector2 dir;

    [SerializeField]
    private float moveSpeed;

    void Awake()
    {
        controller = GetComponent<JellyController>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        StartCoroutine(MoveCoolDown());
    }
    private void FixedUpdate()
    {
        ApplyMove();
    }

    IEnumerator MoveCoolDown()
    {
        while (true)
        {
            SetMoveDir();
            yield return new WaitForSeconds(7f);
            dir = Vector2.zero;
            yield return new WaitForSeconds(3f);
        }
    }
    void SetMoveDir()
    {
        //vector ¼³Á¤
        int dirx = Random.Range(-1, 2);
        int diry = Random.Range(-1, 2);
        dir = new Vector2(dirx, diry);
        dir = dir.normalized;
    }

    private void ApplyMove()
    {
        if (dir.x >= 0)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        rigidBody2D.velocity = dir * moveSpeed;
        controller.CallMoveEvent(dir);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            Debug.Log("asd");
            if (collision.gameObject.name == "Top" || collision.gameObject.name == "Bottom")
            {
                dir.y *= -1;
            }
            else if (collision.gameObject.name == "Left" || collision.gameObject.name == "Right")
            {
                dir.x *= -1;
                if (dir.x >= 0)
                {
                    GetComponentInChildren<SpriteRenderer>().flipX = false;
                }
                else
                {
                    GetComponentInChildren<SpriteRenderer>().flipX = true;
                }
            }
        }
    }

}
