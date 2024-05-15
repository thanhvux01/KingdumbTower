using UnityEngine;


[RequireComponent(typeof(Trajectory_Predictor))]
public class TargetLocator_Catapult : MonoBehaviour
{

    [Tooltip("Your weapon will look at enemies when shoot")]
    [SerializeField] Transform weapon;

    [Tooltip("Where your projectile come from")]
    [SerializeField] Transform initialPoint;
    [SerializeField] GameObject throwObject;
    [SerializeField] float range = 15f;
    [SerializeField] float force = 50f;
    [SerializeField] float maxForce = 60f;
    Animator animator;
    Transform target;
    Trajectory_Predictor trajectory_Predictor;

    private void Awake()
    {

        trajectory_Predictor = GetComponent<Trajectory_Predictor>();
        animator = GetComponent<Animator>();

    }
    private void Update()
    {
        FindClosestTarget();
        Aiming();
    }

    private void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;
        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }

        }
        target = closestTarget;
    }
    private void Aiming()
    {

        if (target != null)
        {
            float targetDistance = Vector3.Distance(transform.position, target.transform.position);
            weapon.LookAt(target.transform.position);
            if (targetDistance < range)
            {
                if (!animator.GetBool("Attack"))
                {
                    animator.SetBool("Attack", true);

                }
            }
            else
            {
                if (animator.GetBool("Attack"))
                {
                    animator.SetBool("Attack", false);
                }
            }
        }
        else
        {
            if (animator.GetBool("Attack"))
            {
                animator.SetBool("Attack", false);
            }
        }

    }

    private void Shoot()
    {
        Rigidbody rb = throwObject.GetComponent<Rigidbody>();
        float neededForce = trajectory_Predictor.Predict(force, maxForce, rb, initialPoint);
        if (neededForce > 0)
        {
            GameObject throwObject_ = Instantiate(throwObject, initialPoint.position, Quaternion.identity);
            Rigidbody rb_ = throwObject_.GetComponent<Rigidbody>();
            rb_.AddForce(initialPoint.forward * neededForce, ForceMode.Impulse);
        }

    }
}












