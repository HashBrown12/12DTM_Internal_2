using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSwitcher : MonoBehaviour
{
    public bool pathTwoClear = true;
    private Rigidbody pathTwoRb;
    // Start is called before the first frame update
    void Start()
    {
        pathTwoRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PathTwoClear(Collision collision)
    {
        if (collision.gameObject.CompareTag("Path_2_Obstacle"))
        {
            pathTwoClear = false;
        }
    }
}
