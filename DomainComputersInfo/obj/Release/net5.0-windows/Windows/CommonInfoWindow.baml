   M S B A M L   `   `   `  ���� N  JDomainComputersInfo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:DomainComputersInfo.WindowsDomainComputersInfo.Windows  2    ,DomainComputersInfo.Windows.CommonInfoWindow   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ;local)clr-namespace:DomainComputersInfo.Windows       � Title$  CommonInfoWindow�� � 
ResizeMode$ NoResize=� � SizeToContent$ WidthAndHeight=� � WindowStartupLocation$ CenterScreen=�$
��1600��$	��900��.��� .+��� -    ��Name$ MainInfoListView��$	��854��$��160,20,10,0q�$	��Top=� �� SelectionMode$ Single=� � ContextMenu �� .@�m� -    m�Name$
 Copy��$��Копировать��m� -   $ Delete��$��Удалить���� m� -   $ Details��$-��'Подробная информация�� �� View �� .P��� $!��Имя компьютера��	 �� DisplayMemberBinding	 �� *PCname+�� $-��'Операционная система��	 �� *OSname+�� $��Версия ОС��	 �� *	OSversion+�� $��Процессор��	 �� *
ProcName+�� $��
Сокет��	 �� *Socket+�� $ ��Виртуализация��	 �� *VirtEn+�� $'��!Материнская плата��	 �� *BBname+�� $��IP адрес��	 �� *Ipaddr+�� $��MAC адрес��	 �� *	Macaddr+�� $��Размер памяти��	 �� *Memory+�� $��Тип памяти��	 �� *	Memtype+� $��15,20,1445,408q�.+��� $��Фильтрация��$
��Wrap=�$��
10,0,0,440q�$	��130���� $!��Имя компьютера��$
��Wrap=�$��0,16,10,420q��� -   
 ��Name$
 PCName_Filter�� �� TextWrapping$
 Wrap=�$��10,36,10,400q��� $-��'Операционная система��$
��Wrap=�$��
5,56,5,380q��� -   $
 OSName_Filter��$
 Wrap=�$��10,76,10,360q��� $��Версия ОС��$
��Wrap=�$��
5,96,5,340q��� -   $
 OSVer_Filter��$
 Wrap=�$��10,116,10,320q��� $��Процессор��$
��Wrap=�$��5,136,5,300q��� -   $
 Proc_Filter��$
 Wrap=�$��10,156,10,280q��� $��
Сокет��$
��Wrap=�$��5,176,5,260q��� -	   $
 Socket_Filter��$
 Wrap=�$��10,196,10,240q��� $ ��Виртуализация��$
��Wrap=�$��5,216,5,220q��� $
 Wrap=�$��10,236,10,200q��� $'��!Материнская плата��$
��Wrap=�$��5,256,5,180q��� $
 Wrap=�$��10,276,10,160q��� $��IP адрес��$
��Wrap=�$��5,296,5,140q��� $
 Wrap=�$��10,316,10,120q��� $��MAC адрес��$
��Wrap=�$��5,336,5,100q��� $
 Wrap=�$��10,356,10,80q��� $��Размер памяти��$
��Wrap=�$��
5,376,5,60q��� $
 Wrap=�$��10,396,10,40q��� $��Тип памяти��$
��Wrap=�$��
5,416,5,20q��� $
 Wrap=�$��10,436,10,0q�$��20��$	��Top=�