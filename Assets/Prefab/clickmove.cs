using UnityEngine;
using UnityEngine.AI;

public class clickmove : MonoBehaviour
{

    public float speed = 5.0f;
    private bool isSelected = false;
    private Vector3 targetPosition;

    // Selection indicator
    public GameObject selectionIndicator;

    void Start()
    {
        selectionIndicator.SetActive(false);
        targetPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    isSelected = true;
                    selectionIndicator.SetActive(true);
                }
                else if (isSelected)
                {
                    targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                }
            }
        }

        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Escape))
        {
            isSelected = false;
            selectionIndicator.SetActive(false);
        }

        if (isSelected)
        {
            MoveToTarget();
        }
    }

    void MoveToTarget()
    {
        float step = speed * Time.deltaTime;
        Vector3 direction = (targetPosition - transform.position).normalized;

        if (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, step * 100);
        }
    }
}
