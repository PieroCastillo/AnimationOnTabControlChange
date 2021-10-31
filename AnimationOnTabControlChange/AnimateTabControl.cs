using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Styling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimationOnTabControlChange
{
    [PseudoClasses(":normal")]
    public class AnimateTabControl : TabControl, IStyleable
    {
        Type IStyleable.StyleKey => typeof(TabControl);

        public AnimateTabControl()
        {
            PseudoClasses.Add(":normal");
            this.GetObservable(SelectedContentProperty).Subscribe(OnContentChanged);
        }

        private void OnContentChanged(object obj)
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
