using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Head : MonoBehaviour
{
    public static int movespeed = 1;
    public Vector3 userDirection = Vector3.right;
    private Vector3 targetPos;
    [SerializeField] private lr_LineController line;
    private bool hasClicked = false;
    public float maxTravelDistance = 1.5f;

    public int MaxHealth = 100;
    public int CurrentHealth = 80;
    public int HealthCost = 5;

    public HealthBar healthBar;

    public Camera mainCamera;
    public float transitionDuration = 3f;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
        healthBar.SetMaxHealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // Head face click
        if (Input.GetMouseButtonDown(0) && !hasClicked && CurrentHealth > 0)
        {
            hasClicked = true;
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;

            //this.targetPos = mousePosition;

            var difference = transform.position - mousePosition;
            var direction = difference.normalized;
            var distance = Mathf.Min(maxTravelDistance, difference.magnitude);

            var endPosition = transform.position + -direction * distance;

            this.targetPos = endPosition;

            line.AddPointToLine();
            SubtractHealth();

            this.FollowCamera(targetPos);
        }

        if (Input.GetMouseButtonUp(0))
        {
            hasClicked = false;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos, movespeed * Time.deltaTime);
    }

    private void SubtractHealth()
    {
        CurrentHealth = CurrentHealth - HealthCost;
        healthBar.SetHealth(CurrentHealth);

        if (CurrentHealth <= 0)
        {
            GameObject gameObject1 = GameObject.FindGameObjectWithTag(ScoreTracker.ScoreTag);
            var depth = GameObject.Find("DepthMeter").transform.GetComponent<DepthMeter>().depth;
            gameObject1.GetComponent<ScoreTracker>().AddScore(depth);
        }
    }

    public void AddHealth(float health)
    {
        CurrentHealth = Mathf.Min(CurrentHealth + (int)health, MaxHealth);
        healthBar.SetHealth(CurrentHealth);
    }

    private void FollowCamera(Vector3 targetPos)
    {
        mainCamera.transform.DOMoveY(targetPos.y, transitionDuration);
    }
}
