using NaturalResources;

namespace Items.ConsumableFarmItems
{
	public interface IConsumableFarmItem
	{
		NaturalResourceValue ConsumableResourcesValue { get; set; }
		float ConsumableRecycleTime { get; set; }
		float CurrentConsumableRecycleTime { get; set; }

		NaturalResourceValue ConsumeResources();
	}
}