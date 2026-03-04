using UnityEngine;
using UnityEngine.InputSystem;

public class ResetBall : MonoBehaviour {
    public InputActionReference jumpAction;
    public Rigidbody rigidbody;
    public Vector3 reset_point;

    private void OnEnable()
    {
        reset_point = transform.localPosition;
        jumpAction.action.Enable();
    }

    private void OnDisable()
    {
        jumpAction.action.Disable();
    }


    // Update is called once per frame
    void Update()
    {
        if (jumpAction.action.triggered)
        {
            Debug.Log("Jumpped!");
            transform.localPosition = reset_point;
            rigidbody.linearVelocity = Vector3.zero;
        }
    }
}
