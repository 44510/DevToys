﻿// Remember to replace the namespace below with your own project's namespace..

namespace DevToys.Blazor.Components;

/// <summary>
/// Determines the horizontal alignment of the content within the <see cref="StackPanel"/>.
/// </summary>
public enum StackHorizontalAlignment
{
    /// <summary>
    /// The content is aligned to the left.
    /// </summary>
    Left,

    /// <summary>
    /// The content is center aligned.
    /// </summary>
    Center,

    /// <summary>
    /// The content is aligned to the right.
    /// </summary>
    Right,
}

/// <summary>
/// Determines the vertical alignment of the content within the <see cref="StackPanel"/>.
/// </summary>
public enum StackVerticalAlignment
{
    /// <summary>
    /// The content is aligned to the top.
    /// </summary>
    Top,

    /// <summary>
    /// The content is center aligned.
    /// </summary>
    Center,

    /// <summary>
    /// The content is aligned to the bottom
    /// </summary>
    Bottom,
}

public partial class StackPanel : StyledComponentBase
{
    protected string? ClassValue => new CssBuilder(FinalCssClasses)
        .AddClass("stack-horizontal", () => Orientation == Orientation.Horizontal)
        .AddClass("stack-vertical", () => Orientation == Orientation.Vertical)
        .Build();

    protected string? StyleValue => new StyleBuilder()
        .AddStyle("column-gap", HorizontalGap.ToPx(), () => HorizontalGap.HasValue)
        .AddStyle("row-gap", VerticalGap.ToPx(), () => VerticalGap.HasValue)
        .AddStyle("flex-wrap", "wrap", () => Wrap)
        .AddStyle(Style)
        .Build();

    /// <summary>
    /// The horizontal alignment of the components in the stack. 
    /// </summary>
    [Parameter]
    public StackHorizontalAlignment ContentHorizontalAlignment { get; set; } = StackHorizontalAlignment.Left;

    /// <summary>
    /// The vertical alignment of the components in the stack.
    /// </summary>
    [Parameter]
    public StackVerticalAlignment ContentVerticalAlignment { get; set; } = StackVerticalAlignment.Top;

    /// <summary>
    /// Gets or set the orientation of the stacked components. 
    /// </summary>
    [Parameter]
    public Orientation Orientation { get; set; } = Orientation.Horizontal;

    /// <summary>
    /// Gets or sets if the stack wraps.
    /// </summary>
    [Parameter]
    public bool Wrap { get; set; } = false;

    /// <summary>
    /// Gets or sets the gap between horizontally stacked components (in pixels).
    /// </summary>
    [Parameter]
    public int? HorizontalGap { get; set; } = 4;

    /// <summary>
    /// Gets or sets the gap between vertically stacked components (in pixels).
    /// </summary>
    [Parameter]
    public int? VerticalGap { get; set; } = 4;

    /// <summary>
    /// Gets or sets the content to be rendered inside the component.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    private string GetHorizontalAlignment()
    {
        return ContentHorizontalAlignment switch
        {
            StackHorizontalAlignment.Left => "start",
            StackHorizontalAlignment.Center => "center",
            StackHorizontalAlignment.Right => "end",
            _ => "start",
        };
    }

    private string GetVerticalAlignment()
    {
        return ContentVerticalAlignment switch
        {
            StackVerticalAlignment.Top => "start",
            StackVerticalAlignment.Center => "center",
            StackVerticalAlignment.Bottom => "end",
            _ => "start",
        };
    }
}