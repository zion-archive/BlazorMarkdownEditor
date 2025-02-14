using System.ComponentModel;
using System.Reflection;

namespace PSC.Blazor.Components.MarkdownEditor;

public static class EditorThemeExtensions
{
    /// <summary>
    /// Gets the description attribute of the theme in EditorTheme enum
    /// </summary>
    /// <param name="theme">The theme.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">No description found for theme</exception>
    public static string GetDescription(this EditorTheme theme)
    {
        var field = theme.GetType().GetField(theme.ToString());
        if (field != null)
        {
            var attribute = field.GetCustomAttribute<DescriptionAttribute>();
            if (attribute != null)
            {
                return attribute.Description;
            }
        }
        
        throw new ArgumentException("No description found for theme", nameof(theme));
    }
}