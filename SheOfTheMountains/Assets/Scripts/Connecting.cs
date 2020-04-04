using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Connecting : MonoBehaviour
{
    public bool isConnecting;
    public bool hasConnected;

    public GameObject[] texts;

    public string[] mainSentence;

    Vector3 mousePos;
    public GameObject circlePrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasConnected)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
                        //GetComponent<LineRenderer>().SetPosition(0, mousePos);
                    }
                }
            }

            if (isConnecting && Input.GetButton("Fire1"))
            {
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector3.forward, Mathf.Infinity);
                //GetComponent<LineRenderer>().SetPosition(1, mousePos);

                if (hit.collider != null)
                {
                    if (hit.collider.tag != "Player" && hit.collider.gameObject.GetComponent<Text>() != null)
                    {
                        Debug.Log(hit.collider.gameObject.GetComponent<Text>().text);

                        MakeString(hit.collider.gameObject.GetComponent<Text>().text);

                        //load answer and next level
                        hasConnected = true;
                        StartCoroutine(FadeOut());
                    }
                }
            }

            if (Input.GetButtonUp("Fire1"))
            {
                for (int i = 0; i < 2; i++)
                {
                    //GetComponent<LineRenderer>().SetPosition(i, mousePos);
                }
            }

        }
        

        
    }


    IEnumerator FadeIn()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].gameObject.GetComponent<Animator>().SetTrigger("fadeOut");
            yield return new WaitForSeconds(0.1f);
        }

        GameManager.Instance.NextLevelLoad();
    }

    void MakeString(string answer)
    {

        for (int i = 0; i < 2; i++)
        {
            GetComponent<LineRenderer>().SetPosition(i, mousePos);
        }

        Instantiate(circlePrefab, mousePos, Quaternion.identity);

        string newString = mainSentence[0] + answer + mainSentence[1];
        //Debug.Log(newString);
        GameManager.Instance.AddStrings(newString);


    }
    

}
