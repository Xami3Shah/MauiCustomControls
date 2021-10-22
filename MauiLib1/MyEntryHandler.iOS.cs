#if __IOS__
using System;

using UIKit;
using CoreGraphics;

using Microsoft.Maui;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform.iOS;

namespace MauiApp6.Platforms.iOS
{
    internal class MyEntryHandler : EntryHandler
    {
        public static PropertyMapper<IMyEntry, MyEntryHandler> Mapper = new PropertyMapper<IMyEntry, MyEntryHandler>(EntryHandler.EntryMapper)
        {
        };

        public MyEntryHandler() : base(Mapper)
        {
        }
        public MyEntryHandler(PropertyMapper mapper = null) : base(mapper ?? Mapper)
        {
        }

        protected override MauiTextField CreateNativeView()
        {
            var v = this.VirtualView;
            var vv = v as IMyEntry;
            return new PaddingTextField(vv.Padding);
        }
    }
    public class PaddingTextField : MauiTextField
    {
        public PaddingTextField(Thickness padding)
        {
            EdgeInsets = new UIEdgeInsets(top: (nfloat)padding.Top, left: (nfloat)padding.Left, bottom: (nfloat)padding.Bottom, right: (nfloat)padding.Right);
        }

        public override CGRect TextRect(CGRect forBounds) => base.TextRect(InsetRect(forBounds, EdgeInsets));
        public override CGRect EditingRect(CGRect forBounds) => base.EditingRect(InsetRect(forBounds, EdgeInsets));

        // Workaround until this method is available in Xamarin.iOS
        public static CGRect InsetRect(CGRect rect, UIEdgeInsets insets)
        {
            return new CGRect(rect.X + insets.Left,
                                   rect.Y + insets.Top,
                                   rect.Width - insets.Left - insets.Right,
                                   rect.Height - insets.Top - insets.Bottom);
        }
        public UIEdgeInsets EdgeInsets { get; private set; }
    }
}
#endif