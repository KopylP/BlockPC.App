using Firebase.Database.Streaming;
using Kopyl.BlockPC.App.Firebase;
using Kopyl.BlockPC.App.Models;
using Kopyl.BlockPC.App.Sys;
using System;
using System.ComponentModel;
using System.Windows;

namespace Kopyl.BlockPC.App
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private FirebaseLockHandler _firebaseLockHandler;
        private NotificationTray _notificationTray;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow = new MainWindow();
            _firebaseLockHandler = new FirebaseLockHandler("first-pc");
            _firebaseLockHandler.Init();
            _notificationTray = new NotificationTray(MainWindow);
            _notificationTray.Stop += _notificationTray_Stop;
        }

        private void _notificationTray_Stop()
        {
            _firebaseLockHandler.Stop();
        }
    }
}

