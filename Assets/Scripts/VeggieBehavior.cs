using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeggieBehavior : MonoBehaviour
{
    [SerializeField]
    private int id;

    private bool dontSpawn = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Touching: " + collision.gameObject.name);

        VeggieBehavior secondVeggie;

        if (collision.gameObject.TryGetComponent<VeggieBehavior>(out secondVeggie)) 
        {
            if (id < 7 && id == secondVeggie.id && dontSpawn == false)
            {
                secondVeggie.dontSpawn = true;
                Destroy(this.gameObject);
                Destroy(collision.gameObject);
                ObjectManager.Instance.SpawnFruit(id + 1, collision.contacts[0].point);                
            }

            if (id == 7 && id == secondVeggie.id) 
            {
                Destroy(this.gameObject);
                Destroy(collision.gameObject);
            }
        }        
    }
}
