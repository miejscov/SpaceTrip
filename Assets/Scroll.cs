using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{

    public GameObject bg1, bg2, cam;
    public float speed = 5f;

    private Flight flight;
    private bool isBg1 = true;
    private float camY;

    // Use this for initialization
    void Start()
    {
        camY = cam.transform.position.y;
        //flight = GameObject.Find("black").GetComponent<Flight>();
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(0,  flight.GetHeigh() * speed);
        if (isBg1)
        {
            if (cam.transform.position.y - camY > bg2.transform.position.y)
            {
				isBg1 = false;
				bg1.transform.position = new Vector3(0, bg2.transform.position.y+10, 10);
            }
        } else{
			if (cam.transform.position.y - camY > bg1.transform.position.y)
            {
				isBg1 = true;
				bg2.transform.position = new Vector3(0, bg1.transform.position.y+10, 10);
            }
		}
    }
}
