   M S B A M L   `   `   `  ���� ^  ZMicrosoft.Samples.Kinect.WpfViewers, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null�^clr-namespace:Microsoft.Samples.Kinect.WpfViewers;assembly=Microsoft.Samples.Kinect.WpfViewers#Microsoft.Samples.Kinect.WpfViewers   Kinect1   Kinect1.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     mmy^clr-namespace:Microsoft.Samples.Kinect.WpfViewers;assembly=Microsoft.Samples.Kinect.WpfViewers     -     � Title$   ��$	��750��$
��1200�� � 
ResizeMode$ NoResize=� � WindowState$ 	Maximized=� � WindowStyle$
 None=����	#FF0B0B0B � SizeToContent$ Manual=�.��� .+��� -   $��
rectangle1��$	��720��$��Center=�$��220,0,238,-9q�
�������$��Center=�$	��720��
�������=   7Microsoft.Samples.Kinect.WpfViewers.KinectSensorChooser  -   $��kinectSensorChooser1��$��Center=�$��0,0,0,0q�$��Center=�$	��328��A� -   $��Player2�����	#FF131BFC$	��161��$��Center=�$��40,-165,0,0q�
�������$��Center=�$	��161��A� -   $��Player3�����	#FF13FC16$	��161��$��Center=�$��322,-12,0,0q�
�������$��Center=�$	��161��A� -   $��Player4�����	#FFF4FC13$	��161��$��Center=�$��623,436,394,114q�
�������$��Center=�$	��161��A� -   $��Player1��
���  ��$	��161��$��Center=�$��220,261,797,289q�
�������$��Center=�$	��161��A� -   $��Player1_blue�����	#FF131BFC$	��148��$��Center=�$��227,268,803,295q�
���  ��$��Center=�$	��148��A� -	   $��Player1_green�����	#FF13FC16$	��142��$��Center=�$��230,271,806,298q����	#FF0319FF$��Center=�$	��142��A� -
   $��Player1_yellow�����	#FFF4FC13$	��136��$��Center=�$��233,274,809,301q����	#FF13FC16$��Center=�$	��136��A� -   $��Player2_red��
���  ��$	��148��$��Center=�$��535,200,495,363q����	#FF131BFC$��Center=�$	��148��A� -   $��Player2_green�����	#FF13FC16$	��142��$��Center=�$��538,203,498,366q�
���  ��$��Center=�$	��142��A� -   $��Player2_yellow�����	#FFF4FC13$	��136��$��Center=�$��541,206,501,369q����	#FF13FC16$��Center=�$	��136��A� -   $��Player3_red��
���  ��$	��148��$��Center=�$��675,276,355,287q����	#FF13FC16$��Center=�$	��148��A� -   $��Player3_blue�����	#FF131BFC$	��142��$��Center=�$��678,279,358,290q�
���  ��$��Center=�$	��142��A� -   $��Player3_yellow�����	#FFF4FC13$	��136��$��Center=�$��681,282,361,293q����	#FF131BFC$��Center=�$	��136��A� -   $��Player4_red��
���  ��$	��148��$��Center=�$��630,442,400,121q����	#FFF4FC13$��Center=�$	��148��A� -   $��Player4_blue�����	#FF131BFC$	��142��$��Center=�$��633,445,403,124q�
���  ��$��Center=�$	��142��A� -   $��Player4_green�����	#FF13FC16$	��136��$��Center=�$��636,448,406,127q����	#FF131BFC$��Center=�$	��136��A� -   $��Player1_white��
�������$	��130��$��Center=�$��235,277,813,304q�
�������$��Center=�$	��130��A� -   $��Player2_white��
�������$	��130��$��Center=�$��544,210,504,371q�
�������$��Center=�$	��130��A� -   $��Player3_white��
�������$	��130��$��Center=�$��684,285,364,296q�
�������$��Center=�$	��130��A� -   $��Player4_white��
�������$	��130��$��Center=�$��639,451,409,130q�
�������$��Center=�$	��130���� -   $��Player1_pos��$��Player1��$��28��$
��Left=�$��	83,35,0,0q�$	��Top=�
��������� -   $��Player1_pos_x��$��X Pos��$��28��$
��Left=�$��	83,55,0,0q�$	��Top=�
��������� -   $��Player1_pos_y��$��Y Pos��
�������$��28��$
��Left=�$��	83,80,0,0q�$	��Top=��� -   $��Player1_pos_z��$��Z Pos��
�������$��28��$
��Left=�$��
83,104,0,0q�$	��Top=��� -   $��Player2_pos��$��Player2��
�������$��28��$
��Left=�$��
83,147,0,0q�$	��Top=��� -   $��Player2_pos_x��$��X Pos��
�������$��28��$
��Left=�$��
83,167,0,0q�$	��Top=��� -   $��Player2_pos_y��$��Y Pos��
�������$��28��$
��Left=�$��
83,192,0,0q�$	��Top=��� -   $��Player2_pos_z��$��Z Pos��
�������$��28��$
��Left=�$��
83,216,0,0q�$	��Top=��� -    $��Player3_pos��$��Player3��
�������$��28��$
��Left=�$��
83,253,0,0q�$	��Top=��� -!   $��Player3_pos_x��$��X Pos��
�������$��28��$
��Left=�$��
83,273,0,0q�$	��Top=��� -"   $��Player3_pos_y��$��Y Pos��
�������$
��Left=�$��83,298,0,385q��� -#   $��Player3_pos_z��$��Z Pos��
�������$��28��$
��Left=�$��
83,322,0,0q�$	��Top=��� -$   $��Player4_pos��$��Player4��
�������$��28��$
��Left=�$��
83,365,0,0q�$	��Top=��� -%   $��Player4_pos_x��$��X Pos��
�������$��28��$
��Left=�$��
83,385,0,0q�$	��Top=��� -&   $��Player4_pos_y��$��Y Pos��
�������$��28��$
��Left=�$��
83,410,0,0q�$	��Top=��� -'   $��Player4_pos_z��$��Z Pos��
�������$��28��$
��Left=�$��
83,434,0,0q�$	��Top=��� -(   $��Player5_pos��$��Player5��
�������$��28��$
��Left=�$��
83,468,0,0q�$	��Top=��� -)   $��Player5_pos_x��$��X Pos��
�������$��28��$
��Left=�$��
83,488,0,0q�$	��Top=��� -*   $��Player5_pos_y��$��Y Pos��
�������$
��Left=�$��83,513,0,170q��� -+   $��Player5_pos_z��$��Z Pos��
�������$��28��$
��Left=�$��
83,537,0,0q�$	��Top=��� -,   $��Player6_pos��$��Player6��
�������$��28��$
��Left=�$��
83,580,0,0q�$	��Top=��� --   $��Player6_pos_x��$��X Pos��
�������$
��Left=�$��83,600,0,83q��� -.   $��Player6_pos_y��$��Y Pos��
�������$��28��$
��Left=�$��
83,625,0,0q�$	��Top=��� -/   $��Player6_pos_z��$��Z Pos��
�������$��28��$
��Left=�$��
83,649,0,0q�$	��Top=�