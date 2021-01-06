using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using HashAlgorithmExample.Util;
using HashAlgorithmExample.Utils;
using static HashAlgorithmExample.Utils.Algorithm;

namespace HashAlgorithmExample.ViewModel {

	public class MainWindowViewModel : INotifyPropertyChanged {

		#region Variables
		private List<HashAlgorithm> _algorithmList;
		public List<HashAlgorithm> AlgorithmList {

			get { return _algorithmList; }
			set {
				_algorithmList = value;
				OnPropertyChanged(nameof(AlgorithmList));
			}
		}

		private HashAlgorithm _selectedAlgorithm;
		public HashAlgorithm SelectedAlgorithm {

			get { return _selectedAlgorithm; }
			set {
				_selectedAlgorithm = value;
				OnPropertyChanged(nameof(SelectedAlgorithm));
				StartHash(null);
			}
		}

		private string _input;
		public string Input {

			get { return _input; }
			set {
				_input = value;
				OnPropertyChanged(nameof(Input));
				StartHash(null);
			}
		}

		private string _output;
		public string Output {

			get { return _output; }
			set {
				_output = value;
				OnPropertyChanged(nameof(Output));
			}
		}

		public DelegateCommand<object> HashCommand { get; }

		#endregion

		public MainWindowViewModel() : base() {

			AlgorithmList = new List<HashAlgorithm> {

				HashAlgorithm.MD5,
				HashAlgorithm.SHA1,
				HashAlgorithm.SHA256,
				HashAlgorithm.SHA384,
				HashAlgorithm.SHA512,
				HashAlgorithm.Whirlpool,
				HashAlgorithm.Streebog
			};

			Input = "The quick brown fox jumps over the lazy dog";
			SelectedAlgorithm = AlgorithmList[0];
			
			HashCommand = new DelegateCommand<object>(StartHash);
		}

		private void StartHash(object obj) {

			Output = SelectedAlgorithm switch {

				HashAlgorithm.MD5			=>		Hasher.GetMD5(Input),
				HashAlgorithm.SHA1			=>		Hasher.GetSHA1(Input),
				HashAlgorithm.SHA256		=>		Hasher.GetSHA256(Input),
				HashAlgorithm.SHA384		=>		Hasher.GetSHA384(Input),
				HashAlgorithm.SHA512		=>		Hasher.GetSHA512(Input),
				HashAlgorithm.Whirlpool		=>		Hasher.GetWhirlpool(Input),
				HashAlgorithm.Streebog		=>		Hasher.GetStreebog(Input),
				_							=>		Hasher.GetSHA512(Input),
			};
			Output = Output.ToUpper(CultureInfo.CurrentCulture);
		}

		#region Property changed & validation
		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string propertyName) {

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion
	}
}
