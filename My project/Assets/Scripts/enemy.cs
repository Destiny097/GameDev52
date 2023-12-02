using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float enemy_speed=1f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0,6,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down* enemy_speed*Time.deltaTime);
        if (transform.position.y<-10)
        {
           transform.position = new Vector3(Random.Range(-6,6),7,0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            Player player=other.transform.GetComponent<Player>().damage();
            
            Destroy(this.gameObject);
            
        }
        if (other.tag=="Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
  