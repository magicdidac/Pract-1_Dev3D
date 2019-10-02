using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class Gun : MonoBehaviour
{
    [SerializeField] protected int maxAmmo = 200;
    [SerializeField] protected int maxLoader = 8;
    [SerializeField] protected int damage = 15;
    [SerializeField] protected float cadence = 1;
    [HideInInspector] public int ammo;
    [HideInInspector] public int gunAmmo;
    [HideInInspector] protected bool reloading;
    [HideInInspector] protected Animator anim;
    [SerializeField] protected GameObject particles = null;
    [HideInInspector] protected Transform particlesSpawn;

    [HideInInspector] protected float lastTime;

    [SerializeField] public float criticProb = .5f;
    [SerializeField] public float criticMultiplier = .5f;

    protected void Start()
    {
        anim = GetComponent<Animator>();
        particlesSpawn = transform.GetChild(0);

        gunAmmo = maxLoader;
        ammo = maxAmmo - maxLoader;
    }

    public abstract void Shoot();

    public abstract void Reload();

    public void AddAmmo(int ammount)
    {
        if (ammo == maxAmmo)
            return;

        ammo += ammount;
        if (ammo > maxAmmo)
            ammo = maxAmmo;
    }

    protected void InstantiateParticles()
    {
        GameObject part = Instantiate(particles, particlesSpawn.position, Quaternion.identity);
        part.transform.SetParent(transform);
        Destroy(part, .5f);
    }

    public bool HaveMaxAmmo()
    {
        return ammo >= maxAmmo;
    }

}
