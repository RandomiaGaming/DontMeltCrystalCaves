using UnityEngine;
public class WallCheckerScript : MonoBehaviour
{
    public bool Walled { get; private set; } = false;

    private void FixedUpdate()
    {
        Walled = false;
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Ground")
        {
            Walled = true;
        }
    }
}