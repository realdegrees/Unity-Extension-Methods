# Ext_Vector3
An extension method which can be used to approximate the position a projectile must be aimed at in order to hit a given target at a given velocity.

HOW TO USE:

    // Declare a Vector3 to store the output in;
    Vector3 output;
    // Assign the static method to your output Vector;
    output = Ext_Vector3.Predict(projectileOrigin, targetPosition, targetVelocity, projectileSpeed);

    // projectileOrigin is the point your projectile starts flying from, e.g.: a gun's barrel;
    // targetPosition is the current position of target;
    // targetVelocity is the direction the target is currently headed in (Must have the correct magnitude);
    // projectileSpeed is the speed your projectile flies at;
    // Optional: EPredictionType output is the type of Vector3 that will be returned
             EPredictionType.Point is the default and returns the position where you need to shoot the projectile at;
             EPredictionType.Direction is the direction your porjectile needs to be shot at (Gets returned with the correct magnitude);

NOTES:

    At extremely high velocities the inner for loop might need to run more than 5 times to return a correct approximation.
    However through testing I found that even at velocities up to 200m/s 5 iterations are way more than sufficient.
    Even with 2 iterations the result is fairly accurate;
    
    The result of this method will never return the exact position or direction but rather a very accurate approximation.

# Ext_Physics
An extension method which can be used to shoot a curved raycast given a start position, direction and gravity.

HOW TO USE:

    // Works almost the same as a regular RayCast (Since it's just a number of RayCasts)
    bool output;
    RayCastHit curvedHit;
    int smoothness; // Defines how smooth/curved the CurveCast will be
    // Create a Vector3 List, this will be used to store the points along the curved RayCast; You can use this to map a LineRenderer to        the points in order to visualize the CurveCast;
    List<Vector3> curvePoints;
    output = CurveCast(origin, direction, gravityDirection, smoothness, RaycastHit hitInfo, maxDistance, List<Vector3> points);
    
NOTES:

    Currently does not support Layers, though if you want they are easy to add since regular RayCasts are used internally.
    Can be overloaded to exclude the List output in case you want to improve performance and don't need to visualize the CurveCast.
    
