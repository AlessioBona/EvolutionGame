using UnityEngine;
using System.Collections;

public class CamMovementScript : MonoBehaviour
{
    public float speed;
    public float negspeed;
    public float min = -5.0f;
    public float max = 30.0f;
    public GameObject player;
    private Vector3 offset;
    

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            player.transform.position = new Vector3(Mathf.Clamp(player.transform.position.x + speed * Time.deltaTime, min, max), player.transform.position.y, player.transform.position.z);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            player.transform.position = new Vector3(Mathf.Clamp(player.transform.position.x + negspeed * Time.deltaTime, min, max), player.transform.position.y, player.transform.position.z);
        }
    }
}