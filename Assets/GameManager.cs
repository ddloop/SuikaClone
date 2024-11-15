using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject placeZone;

    GameObject currentFruit;

    void Start()
    {
        SpawnPlaceableFruit();
    }

    void Update()
    {
        
    }

    void SpawnPlaceableFruit() 
    {
        var newFruit = ObjectManager.Instance.SpawnFruit(Random.Range(0, 4), placeZone.gameObject.transform.position);
        newFruit.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        currentFruit = newFruit;
        StartCoroutine("MouseTrack");
    }

    IEnumerator MouseTrack() 
    {
        while (!Input.GetMouseButtonDown(0)) 
        {
            Vector3 newPosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,placeZone.transform.position.y,0);
            currentFruit.transform.position = newPosition;
            
            yield return 0;
        }

        currentFruit.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(1f);

        SpawnPlaceableFruit();
    }
}
