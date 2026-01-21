using System.Data;
using UnityEngine;

public class triggerActions : MonoBehaviour
{
    [SerializeField] GameObject Spawn;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
            Destroy(Spawn);
    }
}
