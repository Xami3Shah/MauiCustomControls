using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace MauiApp6
{
    public interface IMyEntry : IEntry
    {
        public Thickness Padding { get; set; }
    }
    public class MyEntry : Entry, IMyEntry
    {
        public MyEntry()
        {
        }

        public Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }
        public static readonly BindableProperty PaddingProperty =
            BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(MyEntry), new Thickness(5, 10));
    }
}