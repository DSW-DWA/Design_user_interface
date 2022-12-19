using System;
using System.ComponentModel;
using System.Windows;

namespace Additional_lab_1
{
    public partial class ChildForm : Window
    {
        public ChildForm(MainWindow parent, int name, double parHeight, double parWidth, double aboutHeight, double aboutWidth)
        {
            InitializeComponent();
            this.Title = $"Детка {name}";
            Main.Text = $"Размеры главного окна {parHeight}x{parWidth}";
            About.Text = $"Размеры about окна {aboutHeight}x{aboutWidth}";
            _parent = parent;
            _num = name;
            this.Name = $"Child{name.ToString()}";
        }
        private MainWindow _parent;
        private int _num;
        private void ChildForm_OnClosing(object sender, CancelEventArgs e)
        {
            var result = MessageBox.Show("Закрыть детку?", "Закрытие", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                _parent.CloseChild(_num);
            }
        }
        private void ChildForm_OnStateChanged(object sender, EventArgs e)
        {
            _parent.ChangeChildState(_num);
        }
    }
}