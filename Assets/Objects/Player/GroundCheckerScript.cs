using UnityEngine;
public class GroundCheckerScript : MonoBehaviour
{
    public bool Grounded { get; private set; } = false;

    private void FixedUpdate()
    {
        Grounded = false;
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            Grounded = true;
        }
    }
}