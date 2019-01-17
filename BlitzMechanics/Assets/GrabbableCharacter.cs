using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float timeInSecondsToDestroy;
    [SerializeField] private float scoreGivenIfGrabbed;
    private bool dontAutoDestroy;
    

    void Update()
    {
        if(timeInSecondsToDestroy > 0)
        {
            timeInSecondsToDestroy -= Time.deltaTime;
        }
        else
        {
            if(dontAutoDestroy == false)
            {
                Destroy(this.gameObject);
                EnemySpawner.currentSpawnedEnemies--;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Soy un character y me pego un player");
            dontAutoDestroy = true;
            this.gameObject.transform.parent = collision.gameObject.transform;
            this.gameObject.transform.localPosition = Vector3.zero;
        }
    }
}
