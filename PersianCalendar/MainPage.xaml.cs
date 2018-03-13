using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PersianCalendar {
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page {
		public MainPage() {
			this.InitializeComponent();

			var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
			UpdateTitleBarLayout(coreTitleBar);
			Window.Current.SetTitleBar(AppTitleBar);
			coreTitleBar.LayoutMetricsChanged += CoreTitleBar_LayoutMetricsChanged;
			coreTitleBar.IsVisibleChanged += CoreTitleBar_IsVisibleChanged;
			txtDisplayName.Text = "تقوسم قارسی";

		}

		private void CoreTitleBar_IsVisibleChanged(CoreApplicationViewTitleBar sender, object args) {
			if (sender.IsVisible) {
				AppTitleBar.Visibility = Visibility.Visible;
			} else {
				AppTitleBar.Visibility = Visibility.Collapsed;
			}
		}

		private void CoreTitleBar_LayoutMetricsChanged(CoreApplicationViewTitleBar sender, object args) {
			UpdateTitleBarLayout(sender);
		}

		private void UpdateTitleBarLayout(CoreApplicationViewTitleBar coreTitleBar) {
			// Get the size of the caption controls area and back button 
			// (returned in logical pixels), and move your content around as necessary.
			LeftPaddingColumn.Width = new GridLength(coreTitleBar.SystemOverlayLeftInset);
			RightPaddingColumn.Width = new GridLength(coreTitleBar.SystemOverlayRightInset);
			//TitleBarButton.Margin = new Thickness(0, 0, coreTitleBar.SystemOverlayRightInset, 0);

			// Update title bar control size as needed to account for system size changes.
			AppTitleBar.Height = coreTitleBar.Height;
		}
	}
}
