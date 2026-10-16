using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public GameObject handUI;
    public GameObject UIText;

    public GameObject invKey;
    public GameObject fadeFX;

    public string nextSceneName; // Name of the next scene to load


    private bool inReach;


    void Start()
    {
        handUI.SetActive(false);
        UIText.SetActive(false);

        invKey.SetActive(false);

        fadeFX.SetActive(false);


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            handUI.SetActive(true);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            handUI.SetActive(false);
            UIText.SetActive(false);
        }
    }

  void Update()
{
    if (inReach && Input.GetButtonDown("Interact"))
    {
        if (invKey == null)
        {
            Debug.LogError("Inv Key Must Be Assigned To The Door", this);
            return;
        }

        if (!invKey.activeInHierarchy)
        {
            UIText.SetActive(true);
            return;
        }

        handUI.SetActive(false);
        UIText.SetActive(false);
        SceneManager.LoadScene(nextSceneName);
    }
}

    IEnumerator ending()
    {
        yield return new WaitForSeconds(.6f);
        SceneManager.LoadScene(nextSceneName);
    }

}
