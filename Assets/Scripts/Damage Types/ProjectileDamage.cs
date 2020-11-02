using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : DamageType
{
    [SerializeField] GameObject projectileToSpawn;
    [SerializeField] Transform spawnLocation;

    public HarpoonGun harpoonGun { get; private set; }

    protected override void Start()
    {
        base.Start();
        harpoonGun = GetComponent<HarpoonGun>();
    }

    public void LaunchProjectile()
    {

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hit;

        Vector3 destination = new Vector3();

        if(Physics.Raycast(ray, out hit))
        {
            destination = hit.point;
        }
        else
        {
            destination = ray.GetPoint(1000);
        }

        GameObject projectile = Instantiate(projectileToSpawn, spawnLocation.position, spawnLocation.rotation);
        projectile.GetComponent<Projectile>().owner = this;
        projectile.GetComponent<Rigidbody>().velocity = (destination - spawnLocation.position).normalized * harpoonGun.projectileVelocity;
        //projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward.normalized * harpoonGun.projectileVelocity;
        //projectile.GetComponent<Rigidbody>().AddForce(Vector3.forward * harpoonGun.projectileVelocity);
    }

}
