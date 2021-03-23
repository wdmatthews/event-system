using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace EventSystem.Demo
{
    /// <summary>
    /// Shows an example for event subscription and triggering.
    /// </summary>
    [AddComponentMenu("Event System/Demo")]
    [DisallowMultipleComponent]
    public class Demo : MonoBehaviour
    {
        #region Fields and Properties
        [SerializeField] private EventSubscriber _eventSubscriber = null;
        [SerializeField] private TextMeshProUGUI _numberLabel = null;
        [SerializeField] private Button _generateButton = null;
        [SerializeField] private int _numbersLeft = 2;
        #endregion

        #region Unity Events
        private void Awake()
        {
            // Register the generate-number event.
            _eventSubscriber.Subscribe("generate-number", GenerateNumber);

            // Trigger an event on button click.
            _generateButton.onClick.AddListener(() =>
            {
                _eventSubscriber.Trigger("generate-number");
            });
        }
        #endregion

        #region Public Methods
        public void GenerateNumber()
        {
            // When the generate-number event is triggered, generate a random number for the string.
            _numberLabel.text = Random.Range(0, 100).ToString();
            // Reduce the numbers left to generate.
            _numbersLeft--;
            // Unsubscribe if enough numbers have been generated.
            if (_numbersLeft == 0)
            {
                _eventSubscriber.Unsubscribe("generate-number", GenerateNumber);
                Debug.Log("Unsubscribed from generate-number after generating enough numbers.");
            }
        }
        #endregion
    }
}