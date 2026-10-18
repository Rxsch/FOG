using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public GameObject handUI;
    public GameObject UIText;

    public GameObject invKey;
    public GameObject fadeFX;

    public string nextSceneName;

    private bool inReach;
    private Animator noKeyAnimator;

    void Start()
    {
        if (UIText != null)
        {
            noKeyAnimator = UIText.GetComponent<Animator>();
            UIText.SetActive(false);
        }

        handUI.SetActive(false);

        if (fadeFX != null)
        {
            fadeFX.SetActive(false);
        }
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

            // Let the text animation finish even after looking away.
        }
    }

    void Update()
    {
        if (!inReach || !Input.GetButtonDown("Interact"))
        {
            return;
        }

        if (invKey == null)
        {
            Debug.LogError(
                "Assign Inv Key in the Door component.",
                this
            );
            return;
        }

        if (!invKey.activeInHierarchy)
        {
            ShowNoKeyText();
            return;
        }

        handUI.SetActive(false);
        UIText.SetActive(false);

        SceneManager.LoadScene(nextSceneName);
    }

    void ShowNoKeyText()
    {
        if (UIText == null || noKeyAnimator == null)
        {
            Debug.LogError(
                "Assign UI Text and make sure NoKeyText has an Animator.",
                this
            );
            return;
        }

        UIText.SetActive(true);

        // Restart the animation from the beginning.
        noKeyAnimator.Play("NoKey", 0, 0f);
    }
}