using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    private float speed=5f;
    public float horizontalinput;
    public float verticalinput;
    public GameObject laserPrefab;
    public float firerate = 0.25f;
    public float nextfire = 0.0f;
    public int life=3; 
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new UnityEngine.Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        bounds();
        if(Input.GetKeyDown(KeyCode.Space)&& Time.time>nextfire)
        {
            nextfire = Time.time +firerate;
            Debug.Log("SPACEBAR PRESSED");
            Instantiate(laserPrefab,transform.position,Quaternion.identity );
        }
        

    }
    void movement()
    {
        float verticalinput=Input.GetAxis("Vertical");
        float horizontalinput=Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right*horizontalinput*speed*Time.deltaTime);
        transform.Translate(Vector3.up*verticalinput*speed*Time.deltaTime);
    }

    void bounds()
    {
       if (transform.position.y>=4)
        {
            transform.position=new Vector3(transform.position.x,4,transform.position.z);
        }
        else if (transform.position.y<=-4)
        {
            transform.position=new Vector3(transform.position.x,-4,transform.position.z);
        }
        if (transform.position.x>=9.5f)
        {
            transform.position=new Vector3(9.5f,transform.position.y,transform.position.z);
        }
        else if(transform.position.x<=-9.5f)
        {
             transform.position=new Vector3(-9.5f,transform.position.y,transform.position.z);
        } 
    }
    public void damage()
    {
        life--;
        if(life == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
