using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeObject : MonoBehaviour
{
    private Mesh[] meshes;
    private Material[] materials;
    private PrimitiveType[] primitiveTypes;

    // Use this for initialization
    void Start()
    {
        // Select primitive types
        primitiveTypes = new PrimitiveType[3];
        primitiveTypes[0] = PrimitiveType.Cube;
        primitiveTypes[1] = PrimitiveType.Sphere;
        primitiveTypes[2] = PrimitiveType.Capsule;

        // Generate 3 meshes from the primitive meshes instantiated
        meshes = new Mesh[3];
        for (int i = 0; i <= 2; i++)
        {
            GameObject primitive = GameObject.CreatePrimitive(primitiveTypes[i]);
            meshes[i] = new Mesh();
            meshes[i].vertices = primitive.GetComponent<MeshFilter>().mesh.vertices;
            meshes[i].uv = primitive.GetComponent<MeshFilter>().mesh.uv;
            meshes[i].triangles = primitive.GetComponent<MeshFilter>().mesh.triangles;
            Destroy(primitive);
        }

        // Generate 3 unlit materials (red, green, blue)
        materials = new Material[3];
        materials[0] = new Material(Shader.Find("Standard"));
        materials[0].color = new Color(255.0f, 0.0f, 0.0f);
        materials[1] = new Material(Shader.Find("Standard"));
        materials[1].color = new Color(0.0f, 255.0f, 0.0f);
        materials[2] = new Material(Shader.Find("Standard"));
        materials[2].color = new Color(0.0f, 0.0f, 255.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // Cycle a random object on click
        if (Input.GetMouseButtonDown(0))
            Randomize();
    }

    private void Randomize()
    {
        // Assign a random mesh and material from our arrays
        this.GetComponent<MeshRenderer>().material = materials[Random.Range(0, 3)];
        this.GetComponent<MeshFilter>().mesh = meshes[Random.Range(0, 3)];
    }
}
