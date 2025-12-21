using System.Collections.Generic;
using UnityEngine;

public class Instance_Placer : MonoBehaviour
{
    [SerializeField] Mesh mesh;
    [SerializeField] List<Material> mats;
    [SerializeField] int numberOfFans = 100;
    [SerializeField] float range = 50f;
    [SerializeField] float raycastHeight = 100f;
    [SerializeField] LayerMask terrainLayer;
    [SerializeField] float spawnHeightOffset = 0.45f;

    private List<Matrix4x4[]> matrices;
    private bool isInitialized = false;

    void Start()
    {

        matrices = new List<Matrix4x4[]>();

        int instancesPerMaterial = Mathf.CeilToInt((float)numberOfFans / mats.Count);

        for (int i = 0; i < mats.Count; i++)
        {
            matrices.Add(new Matrix4x4[instancesPerMaterial]);

            int instancesCreated = 0;
            int attempts = 0;
            int maxAttempts = instancesPerMaterial * 10;

            while (instancesCreated < instancesPerMaterial && attempts < maxAttempts)
            {
                Vector3 raycastOrigin = new Vector3(
                    Random.Range(-range, range) + 50f,
                    raycastHeight,
                    Random.Range(-range, range) + 50f
                );

                RaycastHit hit;

                if (Physics.Raycast(raycastOrigin, Vector3.down, out hit, raycastHeight * 2f, terrainLayer))
                {
                    if (hit.collider is TerrainCollider || hit.collider.gameObject.GetComponent<Terrain>() != null)
                    {
                        Vector3 position = hit.point;
                        position.y += spawnHeightOffset;

                        matrices[i][instancesCreated] = Matrix4x4.TRS(
                            position,
                            Quaternion.Euler(90, 0, 0),
                            Vector3.one * Random.Range(4,15)
                        );

                        instancesCreated++;
                    }
                }
                attempts++;
            }

        }

        isInitialized = true;
    }

    void Update()
    {
        if (!isInitialized || matrices == null) return;

        for (int i = 0; i < mats.Count; i++)
        {
            if (mats[i] != null && matrices[i].Length > 0)
            {
                Graphics.DrawMeshInstanced(
                    mesh,
                    0,
                    mats[i],
                    matrices[i]
                );
            }
        }
    }
}


