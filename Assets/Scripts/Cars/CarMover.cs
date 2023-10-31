using UnityEngine;

public class CarMover
{
    private Transform _transform;
    private CarPath _path;
    private PathSegment _currentTarget;
    public float _speed = Random.Range(5,20);
    private bool _isRotating = false;

    public CarMover(Transform carTransform, CarPath path)
    {
        _transform = carTransform;
        _path = path;
        _currentTarget = _path.spawnPoint;
    }
    public void OnStart()
    {
        MeshRenderer carRenderer = _transform.GetComponent<MeshRenderer>();
        float carHeightOffset = carRenderer != null ? carRenderer.bounds.extents.y : 0; 

        _transform.position = new Vector3(_transform.position.x, _currentTarget.point.position.y + carHeightOffset +.1f, _transform.position.z);

        _currentTarget = _path.rotationPoint;
    }

    public void OnUpdate()
    {
        if (!_isRotating){
            MoveTowardsTarget();
            RotateTowardsTarget();
            CheckForTargetReached();
        }

    }

    private void MoveTowardsTarget()
    {

        Vector3 targetPosition = new Vector3(_currentTarget.point.position.x, _transform.position.y, _currentTarget.point.position.z);
        Vector3 direction = (targetPosition - _transform.position).normalized;
        _transform.position += direction * _speed * Time.deltaTime;
    }

    private void RotateTowardsTarget()
    {
        Vector3 targetDirection = -(_currentTarget.point.position - _transform.position).normalized;
        _transform.rotation = Quaternion.LookRotation(targetDirection);
    }

    private void CheckForTargetReached()
    {
        if (Vector3.Distance(_transform.position, _currentTarget.point.position) < .5f)
        {
            if (_currentTarget.Equals(_path.rotationPoint))
            {
                _transform.rotation = Quaternion.Euler(_currentTarget.rotation); // set rotation instantly
                _isRotating = false;
                _speed = 10f;  
                _currentTarget = _path.endPoint; // move to the next point immediately
            }
            else if (_currentTarget.Equals(_path.endPoint))
            {
                DestroyCar();
            }
        }
    }

    // private void PerformRotation()
    // {

    //     float rotationDuration = 1f; 
    //     Quaternion targetRotation = Quaternion.Euler(_currentTarget.rotation);
    //     _transform.rotation = Quaternion.RotateTowards(_transform.rotation, targetRotation, (90.0f / rotationDuration) * Time.deltaTime);

    //     if (Mathf.Abs(Quaternion.Angle(_transform.rotation, targetRotation)) < 20.0f)
    //     {
    //         _transform.rotation = targetRotation;
    //         _isRotating = false;
    //         _speed = 10f;
    //     }
    // }

    private void DestroyCar()
    {
        GameObject.Destroy(_transform.gameObject);
    }
}
