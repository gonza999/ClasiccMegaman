using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool left;
    public float speed;
    private void Update()
    {
        if (!transform.GetComponent<Animator>().GetBool("Hit"))
        {
            if (left)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
        }
        else
        {
            transform.GetComponent<Animator>().Play("Hit");
        }
    }
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

}
