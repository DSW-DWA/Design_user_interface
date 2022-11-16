using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

namespace Task_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            _studentList = new List<Student>();
        }

        private List<Student> _studentList;
        private string[] _lines;
        private string[] _newLines;
        private string[] _sortedLines;
        private void Step1_OnClick(object sender, RoutedEventArgs e)
        {
            _lines = File.ReadAllLines("Data_МиСППИ.csv",System.Text.Encoding.UTF8).Skip(1).ToArray();
            _newLines = File.ReadAllLines("Data_МиСППИ.csv",System.Text.Encoding.UTF8).Skip(1).ToArray();
            _sortedLines = File.ReadAllLines("Data_МиСППИ.csv",System.Text.Encoding.UTF8).Skip(1).ToArray();
            for (var i = 0; i < _lines.Length; i++)
            {
                var items = _lines[i].Split(';');
                var marks = new List<int>();
                for (int j = 2; j < items.Length - 1; j++)
                {
                    if (items[j] != "") marks.Add(Convert.ToInt32(items[j]));
                }
                _studentList.Add(
                    new Student(
                        Convert.ToInt32(items[0]),
                        marks,
                        items[items.Length-1] != "" ? Convert.ToInt32(items[items.Length-1]): 0
                    )
                );
            }
            for (var i = 0; i < _lines.Length; i++)
            {
                _newLines[i] += $";{_studentList[i].Sum}";
                
            }
            _sortedLines = _studentList.OrderBy(x => x.Sum).Select(x => _newLines[x.Id-1]).Reverse().ToArray();
            
            File.WriteAllLines("Result_МиСППИ.csv", _newLines);
        }

        private void Step2_OnClick(object sender, RoutedEventArgs e)
        {
            TextBoxConsole.Text = "";
            foreach (var line in _lines)
            {
                TextBoxConsole.Text += line + Environment.NewLine;
            }
        }

        private void Step3_OnClick(object sender, RoutedEventArgs e)
        {
            TextBoxConsole.Text = "";
            foreach (var line in _newLines)
            {
                TextBoxConsole.Text += line + Environment.NewLine;
            }
        }

        private void Step4_OnClick(object sender, RoutedEventArgs e)
        {
            TextBoxConsole.Text = "";
            foreach (var line in _sortedLines)
            {
                var items = line.Split(';');
                foreach (var item in items)
                {
                    TextBoxConsole.Text += $" {item} |";
                }
                TextBoxConsole.Text += Environment.NewLine;
            }
        }
    }
}