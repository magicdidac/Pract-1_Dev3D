using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] GUIStyle style = null;
    

    [HideInInspector] private AState _currentState;

    [HideInInspector]
    public AState currentState
    {
        get { return _currentState; }

        set
        {
            if (value == null)
                return;

            if (_currentState != null)
                _currentState.DoExit();

            _currentState = value;

        }
    }

    [Space]
    [Header("Enemy AI Parameters")]
    [SerializeField] public bool recievedDamage = false;
    [SerializeField] public bool recievedCritical = false;
    [SerializeField] public bool listenPlayer = false;
    [SerializeField] public bool seePlayer = false;
    [SerializeField] public List<Vector3> positions = new List<Vector3>();
    [HideInInspector] public int posIndex = 0;
    [SerializeField] public float speed = 5;
    [Header("Vision")]
    [SerializeField] public int rayNumber = 5;
    [SerializeField] public float visionAngles = 45;
    [SerializeField] public float visionDistance = 5;
    [SerializeField] public float offser = .5f; 
    [Header("Hear")]
    [SerializeField] public float listenRadius = 4;



    private void Start()
    {
        currentState = new Patrol_ES(this);

        positions.Add(transform.position);

        SphereCollider c = gameObject.AddComponent<SphereCollider>();
        c.radius = listenRadius;
        c.isTrigger = true;
    }

    private void Update()
    {
        currentState.DoUpdate();
    }

    private void FixedUpdate()
    {
        seePlayer = CheckVision();


        currentState = currentState.ChangeState();
        currentState.DoFixedUpdate();


        recievedDamage = false;
        recievedCritical = false;
    }

    private bool IsCurrentType(Type type)
    {
        return currentState.GetType() == type;
    }

    public void SetNearestIndex()
    {
        int nearestIndex = 0;

        for(int i = 1; i < positions.Count; i++)
        {
            if(PointDistance(positions[nearestIndex]) > PointDistance(positions[i]))
            {
                nearestIndex = i;
            }
        }

        posIndex = nearestIndex;

    }

    private float PointDistance(Vector3 point)
    {
        return (point - transform.position).magnitude;
    }

    private bool CheckVision()
    {

        float yOffset = visionAngles / (rayNumber-1);
        float angle = -(visionAngles / 2);

        bool seePlayer = false;

        for (int i = 0; i < rayNumber; i++)
        {
            float newAngle = angle + transform.eulerAngles.y;
            Vector3 dir = (new Vector3(Mathf.Sin(Mathf.Deg2Rad * newAngle) * visionDistance, 0, Mathf.Cos(Mathf.Deg2Rad * newAngle) * visionDistance)).normalized;
            RaycastHit hit;
            Ray ray = new Ray(transform.position + (transform.forward * offser), dir * visionDistance);

            if (Physics.Raycast(ray, out hit, visionDistance))
            {
                float distance = (hit.point - transform.position).magnitude;

                if (hit.transform.parent != null && hit.transform.parent.GetComponent<FPSController>() != null)
                {
                    seePlayer = true;
                    Debug.DrawRay(ray.origin, ray.direction * distance, Color.green);
                }
                else
                {
                    seePlayer = (seePlayer == true);
                    Debug.DrawRay(ray.origin, ray.direction * distance, Color.yellow);
                }
            }
            else
            {
                seePlayer = (seePlayer == true);
                Debug.DrawRay(ray.origin, ray.direction * visionDistance);
            }

            angle += yOffset;
        }

        return seePlayer;

    }


    private void OnTriggerEnter(Collider other)
    {

        if(other.transform.GetComponent<FPSController>() != null)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, (other.transform.position - transform.position).normalized, out hit))
            {
                Debug.Log("Hit: " + hit.transform.gameObject);
                if (hit.transform.parent != null && hit.transform.parent.GetComponent<FPSController>() != null)
                {
                    listenPlayer = true;
                    return;
                }
            }
            listenPlayer = false;
        }



    }

    private void OnDrawGizmos()
    {

        Vector3 oldPos = positions[positions.Count - 1];

        if (!Application.isPlaying)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawLine(oldPos, transform.position);
            Gizmos.color = new Color(0, 255, 0, .5f);
            Gizmos.DrawSphere(transform.position, .5f);
            oldPos = transform.position;
        }

        foreach (Vector3 v in positions)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawLine(oldPos, v);
            Gizmos.color = new Color(255, 0, 0, .5f);
            Gizmos.DrawSphere(v, .5f);
            oldPos = v;
        }

    #if UNITY_EDITOR
        if(currentState != null)
            Handles.Label(transform.position + Vector3.up, currentState.GetType()+"", style);
        else
            Handles.Label(transform.position + Vector3.up, name, style);
#endif

        if (!Application.isPlaying)
        {
            CheckVision();
            
            Gizmos.color = new Color(0, 255, 0, .25f);
            Gizmos.DrawSphere(transform.position, listenRadius);
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(transform.position, listenRadius);
        }

        Vector3 forward = transform.forward * listenRadius;
        Debug.DrawRay(transform.position, forward, Color.green);

        

    }

}
