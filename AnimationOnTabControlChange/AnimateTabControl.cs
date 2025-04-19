using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using System;

namespace AnimationOnTabControlChange
{
	[PseudoClasses(":normal")]
	public class AnimateTabControl : TabControl
	{
		protected override Type StyleKeyOverride => typeof(TabControl);

		public AnimateTabControl()
		{
			PseudoClasses.Add(":normal");
			SelectionChanged += OnContentChanged;
		}

		private void OnContentChanged(object? sender, SelectionChangedEventArgs e)
		{
			if (AnimateOnChange)
			{
				PseudoClasses.Remove(":normal");
				PseudoClasses.Add(":normal");
			}
		}

		public bool AnimateOnChange
		{
			get => GetValue(AnimateOnChangeProperty);
			set => SetValue(AnimateOnChangeProperty, value);
		}

		public static readonly StyledProperty<bool> AnimateOnChangeProperty =
			AvaloniaProperty.Register<AnimateTabControl, bool>(nameof(AnimateOnChange), true);
	}
}
