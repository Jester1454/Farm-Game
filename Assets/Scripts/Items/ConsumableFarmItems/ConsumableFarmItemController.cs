using System.Collections;
using Animations;
using GameController;
using NaturalResources;
using UnityEngine;

namespace Items.ConsumableFarmItems
{
	[RequireComponent(typeof(Collider2D))]
	public class ConsumableFarmItemController : MonoBehaviour
	{
		[SerializeField] private FarmItemType _type;
		[SerializeField] private GameObject _lackStateGameObject;
		[SerializeField] private CounterAnimation _animation;
		
		private bool _lackState = false;
		private Collider2D _collider2D;
		
		private const float UpdateDelay = 1.0f;
		
		public FarmItemType Type
		{
			get { return _type; }
		}
		
		private ConsumableFarmItem _item;
		
		public void Initiazliation(ConsumableFarmItem item)
		{
			_collider2D = GetComponent<Collider2D>();
			_collider2D.enabled = false;
			
			_item = item;
			
			if (item.ProducingResourcesValue.Type != NaturalResourcesType.Nothing)
			{
				StartCoroutine(ProduceCycle());
			}

			if (item.ConsumableResourcesValue.Type != NaturalResourcesType.Nothing)
			{
				StartCoroutine(ConsumeCycle());
			}
		}

		IEnumerator ProduceCycle()
		{
			WaitForSeconds delay = new WaitForSeconds(UpdateDelay);
			while (true)
			{
				if (_item.CurrentProducingRecycleTime >=_item.ProducingRecycleTime)
				{
					if (!_lackState)
					{
						FarmingGameController.ChangeResources(_item.ProducingResourcesValue);
						
						Instantiate(_animation, transform.position, Quaternion.identity).
							Initialization(_item.ProducingResourcesValue.Quantity, false);
					}
					else
					{
						yield break;
					}
					_item.CurrentProducingRecycleTime = 0;
				}
				yield return delay;

				_item.CurrentProducingRecycleTime += UpdateDelay;
			}
		}

		IEnumerator ConsumeCycle()
		{
			WaitForSeconds delay = new WaitForSeconds(UpdateDelay);
			while (true)
			{
				if (_item.CurrentConsumableRecycleTime >=_item.ConsumableRecycleTime)
				{
					if (FarmingGameController.CurrentGame.GetNaturalResources(_item.ConsumableResourcesValue.Type).Quantity <
					    Mathf.Abs(_item.ConsumableResourcesValue.Quantity))
					{
						UpdateLackState(true);
						yield break;
					}
					else
					{
						FarmingGameController.ChangeResources(_item.ConsumableResourcesValue, true);
												
						Instantiate(_animation, transform.position, Quaternion.identity).
							Initialization(_item.ProducingResourcesValue.Quantity, true);
					}
					_item.CurrentConsumableRecycleTime = 0;
				}
				yield return delay;

				_item.CurrentConsumableRecycleTime += UpdateDelay;
			}
		}

		private void OnMouseDown()
		{
			if (_lackState)
			{
				UpdateLackState(false);
				StartCoroutine(ConsumeCycle());
				StartCoroutine(ProduceCycle());
			}
		}

		private void UpdateLackState(bool state)
		{
			_lackState = state;
			_lackStateGameObject.SetActive(state);
			
			StopCoroutine(ProduceCycle());
			StopCoroutine(ConsumeCycle());
			
			_collider2D.enabled = state;
		}
	}
}