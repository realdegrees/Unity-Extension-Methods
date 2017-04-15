using UnityEngine;
public static class Ext_Vector3
{

    /// <summary>
    /// Can be used to approximate the position a projectile must be aimed at in order to hit a given target at a given velocity.
    /// <par />
    /// Note: If the return type is a direction Vector the Vector's magnitude will be equal to the projectileSpeed argument.
    /// </summary>

    public static Vector3 Predict(Vector3 projectileOrigin, Vector3 targetPosition, Vector3 targetVelocity, float projectileSpeed, EPredictionType output = EPredictionType.Point)
    {
        float time;
        float distance;
        Vector3 projectileVelocity = (targetPosition - projectileOrigin).normalized * projectileSpeed;

        Vector3 projectileVelocityPrediction = projectileVelocity;
        Vector3 projectileHitPrediction;

        for (int i = 0; i < 5; i++)
        {
            distance = Vector3.Distance(projectileOrigin, targetPosition);
            time = distance / projectileSpeed;
            projectileHitPrediction = projectileOrigin + projectileVelocityPrediction.normalized * distance;
            targetPosition = projectileOrigin + targetVelocity * time;
            projectileVelocityPrediction = (targetPosition - projectileOrigin).normalized * projectileVelocity.magnitude;
        }
        switch (output)
        {
            case EPredictionType.Point:
                return targetPosition;
            case EPredictionType.Direction:
                return (targetPosition - projectileOrigin).normalized * projectileSpeed;
            default: return targetPosition;
        }
    }

}
public enum EPredictionType
{
    Point,
    Direction
}