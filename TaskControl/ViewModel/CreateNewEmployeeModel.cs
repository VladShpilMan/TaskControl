using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using TaskControl.Helpers;
using TaskControl.Model;
using TaskControl.View;

namespace TaskControl.ViewModel
{
    public class CreateNewEmployeeModel : BaseViewModelClass
    {
        #region Command
        public ICommand CreateEmployeeCMD { get; set; }
        #endregion

        #region Private Fields
        private string _textName;
        private bool _isCreateButton_Enabel = false;
        #endregion

        #region Public Properties
        public string TextName
        {
            get { return _textName; }
            set
            {
                _textName = value;
                if (!String.IsNullOrEmpty(_textName)) IsCreateButton_Enabel = true;
                    else IsCreateButton_Enabel = false;
                OnPropertyChanged("TextName");
            }
        }
        public bool IsCreateButton_Enabel
        {
            get { return _isCreateButton_Enabel; }
            set
            {
                _isCreateButton_Enabel = value;
                OnPropertyChanged("IsCreateButton_Enabel");
            }
        }
        #endregion
        public CreateNewEmployeeModel()
        {
            CreateEmployeeCMD = new RelayCommand(x => CreateEmployee());
        }

        public void CloseWindow() => Application.Current.Windows.OfType<CreateNewEmployee>().FirstOrDefault()?.Close();

        public void CreateEmployee()
        {
            WorkersListModel.connectionSQL.PushEmployeeToDB(new Employee() { EmployeeName = TextName });
            CloseWindow();
        }
    }
}
