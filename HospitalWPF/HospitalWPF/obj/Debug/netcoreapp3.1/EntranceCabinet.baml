   M S B A M L   `   `   `  ????F  BHospitalWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:HospitalWPFHospitalWPF  5   	   !    HospitalWPF.EntranceCabinet   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:HospitalWPF     5   	   _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     ? Title$  EntranceCabinet??5	   	   $	??600??6!   $	??900??6.   $
??1000??6:   $	??600??6J   .??5
      ? ???#dff7f7.+?5   
   ?? $	??400??6   $??15q?6    
???????$??Center=?6?    ?? Padding$ 40q?6Z   $	??500??6g    ?? CornerRadius$ 20??6v    J? Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 30Q?6#      Color$ 	LightBlue??63      ShadowDepth$ 0Q?6E   6W   ._?5      ?? .+?5      ?? $-??'Вход в личный кабинет??6   $??30(?69   $
??Bold"?6G   $??0 0 0 20q?6Y   6m   ? 5      $??	0 0 0 -10q?6   .+?5      ?? -   5        $
??Left=?5      $??Регистрация??68      MaterialDesignFlatButton#??[  6O   ???	#FFF60D0D$??32??6?   $??	294,0,0,0q?6?   $??Center=?6?    ? Cursor$
 Hand??6?   $	??126??6   J? RenderTransformOrigin$ -5.429,3.07&?6  $??16(?61  6B  5      ? 5      $??0 0 0 20q?6   5      ?? 5      -   5        	 ??Name$	 textBoxLogin??5      )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$$
      Введите логин??60    % !MaterialDesignFloatingHintTextBox#??[ 6d    ?? 
CaretBrush ?	#FF6C40BA$??14(?6?   6?   G? 5      -   5         G?Name$ passBox??5      $!
 Введите пароль??6/    # MaterialDesignFilledPasswordBox#??[ 6_   
?????? $??14(?6?   6?   ?? 5      -   5        $"??Авторизоваться??5      $
??0 20q?62   ???	#FFF60D0D$??17(?6W   6?   5      5      5      5      