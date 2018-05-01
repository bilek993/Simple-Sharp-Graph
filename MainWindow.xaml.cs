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
using System.Windows.Navigation;
using System.Windows.Shapes;
using QuickGraph;

namespace Simple_Sharp_Graph
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FileTool _fileTool;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnClickMenuOpen(object sender, RoutedEventArgs e)
        {
            var newGraph = new BidirectionalGraph<object, IEdge<object>>();

            _fileTool = new FileTool("C:\\test.txt");
            _fileTool.OpenFile();
            newGraph.AddVertexRange(_fileTool.GenerateVertexes());

            MainGraphLayout.Graph = newGraph;
        }
    }
}
