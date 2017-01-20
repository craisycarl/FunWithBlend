using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace ModifyingAnimation
{
	public partial class Window1
	{
		public Window1()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

        private void ChangeSpeed(object sender, SelectionChangedEventArgs e)
        {
            double incrementer = 1;

            ComboBox comboBox = sender as ComboBox;
            ComboBoxItem selectedItem = comboBox.SelectedValue as ComboBoxItem;

            string speed = selectedItem.Content.ToString();

            if (speed == "Slow")
            {
                incrementer = 3;
            }
            else if (speed == "Normal")
            {
                incrementer = 2;
            }
            else if (speed == "Fast")
            {
                incrementer = 1;
            }
            ModifyAnimation(incrementer);
        }

        private void ModifyAnimation(double incrementer)
        {
            Storyboard sb = this.FindResource("Oscillate") as Storyboard;
            DoubleAnimationUsingKeyFrames animation = sb.Children[0] as
                DoubleAnimationUsingKeyFrames;
            DoubleKeyFrameCollection keyFrames = animation.KeyFrames;
            for (int i = 0; i < keyFrames.Count; i++)
            {
                SplineDoubleKeyFrame keyFrame = keyFrames[i] as
                    SplineDoubleKeyFrame;
                keyFrame.KeyTime = new TimeSpan(0, 0, (int)incrementer * i);
            }
            sb.Begin(this);
        }
    }
}