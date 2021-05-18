using Assets.Scripts.EventSystems;
using UnityEngine;

namespace Assets.Scripts.Collectible
{
    /// <summary>
    /// Used for collectibles that have some point value
    /// </summary>
    public class PointCollectible : AbstractCollectible
    {
        [Tooltip("How many points this collectible is worth")]
        public int Value = 0;

        public override void Collect()
        {
            base.Collect();

            EventSystem.Current.PointsCollected(Value);
        }
    }
}
