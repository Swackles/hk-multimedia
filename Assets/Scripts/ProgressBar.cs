using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace Assets.Scripts
{
    class ProgressBar : MonoBehaviour
    {
        private Image _progressBar;

        public void Awake()
        {
            _progressBar = GetComponentsInChildren<Image>().First(x => x.name == "Progress");
            if (_progressBar == null)
                throw new MissingComponentException("progress bar has to have a child object that has image component and is named progress");
        }
        /// <summary>
        /// Update the progress of the bar
        /// </summary>
        /// <param name="progress">A float between 1 and 0 to show progression</param>
        public void UpdateProgress(float progress)
        {
            _progressBar.fillAmount = progress;
        }
    }
}
