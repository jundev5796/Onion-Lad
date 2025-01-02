using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Target" || collision.tag == "Player")
        {
            UI.instance.OpenEndScreen();
        }    
    }
}
