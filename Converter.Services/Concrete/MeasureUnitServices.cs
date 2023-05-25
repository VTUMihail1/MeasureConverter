using Converter.Models.MeasureModels.Abstraction;
using Converter.Models.MeasureModels.Concrete;
using Converter.Services.Abstraction;

namespace Converter.Services.Concrete
{
	public class MeasureUnitServices : IMeasureUnitServices
	{
		private IMeasureUnit _mainMeasureUnit;
		
		private IDictionary<string, Length> _relationships;

		private readonly Func<string, bool> ContainsKey;

		public MeasureUnitServices(IDictionary<string, Length> relationships, IMeasureUnit mainMeasureUnit)
		{
			_mainMeasureUnit = mainMeasureUnit;
			_relationships = relationships;

			mainMeasureUnit.Length.Value = 1;

			var name = mainMeasureUnit.Name;
			var length = mainMeasureUnit.Length;


			_relationships.Add(name, length);

			ContainsKey = key => _relationships.ContainsKey(key);
		}

		public void AddMeasureUnit(IMeasureUnit measureUnit)
		{
			var firstKey = measureUnit.Name;
			var secondKey = measureUnit.Length.MeasureBasedOn.Name;

			var value = measureUnit.Length.Value;

			if (!ContainsKey(firstKey) && ContainsKey(secondKey))
			{
				var relationship = value * _relationships[secondKey].Value;

				measureUnit.Length.Value = relationship;
				measureUnit.Length.MeasureBasedOn = _mainMeasureUnit;

				_relationships[firstKey] = measureUnit.Length;
			}

		}

		public float GetMeasure(IMeasureUnit measureUnit)
		{
			var key = measureUnit.Name;

			if (ContainsKey(key))
			{
				var value = _relationships[key].Value;

				return value;
			}

			var notFound = -1;

			return notFound;
		}

		public void UpdateMeasureUnit(IMeasureUnit measureUnit)
		{
			var firstKey = measureUnit.Name;
			var secondKey = measureUnit.Length.MeasureBasedOn.Name;

			if (!ContainsKey(firstKey) || !ContainsKey(secondKey))
			{
				return;
			}

			var measure = measureUnit.Length.MeasureBasedOn;

			bool isTheMainCurrency = measure == _mainMeasureUnit;

			if (!isTheMainCurrency)
			{
				var value = measureUnit.Length.Value;
				var relationship = value / _relationships[secondKey].Value;
				measureUnit.Length.Value = relationship;
				measureUnit.Length.MeasureBasedOn = _mainMeasureUnit;
			}

			_relationships[firstKey] = measureUnit.Length;

		}

		public void RemoveMeasureUnit(IMeasureUnit measureUnit)
		{
			var key = measureUnit.Name;

			if (ContainsKey(key))
			{
				_relationships.Remove(key);
			}

		}
		
	}
}
