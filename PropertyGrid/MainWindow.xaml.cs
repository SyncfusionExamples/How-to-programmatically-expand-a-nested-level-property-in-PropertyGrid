#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using System.Windows.Controls;
using Syncfusion.Windows.PropertyGrid;
using Syncfusion.Windows.Shared;
using System.Windows.Media;
using System;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.Windows.Controls.Primitives;

namespace PropertyGridAttributeDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.propertyGrid.Loaded += PropertyGrid_Loaded;
        }
        private void PropertyGrid_Loaded(object sender, RoutedEventArgs e)
        {
            PropertyView item1 = VisualUtils.FindDescendant(this, typeof(PropertyView)) as PropertyView;

            if (item1 != null)
                item1.ItemContainerGenerator.StatusChanged += ItemContainerGenerator_StatusChanged;
        }
        void ItemContainerGenerator_StatusChanged(object sender, EventArgs e)
        {
            foreach (PropertyCatagoryViewItem item in VisualUtils.EnumChildrenOfType(this, typeof(PropertyCatagoryViewItem)))
            {
                foreach (var items in item.Items)
                {
                    foreach (PropertyViewItem propertyviewitem in VisualUtils.EnumChildrenOfType(this, typeof(PropertyViewItem)))
                    {
                        ToggleButton button = (ToggleButton)propertyviewitem.Template.FindName("ToggleButton", propertyviewitem);
                        if (button.Visibility == System.Windows.Visibility.Visible && !button.IsMouseOver)
                        {
                            button.IsChecked = true;
                        }
                    }

                }
            }
        }        
    }
}
