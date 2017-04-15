# Unity-Target-Position-Prediction
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
