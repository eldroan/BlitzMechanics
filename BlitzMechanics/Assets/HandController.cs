using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    [SerializeField] private BlitzController parent;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        parent.OnChildTriggerEnter2D(collision);
    }
}
