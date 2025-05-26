using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using System;

namespace AnimationOnTabControlChange
{
	[PseudoClasses(":normal", ":reverse")]
	public class AnimateTabControl : TabControl
	{
		protected override Type StyleKeyOverride => typeof(TabControl);
		private int _lastSelectedIndex;

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
			if (!AnimateOnChange) return;
			
			PseudoClasses.Remove(":normal");
			PseudoClasses.Remove(":reverse");
			switch (AnimationType)
			{
				case AnimationType.NORMAL_RTL:
					PseudoClasses.Add(":normal");
					break;
				case AnimationType.REVERSE_LTR:
					PseudoClasses.Add(":reverse");
					break;
				case AnimationType.DEFAULT:
				default:
					PseudoClasses.Add(_lastSelectedIndex <= SelectedIndex ? ":normal" : ":reverse");
					break;
			}
			_lastSelectedIndex = SelectedIndex;
		}

		public bool AnimateOnChange
		{
			get => GetValue(AnimateOnChangeProperty);
			set => SetValue(AnimateOnChangeProperty, value);
		}

		public static readonly StyledProperty<bool> AnimateOnChangeProperty =
			AvaloniaProperty.Register<AnimateTabControl, bool>(nameof(AnimateOnChange), true);

		#region SKIP INITIAL
		
		/// <summary>
		/// Determines whether the initial animation is skipped when the control is first displayed or
		/// attached to the visual tree.
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
		
		#endregion

		#region TYPE

		/// <summary>
		/// Defines the type of animation used when transitioning between tabs in the AnimateTabControl.
		/// </summary>
		public static readonly StyledProperty<AnimationType> AnimationTypeProperty =
			AvaloniaProperty.Register<AnimateTabControl, AnimationType>(nameof(AnimationType), AnimationType.DEFAULT);

		/// <summary>
		/// Gets or sets the AnimationType property, which defines the type of animation
		/// used when transitioning between tabs in the AnimateTabControl.
		/// </summary>
		public AnimationType AnimationType
		{
			get => GetValue(AnimationTypeProperty);
			set => SetValue(AnimationTypeProperty, value);
		}
		#endregion
	}
}
