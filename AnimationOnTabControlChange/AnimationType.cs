namespace AnimationOnTabControlChange;

public enum AnimationType
{
    /// <summary>
    /// Animates the tab control based on the selected index.
    /// </summary>
    DEFAULT = 0,
    /// <summary>
    /// All animations will be "right-to-left" 
    /// </summary>
    NORMAL_RTL = 1,
    /// <summary>
    /// All animations will be "left-to-right"
    /// </summary>
    REVERSE_LTR = 2
}