using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XScaffolding.Attributes;

namespace XScaffolding
{
	[XScaffoldModel]
	public class MyModel
	{
		[EntryField]
		public string Entry { get; set; }
		[EntryField(Multiline=true)]
		public string MultiLineEntry { get; set; }
		[TextField]
		public string Text { get; set; }
		[SwitchField]
		public bool Switch { get; set; }
		[PickerField(Options=new string[] {"Fred", "Wilma", "Barney", "Betty"})]
		public string Picker { get; set; }
		[SliderField(Minimum=1, Maximum=10)]
		public int Slider { get; set; }
		[StepperField(Minimum = 1, Maximum = 5)]
		public int Stepper { get; set; }
		[DateTimeField(DateTimeFieldAttribute.DateTimeFieldType.DateOnly)]
		public DateTime Date { get; set; }
		[DateTimeField(DateTimeFieldAttribute.DateTimeFieldType.TimeOnly)]
		public DateTime Time { get; set; }
	}
}
