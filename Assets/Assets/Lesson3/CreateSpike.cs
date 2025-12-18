using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class CreateSpike : MonoBehaviour
{
    [Range(0f, 1f)]
    public float topScale = 1f; // Масштаб верхней части

    void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = meshFilter.mesh;
        Vector3[] vertices = mesh.vertices;

        // Модифицируем верхние вершины (вершины с Y > 0)
        for (int i = 0; i < vertices.Length; i++)
        {
            if (vertices[i].y > 0f) // Верхние вершины куба
            {
                vertices[i].x *= topScale;
                vertices[i].z *= topScale;
            }
        }

        mesh.vertices = vertices;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }
}
