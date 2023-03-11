using UnityEngine;

public class CollissionDetector : MonoBehaviour
{
    public PlayerMovement movement;

    void OnCollisionEnter()
    {
        Debug.Log("hit");
    }

}
