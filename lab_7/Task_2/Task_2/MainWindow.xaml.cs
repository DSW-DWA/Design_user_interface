using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using Microsoft.Win32;

namespace Task_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string[] _lines;
        private string _nameOfFile;
        private string _longestWorld;
        private List<string> _words;
        private void ChooseFile_OnClick(object sender, RoutedEventArgs e)
        {
            FileDialog win = new OpenFileDialog();
            if (win.ShowDialog() == true)
            {
                _nameOfFile = $"{win.SafeFileName}";
                _lines = File.ReadAllLines($"{win.FileName}");
                foreach (var line in _lines)
                {
                    TopTextBox.Text += $"{line}{Environment.NewLine}";
                }
            }
        }

        private void ShowData_OnClick(object sender, RoutedEventArgs e)
        {
            BottomTextBox.Text = "";
            var nl = Environment.NewLine;
            BottomTextBox.Text += $"Имя файла: {_nameOfFile}{nl}";
            BottomTextBox.Text += $"Колл-во строк:{_lines.Count()}{nl}";
            BottomTextBox.Text += $"Не пустых слов слово:{_lines.Where(x => x != "").Count()}{nl}";
            _longestWorld = _lines.Where(x => x != "").First(x => x.Length == _lines.Max(xx => xx.Length));
            var litWord = _lines.Where(x => x != "")
                .First(x => x.Length == _lines.Where(xx => xx != "").Min(xx => xx.Length));
            BottomTextBox.Text += $"Самое длинное слово:{_longestWorld}{nl}";
            BottomTextBox.Text += $"Самое короткое солов:{litWord}{nl}";
            var mid = _lines.Length / 2;
            BottomTextBox.Text += $"Медианная строка:{_lines[mid]}{nl}";
        }

        private void ChangeInfo_OnClick(object sender, RoutedEventArgs e)
        {
            BottomTextBox.Text = "";
            var nl = Environment.NewLine;
            var pattern = @"\w+";
            _words = new List<string>();
            _lines.Where(x => x != "").ToList().ForEach(x =>
            {
                foreach (Match match in Regex.Matches(x, pattern))
                {
                    _words.Add(match.Value);
                } 
            });
            BottomTextBox.Text += $"{_nameOfFile}{nl}";
            BottomTextBox.Text += $"{_words.Count}{nl}";
            _longestWorld = _words.First(x => x.Length == _words.Max(xx => xx.Length));
            BottomTextBox.Text += $"{_words.Max(x => x.Length)}{nl}";
            BottomTextBox.Text += $"{_longestWorld}{nl}";
            for (var i = 1; i <= _longestWorld.Length; i++)
            {
                BottomTextBox.Text += $"{i} | {_words.Count(x => x.Length == i)}{nl}";
            }

        }
    }
}