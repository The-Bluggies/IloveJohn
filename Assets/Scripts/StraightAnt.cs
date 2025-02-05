using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightAnt : MonoBehaviour
{
    public GameObject Player;
    public GameObject Bullet;
    public GameObject AcidAttack;

    public AudioClip collectSound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RangedAttack", 1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 11)
        {
            EnemyMovement();
        }
    }

    void EnemyMovement()
    {
        transform.Translate(new Vector2(-1, 0) * Time.deltaTime * 10f);
    }

    void RangedAttack()
    {
        Instantiate(AcidAttack, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if (whatDidIHit.tag == "Weapon")
        {
            AudioSource.PlayClipAtPoint(collectSound, Camera.main.transform.position);
            Destroy(this.gameObject);
            Destroy(whatDidIHit.gameObject);
            GameObject.Find("GameManager").GetComponent<GameManager>().AddScore(1);
        }
        else if (whatDidIHit.tag == "Player")
        {
            GameObject.Find("Player(Clone)").GetComponent<Player>().loseALife();
            Destroy(this.gameObject);
            Debug.Log("Player is hit");
        }
    }
}
