using UnityEngine;

namespace ithappy.Animals_FREE
{
    [RequireComponent(typeof(CreatureMover))]
    public class CreatureRandomMove : MonoBehaviour
    {
        [Header("Movement Area")]
        [SerializeField] private BoxCollider penArea;

        [Header("Idle Settings")]
        [SerializeField] private float idleTimeMin = 1f;
        [SerializeField] private float idleTimeMax = 3f;

        private CreatureMover mover;

        private Vector2 axis;
        private Vector3 target;

        private float idleTimer;
        private bool isIdle = true;

        private void Awake()
        {
            mover = GetComponent<CreatureMover>();
            PickNewTarget();
        }

        private void Update()
        {
            if (isIdle)
            {
                idleTimer -= Time.deltaTime;
                if (idleTimer <= 0f)
                {
                    PickNewTarget();
                    isIdle = false;
                }
                else
                {
                    mover.SetInput(Vector2.zero, transform.position, false, false);
                }
            }
            else
            {
                MoveTowardsTarget();

                float dist = Vector3.Distance(transform.position, target);
                if (dist < 0.5f)
                {
                    isIdle = true;
                    idleTimer = Random.Range(idleTimeMin, idleTimeMax);
                }
            }
        }

        private void PickNewTarget()
        {
            if (penArea == null)
            {
                Debug.LogWarning("Pen Area (BoxCollider) chưa được gán!");
                target = transform.position;
                return;
            }

            Bounds b = penArea.bounds;

            float x = Random.Range(b.min.x, b.max.x);
            float z = Random.Range(b.min.z, b.max.z);
            target = new Vector3(x, transform.position.y, z);
        }

        private void MoveTowardsTarget()
        {
            Vector3 dir = (target - transform.position).normalized;
            axis = new Vector2(dir.x, dir.z);

            mover.SetInput(axis, target, false, false);
        }
    }
}
