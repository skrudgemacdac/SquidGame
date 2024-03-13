using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody _rigidbody;
    public Animator animator;
    public float speed;
    public float runSpeed;
    public float rotationSpeed;
    public GameObject Character;
    public GameObject RagDoll;
    public Text winText;
    public LayerMask notPlayerMask;
    public float jumpForce;
    public Transform groundChecker;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 dirVector = new Vector3(horizontal, 0, vertical);
        if (dirVector.magnitude > Mathf.Abs(0.05f))
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dirVector), Time.deltaTime * rotationSpeed);

        animator.SetFloat("speed", Vector3.ClampMagnitude(dirVector, 1).magnitude);
        Vector3 moveDir = Vector3.ClampMagnitude(dirVector, 1) * speed;
        _rigidbody.velocity = new Vector3(moveDir.x, _rigidbody.velocity.y, moveDir.z);
        _rigidbody.angularVelocity = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Run();
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Jump();
        }

        if (Physics.Raycast(groundChecker.transform.position, Vector3.down, 10f, notPlayerMask))
        {
            animator.SetBool("isInAir", false);
        }
        else 
        {
            animator.SetBool("isInAir", true);
        }
    }

    public void Die()
    {
        Character.SetActive(false);
        RagDoll.SetActive(true);
        Instantiate(RagDoll, transform.position, transform.rotation);
    }

    //public void Win() 
    //{
    //    winText.gameObject.SetActive(true);
    //    StopAllCoroutines();
    //    SceneManager.LoadScene(0);
    //}

    void Run() 
    {
        speed = runSpeed;
    }

    void Jump() 
    {
        if (Physics.Raycast(groundChecker.transform.position, Vector3.down, 10f, notPlayerMask)) 
        {
            animator.SetTrigger("Jump");
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}