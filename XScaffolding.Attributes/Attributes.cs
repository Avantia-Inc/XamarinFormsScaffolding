using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XScaffolding.Attributes
{
	[AttributeUsage(AttributeTargets.Class)]
    public class XScaffoldModelAttribute : Attribute
    {
    }

	public interface IEditFieldAttribute { }

	[AttributeUsage(AttributeTargets.Property)]
	public class EntryFieldAttribute : Attribute, IEditFieldAttribute
	{
		public string Label { get; set; }
		public string Placeholder { get; set; }
		public bool Multiline { get; set; }
	}

	[AttributeUsage(AttributeTargets.Property)]
	public class TextFieldAttribute : Attribute, IEditFieldAttribute
	{
		public string Label { get; set; }
	}

	[AttributeUsage(AttributeTargets.Property)]
	public class SwitchFieldAttribute : Attribute, IEditFieldAttribute
	{
		public string Label { get; set; }
	}

	[AttributeUsage(AttributeTargets.Property)]
	public class PickerFieldAttribute : Attribute, IEditFieldAttribute
	{
		public string Label { get; set; }
		public string[] Options { get; set; }
	}

	[AttributeUsage(AttributeTargets.Property)]
	public class SliderFieldAttribute : Attribute, IEditFieldAttribute
	{
		public string Label { get; set; }
		public double Maximum { get; set; }
		public double Minimum { get; set; }
	}

	[AttributeUsage(AttributeTargets.Property)]
	public class StepperFieldAttribute : Attribute, IEditFieldAttribute
	{
		public string Label { get; set; }
		public double Increment { get; set; }
		public double Maximum { get; set; }
		public double Minimum { get; set; }
	}

	[AttributeUsage(AttributeTargets.Property)]
	public class DateTimeFieldAttribute : Attribute, IEditFieldAttribute
	{
		public readonly DateTimeFieldType Type;
		public string Label { get; set; }
		public string Format { get; set; }

		public DateTimeFieldAttribute(DateTimeFieldType dateTimeFieldType)
		{
			this.Type = dateTimeFieldType;
		}

		public enum DateTimeFieldType
		{
			DateOnly,
			TimeOnly
		}
	}
}
