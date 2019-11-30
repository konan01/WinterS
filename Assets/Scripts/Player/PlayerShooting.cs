using Photon.Pun;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
     public static int damagePerShot = 20;
     public static float timeBetweenBullets = 0.3f;
     public static int length=1;

    public GameObject Prefab_Projactile;

    //public bool shottriger= false;
    public int debuglengt = 1;

    float timer;
    float effectsDisplayTime = 0.2f;
    private JoyCon shot;
    private PhotonView photonView;
    void Awake ()
    {
        shot = GameObject.FindGameObjectWithTag("Joystik1").GetComponent<JoyCon>();
        photonView= GetComponent<PhotonView>();
    }


    void Update ()
    {
        length = debuglengt;
        timer += Time.deltaTime;

        if (photonView.IsMine && shot.IsActive() && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            OnceShoot();
        }
        //if (shottriger && timer >= timeBetweenBullets && Time.timeScale != 0)
        //    OnceShoot();
        //if (shot.IsActive() && Time.timeScale != 0)
        //{
        //    Shoot();
        //}
        //if (timer >= timeBetweenBullets * effectsDisplayTime)
        //{
        //    DisableEffects ();
        //}
    }

    void OnceShoot ()
    {
        timer = 0f;

        if (length == 1)
        {
            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position, Quaternion.LookRotation(transform.forward));
            //Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward));
        }
        else if (length == 2)
        {
            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position + transform.right * 0.1f, Quaternion.LookRotation(transform.forward));
            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position + transform.right * 0.1f * -1, Quaternion.LookRotation(transform.forward));

            //Instantiate(Prefab_Projactile, transform.position+ transform.right * 0.1f, Quaternion.LookRotation(transform.forward));
            //Instantiate(Prefab_Projactile, transform.position+ transform.right * 0.1f * -1, Quaternion.LookRotation(transform.forward));

        }
        else if (length == 3)
        {
            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position + transform.up * 0.1f, Quaternion.LookRotation(transform.forward));
            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position + transform.right * 0.1f + transform.up * -0.1f, Quaternion.LookRotation(transform.forward));
            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position + transform.right * -0.1f + transform.up * -0.1f, Quaternion.LookRotation(transform.forward));

            //Instantiate(Prefab_Projactile, transform.position + transform.up * 0.1f, Quaternion.LookRotation(transform.forward));
            //Instantiate(Prefab_Projactile, transform.position + transform.right * 0.1f + transform.up * -0.1f, Quaternion.LookRotation(transform.forward));
            //Instantiate(Prefab_Projactile, transform.position + transform.right * -0.1f + transform.up * -0.1f, Quaternion.LookRotation(transform.forward));

        }
        else if (length == 4)
        {
            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position + transform.up * 0.2f, Quaternion.LookRotation(transform.forward));
            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position + transform.up * 0.2f * -1, Quaternion.LookRotation(transform.forward));

            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position + transform.right * 0.2f, Quaternion.LookRotation(transform.forward));
            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position + transform.right * 0.2f * -1, Quaternion.LookRotation(transform.forward));

            //Instantiate(Prefab_Projactile, transform.position + transform.up* 0.2f, Quaternion.LookRotation(transform.forward));
            //Instantiate(Prefab_Projactile, transform.position + transform.up* 0.2f * -1, Quaternion.LookRotation(transform.forward));

            //Instantiate(Prefab_Projactile, transform.position + transform.right * 0.2f, Quaternion.LookRotation(transform.forward));
            //Instantiate(Prefab_Projactile, transform.position + transform.right * 0.2f * -1, Quaternion.LookRotation(transform.forward));


        }
        else if (length == 5)
        {
            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position, Quaternion.LookRotation(transform.forward));

            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position + transform.up * 0.2f, Quaternion.LookRotation(transform.forward));
            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position + transform.up * 0.2f * -1, Quaternion.LookRotation(transform.forward));

            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position + transform.right * 0.2f, Quaternion.LookRotation(transform.forward));
            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position + transform.right * 0.2f * -1, Quaternion.LookRotation(transform.forward));

            //Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward));
            //Instantiate(Prefab_Projactile, transform.position + transform.up * 0.2f, Quaternion.LookRotation(transform.forward));
            //Instantiate(Prefab_Projactile, transform.position + transform.up * 0.2f * -1, Quaternion.LookRotation(transform.forward));

            //Instantiate(Prefab_Projactile, transform.position + transform.right * 0.2f, Quaternion.LookRotation(transform.forward));
            //Instantiate(Prefab_Projactile, transform.position + transform.right * 0.2f * -1, Quaternion.LookRotation(transform.forward));

        }
        else if (length == 6)
        {
            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position + transform.up * 0.2f, Quaternion.LookRotation(transform.forward));
            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position + transform.right * 0.2f + transform.up * -0.2f, Quaternion.LookRotation(transform.forward));
            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position + transform.right * -0.2f + transform.up * -0.2f, Quaternion.LookRotation(transform.forward));

            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position + transform.up * -0.2f, Quaternion.LookRotation(transform.forward));
            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position + transform.right * -0.2f + transform.up * 0.2f, Quaternion.LookRotation(transform.forward));
            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position + transform.right * 0.2f + transform.up * 0.2f, Quaternion.LookRotation(transform.forward));

            //Instantiate(Prefab_Projactile, transform.position + transform.up * 0.2f, Quaternion.LookRotation(transform.forward));
            //Instantiate(Prefab_Projactile, transform.position + transform.right * 0.2f + transform.up * -0.2f, Quaternion.LookRotation(transform.forward));
            //Instantiate(Prefab_Projactile, transform.position + transform.right * -0.2f + transform.up * -0.2f, Quaternion.LookRotation(transform.forward));

            //Instantiate(Prefab_Projactile, transform.position + transform.up * -0.2f, Quaternion.LookRotation(transform.forward));
            //Instantiate(Prefab_Projactile, transform.position + transform.right * -0.2f + transform.up * 0.2f, Quaternion.LookRotation(transform.forward));
            //Instantiate(Prefab_Projactile, transform.position + transform.right * 0.2f + transform.up * 0.2f, Quaternion.LookRotation(transform.forward));

        }
        else if (length == 7)
        {
            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position, Quaternion.LookRotation(transform.forward));

            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position, Quaternion.LookRotation(transform.forward));
            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position, Quaternion.LookRotation(transform.forward));
            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position, Quaternion.LookRotation(transform.forward));

            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position, Quaternion.LookRotation(transform.forward));
            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position, Quaternion.LookRotation(transform.forward));
            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position, Quaternion.LookRotation(transform.forward));

            //Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward));

            //Instantiate(Prefab_Projactile, transform.position + transform.up * 0.2f, Quaternion.LookRotation(transform.forward));
            //Instantiate(Prefab_Projactile, transform.position + transform.right * 0.2f + transform.up * -0.2f, Quaternion.LookRotation(transform.forward));
            //Instantiate(Prefab_Projactile, transform.position + transform.right * -0.2f + transform.up * -0.2f, Quaternion.LookRotation(transform.forward));

            //Instantiate(Prefab_Projactile, transform.position + transform.up * -0.2f, Quaternion.LookRotation(transform.forward));
            //Instantiate(Prefab_Projactile, transform.position + transform.right * -0.2f + transform.up * 0.2f, Quaternion.LookRotation(transform.forward));
            //Instantiate(Prefab_Projactile, transform.position + transform.right * 0.2f + transform.up * 0.2f, Quaternion.LookRotation(transform.forward));


        }
        else if (length == 8)
        {
            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position, Quaternion.LookRotation(transform.forward));

            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position, Quaternion.LookRotation(transform.forward));
            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position, Quaternion.LookRotation(transform.forward));

            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position, Quaternion.LookRotation(transform.forward));
            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position, Quaternion.LookRotation(transform.forward));

            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position, Quaternion.LookRotation(transform.forward));
            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position, Quaternion.LookRotation(transform.forward));

            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position, Quaternion.LookRotation(transform.forward));
            PhotonNetwork.Instantiate(Prefab_Projactile.name, transform.position, Quaternion.LookRotation(transform.forward));

            //Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward));

            //Instantiate(Prefab_Projactile, transform.position + transform.up * 0.2f, Quaternion.LookRotation(transform.forward));
            //Instantiate(Prefab_Projactile, transform.position + transform.up * 0.2f * -1, Quaternion.LookRotation(transform.forward));

            //Instantiate(Prefab_Projactile, transform.position + transform.right * 0.2f, Quaternion.LookRotation(transform.forward));
            //Instantiate(Prefab_Projactile, transform.position + transform.right * 0.2f * -1, Quaternion.LookRotation(transform.forward));

            //Instantiate(Prefab_Projactile, transform.position + transform.up * 0.4f, Quaternion.LookRotation(transform.forward));
            //Instantiate(Prefab_Projactile, transform.position + transform.up * 0.4f * -1, Quaternion.LookRotation(transform.forward));

            //Instantiate(Prefab_Projactile, transform.position + transform.right * 0.4f, Quaternion.LookRotation(transform.forward));
            //Instantiate(Prefab_Projactile, transform.position + transform.right * 0.4f * -1, Quaternion.LookRotation(transform.forward));

        }
        else if (length == 9)
        {
            //Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward));

            //Instantiate(Prefab_Projactile, transform.position + transform.up * 0.2f, Quaternion.LookRotation(transform.forward));
            //Instantiate(Prefab_Projactile, transform.position + transform.right * 0.2f + transform.up * -0.2f, Quaternion.LookRotation(transform.forward));
            //Instantiate(Prefab_Projactile, transform.position + transform.right * -0.2f + transform.up * -0.2f, Quaternion.LookRotation(transform.forward));

            //Instantiate(Prefab_Projactile, transform.position + transform.right * -0.2f, Quaternion.LookRotation(transform.forward));
            //Instantiate(Prefab_Projactile, transform.position + transform.right * 0.2f, Quaternion.LookRotation(transform.forward));

            //Instantiate(Prefab_Projactile, transform.position + transform.up * -0.2f, Quaternion.LookRotation(transform.forward));
            //Instantiate(Prefab_Projactile, transform.position + transform.right * -0.2f + transform.up * 0.2f, Quaternion.LookRotation(transform.forward));
            //Instantiate(Prefab_Projactile, transform.position + transform.right * 0.2f + transform.up * 0.2f, Quaternion.LookRotation(transform.forward));

            
           

        }

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
    void ShootGun()
    {
        timer = 0f;

       
        if (length == 3)
        {
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward));
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward + transform.right * 0.2f));
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward + transform.right * 0.2f * -1));

        }
        else if (length == 4)
        {
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward + transform.right * 0.1f));
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward + transform.right * 0.2f));
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward + transform.right * 0.1f * -1));
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward + transform.right * 0.2f * -1));

        }

        else if (length == 5)
        {
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward));
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward + transform.right * 0.1f));
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward + transform.right * 0.2f));
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward + transform.right * 0.1f * -1));
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward + transform.right * 0.2f * -1));

        }
        else if (length == 6)
        {

            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward + transform.right * 0.1f));
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward + transform.right * 0.2f));
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward + transform.right * 0.3f));
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward + transform.right * 0.1f * -1));
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward + transform.right * 0.2f * -1));
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward + transform.right * 0.3f * -1));

        }
        else if (length == 7)
        {
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward));
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward + transform.right * 0.1f));
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward + transform.right * 0.2f));
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward + transform.right * 0.3f));
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward + transform.right * 0.1f * -1));
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward + transform.right * 0.2f * -1));
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward + transform.right * 0.3f * -1));

        }
        else if (length == 8)
        {

            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward));
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward + transform.right * 0.1f));
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward + transform.right * 0.2f));
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward + transform.right * 0.3f));
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward + transform.right * 0.4f));
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward + transform.right * 0.1f * -1));
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward + transform.right * 0.2f * -1));
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward + transform.right * 0.3f * -1));
            Instantiate(Prefab_Projactile, transform.position, Quaternion.LookRotation(transform.forward + transform.right * 0.4f * -1));

        }
    }
    public void DisableEffects()
    {

    }
}

