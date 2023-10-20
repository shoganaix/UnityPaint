using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMesh : MonoBehaviour
{
    private List<Mesh> meshes; // Lista para almacenar las Meshes
    private Vector3 lastMousePosition;

    private void Start()
    {
        meshes = new List<Mesh>(); // Inicializa la lista
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Mouse Pressed, crear un nuevo Mesh
            CreateNewMesh();
        }

        if (Input.GetMouseButton(0))
        {
            // Mouse held down, continuar el dibujo en el Mesh actual
            DrawOnCurrentMesh();
        }
    }

    private void CreateNewMesh()
    //Crea una mesh cuadrada a partir de dos triangulos
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[4];
        Vector2[] uv = new Vector2[4];
        int[] triangles = new int[6];

        vertices[0] = Utils.GetMouseWorldPosition();
        vertices[1] = Utils.GetMouseWorldPosition();
        vertices[2] = Utils.GetMouseWorldPosition();
        vertices[3] = Utils.GetMouseWorldPosition();

        uv[0] = Vector2.zero;
        uv[1] = Vector2.zero;
        uv[2] = Vector2.zero;
        uv[3] = Vector2.zero;

        triangles[0] = 0;
        triangles[1] = 3;
        triangles[2] = 1;

        triangles[3] = 1;
        triangles[4] = 3;
        triangles[5] = 2;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.MarkDynamic();

        GetComponent<MeshFilter>().mesh = mesh;

        lastMousePosition = Utils.GetMouseWorldPosition();

        meshes.Add(mesh);
    }

    private void DrawOnCurrentMesh()
    //De la anterior mesh añade vertices
    {
        Mesh currentMesh = meshes[meshes.Count - 1];

        float minDistance = 0.1f;
        if (Vector3.Distance(Utils.GetMouseWorldPosition(), lastMousePosition) > minDistance)
        {
            Vector3[] vertices = new Vector3[currentMesh.vertices.Length + 2];
            Vector2[] uv = new Vector2[currentMesh.uv.Length + 2];
            int[] triangles = new int[currentMesh.triangles.Length + 6];

            currentMesh.vertices.CopyTo(vertices, 0);
            currentMesh.uv.CopyTo(uv, 0);
            currentMesh.triangles.CopyTo(triangles, 0);

            int vIndex = vertices.Length - 4;
            int vIndex0 = vIndex + 0;
            int vIndex1 = vIndex + 1;
            int vIndex2 = vIndex + 2;
            int vIndex3 = vIndex + 3;

            Vector3 mouseForwardVector = (Utils.GetMouseWorldPosition() - lastMousePosition).normalized;
            Vector3 normal2D = new Vector3(0, 0, -1f);
            float lineThickness = 0.1f;
            Vector3 newVertexUp = Utils.GetMouseWorldPosition() + Vector3.Cross(mouseForwardVector, normal2D) * lineThickness;
            Vector3 newVertexDown = Utils.GetMouseWorldPosition() + Vector3.Cross(mouseForwardVector, normal2D * -1f) * lineThickness;

            vertices[vIndex2] = newVertexUp;
            vertices[vIndex3] = newVertexDown;

            uv[vIndex2] = Vector2.zero;
            uv[vIndex3] = Vector2.zero;

            int tIndex = triangles.Length - 6;

            triangles[tIndex + 0] = vIndex0;
            triangles[tIndex + 1] = vIndex2;
            triangles[tIndex + 2] = vIndex1;

            triangles[tIndex + 3] = vIndex1;
            triangles[tIndex + 4] = vIndex2;
            triangles[tIndex + 5] = vIndex3;

            currentMesh.vertices = vertices;
            currentMesh.uv = uv;
            currentMesh.triangles = triangles;

            lastMousePosition = Utils.GetMouseWorldPosition();

            meshes.Add(currentMesh);
        }
    }
}
