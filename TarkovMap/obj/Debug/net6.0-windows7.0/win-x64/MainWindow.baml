   M S B A M L   `   `   `  ����D  @TarkovMap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TarkovMap	TarkovMap  5   	   e aMicrosoft.Web.WebView2.Wpf, Version=1.0.1264.42, Culture=neutral, PublicKeyToken=2a8ab48044d2601ekLclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.WpfMicrosoft.Web.WebView2.Wpf 5   	       TarkovMap.TrkvHelper   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:TarkovMap     5   	   \WpfLclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.Wpf     5   	     � Title$  Tarkov Helper��5	   	   $
��1080��6   $
��1920��6-   
���   �
���   � � WindowStyle$ SingleBorderWindow=�5
   	   .��5      � -   5         �Name$
 grid��5      ���	#FF151515 J� RenderTransformOrigin$ 0.503,0.435&�60   .+�5   
   � -   5        $ webgrid��5      $
��1020��6    $
��1280��6.   $y�Hidden=�6;   .+�5      )  #Microsoft.Web.WebView2.Wpf.WebView2  -   5        $��webView��5         Source$9 3https://escapefromtarkov.fandom.com/wiki/Ballistics?�6+   $	��920��6h   $
��1280��6u   6�   �� 5      -   5        $��CLOSE��5      $��1219,26,0,0q�6%   $��Bahnschrift)�6:   $��16(�6S   
�������
���   �$��24��6�   $	��Top=�6�   $ 0.5,0.5&�6�   $
��Bold"�6�   z�5      V� 5      .~�5      ��  �� ScaleX$ 1Q�6)   �� 5      �� 5      T� 5      5      5      �� 5      $��808,26,448,971q�6   $��/icons8-search-96.png��6,   $
��Fill=�6K   $ 0.5,0.5&�6Z    J� OpacityMask �	#FF6F6F6F6z   �� 5      -   5        $��URLBox��5      $��Center=�6%   $��0,25,0,0q�6B    �� TextWrapping$
 Wrap=�6T   $�� ��6h   $	��Top=�6p   $	��388��6�   $��25��6�   ���	#599AA536$��14(�6�    �� AcceptsReturn$ False��6�   
�������6�   �� 5      -   5        $��	LoadLabel��5      $��Loading site...��6%   $
��Left=�6?   $��
839,25,0,0q�6Z   $	��Top=�6n   $��29��6�   $	��124��6�   ���	#FFED43436�   5      �� 5!   
   -   5        	 ��Name$	 	MapBorder��5!      $
}�True��6$   $��
0,10,0,-10q�68   ._�5"      �� -   5        
 ��Name$	
 Map��5"      $��Center=�6!   $��0,0,0,0q�6>   $��Uniform=�6O   $��Center=�6a   z�5&      V� 5'      .~�5(      T� 6/   �� 5)      6+   5*      5-      5.      �� 5/   
   -	   5         ��Name$ MapName��5/      $��l��6!   $
��Left=�6-   $��46��6H   $��10,0,0,0q�6T   $	��Top=�6f   $	��200��6~   9� 54   
   -
   5        $
��Left=�54      $�� ��6.   $��	0,0,0,776q�68   $	��288��6K    9� 
IsExpanded$
 True��6W   .��55      � $	��293��6   $	��253��6   $	��Top=�6,   .+�56      �� -   5        $��
Ballistics��56      $��0,10,0,0q�6.   $	��Top=�6@   ���	#66DDDDDD$
��Left=�6�   $	��169��6�   �� 57      -   5        $��Market��57      $��0,40,0,0q�6*   $	��Top=�6<   ���	#66DDDDDD$
��Left=�6�   $	��169��6�   �� 58      -   5        $��Toggle Browser��58      $��0,70,0,0q�62   $	��Top=�6D   ���	#66DDDDDD$
��Left=�6�   $	��169��6�   �� 59      -   5         ��Name$ ToggleBorder��59      $��Toggle border��6/   $
��Left=�6G   $	��Top=�6b   $��91��6z   ���	#66DDDDDD$��	0,205,0,0q�6�   �� 5:      -   5        $��
WikiSearch��5:      $
��Left=�6,   $��	0,126,0,0q�6G   $
 Wrap=�6Z   $��Search Wiki��6n   $	��Top=�6�   $	��169��6�   $��30��6�   6�   �� 5;      -   5        $��WikiSearchButton��5;      $��Search��61   $
��Left=�6B   $��	0,156,0,0q�6]   $	��Top=�6p   $	��169��6�   $��32��6�   ���	#FF6161616�   5<      5?      �� 5A   
   -   5        $ 
DebugLabel��5A      $��debug��6$   $
��Left=�64   $��	10,0,0,10q�6O   $��Bottom=�6b   $��40��6}   $	��111��6�   ���	#26989898���	#FFEA0D0D6�   5D      5E      