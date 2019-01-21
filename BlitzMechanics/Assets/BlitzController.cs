using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlitzController : MonoBehaviour
{
    [SerializeField] private GameObject fist;
    [SerializeField] private GameObject handStartPos;
    [SerializeField] private GameObject handFinishPos;
    [SerializeField] private RectTransform line;
    [SerializeField] private float shootspeed;
    [SerializeField] public static bool firingArm;
    [SerializeField] private bool movingForward;
    private bool targetHit;

    //GameObject hitGO;
    List<GameObject> objectsHit;

    // Start is called before the first frame update
    void Start()
    {
        firingArm = false;
        targetHit = false;
        movingForward = true;
        objectsHit = new List<GameObject>();
    }

    // Update is called once per frame
    public void FireArm()
    {
        if(firingArm == false)
        {
            firingArm = true;
            movingForward = true;
            targetHit = false;
        }

    }

    public void FixedUpdate()
    {
        if (firingArm)
        {
            if (movingForward)
            {
                //Debug.Log("Ida");
                Vector3 val1 = Vector3.MoveTowards(fist.transform.position, handFinishPos.transform.position, shootspeed);
                line.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, val1.x- 260);

                fist.transform.position = val1;

                if(Vector3.Distance(fist.transform.position, handFinishPos.transform.position) < 0.1f)
                {

                    movingForward = false;
                }
            }
            else
            {
                Vector3 val2 = Vector3.MoveTowards(fist.transform.position, handStartPos.transform.position, shootspeed);
                line.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, val2.x - 260);
                fist.transform.position = val2;
                if (Vector3.Distance(fist.transform.position, handStartPos.transform.position) < 0.1f)
                {
                    if (targetHit)
                    {
                        //Do something here
                        //Destroy(hitGO);
                        //hitGO = null;
                        //EnemySpawner.currentSpawnedEnemies--;
                        foreach(GameObject enemy in objectsHit)
                        {
                            //objectsHit.Remove(enemy);
                            Destroy(enemy);
                            EnemySpawner.currentSpawnedEnemies--;
                        }
                        objectsHit = new List<GameObject>();
                    }
                    firingArm = false;
                }
            }
        }
    }
    public void OnChildTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Debug.Log("Soy un Player y me pego un Enemy");

            targetHit = true;
            movingForward = false;
            //hitGO = collision.gameObject;
            objectsHit.Add(collision.gameObject);
        }
    }
    
}
