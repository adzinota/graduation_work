   M S B A M L   `   `   `  ����  DomainComputersInfo2    ,DomainComputersInfo.Windows.CommonInfoWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$E  ?Основная информация о компьютерах��5   	    � 
ResizeMode$ NoResize=�63    � SizeToContent$ WidthAndHeight=�6I    � WindowStartupLocation$ CenterScreen=�6h   $
��1280��6�   $	��768��6�   .��5      � .+�5	   
   �� -   5         ��Name$ MainInfoListView��5	      $	��668��6-   $��
22,66,20,0q�6:   $	��Top=�6N    �� SelectionMode$ Single=�6f    � ContextMenu 5
      �� 5      .@�5      m� -   5         m�Name$
 Copy��5   B   $6��0Копировать имя компьютера��6   6P   m� 5      -   5        $ Delete��5   0   $��Удалить��6   6@   �� 5      m� 5      -   5        $ Details��5   =   $-��'Подробная информация��6   6N   5       �� View 5      �� 5      .P�5      �� $!��Имя компьютера��6%   	 �� DisplayMemberBinding	 6=   �� *PCname+�� 5      $-��'Операционная система��6%   	 6C   �� *OSname+�� 5      $��Версия ОС��6%   	 68   �� *	OSversion+�� 5      $��Процессор��6%   	 68   �� *
ProcName+�� 5      $��
Сокет��6%   	 64   �� *Socket+�� 5      $ ��Виртуализация��6%   	 6<   �� *VirtEn+�� 5      $'��!Материнская плата��6%   	 6@   �� *BBname+�� 5      $��IP адрес��6%   	 67   �� *Ipaddr+�� 5      $��MAC адрес��6%   	 68   �� *	Macaddr+�� 5      $��Размер памяти��6%   	 6<   �� *Memory+�� 5      $��Тип памяти��6%   	 69   �� *	Memtype+5      5!      �� 5"   
   $7��1Фильтр по имени компьютера��6   $
��Wrap=�66   $��20,20,1050,708q�6J   $��14(�6b   $��25��6p   $	��205��6|   �� 5#   
   -   5        
 ��Name$
 PCName_Filter��5#       �� TextWrapping$
 Wrap=�6Q   $��240,20,835,707q�6e   $��14(�6}   $��25��6�   $	��205��6�   5$      5%      