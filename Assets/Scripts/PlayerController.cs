using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    Rigidbody rgbd;
    public float speed = 10;
    public GameObject focalPoint,powerUpIndicator;
    bool hasPowerup;
    private float powerUpStrength = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PowerUps")
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            powerUpIndicator.SetActive(true);
            StartCoroutine(PowerUpCountDownCor());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy"&& hasPowerup)
        {
            Rigidbody enemy = collision.gameObject.GetComponent<Rigidbody>();
            enemy.AddForce((enemy.position - transform.position)*powerUpStrength, ForceMode.Impulse);
            Debug.Log(hasPowerup);
        }
    }

    IEnumerator PowerUpCountDownCor()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerUpIndicator.SetActive(false);
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rgbd = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        rgbd.AddForce(focalPoint.transform.forward*speed*forwardInput);
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -.5f, 0);
    }
}
