using System.Timers;
using Assets.Scripts.EventSystems;
using UnityEngine;
using QFSW.QC;

namespace Assets.Scripts.Entity
{
    [CommandPrefix("Entity.Virus.")]
    [RequireComponent(typeof(LineRenderer))]
    class Virus : AbstractEntity, IMedicineCollectedHandler, IMedicineMissedHandler
    {
        private float SpeedModifier = 1f;
        [SerializeField] private float Range = 10f;

        private byte  MedicineMissed = 1;
        private byte MedicineCollected = 1;

        private byte VertexCount = 50;
        private LineRenderer LR;

        private bool DebugMode = false;

        private Vector2? Target = null;
        [Tooltip("By how many pixels does the virus go past the target")]
        [SerializeField] private float Overextend = 3f;

        [Tooltip("Cooldown period in ms after an attack that the virus can't attack again")]
        [SerializeField] private float CooldownTime = 2000f;
        
        
        [ReadOnly] public bool Cooldown = false;

        private void Awake()
        {
            LR = GetComponent<LineRenderer>();
        }

        private void Update()
        {
            float step = Speed * SpeedModifier * Time.deltaTime;

            if (DebugMode)
            {
                if (Target != null)
                    DrawPathToTarget((Vector2)Target, Color.red);
                else if (!Cooldown)
                    DrawRangeBox();
            }

            bool isPlayerInRange = Range >= Vector2.Distance(transform.position, Player.Current.transform.position);

            // Handles movement
            if (!Cooldown && isPlayerInRange && Target == null) // If virus can atatck the player
                StartAttack();
            else if (Target != null) // If virus is in the middle of the attack
            {
                transform.position = Vector2.MoveTowards(transform.position, (Vector2)Target, step);

                // if virus has reached target, start attack cooldown
                if ((Vector2)transform.position == (Vector2)Target) 
                {
                    Debug.Log(CooldownTime / SpeedModifier);
                    Timer timeoutTimer = new Timer(CooldownTime / SpeedModifier);
                    timeoutTimer.Elapsed += OnCooldownEnd;
                    timeoutTimer.AutoReset = false;
                    timeoutTimer.Start();

                    Cooldown = true;
                    Target = null;
                }
            }
        }

        // Need to overwrite animations coming from entity
        new private void FixedUpdate() { }

        #region Debug
        [Command("Debug", MonoTargetType.All)]
        private void ToggleDebug()
        {
            DebugMode = !DebugMode;

            if (!DebugMode)
                LR.positionCount = 0;
        }

        private void DrawPathToTarget(Vector2 target, Color color)
        {
            LR.positionCount = 0;

            LR.startColor = color;
            LR.endColor = color;
            LR.widthMultiplier = 0.1f;

            LR.positionCount = 2;

            LR.SetPosition(0, transform.position);
            LR.SetPosition(1, target);

        }

        /// <summary>
        /// Draws a circle around the virus indicating its range.
        /// </summary>
        private void DrawRangeBox()
        {
            LR.positionCount = 0;

            LR.startColor = Color.green;
            LR.endColor = Color.green;
            LR.widthMultiplier = 0.1f;
            float theta = 0f;

            LR.positionCount = VertexCount + 1;
            for (int i = 0; i < VertexCount; i++)
            {
                Vector2 pos = new Vector2(Range * Mathf.Cos(theta), Range * Mathf.Sin(theta));
                LR.SetPosition(i, pos + (Vector2)transform.position);
                theta += (2f * Mathf.PI) / VertexCount;
            }

            LR.SetPosition(LR.positionCount - 1, LR.GetPosition(0));
        }
        #endregion

        /// <summary>
        /// Starts the attack and calucates the point to move to
        /// </summary>
        private void StartAttack()
        {
            // Calucate the coordinates to attack
            Vector2 player = Player.Current.transform.position;
            Vector2 virus = transform.position;

            Vector2 difference = player - virus;
            float distance = Vector2.Distance(virus, player);

            // Calculating the angle between X axis and hypotenuse (distance)
            float theda = Mathf.Acos(difference.x / distance);  // Gives the result in radians

            distance += Overextend;

            float x = Mathf.Cos(theda) * distance;
            float y = Mathf.Sin(theda) * x;


            Target = new Vector2(x, y) + virus;
        }

        #region EventHandlers
        private void OnCooldownEnd(object source, ElapsedEventArgs e)
        {
            Cooldown = false;
        }

        #region Medicine
        public void OnMedicineCollected()
        {
            MedicineMissed++;
            SpeedModifier = MedicineMissed / MedicineCollected;
        }

        public void OnMedicineMissed()
        {
            MedicineCollected++;
            SpeedModifier = MedicineMissed / MedicineCollected;
        }
        #endregion

        #endregion
    }
}
