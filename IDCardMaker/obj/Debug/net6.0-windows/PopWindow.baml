   M S B A M L   `   `   `  ����F  BIDCardMaker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:IDCardMakerIDCardMaker  5   	       IDCardMaker.PopWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:IDCardMaker     5   	      MaterialDesignBody#���   5   	   $��Regular"�5	   	   $��20(�5
   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	   $	��600��5   	   $	��320��6    � WindowStyle$
 None=�5   	   .��5      � .+�5   
   #  MaterialDesignThemes.Wpf.Card  $	��300��6   .��5      �  � RowDefinitions 5      �� 5      $	��180 �6$   �� 5      $	��100 �6$   �� 5      $	��250 �6$   �� 5      $
��Auto �6$   .+�5      �� -   5         ��Name$ OperatorPhoto��5      $	��180��5      $	��180��5      $��UniformToFill=�5      �� 5      $��1��6   $��Center=�6*   $	��Top=�6G    �� Orientation$ 
Horizontal=�6_   .+�5       �� $��0,0,0,0q�6!   $��Center=�62   $��70��6O   .+�5!      �� $��Center=�6    $��Microsoft YaHei UI)�6=   $
��Bold"�6]   .��6o   等级6s   �� 5"      -   5         ��Name$ 	LevelShow��5"   !   $��0,5,0,0q�64    & "MaterialDesignFloatingActionButton#��[ 5#      ���#FFFFFF���#FFFFFF���	#DD0000003  -MaterialDesignThemes.Wpf.ButtonProgressAssist   IsIndicatorVisible$
 True��5'         Value$ 70Q�5(      	   IndicatorForeground	 �#ffcc80
   IndicatorBackground
 �#FFFFFF$
��LV70��5+      $��50��5,   �   $��50��6�   {�6   �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType
 Window6�   5-      �� 5.      $��Center=�6!   $��Center=�6>   $��60��6Y   .+�5/      �� $��Center=�6    $��Microsoft YaHei UI)�6=   $
��Bold"�6]   $��10(�6o   .��6}   精英6�   �� 50      -   5        $ 	EliteShow��50   !   $��0,5,0,0q�64   #��[ 51      ���#FFFFFF���#FFFFFF���	#DD000000$
 True��55      $	 100Q�56      	 �#00FF66
 �#FFFFFF$��2��59      $��40��5:   �   $��40��6�   {�6   �� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window6�   5;      �� 5<      $��Center=�6!   $��60��6>   $��Center=�6I   .+�5=      �� $��Center=�6    $��Microsoft YaHei UI)�6=   $
��Bold"�6]   $��10(�6o   .��6}   潜能6�   �� 5>      -   5        $ PotenialShow��5>   !   $��0,5,0,0q�67   #��[ 5?      ���#FFFFFF���#FFFFFF���	#DD000000$
 True��5C      $ 0Q�5D      	 �#0997F7
 �#FFFFFF$��1��5G      $��40��5H   �   $��40��6�   {�6   �� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window6�   5I      5J      �� 5L      $��2��6   $ Vertical=�6*   .+�5M      �� $ Vertical=�6!   $��Center=�68   $��Center=�6S   .+�5N      �� -   5         ��Name$ EliteSel��5N   a    ) %MaterialDesignChoiceChipAccentListBox#��[ 6"   $
��Auto��6s   .@�5O      �� -   5        $��未精��5O   *   $��10(�67   $
��Auto��6E   6R   �� 5P      -   5        $��精一��5P   *   $��10(�67   $
��Auto��6E   6R   �� 5Q      -   5         �� 
IsSelected$
 True��5Q   *   $��精二��6<   $��10(�6I   $
��Auto��6W   6d   5R      �� 5S      -	   5         ��Name$ Level��5S   #   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 等级��62      FloatingScale$	 0.8Q�5T      $��12(�6G      FloatingOffset$ 0, -24&�5U      $��72��5V      $	��130��5W       & "MaterialDesignFloatingHintComboBox#��[ 5Y      ��5X      �� *#!LongListToTestComboVirtualization+5Z      5[      �� 5\      $��Center=�6"   $ Vertical=�6?   $��Center=�6V   $	��300��6q   .+�5]      �� -
   5        $ 	Potential��5]   #   $ 潜能��66   $	��130��6Z   $	 0.8Q�5^      $��12(�6G   $ 0, -24&�5_      $��72��5`      #��[ 5b      ��5a      �� *#!LongListToTestComboVirtualization+5c      �� 5d      -   5        $
 Skin��5d   #   $ 皮肤��61   $	��130��6V   $	 0.8Q�5e      $��12(�6G   $ 0, -24&�5f      $��72��5g      #��[ 5i      ��5h      �� *#!LongListToTestComboVirtualization+5j      5k      �� 5l      $ 
Horizontal=�6!   .+�5m      �� $��11(�6    .��6.   	一技能63   (  "MaterialDesignThemes.Wpf.RatingBar  5n      -   5          Name$ skill1��5o      
   Max$ 10��5p         Value$ 7��5q      5r      �� 5s      $ 
Horizontal=�6!   .+�5t      �� $��11(�6    .��6.   	二技能63     5u      -   5        $ skill2��5v      $ 10��5w      $ 7��5x      5y      �� 5z      $ 
Horizontal=�6!   .+�5{      �� $��11(�6    .��6.   	三技能63     5|      -   5        $ skill3��5}      $ 10��5~      $ 7��5      5�      5�      �� 5�      $��3��6   $ 
Horizontal=�6*   $��Right=�6C   .+�5�      �� -   5        $ Confirm��5�   R     MaterialDesignRaisedButton#��[ 6   $��0,0,0,0q�5�      $
��Auto��5�       � ToolTip$/ )Resource name: MaterialDesignRaisedButton��5�      $��确认��5�      {�5�      �� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window6�   �� 5�      -   5        $ Cancel��5�   M   #��[ 5�      $
��Auto��5�      $��15,0,0,0q�5�      $/ )Resource name: MaterialDesignRaisedButton��5�      $��取消��5�      {�5�      �� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window6�   5�      5�      5�      5�      5�      