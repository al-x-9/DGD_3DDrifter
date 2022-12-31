using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("POINT!");

            //FIND THE GAME MANANGER SCRIPT IN THE SCENE AND TRIGGER THE INCRESESCORE FUNCTION ASSOCIATED WITH IT
            FindObjectOfType<GameManager>().IncreaseScore();

            //THEN DESTROY THE POINT OBJECT
            Destroy(this.gameObject);
        }
    }
}
