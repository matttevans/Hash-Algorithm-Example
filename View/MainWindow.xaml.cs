using System.Windows;
using HashAlgorithmExample.ViewModel;

namespace HashAlgorithmExample {

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {

		public MainWindow() {

			MainWindowViewModel ViewModel = new MainWindowViewModel();
			DataContext = ViewModel;

			InitializeComponent();
		}
	}
}
