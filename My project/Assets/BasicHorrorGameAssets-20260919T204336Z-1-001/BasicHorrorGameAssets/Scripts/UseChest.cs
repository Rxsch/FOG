using UnityEngine;

public class UseChest : MonoBehaviour
{
    public GameObject handUI;
    public GameObject objToActivate;

    private bool inReach;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        handUI.SetActive(false);
        objToActivate.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Reach"))
        {
            inReach = true;
            handUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Reach"))
        {
            inReach = false;
            handUI.SetActive(false);
        }
    }

    void Update()
    {
        if (inReach && Input.GetKeyDown(KeyCode.E))
        {
            handUI.SetActive(false);
            objToActivate.SetActive(true);

            animator.SetBool("open", true);

            GetComponent<BoxCollider>().enabled = false;
        }
    }
}