using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Vekto.Models;
using Vekto.ViewModels;


namespace Vekto.Commands
{
    // Command: kobler knappen til controlleren. Selve logikken ligger i controlleren.
    public class NewEmployee : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is CreateEmployeeController cec)
            {
                try
                {
                    cec.CreateEmployee();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
