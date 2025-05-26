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
			if (!SkipInitialAnimation)
				AttachedToVisualTree += (_, _) => SelectionChanged += OnContentChanged;
			else
			{
				PseudoClasses.Add(":normal");
				SelectionChanged += OnContentChanged;
			}
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

		/// <summary>
		/// Identifies the SkipInitialAnimation property, which determines whether
		/// the initial animation is skipped when the control is first displayed or attached to the visual tree.
		/// </summary>
		public static readonly StyledProperty<bool> SkipInitialAnimationProperty =
			AvaloniaProperty.Register<AnimateTabControl, bool>(nameof(SkipInitialAnimation), true);

		/// <summary>
		/// Gets or sets a value indicating whether the initial animation should be skipped
		/// when the control is first displayed or attached to the visual tree.
		/// </summary>
		public bool SkipInitialAnimation
		{
			get => GetValue(SkipInitialAnimationProperty);
			set => SetValue(SkipInitialAnimationProperty, value);
		}
	}
}
