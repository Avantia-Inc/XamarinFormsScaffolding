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

			var entryField = new Entry {  };
			entryField.SetBinding(EntryCell.TextProperty, new Binding("Entry", BindingMode.TwoWay, source: Model));

			var multiLineEntryField = new Editor();
			multiLineEntryField.SetBinding(Editor.TextProperty, new Binding("MultiLineEntry", BindingMode.TwoWay, source: Model));

			var textField = new Label { Text = Model.Text };

			var switchField = new Switch();
			switchField.SetBinding(Switch.IsToggledProperty, new Binding("Switch", BindingMode.TwoWay, source: Model));

			var pickerField = new Picker();
			pickerField.Items.Add(MYPROJECT.Resources.FredOption);
			pickerField.Items.Add(MYPROJECT.Resources.WilmaOption);
			pickerField.Items.Add(MYPROJECT.Resources.BarneyOption);
			pickerField.Items.Add(MYPROJECT.Resources.BettyOption);
			pickerField.SelectedIndex = pickerField.Items.IndexOf(Model.Picker);
			pickerField.SelectedIndexChanged += (object sender, EventArgs e) => { Model.Picker = pickerField.SelectedIndex > -1 ? pickerField.Items[pickerField.SelectedIndex]: null; };

			var sliderField = new Slider { Minimum = 1, Maximum = 10 };
			sliderField.SetBinding(Slider.ValueProperty, new Binding("Slider", BindingMode.TwoWay, source: Model));
			var sliderFieldDetail = new Label { Text = Model.Slider.ToString("G"), FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) };
			sliderField.ValueChanged += (object sender, ValueChangedEventArgs e) => { sliderFieldDetail.Text = e.NewValue.ToString("G"); };
			var sliderFieldView = new StackLayout { Orientation = StackOrientation.Horizontal, Spacing = 15, Children = { sliderField, sliderFieldDetail } };

			var stepperField = new Stepper { Increment = 1, Minimum = 1, Maximum = 5 };
			stepperField.SetBinding(Stepper.ValueProperty, new Binding("Stepper", BindingMode.TwoWay, source: Model));
			var stepperFieldDetail = new Label { Text = Model.Stepper.ToString("G"), FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) };
			stepperField.ValueChanged += (object sender, ValueChangedEventArgs e) => { stepperFieldDetail.Text = e.NewValue.ToString("G"); };
			var stepperFieldView = new StackLayout { Orientation = StackOrientation.Horizontal, Spacing = 15, Children = { stepperField, stepperFieldDetail } };

			var dateField = new DatePicker { Format = "D" };
			dateField.SetBinding(DatePicker.DateProperty, new Binding("Date", BindingMode.TwoWay, source: Model));

			var timeField = new TimePicker { Format = "T" };
			timeField.SetBinding(TimePicker.TimeProperty, new Binding("Time", BindingMode.TwoWay, source: Model));

			this.Content = new ScrollView
			{
				Content = new StackLayout
				{
					Orientation = StackOrientation.Vertical,
					Spacing = 15,
					Children = 
					{
						new StackLayout { Orientation = StackOrientation.Vertical, Children = { new Label { Text = MYPROJECT.Resources.EntryLabel, FontAttributes = FontAttributes.Bold }, entryField } },
						new StackLayout { Orientation = StackOrientation.Vertical, Children = { new Label { Text = MYPROJECT.Resources.MultiLineEntryLabel, FontAttributes = FontAttributes.Bold }, multiLineEntryField } },
						new StackLayout { Orientation = StackOrientation.Vertical, Children = { new Label { Text = MYPROJECT.Resources.TextLabel, FontAttributes = FontAttributes.Bold }, textField } },
						new StackLayout { Orientation = StackOrientation.Vertical, Children = { new Label { Text = MYPROJECT.Resources.SwitchLabel, FontAttributes = FontAttributes.Bold }, switchField } },
						new StackLayout { Orientation = StackOrientation.Vertical, Children = { new Label { Text = MYPROJECT.Resources.PickerLabel, FontAttributes = FontAttributes.Bold }, pickerField } },
						new StackLayout { Orientation = StackOrientation.Vertical, Children = { new Label { Text = MYPROJECT.Resources.SliderLabel, FontAttributes = FontAttributes.Bold }, sliderFieldView } },
						new StackLayout { Orientation = StackOrientation.Vertical, Children = { new Label { Text = MYPROJECT.Resources.StepperLabel, FontAttributes = FontAttributes.Bold }, stepperFieldView } },
						new StackLayout { Orientation = StackOrientation.Vertical, Children = { new Label { Text = MYPROJECT.Resources.DateLabel, FontAttributes = FontAttributes.Bold }, dateField } },
						new StackLayout { Orientation = StackOrientation.Vertical, Children = { new Label { Text = MYPROJECT.Resources.TimeLabel, FontAttributes = FontAttributes.Bold }, timeField } }
					}
				}
			};
		}
	}

}
