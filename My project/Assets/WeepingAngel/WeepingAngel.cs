using UnityEngine;
using UnityEngine.AI;

public class WeepingAngel : MonoBehaviour
{
    public NavMeshAgent ai;
    public Transform player;
    public Camera playerCam;
    public float speed = 4f;

    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        if (ai == null) ai = GetComponent<NavMeshAgent>();
        if (playerCam == null) playerCam = Camera.main;
    }

    void Update()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(playerCam);
        bool inView = GeometryUtility.TestPlanesAABB(planes, rend.bounds);
        Vector3 c = rend.bounds.center;
        Vector3 e = rend.bounds.extents;
        Vector3[] points =
        {
            c,                                  // middle
            c + Vector3.up * e.y * 0.9f,        // head
            c - Vector3.up * e.y * 0.9f,        // feet
            c + playerCam.transform.right * e.x * 0.9f,  // right side
            c - playerCam.transform.right * e.x * 0.9f   // left side
        };

        bool canSeeAnyPart = false;
        foreach (Vector3 p in points)
        {
            if (!Physics.Linecast(playerCam.transform.position, p, out RaycastHit hit) || hit.transform == transform)
            {
                canSeeAnyPart = true;
                break;
            }
        }

        bool isSeen = inView && canSeeAnyPart;

        if (isSeen)
        {
            // Freeze instantly
            ai.speed = 0;
            ai.velocity = Vector3.zero;
            ai.isStopped = true;
        }
        else
        {
            // Chase the player
            ai.isStopped = false;
            ai.speed = speed;
            ai.SetDestination(player.position);
        }
    }
}