# Update_FlipVIew_Source
testing repo with Mahapps

in order to reproduce this issue

run the application

scroll up and down , 

and you would see this error in the output:

System.Windows.Data Error: 4 : Cannot find source for binding with reference 'RelativeSource FindAncestor, AncestorType='System.Windows.Controls.ItemsControl', AncestorLevel='1''. BindingExpression:Path=HorizontalContentAlignment; DataItem=null; target element is 'ListBoxItem' (Name=''); target property is 'HorizontalContentAlignment' (type 'HorizontalAlignment')

select any item in the list box

rightclick and click on capture

a new image is now added to the source

scroll the wheel up and down and pick any random listbox item and do step 6

add on the same item another image, 

scroll up and down  and you would get to this error:
{"'System.Windows.Controls.DeferredSelectedIndexReference' is not a valid value for property 'SelectedIndex'."}
