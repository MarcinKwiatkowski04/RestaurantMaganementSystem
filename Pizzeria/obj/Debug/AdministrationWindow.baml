   M S B A M L   `   `   `  ����C  ?Pizzeria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PizzeriaPizzeria  5   	   #    Pizzeria.AdministrationWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Pizzeria     5   	     � Title$  Administracja��5   	   $	��450��6   $	��800��6,    � WindowState$ 	Maximized=�5	   	    � WindowStyle$
 None=�5
      .��5      � ���	#FFFF4D14 � RowDefinitions 5   
   �� 5      -   5         �Name$ 
WorkersRow��5   (   $��3* �6   6(   �� 5      -   5        $ WorkersEditingRow��5   (   $��1* �6   6(   �� 5      -   5        $ 	BudgetRow��5   (   $��2* �6   6(   �� 5      -   5        $ 	bottomRow��5   (   $��1* �6   6(   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��WorkersDataGrid��5      $��0��6*   $��Verdana)�67   ���	#FFFF46026L   �� 5   
   -   5        $��budgetLabel��5   w   $��AKTUALNY BUDŻET: ��6   $��2��6,   $
��Left=�69   $��50,20,50,20q�6T   $��20(�6i   
�������$��Verdana)�6�   �� 5   
   -   5        $��issuePayrollsButton��5      $�� 2��6,   $��WYŚLIJ WYPŁATY��6;   $��50,20,50,20q�6T   $��Right=�6j   
�������$��Verdana)�6�   �� 5   
   -   5        $��
BackButton��5      $��WRÓĆ��6#   $��4��62   
�������$��Verdana)�6k   5      5      