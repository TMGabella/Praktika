   M S B A M L   `   `   `  ����  Praktika    Praktika.AdminWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$`  ZПанель управления администратора Бюро Знакомств��5   	   $	��500��6A   $	��920��6N   ���#FDFDFD � 	Resources 5         DataGridHeaderStyle �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� Property �� Value��%C  &	        �� 5	   
   "  6,   .�5
      ��  � �� �#FF40816+   �� 5       � ��
 �����6+   �� 5       � ��$
 Bold"�6+   �� 5       � �� �#FF40816,   �� 5       � ��$ 0 0 0 2q�60   �� 5       � ��$ 10q�6(   �� 5       � ��$ Center=�64   5      5      .��5      � $��10q�6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ ClientsDataGrid��5         AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly . 	   SelectionMode$	 Single=�6q   
����������#FF4081$��2q�5   <   ���#333$	��Top=�6b   $	��350��6z   
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID Клиента��6%      HeaderStyle# [  6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *
ClientId+6V     5      $ Полное Имя��6%   # [  6V    69   �� *
FullName+6V     5      $ Возраст��6%   # [  6N    66   �� *Age+6N     5      $ Пол��6%   # [  6M    62   �� *Gender+6M     5      $' !Электронная Почта��6%   # [  6Z    6@   �� *Email+6Z     5      $ Интересы��6%   # [  6U    67   �� *	Interests+6U     5      $ Тип Отношений��6%   # [  6a    6<   �� *RelationshipType+6a     5       $2 ,Предпочтения в Партнере��6%   # [  6m    6F   �� *PartnerPreferences+6m     5"      $ Дата Создания��6%   # [  6Z    6<   �� *	CreatedAt+6Z   5$      �� 5'   
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��Bottom=�6K   $��10q�6f   .+�5(      �� -   5         ��Name$ 	AddButton��5(      $��Добавить��6(   $��5q�6S   ���#FF4081
�������$
��Bold"�6�   ���#FF4081$��2q�6�   $��10q�6�   �� 5)      -   5        $ 
EditButton��5)      $ ��Редактировать��6)   $��5q�6Z   ���#FF4081
�������$
��Bold"�6�   ���#FF4081$��2q�6�   $��10q�6�   �� 5*      -   5        $ DeleteButton��5*      $��Удалить��6+   $��5q�6X   ���#FF4081
�������$
��Bold"�6�   ���#FF4081$��2q�6�   $��10q�6�   5+      5,      5-      