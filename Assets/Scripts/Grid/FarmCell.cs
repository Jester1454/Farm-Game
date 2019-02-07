using System;
using Items.ConsumableFarmItems;
using UnityEngine;

namespace Grid
{
	[Serializable]
	public class FarmCell
	{
		[SerializeField] private Vector2Int _coordinates;

		public Vector2Int Coordinates
		{
			get { return _coordinates; }
		}

		[SerializeField] private bool _isEmpty;
		
		public bool IsEmpty
		{
			get { return _isEmpty; }
		}
		
		[SerializeField] private ConsumableFarmItem _cellItem;
		public ConsumableFarmItem CellItem
		{
			get { return _cellItem; }
		}
		
		public FarmCell(Vector2Int coordinate, ConsumableFarmItem item = null)
		{
			_coordinates = coordinate;
			_cellItem = item;
			_isEmpty = item == null;
		}		
		
		public FarmCell(int x, int y, ConsumableFarmItem item = null)
		{
			_coordinates = new Vector2Int(x,y);
			_cellItem = item;
			_isEmpty = item == null;
		}

		public void SetConsumableFarmItem(ConsumableFarmItem item)
		{
			_cellItem = item;
			_isEmpty = false;
		}
	}
}