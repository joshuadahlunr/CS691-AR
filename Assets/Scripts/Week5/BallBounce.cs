using System.Collections;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public Rigidbody rigidbody;
    public MeshRenderer mesh;
    public Material hitMat, offMat;

    public Coroutine flasher = null;

    IEnumerator Flash(float time)
    {
        mesh.material = hitMat;
        yield return new WaitForSeconds(time); 
        mesh.material = offMat;
        flasher = null;
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ball"))
            return;
        
        rigidbody.linearVelocity = (rigidbody.transform.position - collision.transform.position).normalized * .5f;
        if (flasher is not null) StopCoroutine(flasher);
        flasher = StartCoroutine(Flash(1.0f/60 * 20));
    }
}
