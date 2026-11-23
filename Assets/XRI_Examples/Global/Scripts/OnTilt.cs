using UnityEngine.Events;

namespace UnityEngine.XR.Content.Interaction
{
    /// <summary>
    /// Runs functionality when an object is tilted.
    /// Used with grabbable objects for pouring.
    /// </summary>
    public class OnTilt : MonoBehaviour
    {
        /// <summary>
        /// Extra angle value that is added/removed from the threshold to events from rapid-fire triggering on and off.
        /// </summary>
        const float k_AngleBuffer = 0.05f;

        [SerializeField]
        [Tooltip("Tilt range, 0 - 180 degrees.")]
        [Range(k_AngleBuffer * 2f, (1 - k_AngleBuffer * 2f))]
        float m_Threshold = 0.5f;

        [SerializeField]
        [Tooltip("The transform to check for tilt. Will default to this object if not set.")]
        Transform m_Target;

        [SerializeField]
        [Tooltip("The transform to get as the source of the 'up' direction. Will default to world up if not set.")]
        Transform m_UpSource;

        [SerializeField]
        [Tooltip("The transform to get as the source of the 'down' direction. Will default to world down if not set.")]
        Transform m_DownSource;       

        [SerializeField]
        [Tooltip("Event to trigger when tilting goes over the threshold.")]
        UnityEvent m_OnBegin = new UnityEvent();

        [SerializeField]
        [Tooltip("Event to trigger when tilting returns from the threshold.")]
        UnityEvent m_OnEnd = new UnityEvent();

        [SerializeField]
        [Tooltip("Prefab to spawn from the tip while tilted.")]
        GameObject m_BallPrefab;

        [SerializeField]
        [Tooltip("The tip from which balls are spawned. Will default to the target transform.")]
        Transform m_SpawnPoint;

        [SerializeField]
        [Tooltip("Time in seconds between spawned balls.")]
        float m_SpawnInterval = 0.1f;

        [SerializeField]
        [Tooltip("Initial speed applied to spawned balls.")]
        float m_SpawnVelocity = 1f;

        /// <summary>
        /// Event to trigger when tilting goes over the threshold.
        /// </summary>
        public UnityEvent onBegin => m_OnBegin;

        /// <summary>
        /// Event to trigger when tilting returns from the threshold.
        /// </summary>
        public UnityEvent onEnd => m_OnEnd;

        bool m_WithinThreshold;
        float m_NextSpawnTime;

        void Update()
        {
            CheckOrientation();

            if (m_WithinThreshold && Time.time >= m_NextSpawnTime)
            {
                SpawnWaterBall();
                m_NextSpawnTime = Time.time + Mathf.Max(0.01f, m_SpawnInterval);
            }
        }

        void CheckOrientation()
        {
            var targetUp = m_Target != null ? m_Target.up : transform.up;
            var baseUp = m_UpSource != null ? m_UpSource.up : Vector3.up;

            var similarity = Vector3.Dot(-targetUp, baseUp);
            similarity = Mathf.InverseLerp(-1, 1, similarity);

            if (m_WithinThreshold)
                similarity += k_AngleBuffer;
            else
                similarity -= k_AngleBuffer;

            var thresholdCheck = (similarity >= m_Threshold);

            if (m_WithinThreshold != thresholdCheck)
            {
                m_WithinThreshold = thresholdCheck;

                if (m_WithinThreshold)
                {
                    m_OnBegin.Invoke();
                }
                else
                {
                    m_OnEnd.Invoke();
                }
            }
        }

        public void SpawnWaterBall()
        {
            if (m_BallPrefab == null)
                return;

            var spawnPoint = m_SpawnPoint != null ? m_SpawnPoint : m_Target;
            var position = spawnPoint != null ? spawnPoint.position : transform.position;
            var rotation = spawnPoint != null ? spawnPoint.rotation : transform.rotation;
            var ball = Instantiate(m_BallPrefab, position, rotation);

            if (ball.TryGetComponent<Rigidbody>(out var rigidbody))
            {
                var direction = spawnPoint != null ? spawnPoint.forward : -transform.up;
                rigidbody.linearVelocity = direction.normalized * m_SpawnVelocity;
            }
        }
}
}