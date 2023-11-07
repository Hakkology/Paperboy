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
        if (Vector3.Distance(_transform.position, _currentTarget.point.position) < .1f)
        {
            if (_currentTarget.Equals(_path.rotationPoint))
            {
                Quaternion targetRotation = Quaternion.Euler(_currentTarget.rotation);
                
                Quaternion flatRotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);
                _transform.rotation = flatRotation;

                _isRotating = false;
                _speed = 10f;  
                _currentTarget = _path.endPoint;
            }
            else if (_currentTarget.Equals(_path.endPoint))
            {
                DestroyCar();
            }
        }
    }


    private void DestroyCar()
    {
        GameObject.Destroy(_transform.gameObject);
    }
}
