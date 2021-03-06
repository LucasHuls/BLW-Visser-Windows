﻿/*
 * Lucas Huls © 2020
 * lucashuls.nl
 */
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace WIC_SDK_Sample.View
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        public SplashScreen()
        {
            InitializeComponent();
            Loadprogressbar();
        }

        private async void Loadprogressbar()
        {
            pbLoading.Value = 0;
            pbLoading.Maximum = 100;

            Duration duration = new Duration(TimeSpan.FromSeconds(30));
            DoubleAnimation dblanim = new DoubleAnimation(3000.0, duration);
            pbLoading.ValueChanged += (s, e) =>
            {
                if (pbLoading.Value == 100)
                {
                    LoginScreen loginScreen = new LoginScreen();
                    loginScreen.Show();
                    Hide();
                }
            };
            pbLoading.BeginAnimation(ProgressBar.ValueProperty, dblanim);
            while (pbLoading.IsEnabled == true)
            {
                percentage.Text = Math.Round(((pbLoading.Value / pbLoading.Maximum) * 100), 0).ToString() + "%";
                await Task.Delay(1);
            }
        }
    }
}
