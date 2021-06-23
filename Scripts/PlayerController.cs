using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public  Vector2 jumpForce = new Vector2(0, 300);
	public Camera cam;
	private Rigidbody2D rb;

	public void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	public void ApplyForce() {
        rb.velocity = Vector2.zero;
        rb.AddForce(jumpForce);		
	}
	
	
    public void Update() {
        if (Input.GetKeyUp("space")) {
			ApplyForce();
        }

        // Die by being off screen
        Vector2 screenPosition = cam.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0)
            Die();
    }

    public void OnTriggerEnter2D(Collider2D other) {
        Die();
    }

    void Die() {
        SceneManager.LoadScene(0);
    }
}
