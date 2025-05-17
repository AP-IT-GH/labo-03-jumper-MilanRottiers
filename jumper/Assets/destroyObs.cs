using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class destroyObs : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject agent;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "bonusObstacle(Clone)")
        {
            agent.GetComponent<CubeAgent>().Bad();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name == "obstacle(Clone)")
        {
            agent.GetComponent<CubeAgent>().Good();
            Destroy(collision.gameObject);
        }
    }
}
