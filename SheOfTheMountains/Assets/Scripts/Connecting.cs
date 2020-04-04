using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Connecting : MonoBehaviour
{
    public bool isConnecting;
    public bool hasConnected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasConnected)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            if (Input.GetButtonDown("Fire1"))
            {
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector3.forward, Mathf.Infinity);

                // If it hits something...
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "Player")
                    {
                        isConnecting = true;
                        GetComponent<LineRenderer>().SetPosition(0, mousePos);
                    }
                }
            }

            if (isConnecting && Input.GetButton("Fire1"))
            {
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector3.forward, Mathf.Infinity);
                GetComponent<LineRenderer>().SetPosition(1, mousePos);

                if (hit.collider != null)
                {
                    if (hit.collider.tag != "Player" && hit.collider.gameObject.GetComponent<Text>() != null)
                    {
                        Debug.Log(hit.collider.gameObject.GetComponent<Text>().text);

                        //load answer and next level
                        hasConnected = true;
                        GetComponent<Animator>().SetTrigger("fadeOut");
                    }
                }
            }
        }
        

        
    }

    public void NextLevel()
    {
        //Call Game Manager, instantiate next prefab
        Destroy(gameObject);
    }

}
