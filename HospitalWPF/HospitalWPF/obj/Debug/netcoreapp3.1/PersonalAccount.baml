   M S B A M L   `   `   `  ????F  BHospitalWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:HospitalWPFHospitalWPF  5   	   !    HospitalWPF.PersonalAccount   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:HospitalWPF     5   	   _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
     ? Title$  PersonalAccount??5	   	   $	??600??6!   $	??900??6.   $
??1000??6:   $	??600??6J   .??5
      ? ???#dff7f7.+?5   
   ?? $	??500??6   $??	35,0,35,0q?6    
???????$??Center=?6F    ?? Padding$	 200q?6a   $	??900??6o    ?? CornerRadius$ 20??6~   $	??830??6?   $	??440??6?    J? RenderTransformOrigin$ 0.468,0.416&?6?    J? Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 30Q?6#      Color$ 	LightBlue??63      ShadowDepth$ 0Q?6E   6W   ._?5      ?? $??Center=?6   $	??440??62   $??Center=?6?   $	??830??6Z   .+?5      ? $??234,-71,-7,-42q?6   $	??222??6/   $	??187??6;    ?? Left$	 180??6H   
	 ?? Top$		 202??6Z   
 ? ColumnDefinitions
 5      ?? 5      $??* ?6+   ?? 5      $??* ?6+   .+?5      ?? $??0??6!   $??31,4,0,0q?6.   $	??136??6@   $	??Top=?6M   $
??Left=?6e   .+?5      ?? $??Имя??6$   $??14(?6/   $
??Bold"?6=   $??27??6O   
???   ?6[   ?? 5      $??Фамилия??6$   $??14(?63   $
??Bold"?6A   $??27??6S   
???   ?6_   ?? 5      $??Отчество??6$   $??14(?64   $
??Bold"?6B   $??27??6T   
???   ?6`   ?? 5      $??Возраст??6$   $??14(?63   $
??Bold"?6A   $??27??6S   
???   ?6_   ?? 5      $??Пол??6$   $??14(?6/   $
??Bold"?6=   $??27??6O   
???   ?6[   5      ?? 5!      $??0??6!   $	??136??6.   $	??Top=?6;   $??Center=?6S   $	??111??6p   $??1??6|   .+?5"      ?? -   5         ??Name$ textBoxName??5"   "   $??14(?67   $
??Bold"?6E   $??27??6W   ???	#FF7979796c   ?? 5#      -   5        $ textBoxFullName??5#   "   $??14(?6;   $
??Bold"?6I   $??27??6[   ???	#FF7979796g   ?? 5$      -   5        $ textBoxPatronymic??5$   "   $??14(?6=   $
??Bold"?6K   $??27??6]   ???	#FF7979796i   ?? 5%      -   5        $ 
textBoxAge??5%   "   $??14(?66   $
??Bold"?6D   $??27??6V   ???	#FF7979796b   ?? 5&      -   5        $ textBoxGender??5&   "   $??14(?69   $
??Bold"?6G   $??27??6Y   ???	#FF7979796e   5'      5)      ?? 5*      $??Пользователь??6   $??18(?60   $
??Bold"?6>   $??532,167,267,387q?6P   $	 -54??6i   $		 -65??6{   
???   ?6?   ?? 5+      $!??Личный кабинет??6   $??30(?62   $
??Bold"?6@   $??319,93,320,452q?6R   $	 -25??6j   $		 -80??6|   ?? 5,      -   5        $(??"Записаться к врачу??5,      $??523,443,127,109q?66   ???	#FFF60D0D$??17(?6f    ? Cursor$
 Hand??6t   $??40??6?   $	??250??6?   $	 -14??6?   $		 -75??6?   ???	#FF673AB76?   ?? 5-      $??Фотокарточка??6   $??678,188,72,246q?60   ???	#FFCDCCCC$??16(?6_   $
 Hand??6m   $	??150??6{   $	??150??6?   ???	#FF575757$	 -35??6?   $		 -70??6?   ?? 5.      -   5         ??Name$ TextBoxEdit??5.      $ ??Редактировать??6.   $??678,188,72,246q?6F   ???	#FFF0F0F0$??14(?6u   $
 Hand??6?   $	??150??6?   $??30??6?   
???????$	 -35??6?   $	 87??6?   ???	#DD8888886?   ?? 5/      -   5        $ TextBoxSave??5/      $??Сохранить??6.   $??520,188,72,246q?6B   ???	#FFF0F0F0$??14(?6q   $
 Hand??6   $	??150??6?   $??30??6?   
???????$	 -35??6?   $	 87??6?   ???	#DD8888886?   ?? 50      $	??250??6   $??	35,0,35,0q?6(   $ 50q?6;   $??0??6H   $ 20??6U   $	??213??6g   $	??220??6s   $ 
0.511,0.52&?6?   $		 107??6?   $ 41??6?   ??51      ?? 52       ?? Color$ 	#FFF9F9F9??6*    ?? Opacity$ 1Q?6<    54        55      $ 5Q?6+   $ 	#FFD6D1D1??6:   $ 0Q?6L   6^   ._?57      ? $??-28,-26,-28,-40q?6   .+?58      ?? $??Информация??6$   $??18(?66   $
??Bold"?6D   $??Center=?6V   $??0,-10,0,166q?6s   
???   ?6?   ?? 59      -	   5        $??
Врачи??59   !   ???	#FFF0F0F0$??14(?6H   $
 Hand??6V   $??30??6d   
??????????	#DD888888$??
0,10,0,115q?6?   6?   ?? 5:      $#??История болезни??6!   ???	#FFF0F0F0$??14(?6R   $
 Hand??6`   $??30??6n   
??????????	#DD888888$??	0,48,0,77q?6?   ?? 5;      $1??+Текущие записи к врачам??6!   ???	#FFF0F0F0$??14(?6Z   $
 Hand??6h   $??30??6v   
??????????	#DD888888$??	0,86,0,39q?6?   ?? 5<      $-??'Подробная информация??6!   ???	#FFF0F0F0$??14(?6W   $
 Hand??6e   $??30??6s   
??????????	#DD888888$??	0,124,0,1q?6?   5=      5>      5?      5@      5A      5B      