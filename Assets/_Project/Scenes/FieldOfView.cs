using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    private Mesh mesh;
    public int numberOfRays;
    public float viewDist;
    public float viewAngle;
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

    }

    // Update is called once per frame
    void Update()
    {
        float fov = viewAngle;
        Vector3 origin = Vector3.zero;
        int rayCount = numberOfRays;
        float angle = 0f;
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
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, vectorToAngle(angle), viewDistance);
            Debug.DrawRay(origin,vectorToAngle(angle), Color.green);
            if (raycastHit2D.collider == null)
            {
                vertex = origin + vectorToAngle(angle) * viewDistance;
            }
            else
            {
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

    private Vector3 vectorToAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin((angleRad)));
    }
}
