using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    public float interactionDistance = 3f;
    public GameObject interactionPrompt;

    void Start()
    {
        interactionPrompt.SetActive(false);
    }

    void Update()
    {
        Ray ray = new Ray(
            Camera.main.transform.position,
            Camera.main.transform.forward
        );

        bool lookingAtInteractable = false;

        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                lookingAtInteractable = true;

                if (Keyboard.current != null &&
                    Keyboard.current.eKey.wasPressedThisFrame)
                {
                    Destroy(hit.collider.gameObject);
                    interactionPrompt.SetActive(false);
                }
            }
        }

        interactionPrompt.SetActive(lookingAtInteractable);
    }
}