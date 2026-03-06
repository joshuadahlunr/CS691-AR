using UnityEngine;

public class ResizableCube : MonoBehaviour
{
    public void SetX(float scale)
    {
        transform.localScale = new Vector3(scale * .1f, transform.localScale.y, transform.localScale.z);
    }
    
    public void SetY(float scale)
    {
        transform.localScale = new Vector3(transform.localScale.x, scale * .1f, transform.localScale.z);
    }
    
    public void SetZ(float scale)
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, scale * .1f);
    }
}
