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
using VKR.Model;

namespace VKR
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class ClientAddWindow : Window
    {
        public Client Client { get; set; }
        public ClientAddWindow(Client client)
        {
            InitializeComponent();
            Client = client;
            DataContext = Client;
        }
        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
