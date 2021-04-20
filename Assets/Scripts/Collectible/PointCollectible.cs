using Assets.Scripts.EventSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        [Obsolete("OnCollected is deprecated, please use Collect instead.")]
        public override void OnCollected()
        {
            Collect();
        }

        public override void Collect()
        {
            EventSystem.Current.PointsCollected(Value);
            gameObject.SetActive(false);
        }

        [Obsolete("OnMissed is deprecated, only use currently is old compatibility.")]
        public override void OnMissed()
        {

        }
    }
}
