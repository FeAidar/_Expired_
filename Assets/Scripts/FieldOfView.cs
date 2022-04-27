using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
        private Mesh mesh;
    public float Fov = 45f;
    public float Distance = 50f;
    private float fov;
    private float startingAngle;
    private Vector3 origin;
    public int raycount = 50;
    public bool peguei;
    private float viewDistance = 0;
    public bool lanterna;
    public float teste;
    public float teste2;
    public GameObject Player;





    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        origin = Vector3.zero;
        StartCoroutine("distancia");

    }
     private void LateUpdate() { 
          
        int rayCount = raycount;
        fov = Fov;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;
        
               mesh.RecalculateBounds();


        Vector3[] vertices = new Vector3[rayCount +1 +1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i<= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, UtilsClass.GetVectorFromAngle(angle), viewDistance, layerMask);
            if (raycastHit2D.collider == null)
            {
                //no hit
                vertex = origin + UtilsClass.GetVectorFromAngle(angle) * viewDistance;
                //Debug.Log("NADA");
                
            }
            else
            {
                if (raycastHit2D.collider.tag == "Player")
                { //Debug.Log("peguei o heroi");
                   peguei = true;

                }

                //Hit Object
                vertex = raycastHit2D.point;
               //Debug.Log("ACHEI!");

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
            angle -= angleIncrease;
        }


        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
            
    }
    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void SetAimDirection(Vector3 aimDirection)
    {
        if(!lanterna)
        startingAngle = UtilsClass.GetAngleFromVectorFloat(aimDirection) - fov / 2f;
        else
        {
            if (Player.transform.rotation.eulerAngles.y == 180)
            {
                startingAngle = -teste;
                
            }

            if (Player.transform.rotation.eulerAngles.y == 0)
            {
                startingAngle = teste2;
                
            }

        }
        
  
    }

    IEnumerator distancia()
    {
        yield return new WaitForSeconds(0.3f);
        viewDistance = Distance;
        
    }
}
