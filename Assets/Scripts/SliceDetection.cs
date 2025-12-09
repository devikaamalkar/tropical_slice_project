using UnityEngine;

public class SliceDetection : MonoBehaviour
{
    Camera cam;
    public float sliceRadius = 0.7f; 

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        FollowMouse();

        if (Input.GetMouseButton(0)) 
        {
            TrySlice();
        }
    }

    void FollowMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f; 
        Vector3 worldPos = cam.ScreenToWorldPoint(mousePos);
        transform.position = worldPos;
    }

    void TrySlice()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, sliceRadius);

        foreach (Collider c in hits)
        {
            Fruit f = c.GetComponent<Fruit>();
            if (f != null)
            {
                f.Slice();
            }
        }
    }
}
