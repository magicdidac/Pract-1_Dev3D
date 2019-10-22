using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public abstract class Gun : MonoBehaviour
{
    [SerializeField] protected int maxAmmo = 200;
    [SerializeField] protected int maxLoader = 8;
    [SerializeField] protected int damage = 15;
    [SerializeField] protected float cadence = 1;
    [HideInInspector] public int ammo;
    [HideInInspector] public int gunAmmo;
    [HideInInspector] protected bool reloading;
    [SerializeField] protected GameObject particles = null;
    [HideInInspector] protected Transform particlesSpawn;

    [HideInInspector] protected float lastTime;

    [SerializeField] private GameObject bulletHoleDecal = null;

    [HideInInspector] protected FPSController player;

    protected void Start()
    {
        player = GameManager.instance.player;
        particlesSpawn = transform.GetChild(0);

        gunAmmo = maxLoader;
        ammo = maxAmmo/2  - maxLoader;

        player.animationController.StartAnimation("GetIn", false);
    }

    public abstract void Shoot();

    public abstract void Reload();

    protected void InstantiateDecal(Vector3 position, Vector3 normal, Transform transform)
    {
        GameObject decal = Instantiate(bulletHoleDecal, position, Quaternion.LookRotation(normal), transform);

        decal.transform.eulerAngles = new Vector3(decal.transform.eulerAngles.x, decal.transform.eulerAngles.y, Random.Range(0f, 359.99f));

        SetGlobalScale(decal.transform, decal.transform.localScale);

        DecalGarbage.AddDecal(decal);

    }

    public static void SetGlobalScale(Transform transform, Vector3 globalScale)
    {
        transform.localScale = Vector3.one;
        transform.localScale = new Vector3(globalScale.x / transform.lossyScale.x, globalScale.y / transform.lossyScale.y, globalScale.z / transform.lossyScale.z);
    }

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
