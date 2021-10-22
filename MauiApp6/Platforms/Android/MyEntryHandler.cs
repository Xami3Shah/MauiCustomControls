using Android.Views;

using Microsoft.Maui;
using Microsoft.Maui.Handlers;

namespace MauiApp6.Platforms.Android
{
    public class MyEntryHandler : EntryHandler
    {
        public static PropertyMapper<IMyEntry, MyEntryHandler> Mapper = new PropertyMapper<IMyEntry, MyEntryHandler>(EntryHandler.EntryMapper)
        {
            ["Gravity"] = MapGravity,
            [nameof(IMyEntry.Padding)] = MapPadding,
        };

        public MyEntryHandler() : base(Mapper)
        {
        }
        public MyEntryHandler(PropertyMapper mapper = null) : base(mapper ?? Mapper)
        {
        }

        public static void MapGravity(MyEntryHandler handler, IMyEntry entry)
        {
            handler.NativeView.Gravity = GravityFlags.CenterVertical;
        }

        public static void MapPadding(MyEntryHandler handler, IMyEntry entry)
        {
            // left-top right-bottom padding
            handler.NativeView.SetPadding((int)entry.Padding.Left, (int)entry.Padding.Top, (int)entry.Padding.Right, (int)entry.Padding.Bottom);
        }
    }
}