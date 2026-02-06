using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    // Movement along X and Y axes.
    private float movementX;
    private float movementY;

    // Speed at which the player moves.
    [SerializeField] public float speed;

    // Rigidbody of the player.
    private Rigidbody rb;
    private int count;
    public TextMeshProUGUI countText;
    public GameObject winText;

    private AudioSource Bgm;
    public AudioClip wallSound;
    public AudioClip pickupSound;

    public GameObject restartButton;
    public GameObject nextLevelButton;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get and store the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();
        Bgm = GetComponent<AudioSource>();
        count = 0;
        SetCountText();
        winText.SetActive(false);
    }

    // This function is called when a move input is detected.
    void OnMove (InputValue movementValue)
    {
        // Convert the input value into a Vector2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>();

        // Store the X and Y components of the movement.
        movementX = movementVector.x;
        movementY = movementVector.y;

       
    }

    
    void SetCountText()
    {
        countText.text = "Count:" + count.ToString();
        if(count >= 13)
        {
            winText.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            nextLevelButton.gameObject.SetActive(true);

        }
    }

    private void FixedUpdate()
    {
        // Create a 3D movement vector using the X and Y inputs.
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        // Apply force to the Rigidbody to move the player.
        rb.AddForce(movement* speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            other.gameObject.SetActive(false);
            Bgm.PlayOneShot(pickupSound, 1.0f);
            count = count + 1;
            SetCountText();
        }

    

    }




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Bgm.PlayOneShot(wallSound, 1.0f);
        }




        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            winText.gameObject.SetActive(true);
            winText.GetComponent<TextMeshProUGUI>().text = "You Lose!";
            restartButton.gameObject.SetActive(true);

        }

     
    }

   
}
