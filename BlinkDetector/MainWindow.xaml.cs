using System;
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
using Hardcodet.Wpf.TaskbarNotification;
using Microsoft.Toolkit.Uwp.Notifications;

namespace BlinkDetector
{
    //https://webbibouroku.com/Blog/Article/toast-cs
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Visibility = Visibility.Hidden;
            new ToastContentBuilder()
                .AddText("入力してね！")
                .AddInputTextBox("textbox", "this is placeholder ...", "手入力欄")
                .AddComboBox("combobox", "選択欄", "a", new (string, string)[]{
        ("a", "選択肢A"),
        ("b", "選択肢B"),
        ("c", "選択肢C"),
                })
                .AddButton(new ToastButton("OK", "ok"))
                .AddButton(new ToastButton("キャンセル", "cancel"))
                .Show();

        }
    }
}
