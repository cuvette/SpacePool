var target : Transform;
var distance = 10.0;
var maxDistance = 100.0;
var minDistance = 1.0;
var dSpeed = 120;
var sampleXMaxAngle = 70;
var sampleYMaxAngle = 70;
var smoothRotation = 0.2f;
var smoothSample = 0.2f;
var xSpeed = 250.0;
var ySpeed = 120.0;

var yMinLimit = -20;
var yMaxLimit = 80;

private var x = 0.0;
private var y = 0.0;
private var sampleX = 0.0;
private var sampleY = 0.0;

@script AddComponentMenu("Camera-Control/Mouse Orbit")

function Start () {
    var angles = transform.eulerAngles;
    x = angles.y;
    y = angles.x;

	// Make the rigid body not change rotation
   	if (GetComponent.<Rigidbody>())
		GetComponent.<Rigidbody>().freezeRotation = true;
}

function Update () {
    if (target) {
        x += Input.GetAxis("Horizontal2") * xSpeed * 0.02;
        y -= Input.GetAxis("Vertical2") * ySpeed * 0.02;
        
        if(Input.GetButton("ZoomIn"))
        {
        	distance -= 1 * dSpeed * 0.02;
        }
        if(Input.GetButton("ZoomOut"))
        {
        	distance += 1 * dSpeed * 0.02;
        }
        
        sampleX = Input.GetAxis("Horizontal") * sampleXMaxAngle;
        sampleY = Input.GetAxis("Vertical") * sampleYMaxAngle;
        
        if(distance <= minDistance)
        {
        	distance = minDistance;
 		}
 		if(distance >= maxDistance)
 		{
 			distance = maxDistance;
 		}
 		
 		y = ClampAngle(y, yMinLimit, yMaxLimit);
 		       
        var rotation = Quaternion.Euler(y, x, 0);
        var position = rotation * Vector3(0.0, 0.0, -distance) + target.position;
        var rotation2 = Quaternion.Euler(y + sampleY,x + sampleX, 0);
        
        transform.rotation = Quaternion.Lerp(transform.rotation,rotation,smoothRotation);
        transform.position = Vector3.Lerp(transform.position, position, smoothRotation);
    	transform.rotation = Quaternion.Lerp(transform.rotation,rotation2,smoothSample);
    }
}

static function ClampAngle (angle : float, min : float, max : float) {
	if (angle < -360)
		angle += 360;
	if (angle > 360)
		angle -= 360;
	return Mathf.Clamp (angle, min, max);
}