using UnityEngine;
using UnityEngine.Splines;
public class MoveAlongSpline : MonoBehaviour
{
    public SplineContainer Spline;
    public float Speed;
    float DistancePercentage = 0f;

    float SplineLength;
    private void Start()
    {
        SplineLength = Spline.CalculateLength(); // kijkt hoe groot de spline is.
    }
    private void Update()
    {
        DistancePercentage += Speed * Time.deltaTime / SplineLength; // beweegt het object over de lengte van de spline.

        Vector3 currentPosition = Spline.EvaluatePosition(DistancePercentage);//checks where on the spline the object is.
        transform.position = currentPosition;
        if(DistancePercentage > 1f)
        {
            UIchanger.instance.AddLives();
            DistancePercentage = 0f;
        }
        Vector3 Nextposition = Spline.EvaluatePosition(DistancePercentage + 0.05f);
        Vector3 Direction = Nextposition - currentPosition;
        transform.rotation = Quaternion.LookRotation(Direction, transform.up);
    }

}

