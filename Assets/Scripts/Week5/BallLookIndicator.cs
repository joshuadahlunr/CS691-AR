using UnityEngine;

public class BallLookIndicator : MonoBehaviour
{
    public GameObject targetBall;
    public GameObject pair;
    private Rigidbody ballBody;
    private BallBounce bounce;
    // public Vector3 offset;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballBody = targetBall.gameObject.GetComponent<Rigidbody>();
        bounce = targetBall.GetComponent<BallBounce>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = targetBall.transform.position;
        transform.localPosition += Vector3.forward * .005f;
        transform.rotation = Quaternion.LookRotation(ballBody.linearVelocity);
        
        // Debug.Log((transform.position - pair.transform.position).sqrMagnitude);
        if (bounce.flasher is not null)
        {
            transform.rotation = Quaternion.LookRotation(pair.transform.position - transform.position);
        }
        transform.localRotation *= Quaternion.AngleAxis(90, Vector3.up);
    }
}
