using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    private Mesh mesh;
    [SerializeField]private LayerMask _layerMask;
    public int numberOfRays;
    public float viewDist;
    public float viewAngle;
    private Vector3 origin;
    private float startingAnlge;
    [SerializeField] private int playerLayer;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
        mesh = new Mesh();
        var bounds = new Bounds(Vector3.negativeInfinity, Vector3.positiveInfinity);
        mesh.bounds = bounds;


        GetComponent<MeshFilter>().mesh = mesh;
        origin = Vector3.zero;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        float fov = viewAngle;
        int rayCount = numberOfRays;
        float angle = startingAnlge;
        float angleInc = fov / rayCount;
        float viewDistance = viewDist;

        Vector3[] vertices = new Vector3[rayCount + 1 +1];
        Vector2[]uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];
        
        vertices[0] = origin;
        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, vectorToAngle(angle), viewDistance, _layerMask);
            Debug.DrawRay(origin,vectorToAngle(angle));
            if (raycastHit2D.collider == null)
            {
                vertex = origin + vectorToAngle(angle) * viewDistance;
            }
            else
            {
                    if(raycastHit2D.collider.gameObject.layer.Equals(playerLayer))
                    {
                      
                       target = raycastHit2D.collider.transform;
                       
                    }


                    vertex = raycastHit2D.point;
            }

            vertices[vertexIndex] = vertex;
            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleInc;

        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

    }

    

    public void setOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void setViewDirection(Vector3 direction)
    {
        startingAnlge = vectorToFloatAngle(direction) + viewAngle/2;
    }
    private Vector3 vectorToAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin((angleRad)));
    }

    private static float vectorToFloatAngle(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }

    public Transform getTarget()

    {
        return target;
    }
}
