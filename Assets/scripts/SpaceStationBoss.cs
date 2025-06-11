using JetBrains.Annotations;
using UnityEngine;




public class SpaceStationBoss : MonoBehaviour
{

    public BoosTurret[] turrets;
    public float fireCD = 3f;
    private GameObject player;

    public GameObject nucleo;
    public float openingCd = 3f;
    public float openingTime = 0f;

    public bool isOpen = false;

    public bool isOpening = true;

    public float health = 1f;

    public GameObject


     void Start()
    {
        player = FindAnyObjectByType<PlayerControler>().gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        fireCD -= Time.deltaTime;

        if (fireCD <= 0)
        {
            closestTurret();
            fireCD = 3f;
        }


        openingCd -= Time.deltaTime;
        if (openingCd <= 0)
        {

            nucleo.SetActive(true);


        }


    }

    void closestTurret()
    {
        BoosTurret closest = turrets[0];
        float closestDistance = Vector2.Distance(player.transform.position, closest.transform.position);

        for (int i = 0; i < turrets.Length; i++)
        {

            if (turrets[i].isActive)
            {
                float dist = Vector2.Distance(player.transform.position, turrets[i].transform.position);
                if (dist < closestDistance)
                {
                    closest = turrets[i];
                    closestDistance = dist;
                }
            }

        }
        if (closest.isActive)
        {
            closest.Fire(player.transform.position - closest.transform.position);
        }




        void nucleoOpening()
        {

            isOpening = openingTime <= 0 ? true : openingTime >= 3 ? false : isOpening;
            if (isOpening)
            {
                openingTime += Time.deltaTime;
            }
            else
            {
                openingTime -= Time.deltaTime;
                if (openingTime <= 0)
                {
                    isOpen = false;
                    nucleo.SetActive(false);
                    openingCd = 3f;
                }
            }

            SpriteRenderer sr = nucleo.GetComponent<SpriteRenderer>();

            if (openingTime <= 1)
            {
                sr.color = Color.green;
            }
            if (openingTime > 1 && openingTime <= 2)
            {
                sr.color = Color.yellow;
            }
            if (openingTime > 2 && openingTime <= 3)
            {
                sr.color = Color.red;
            }


        }

    }

    public void Damage(float damage)
    {

        if (isOpen == false) return;
        health -= damage;
        if (true)
        {
            Destroy(bossBody);
        }

    }


}



