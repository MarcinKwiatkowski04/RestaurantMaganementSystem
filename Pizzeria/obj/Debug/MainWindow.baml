   M S B A M L   `   `   `  ����C  ?Pizzeria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PizzeriaPizzeria  5   	       Pizzeria.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Pizzeria     5   	     � Title$  Menu główne��5   	   $	��450��6   $	��800��6*    � WindowState$ 	Maximized=�5	   	    � WindowStyle$
 None=�5
      .��5      � ���	#FFFA4616 � RowDefinitions 5   
   �� 5      -   5         �Name$ topRow��5   )   $	��16* �6   6)   �� 5      -   5        $ 
kitchenRow��5   (   $��8* �6   6(   �� 5      -   5        $ deliveryRow��5   (   $��8* �6   6(   �� 5      -   5        $ administrationRow��5   (   $��8* �6   6(   �� 5      -   5        $ 	bottomRow��5   (   $��1* �6   6(   .+�5   
   �� $��logo.png��6   $��0��6"   $
��Left=�6/   $��10, 10, 10, 10q�6J   �� 5   
   -   5        $��getOrder��5      $��0��6"   $��20, 50, 20, 50q�6/   $��PRZYJMIJ ZAMÓWIENIE��6G   $��Right=�6e   
�������$��Verdana)�6�   �� 5   
   -   5        $��kitchenButton��5      $��1��6'   $��20, 10, 20, 10q�64   $��KUCHNIA��6L   ���	#FFFFF8F8$��Verdana)�6�   �� 5   
   -   5        $��deliveryButton��5      $��2��6(   $��20, 10, 20, 10q�65   $��DOSTAWA��6M   ���	#FFFCFCFC$��Verdana)�6�   �� 5   
   -	   5        $��administrationButton��5      $��3��6.   $��20, 10, 20, 10q�6;   $��ADMINISTRACJA��6S   
�������$��Verdana)�6�   5      5      