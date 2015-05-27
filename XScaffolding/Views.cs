using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using XScaffolding;


namespace MYPROJECT.Views
{
	public partial class MyModelForm : ContentPage
	{
		public MyModel Model { get; set; }

		public MyModelForm()
		{
			this.Title = MYPROJECT.Resources.MyModelTitle;

			var entryField = new EntryCell { Label = MYPROJECT.Resources.EntryLabel };
			entryField.SetBinding(EntryCell.TextProperty, new Binding("Entry", BindingMode.TwoWay, source: Model));

			var multiLineEntryField = new Editor();
			var multiLineEntryFieldView = new ViewCell { View = new StackLayout { Children = { new Label { Text = MYPROJECT.Resources.MultiLineEntryLabel }, multiLineEntryField } } };
			multiLineEntryField.SetBinding(Editor.TextProperty, new Binding("MultiLineEntry", BindingMode.TwoWay, source: Model));

			var textField = new TextCell { Text = MYPROJECT.Resources.TextLabel, Detail = Model.Text };

			var switchField = new SwitchCell { Text = MYPROJECT.Resources.SwitchLabel };
			switchField.SetBinding(SwitchCell.OnProperty, new Binding("Switch", BindingMode.TwoWay, source: Model));

			var pickerField = new Picker { Title = MYPROJECT.Resources.PickerLabel };
			pickerField.Items.Add("Fred");
			pickerField.Items.Add("Wilma");
			pickerField.Items.Add("Barney");
			pickerField.Items.Add("Betty");
			pickerField.SelectedIndex = pickerField.Items.IndexOf(Model.Picker);
			pickerField.SelectedIndexChanged += (object sender, EventArgs e) => { Model.Picker = pickerField.SelectedIndex > -1 ? pickerField.Items[pickerField.SelectedIndex]: null; };
			var pickerFieldView = new ViewCell { View = new StackLayout { Children = { new Label { Text = MYPROJECT.Resources.PickerLabel }, pickerField } } };

			var sliderField = new Slider { Minimum = 1, Maximum = 10 };
			sliderField.SetBinding(Slider.ValueProperty, new Binding("Slider", BindingMode.TwoWay, source: Model));
			var sliderFieldView = new ViewCell { View = new StackLayout { Children = { new Label { Text = MYPROJECT.Resources.SliderLabel }, sliderField } } };

			var stepperField = new Stepper { Increment = 1, Minimum = 1, Maximum = 5 };
			stepperField.SetBinding(Stepper.ValueProperty, new Binding("Stepper", BindingMode.TwoWay, source: Model));
			var stepperFieldView = new ViewCell { View = new StackLayout { Children = { new Label { Text = MYPROJECT.Resources.StepperLabel }, stepperField } } };

			var dateField = new DatePicker { Format = "D" };
			dateField.SetBinding(DatePicker.DateProperty, new Binding("Date", BindingMode.TwoWay, source: Model));
			var dateFieldView = new ViewCell { View = new StackLayout { Children = { new Label { Text = MYPROJECT.Resources.DateLabel }, dateField } } };

			var timeField = new TimePicker { Format = "T" };
 			timeField.SetBinding(TimePicker.TimeProperty, new Binding("Time", BindingMode.TwoWay, source: Model));
			var timeFieldView = new ViewCell { View = new StackLayout { Children = { new Label { Text = MYPROJECT.Resources.TimeLabel }, timeField } } };

			this.Content = new TableView
			{
				Intent = TableIntent.Form,
				Root = new TableRoot
				{
					new TableSection
					{
						entryField, multiLineEntryFieldView, textField, switchField, pickerFieldView, sliderFieldView, stepperFieldView
					}
				}
			};
		}
	}

}
