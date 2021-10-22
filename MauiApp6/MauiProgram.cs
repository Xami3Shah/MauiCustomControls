using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Hosting;

namespace MauiApp6
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				});


			builder.ConfigureMauiHandlers(handlers =>
			{

#if __ANDROID__
				//This line does not work
				//handlers.AddHandler(typeof(MauiLib1.MyEntry), typeof(MauiLib1.MyEntryHandler));

				//This line works
				handlers.AddHandler(typeof(MyEntry), typeof(MauiApp6.Platforms.Android.MyEntryHandler));

#elif __IOS__
				//This line might not work
				//handlers.AddHandler(typeof(MauiLib1.MyEntry), typeof(MauiLib1.MyEntryHandler));

				//This line may work
				handlers.AddHandler(typeof(MyEntry), typeof(MauiApp6.Platforms.iOS.MyEntryHandler));
#elif WINDOWS
#endif
			});

			return builder.Build();
		}
	}
}