using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] public static int damagePerShot = 20;
    [SerializeField] public static float timeBetweenBullets = 0.4f;

    public GameObject Prefab_Projactile;
    float timer;
   
    float effectsDisplayTime = 0.2f;
    private JoyCon shot;
    Vector3 direction;
    public int length;
    public int strange;
    void Awake ()
    {
        shot = GameObject.FindGameObjectWithTag("Joystik1").GetComponent<JoyCon>();
        
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if (shot.IsActive() && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot();
        }
        //if (shot.IsActive() && Time.timeScale != 0)
        //{
        //    Shoot();
        //}
        //if (timer >= timeBetweenBullets * effectsDisplayTime)
        //{
        //    DisableEffects ();
        //}
    }

    public void DisableEffects ()
    {
       
    }


    void Shoot ()
    {
        Quaternion newRotation;
        int n=1;
        float angle=0.2f;
        timer = 0f;
        //for (int i = 0; i < length; i++)
       // {
            if (length == 1)
            {
                direction = transform.forward;
                newRotation = Quaternion.LookRotation(direction);
                Instantiate(Prefab_Projactile, transform.position, newRotation);
            }
            if (length >= 2)
            {
                for (int j = 0; j < length ; j++, n *= j == length / 2 ? 1 : -1,  n = j == (int)length/2 && length>2? 0 : n , angle= j == length / 2 ? 0 : angle)
                {
                    direction = transform.forward + transform.right * n *angle;
                    newRotation = Quaternion.LookRotation(direction);
                    Instantiate(Prefab_Projactile, transform.position, newRotation);
                }
                
            }
        //}
        
       // direction2 = transform.forward + transform.right;
       // Quaternion newRotation1 = Quaternion.LookRotation(direction2);
       // Instantiate(Prefab_Projactile, transform.position, newRotation1);
       // direction3 = transform.forward + transform.right * -1;
       // Quaternion newRotation2 = Quaternion.LookRotation(direction3);
       // Instantiate(Prefab_Projactile, transform.position, newRotation2);
       // //direction4 = transform.forward;
       // //Quaternion newRotation3 = Quaternion.LookRotation(direction4);
       //// Instantiate(Prefab_Projactile, transform.position, newRotation3);
       // direction5 = transform.forward + transform.right * 0.5f;
       // Quaternion newRotation4 = Quaternion.LookRotation(direction5);
       // Instantiate(Prefab_Projactile, transform.position, newRotation4);
       // direction6 = transform.forward + transform.right * -1 * 0.5f;
       // Quaternion newRotation5 = Quaternion.LookRotation(direction6);
       // Instantiate(Prefab_Projactile, transform.position, newRotation5);



        //if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
        //{
        //    EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
        //    if(enemyHealth != null)
        //    {
        //        enemyHealth.TakeDamage (damagePerShot, shootHit.point);
        //    }
        //    gunLine.SetPosition (1, shootHit.point);
        //}
        //else
        //{
        //    gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        //}
    }
}
