   M S B A M L   `   `   `  ????F  BHospitalWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:HospitalWPFHospitalWPF  5   	       HospitalWPF.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:HospitalWPF     5   	   _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     ? Title$  Hospital??5	   	   $	??600??6   $	??900??6(   $
??1000??64   $	??600??6D   .??5
      ? ???#dff7f7.+?5   
   ?? $	??400??6   $??15q?6    
???????$??Center=?6?    ?? Padding$ 40q?6Z   $	??500??6g    ?? CornerRadius$ 20??6v    J? Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 30Q?6#      Color$ 	LightBlue??63      ShadowDepth$ 0Q?6E   6W   ._?5      ?? .+?5      ?? $??Регистрация??6   $??30(?6/   $
??Bold"?6=   $??0 0 0 20q?6O   6c   ? 5      $??0 0 0 20q?6   .+?5      ?? -   5        $
??Left=?5      $??
Войти??68      MaterialDesignFlatButton#??[  6I   ???	#FFF60D0D$??32??6?   $??	330,0,0,0q?6?   $??Center=?6?    ? Cursor$
 Hand??6?   $??18(?6?   $??90??6  6  5      ?? 5      -   5         ??Name$ textBoxEmail??5      )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 
     Email??60    % !MaterialDesignFloatingHintTextBox#??[ 6\   $??16(?6?   G? 5      -   5        
 G?Name$
 passBox??5      $!	 Введите пароль??6/    # MaterialDesignFilledPasswordBox#??[ 6_   
?????? $??16(?6?   6?   ?? 5      -   5        $*??$Зарегистрироваться??5      $
??0 20q?66   ???	#FFF60D0D$??18(?6[   $
 Hand??6~   6?   5      5      5      5      