using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjectFish", menuName = "Scriptable Objects/ScriptableObjectFish")]
public class ScriptableObjectFish : ScriptableObject
{
    [Range(0, 10)]
    public float maxSpeed = 1f;

    [Range(.1f, .5f)]
    public float maxForce = .03f;

    [Range(1, 10)]
    public float neighborhoodRadius = 3f;

    [Range(0.1f, 10f)]
    public float separationRadius = 1f;

    [Range(0, 3)]
    public float separationAmount = 1f;

    [Range(0, 3)]
    public float cohesionAmount = 1f;

    [Range(0, 3)]
    public float alignmentAmount = 1f;

    public float MaxSpeed
    {
        get { return maxSpeed; }
    }

    public float MaxForce
    {
        get { return maxForce; }
    }

    public float NeighborhoodRadius
    {
        get { return neighborhoodRadius; }
    }

    public float SeparationRadius
    {
        get { return separationRadius; }
    }

    public float SeparationAmount
    {
        get { return separationAmount; }
    }
    public float CohesionAmount
    {
        get { return cohesionAmount; }
    }
    public float AlignmentAmount
    {
        get { return alignmentAmount; }
    }
}
