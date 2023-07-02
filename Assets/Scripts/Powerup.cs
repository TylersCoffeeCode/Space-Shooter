using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    //ID for powerups
    //0 = trople shot
    //1 = speed
    //2 = shields
    [SerializeField] //0 = Triple Shot 1 = Speed 2 = Shield
    private int _powerupID;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -6.0f)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.transform.GetComponent<Player>();
            if (player != null)
            {
                if (_powerupID == 0)
                {
                    player.TripleShotActive();
                } else if (_powerupID == 1)
                {
                    Debug.Log("SPEED GET");
                } else if (_powerupID == 2)
                {
                    Debug.Log("SHIELDED");
                }
            }

            Destroy(this.gameObject);
        }
    }

}
