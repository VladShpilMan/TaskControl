﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TaskControl.ViewModel;

namespace TaskControl.View
{
    /// <summary>
    /// Логика взаимодействия для CreateNewEmployee.xaml
    /// </summary>
    public partial class CreateNewEmployee : Window
    {
        public CreateNewEmployee()
        {
            DataContext = new CreateNewEmployeeModel();
            InitializeComponent();
        }
    }
}
