using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform Player1;
    public Transform Player2;
    public Transform Player3;
    public Transform Player4;
    public float smoothSpeed = 0.125f;
    public float rotationSpeed = 10F;

    GameObject playerObj1;
    GameObject playerObj2;
    GameObject playerObj3;
    GameObject playerObj4;
    public Vector3 cameraOffset;

    private PlayerClientToServer fromServer;

    void Start()
    {
        playerObj1 = GameObject.Find("Player 1");
        playerObj2 = GameObject.Find("Player 2");
        playerObj3 = GameObject.Find("Player 3");
        playerObj4 = GameObject.Find("Player 4");
        cameraOffset = new Vector3(0, 1.25f, 0);
    }
    // LateUpdate function runs after Update and doesn't compete (smoother performance)
    void LateUpdate()
    {

        float ImPlayer = float.Parse(GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().ImPlayer);

        // Camera follows players position in first person.
        if (ImPlayer == 1)
        {
            Vector3 rotation = playerObj1.transform.eulerAngles;

            transform.position = playerObj1.transform.position + cameraOffset;
            transform.eulerAngles = rotation;

        }
        else if (ImPlayer == 2)
        {
            Vector3 rotation = playerObj2.transform.eulerAngles;

            transform.position = playerObj2.transform.position + cameraOffset;
            transform.eulerAngles = rotation;
        }
        else if (ImPlayer == 3)
        {
            Vector3 rotation = playerObj3.transform.eulerAngles;

            transform.position = playerObj3.transform.position + cameraOffset;
            transform.eulerAngles = rotation;
        }
        else if (ImPlayer == 4)
        {
            Vector3 rotation = playerObj4.transform.eulerAngles;

            transform.position = playerObj4.transform.position + cameraOffset;
            transform.eulerAngles = rotation;
        }

        /*
        // Camera follows players position in first person.
        if (ImPlayer == 1)
        {
            /*Vector3 desiredPosition = Player1 .position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.rotation = Player1.rotation;

            // Get current rotation of camera and rotate with player rotation
            Vector3 rotation = transform.eulerAngles;
            rotation.x += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
            transform.eulerAngles = rotation;*/

        /*var rotation = playerObj.transform.eulerAngles.y * rotationSpeed;
        rotation *= Time.deltaTime;
    }
    else if (ImPlayer == 2)
    {
        Vector3 desiredPosition = Player2.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.rotation = Player2.rotation;

        // Get current rotation of camera and rotate with player rotation
        Vector3 rotation = transform.eulerAngles;
        rotation.x += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.eulerAngles = rotation;
    }
    else if (ImPlayer == 3)
    {
        Vector3 desiredPosition = Player3.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.rotation = Player3.rotation;

        // Get current rotation of camera and rotate with player rotation
        Vector3 rotation = transform.eulerAngles;
        rotation.x += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.eulerAngles = rotation;
    }
    else if (ImPlayer == 4)
    {
        Vector3 desiredPosition = Player4.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.rotation = Player4.rotation;

        // Get current rotation of camera and rotate with player rotation
        Vector3 rotation = transform.eulerAngles;
        rotation.x += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.eulerAngles = rotation;
    }*/
    }
}
