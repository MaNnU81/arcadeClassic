using UnityEngine;

public class TurretAmmo : Ammo
{
   

    new void Start()
    {
        
    }

    // Update is called once per frame
   new void Update()
    {


        lifespan -= Time.deltaTime;
        if (lifespan <= 0)
        {
            Destroy(gameObject);
        }
    }



    public  void pushToPlayer(Vector2 dir)
    {
       

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(dir * speed, ForceMode2D.Impulse);
    }

    new void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerStats ps = collision.gameObject.GetComponent<playerStats>();  
            ps.takeDamage(damage);
            Destroy(gameObject);

        }

    }
}
