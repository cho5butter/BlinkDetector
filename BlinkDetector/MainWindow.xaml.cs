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
using OpenCvSharp;

namespace BlinkDetector
{
    //https://webbibouroku.com/Blog/Article/toast-cs
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : System.Windows.Window
    {
        private VideoCapture capture;
        private Mat frame;
        private System.Drawing.Bitmap bmp;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Drawing.Graphics graphic;
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

        private void GetWebcam()
        {
            int WIDTH = 640;
            int HEIGHT = 480;

            capture = new VideoCapture();
            if (!capture.IsOpened())
            {
                MessageBox.Show("camera was not found!");
                this.Close();
            }
            capture.FrameWidth = WIDTH;
            capture.FrameHeight = HEIGHT;

            frame = new Mat(HEIGHT, WIDTH, MatType.CV_8UC3);

            bmp = new System.Drawing.Bitmap(frame.Cols, frame.Rows, (int)frame.Step(), System.Drawing.Imaging.PixelFormat.Format24bppRgb, frame.Data);

            pictureBox1 = new System.Windows.Forms.PictureBox();

            pictureBox1.Width = frame.Cols;
            pictureBox1.Height = frame.Rows;

            graphic = pictureBox1.CreateGraphics();
        }
    }
}
