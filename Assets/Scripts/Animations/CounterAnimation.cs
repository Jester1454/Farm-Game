using System.Collections;
using UnityEngine;

namespace Animations
{
    public class CounterAnimation : MonoBehaviour
    {
        [SerializeField] private TextMesh _textMesh;
        [SerializeField] private Color _positiveColor;
        [SerializeField] private Color _negativeColor;
        [SerializeField] private float _animationDuration;

        public void Initialization(float costCounter, bool isNegative)
        {
            //hack for access to sorting layer in text mesh
            _textMesh.GetComponent<Renderer>().sortingOrder = 3;
            if (isNegative)
            {
                _textMesh.text = "-" + costCounter;
                _textMesh.color = _negativeColor;
            }
            else
            {
                _textMesh.text = "+" + costCounter;
                _textMesh.color = _positiveColor;
            }
            
            StartCoroutine(FadeImage());
            StartCoroutine(Movement());
        }

        private IEnumerator FadeImage()
        {
            if (_textMesh == null)
            {
                Debug.LogError("image is null");
                yield break;
            }
            
            for (float i = _animationDuration; i >= 0; i -= Time.deltaTime)
            {
                _textMesh.color = new Color(_textMesh.color.r, _textMesh.color.g, _textMesh.color.b, i);
                yield return null;
            }
            
            Destroy(gameObject);
        }

        private IEnumerator Movement()
        {
            Vector2 targetPosition = (Vector2)transform.position + Vector2.up*2;
            while ((Vector2)transform.position != targetPosition)
            {
                MovementTo(targetPosition);

                yield return null;
            }
        }
        
        private void MovementTo(Vector2 position)
        {
            transform.position = Vector2.MoveTowards(transform.position, position, Time.deltaTime);
        }
    }
}
