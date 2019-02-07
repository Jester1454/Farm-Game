using NaturalResources;

namespace Items.ProducingFarmItems
{
	public interface IProducingFarmItem
	{
		NaturalResourceValue ProducingResourcesValue { get; set; }
		float ProducingRecycleTime { get; set; }
		float CurrentProducingRecycleTime { get; set; }
		
		NaturalResourceValue GetResources();
	}
}
