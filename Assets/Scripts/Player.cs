using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canFire = -1f;
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;
    [SerializeField]
    private bool _isTripleShotActive = false;
    [SerializeField]
    private GameObject _tripleShotPrefab;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        
        if (_spawnManager == null)
        {
            Debug.Log("Spawn Manger is NULL");
        }
    }

    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }

    }

    void FireLaser()
    {
            _canFire = Time.time + _fireRate;
            
            //if space key press
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_isTripleShotActive)
                {
                Vector3 tripleShotPosition = new Vector3(transform.position.x, transform.position.y, 0);
                Instantiate(_tripleShotPrefab, tripleShotPosition, Quaternion.identity);
                } else
                {
                Instantiate(_laserPrefab, new Vector3(transform.position.x, transform.position.y + 1.05f, 0), Quaternion.identity);
                }
            }
            //if tripleshotactive is true
                //fire 3 lasers
            //else fire 1 laser

            //instantiate 3 lasers (prefab)
    }
    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);


        if (transform.position.x >= 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }

    public void Damage()
    {
        _lives -= 1;

        if (_lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }

}
