using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BingDailyUWP.Model;

namespace BingDailyUWP.ViewModel
{
    public class PictureViewModel
    {
        public DelegateCommand ShowCommand { get; set; }
        public PictureModel Picture { get; set; }

        public PictureViewModel()
        {
            Picture = new PictureModel();
            ShowCommand = new DelegateCommand();
            ShowCommand.ExecuteCommand = new Action<object>(ShowPictureData);
        }

        private void ShowPictureData(object obj)
        {
            // TODO 从控件传入值
        }
    }

    public class DelegateCommand : ICommand
    {
        public Action<object> ExecuteCommand = null;
        public Func<object, bool> CanExecuteCommand = null;
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            if (CanExecuteCommand != null)
            {
                return this.CanExecuteCommand(parameter);
            }
            else
            {
                return true;
            }
        }

        public void Execute(object parameter)
        {
            if (this.ExecuteCommand != null)
            {
                this.ExecuteCommand(parameter);
            }
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
