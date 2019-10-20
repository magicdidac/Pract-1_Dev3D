using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
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


    [HideInInspector] private FieldOfView fow;


    private void Start()
    {
        fow = GetComponent<FieldOfView>();

        currentState = new Patrol_ES(this);

        positions.Add(transform.position);

    }

    private void Update()
    {
        currentState.DoUpdate();
    }

    private void FixedUpdate()
    {
        seePlayer = fow.SeePlayer();
        listenPlayer = fow.ListenPlayer();

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

}
