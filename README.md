# How-to-programmatically-expand-a-nested-level-property-in-PropertyGrid
Programmatically expand a nested level property in PropertyGrid

We can expand and collapse a nested level property in propertygrid by using the “StatusChanged” event, on setting “IsChecked” property to “True” for ToggleButton. The same has been demonstrated in the following sample.

Code Example [C#] : 

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

