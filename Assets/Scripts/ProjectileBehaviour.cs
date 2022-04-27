using UnityEngine;
using System.Collections;

public class ProjectileBehaviour : MonoBehaviour
{
    public float Speed = 14.5f;
    public Vector3 LaunchOffset;
    public bool Thrown;
    public bool Explode;
    public float Damage = 1;
    public float SplashRange = 1.5f;



    private void Start()
    {
        StartCoroutine(Wait());
        if (Thrown)
        {

            var direction = transform.right + Vector3.up;
            GetComponent<Rigidbody2D>().AddForce(direction *Speed, ForceMode2D.Impulse);

        }
        transform.Translate(LaunchOffset);

        Destroy(gameObject, 4); // destrói depois de 5 segundos
    }

    void Update()
    {
        if (!Thrown)
        { transform.position += transform.right * Time.deltaTime * 2 * Speed; }
       

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (SplashRange > 0)       
        {
            Wait();
            var hitColliders = Physics2D.OverlapCircleAll(transform.position, SplashRange);
            foreach (var hitCollider in hitColliders)
            {
                var enemy = hitCollider.GetComponent<EnemyBehaviour>();
                if (enemy)
                {
                    var closestPoint = hitCollider.ClosestPoint(transform.position);
                    var distance = Vector3.Distance(closestPoint, transform.position);

                    var damagePercent = Mathf.InverseLerp(SplashRange, 0, distance);
                    
                    if (Explode)
                    {
                      enemy.TakeHit(5);
              


                    }
                }
            }

        }

        else
        {
        if (Thrown)
        {
            Wait();
            if (Explode)
                {
                var enemy = collision.collider.GetComponent<EnemyBehaviour>();
                if (enemy)
                {
                    enemy.TakeHit(5);
                }


            }

            Destroy(gameObject, 4);
        }
        else
        {
            var enemy = collision.collider.GetComponent<EnemyBehaviour>();
            if (enemy)
            {
                enemy.TakeHit(1);
            }
            Destroy(gameObject);
        }
        }

    }

    IEnumerator Wait()
    {

        //Print the time of when the function is first called.
       // Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);
        Explode =true;

        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }


}