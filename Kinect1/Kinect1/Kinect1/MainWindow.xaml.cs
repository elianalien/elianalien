// MainWindow.xaml.cs - V101014
// auth:kusumah.rizky@gmail.com
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Kinect;
using Coding4Fun.Kinect.Wpf;

namespace Kinect1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private int pixel_scale = 240;
        private int stage_size = 720;
        private int center_to_nol_z = 560;
        private int[] circle_center = new int[4];
        private int kinect_distance = 4/10;
        bool closing = false;
        const int skeletonCount = 6;
        Skeleton[] AllSkeleton = new Skeleton[skeletonCount];
        private float[][] player = new float[4][];
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            kinectSensorChooser1.KinectSensorChanged += new DependencyPropertyChangedEventHandler(kinectSensorChooser1_KinectSensorChanged);
            instance_ui();
            for (int i = 0; i < 4; i++) player[i] = new float[3];
            circle_center[0] = 16;
            circle_center[1] = 13;
            circle_center[2] = 10;
            circle_center[3] = 7;
        }

        private void instance_ui()
        {
            Player1.Visibility = System.Windows.Visibility.Hidden;
            Player2.Visibility = System.Windows.Visibility.Hidden;
            Player3.Visibility = System.Windows.Visibility.Hidden;
            Player4.Visibility = System.Windows.Visibility.Hidden;
            Player1_white.Visibility = System.Windows.Visibility.Hidden;
            Player2_white.Visibility = System.Windows.Visibility.Hidden;
            Player3_white.Visibility = System.Windows.Visibility.Hidden;
            Player4_white.Visibility = System.Windows.Visibility.Hidden;
            Player1_yellow.Visibility = System.Windows.Visibility.Hidden;
            Player1_green.Visibility = System.Windows.Visibility.Hidden;
            Player1_blue.Visibility = System.Windows.Visibility.Hidden;
            Player2_yellow.Visibility = System.Windows.Visibility.Hidden;
            Player2_green.Visibility = System.Windows.Visibility.Hidden;
            Player2_red.Visibility = System.Windows.Visibility.Hidden;
            Player3_yellow.Visibility = System.Windows.Visibility.Hidden;
            Player3_blue.Visibility = System.Windows.Visibility.Hidden;
            Player3_red.Visibility = System.Windows.Visibility.Hidden;
            Player4_blue.Visibility = System.Windows.Visibility.Hidden;
            Player4_green.Visibility = System.Windows.Visibility.Hidden;
            Player4_red.Visibility = System.Windows.Visibility.Hidden;
            rectangle1.Visibility = System.Windows.Visibility.Hidden;
        }

        void kinectSensorChooser1_KinectSensorChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            KinectSensor zero =(KinectSensor)e.OldValue;
            stopKinect(zero);
            KinectSensor sensor = (KinectSensor)e.NewValue;
            if (sensor == null) return;
            sensor.SkeletonStream.Enable();
            sensor.DepthStream.Enable(DepthImageFormat.Resolution320x240Fps30);
            sensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
            sensor.AllFramesReady += new EventHandler<AllFramesReadyEventArgs>(sensor_AllFramesReady);
            try
            {
                sensor.Start();
                rectangle1.Visibility = System.Windows.Visibility.Visible;
            }
            catch
            {
                kinectSensorChooser1.AppConflictOccurred();
            }
        }

        void sensor_AllFramesReady(object sender, AllFramesReadyEventArgs e)
        {
            if (closing) return;
            using (SkeletonFrame skeletonFrameData = e.OpenSkeletonFrame())
            {
                if (skeletonFrameData == null) return;
                skeletonFrameData.CopySkeletonDataTo(AllSkeleton);
            }
            int count = 0;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 3; j++) player[i][j] = 0;

            for (int i = 0; i < skeletonCount; i++)
            {
                printdata(i, AllSkeleton[i].Position.X, AllSkeleton[i].Position.Y, AllSkeleton[i].Position.Z);
                if (AllSkeleton[i].Position.X == 0 && AllSkeleton[i].Position.Y == 0 && AllSkeleton[i].Position.Z == 0)
                    continue;
                else
                {
                    player[count][0] = AllSkeleton[i].Position.X;
                    player[count][1] = AllSkeleton[i].Position.Y;
                    player[count][2] = AllSkeleton[i].Position.Z;
                    count++;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                updatePosition(i, player[i][0], player[i][1], player[i][2]);
            }
            check_overlapping();
        }

        void printdata(int i,float x, float y, float z)
        {
            switch (i)
            {
                case 0:
                    Player1_pos_x.Content = x + " m";
                    Player1_pos_y.Content = y + " m";
                    Player1_pos_z.Content = z + " m";
                    break;
                case 1:
                    Player2_pos_x.Content = x + " m";
                    Player2_pos_y.Content = y + " m";
                    Player2_pos_z.Content = z + " m";
                    break;
                case 2:
                    Player3_pos_x.Content = x + " m";
                    Player3_pos_y.Content = y + " m";
                    Player3_pos_z.Content = z + " m";
                    break;
                case 3:
                    Player4_pos_x.Content = x + " m";
                    Player4_pos_y.Content = y + " m";
                    Player4_pos_z.Content = z + " m";
                    break;
                case 4:
                    Player5_pos_x.Content = x + " m";
                    Player5_pos_y.Content = y + " m";
                    Player5_pos_z.Content = z + " m";
                    break;
                case 5:
                    Player6_pos_x.Content = x + " m";
                    Player6_pos_y.Content = y + " m";
                    Player6_pos_z.Content = z + " m";
                    break;
            }
            
        }

        void stopKinect(KinectSensor sensor)
        {
            if (sensor != null)
            {
                if (sensor.IsRunning)
                {
                    sensor.Stop();
                    if (sensor.AudioSource != null)
                    {
                        sensor.AudioSource.Stop();
                    }
                }
            }
        }

        private void updatePosition(int playerId, float x, float y, float z)
        {
            switch (playerId)
            {
                case 0:
                    if ((x == 0 && y == 0 && z == 0) || (x > 3 && z > 3))
                    {
                        Player1.Visibility = System.Windows.Visibility.Hidden;
                        Player1_white.Visibility = System.Windows.Visibility.Hidden;
                        Player1_yellow.Visibility = System.Windows.Visibility.Hidden;
                        Player1_green.Visibility = System.Windows.Visibility.Hidden;
                        Player1_blue.Visibility = System.Windows.Visibility.Hidden;
                    }
                    else
                    {
                        Player1.Visibility = System.Windows.Visibility.Visible;
                        Player1_white.Visibility = System.Windows.Visibility.Visible;
                        Player1.Margin = new Thickness(Convert.ToInt32(x * pixel_scale), Convert.ToInt32(z * pixel_scale) -
                            (center_to_nol_z)-(pixel_scale*kinect_distance), 0, 0);
                        Player1_white.Margin = new Thickness(Convert.ToInt32(x * pixel_scale) + circle_center[0], 
                            Convert.ToInt32(z * pixel_scale) + circle_center[0] - (center_to_nol_z) - 
                            (pixel_scale * kinect_distance), circle_center[0], circle_center[0]);
                        Player1_yellow.Margin = new Thickness(Convert.ToInt32(x * pixel_scale) + circle_center[1],
                            Convert.ToInt32(z * pixel_scale) + circle_center[1] - (center_to_nol_z) -
                            (pixel_scale * kinect_distance), circle_center[1], circle_center[1]);
                        Player1_green.Margin = new Thickness(Convert.ToInt32(x * pixel_scale) + circle_center[2],
                            Convert.ToInt32(z * pixel_scale) + circle_center[2] - (center_to_nol_z) -
                            (pixel_scale * kinect_distance), circle_center[2], circle_center[2]);
                        Player1_blue.Margin = new Thickness(Convert.ToInt32(x * pixel_scale) + circle_center[3],
                            Convert.ToInt32(z * pixel_scale) + circle_center[3] - (center_to_nol_z) -
                            (pixel_scale * kinect_distance), circle_center[3], circle_center[3]);
                    }
                    break;
                case 1:
                    if ((x == 0 && y == 0 && z == 0) || (x > 3 && z > 3))
                    {
                        Player2.Visibility = System.Windows.Visibility.Hidden;
                        Player2_white.Visibility = System.Windows.Visibility.Hidden;
                        Player2_yellow.Visibility = System.Windows.Visibility.Hidden;
                        Player2_green.Visibility = System.Windows.Visibility.Hidden;
                        Player2_red.Visibility = System.Windows.Visibility.Hidden;
                    }
                    else
                    {
                        Player2.Visibility = System.Windows.Visibility.Visible;
                        Player2_white.Visibility = System.Windows.Visibility.Visible;
                        Player2.Margin = new Thickness(Convert.ToInt32(x * pixel_scale), Convert.ToInt32(z * pixel_scale) -
                            (center_to_nol_z) - (pixel_scale * kinect_distance), 0, 0);
                        Player2_white.Margin = new Thickness(Convert.ToInt32(x * pixel_scale) + circle_center[0],
                            Convert.ToInt32(z * pixel_scale) + circle_center[0] - (center_to_nol_z) -
                            (pixel_scale * kinect_distance), circle_center[0], circle_center[0]);
                        Player2_yellow.Margin = new Thickness(Convert.ToInt32(x * pixel_scale) + circle_center[1],
                            Convert.ToInt32(z * pixel_scale) + circle_center[1] - (center_to_nol_z) -
                            (pixel_scale * kinect_distance), circle_center[1], circle_center[1]);
                        Player2_green.Margin = new Thickness(Convert.ToInt32(x * pixel_scale) + circle_center[2],
                            Convert.ToInt32(z * pixel_scale) + circle_center[2] - (center_to_nol_z) -
                            (pixel_scale * kinect_distance), circle_center[2], circle_center[2]);
                        Player2_red.Margin = new Thickness(Convert.ToInt32(x * pixel_scale) + circle_center[3],
                            Convert.ToInt32(z * pixel_scale) + circle_center[3] - (center_to_nol_z) -
                            (pixel_scale * kinect_distance), circle_center[3], circle_center[3]);
                    }
                    break;
                case 2:
                    if ((x == 0 && y == 0 && z == 0) || (x > 3 && z > 3))
                    {
                        Player3.Visibility = System.Windows.Visibility.Hidden;
                        Player3_white.Visibility = System.Windows.Visibility.Hidden;
                        Player3_yellow.Visibility = System.Windows.Visibility.Hidden;
                        Player3_blue.Visibility = System.Windows.Visibility.Hidden;
                        Player3_red.Visibility = System.Windows.Visibility.Hidden;
                    }
                    else
                    {
                        Player3.Visibility = System.Windows.Visibility.Visible;
                        Player3_white.Visibility = System.Windows.Visibility.Visible;
                        Player3.Margin = new Thickness(Convert.ToInt32(x * pixel_scale), Convert.ToInt32(z * pixel_scale) -
                            (center_to_nol_z) - (pixel_scale * kinect_distance), 0, 0);
                        Player3_white.Margin = new Thickness(Convert.ToInt32(x * pixel_scale) + circle_center[0],
                            Convert.ToInt32(z * pixel_scale) + circle_center[0] - (center_to_nol_z) -
                            (pixel_scale * kinect_distance), circle_center[0], circle_center[0]);
                        Player3_yellow.Margin = new Thickness(Convert.ToInt32(x * pixel_scale) + circle_center[1],
                            Convert.ToInt32(z * pixel_scale) + circle_center[1] - (center_to_nol_z) -
                            (pixel_scale * kinect_distance), circle_center[1], circle_center[1]);
                        Player3_blue.Margin = new Thickness(Convert.ToInt32(x * pixel_scale) + circle_center[2],
                            Convert.ToInt32(z * pixel_scale) + circle_center[2] - (center_to_nol_z) -
                            (pixel_scale * kinect_distance), circle_center[2], circle_center[2]);
                        Player3_red.Margin = new Thickness(Convert.ToInt32(x * pixel_scale) + circle_center[3],
                            Convert.ToInt32(z * pixel_scale) + circle_center[3] - (center_to_nol_z) -
                            (pixel_scale * kinect_distance), circle_center[3], circle_center[3]);
                    }
                    break;
                case 3:
                    if ((x == 0 && y == 0 && z == 0) || (x > 3 && z > 3))
                    {
                        Player4.Visibility = System.Windows.Visibility.Hidden;
                        Player4_white.Visibility = System.Windows.Visibility.Hidden;
                        Player4_green.Visibility = System.Windows.Visibility.Hidden;
                        Player4_blue.Visibility = System.Windows.Visibility.Hidden;
                        Player4_red.Visibility = System.Windows.Visibility.Hidden;
                    }
                    else
                    {
                        Player4.Visibility = System.Windows.Visibility.Visible;
                        Player4_white.Visibility = System.Windows.Visibility.Visible;
                        Player4.Margin = new Thickness(Convert.ToInt32(x * pixel_scale), Convert.ToInt32(z * pixel_scale) -
                            (center_to_nol_z) - (pixel_scale * kinect_distance), 0, 0);
                        Player4_white.Margin = new Thickness(Convert.ToInt32(x * pixel_scale) + circle_center[0],
                            Convert.ToInt32(z * pixel_scale) + circle_center[0] - (center_to_nol_z) -
                            (pixel_scale * kinect_distance), circle_center[0], circle_center[0]);
                        Player4_green.Margin = new Thickness(Convert.ToInt32(x * pixel_scale) + circle_center[1],
                            Convert.ToInt32(z * pixel_scale) + circle_center[1] - (center_to_nol_z) -
                            (pixel_scale * kinect_distance), circle_center[1], circle_center[1]);
                        Player4_blue.Margin = new Thickness(Convert.ToInt32(x * pixel_scale) + circle_center[2],
                            Convert.ToInt32(z * pixel_scale) + circle_center[2] - (center_to_nol_z) -
                            (pixel_scale * kinect_distance), circle_center[2], circle_center[2]);
                        Player4_red.Margin = new Thickness(Convert.ToInt32(x * pixel_scale) + circle_center[3],
                            Convert.ToInt32(z * pixel_scale) + circle_center[3] - (center_to_nol_z) -
                            (pixel_scale * kinect_distance), circle_center[3], circle_center[3]);
                    }
                    break;
            }
        }

        private void check_overlapping()
        {
            if (Player1.Visibility == System.Windows.Visibility.Visible && Player2.Visibility == System.Windows.Visibility.Visible)
            {
                double vertical = Player1.Margin.Left - Player2.Margin.Left;
                double horizontal = Player1.Margin.Top - Player2.Margin.Top;
                if (Math.Round(Math.Sqrt((vertical * vertical) + (horizontal * horizontal)), 0) < (161 * 2))
                {
                    Player1_blue.Visibility = System.Windows.Visibility.Visible;
                    Player2_red.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    Player1_blue.Visibility = System.Windows.Visibility.Hidden;
                    Player2_red.Visibility = System.Windows.Visibility.Hidden;
                }

                if (Player1.Visibility == System.Windows.Visibility.Visible && Player3.Visibility == System.Windows.Visibility.Visible)
                {
                    vertical = Player1.Margin.Left - Player2.Margin.Left;
                    horizontal = Player1.Margin.Top - Player2.Margin.Top;
                    if (Math.Round(Math.Sqrt((vertical * vertical) + (horizontal * horizontal)), 0) < (161 * 2))
                    {
                        Player1_green.Visibility = System.Windows.Visibility.Visible;
                        Player3_red.Visibility = System.Windows.Visibility.Visible;
                    }

                    else
                    {
                        Player1_green.Visibility = System.Windows.Visibility.Hidden;
                        Player3_red.Visibility = System.Windows.Visibility.Hidden;
                    }

                    if (Player1.Visibility == System.Windows.Visibility.Visible && Player4.Visibility == System.Windows.Visibility.Visible)
                    {
                        vertical = Player1.Margin.Left - Player4.Margin.Left;
                        horizontal = Player1.Margin.Top - Player4.Margin.Top;
                        if (Math.Round(Math.Sqrt((vertical * vertical) + (horizontal * horizontal)), 0) < (161 * 2))
                        {
                            Player1_yellow.Visibility = System.Windows.Visibility.Visible;
                            Player4_red.Visibility = System.Windows.Visibility.Visible;
                        }
                        else
                        {
                            Player1_yellow.Visibility = System.Windows.Visibility.Hidden;
                            Player4_red.Visibility = System.Windows.Visibility.Hidden;
                        }

                        vertical = Player2.Margin.Left - Player4.Margin.Left;
                        horizontal = Player2.Margin.Top - Player4.Margin.Top;
                        if (Math.Round(Math.Sqrt((vertical * vertical) + (horizontal * horizontal)), 0) < (161 * 2))
                        {
                            Player2_yellow.Visibility = System.Windows.Visibility.Visible;
                            Player4_blue.Visibility = System.Windows.Visibility.Visible;
                        }

                        else
                        {
                            Player2_yellow.Visibility = System.Windows.Visibility.Hidden;
                            Player4_blue.Visibility = System.Windows.Visibility.Hidden;
                        }

                        vertical = Player3.Margin.Left - Player4.Margin.Left;
                        horizontal = Player3.Margin.Top - Player4.Margin.Top;
                        if (Math.Round(Math.Sqrt((vertical * vertical) + (horizontal * horizontal)), 0) < (161 * 2))
                        {
                            Player3_yellow.Visibility = System.Windows.Visibility.Visible;
                            Player4_green.Visibility = System.Windows.Visibility.Visible;
                        }

                        else
                        {
                            Player3_yellow.Visibility = System.Windows.Visibility.Hidden;
                            Player4_green.Visibility = System.Windows.Visibility.Hidden;
                        }
                    }

                    vertical = Player2.Margin.Left - Player3.Margin.Left;
                    horizontal = Player2.Margin.Top - Player3.Margin.Top;
                    if (Math.Round(Math.Sqrt((vertical * vertical) + (horizontal * horizontal)), 0) < (161 * 2))
                    {
                        Player2_green.Visibility = System.Windows.Visibility.Visible;
                        Player3_blue.Visibility = System.Windows.Visibility.Visible;
                    }

                    else
                    {
                        Player2_green.Visibility = System.Windows.Visibility.Hidden;
                        Player3_blue.Visibility = System.Windows.Visibility.Hidden;
                    }
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            stopKinect(kinectSensorChooser1.Kinect);
            closing = true;
        }       

    }
}
