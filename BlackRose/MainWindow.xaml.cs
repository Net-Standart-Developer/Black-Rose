using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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

namespace BlackRose
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DefaultDialogService DefaultDialogService;
        ViewModel ViewModel;
        
        public MainWindow()
        {
            InitializeComponent();
            DefaultDialogService = new DefaultDialogService();
            ViewModel = new ViewModel(DefaultDialogService, Application.Current, this);
            DataContext = ViewModel;

            List<string> styles = new List<string> { "тёмная", "светлая" };
            StyleBox.SelectionChanged += ThemeChange;
            StyleBox.ItemsSource = styles;
            StyleBox.SelectedItem = "тёмная";
        }
        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            string style = StyleBox.SelectedItem as string;
            Uri uri = null;
            switch (style)
            {
                case "тёмная":
                    uri = new Uri("Styles/DarkStyle.xaml", UriKind.Relative);
                    break;
                case "светлая":
                    uri = new Uri("Styles/LightStyle.xaml", UriKind.Relative);
                    break;
            }


            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void Tracks_Drop(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] path = (string[])e.Data.GetData(DataFormats.FileDrop);
                for (int count = 0; count < path.Length; count++)
                    if (System.IO.Path.IsPathRooted(path[count]) && DefaultDialogService.ext.Contains(System.IO.Path.GetExtension(path[count])))
                    {
                        ViewModel.TakeNewTrack(path[count]);
                    }
            }
        }

        private void Tracks_DragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.None;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] path = ((string[])e.Data.GetData(DataFormats.FileDrop));
                for (int count = 0; count < path.Length; count++)
                {
                    if (!(System.IO.Path.IsPathRooted(path[count]) && DefaultDialogService.ext.Contains(System.IO.Path.GetExtension(path[count]))))
                    {
                        return;
                    }
                }
                e.Effects = DragDropEffects.Copy;  
            }
        }

        private void sliderPos_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel.IsPause)
                ViewModel.IsNeededStartRec = false;
            else if(ViewModel.PauseTrack.CanExecute(null))
            {
                ViewModel.PauseTrack.Execute(null);
            }
        }

        private void sliderPos_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(ViewModel.ContinueTrack.CanExecute(null) && ViewModel.IsNeededStartRec)
            {
                ViewModel.ContinueTrack.Execute(null);
            }
        }
    }
}
