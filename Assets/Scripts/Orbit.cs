using Unity.Mathematics;
using UnityEngine;

public class Orbit : MonoBehaviour {

    public Transform OrbitPoint;
    
    void Update()  {
        var v = OrbitPoint.localPosition + new Vector3(math.cos(Time.timeSinceLevelLoad) * .3f, .1f, math.sin(Time.timeSinceLevelLoad) * .3f);
        transform.localPosition = v;
    }
}
