   M S B A M L   `   `   `  ????@  <Task1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Task1Task1  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       Task1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Task1     5   	   :xctk)http://schemas.xceed.com/wpf/xaml/toolkit     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   -   5        
????? ?  ? Title$  
MainWindow??5   	   $	??600??6   $	??600??6)    ? 	Resources 5         MyStoryboard ?? 
TargetName ?? TargetProperty W? From	 W? To g? Duration  MyStoryboardAfter S? 
MethodName S? 
ObjectType  System.Type  colorsTypeOdp	 S? MethodParameters
 S? ObjectInstance  colorPropertiesOdp??%?  &	        &	 ?     &	 z    &	 K    7  ?? 5   
   .??5      ?? -   5        .??5      W? $ MyAnimation??5      $ (RotateTransform.Angle)?5      $	 0.0X?5      $ 90X?6    $ 0:0:1D?6(   5      5      ?? 5   
   .??5      ?? .??5      W? $ MyAnimation??5      $ (RotateTransform.Angle)?5      $	 0.0X?5      $ 90X?6    $ 0:0:1D?6(   5      5      S? 5   
   $ GetType??6   "  5      	 5       ??5!      tpSystem.Windows.Media.Colors, PresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35??5#   6   5%      S? 5&   
   8
   $ GetProperties??5'      5(      5)      .??5*      ? .+?5+   
   ?? -   5         ??Name$
 Draw??5+       ? ContextMenu 5,   
   ?? 5-      .@?5.      m? -   5        $??Сохранить??5.      6K   m? 5/      -   5        $??AutoRewrite??5/   7   $&?? Авто. перерисовка??6   6f   m? 50      -   5        $??Rewrite??50   1   $??Перерисовка??6   6\   51      .@?53      ?? -   5        $??DrawRectangle??53      ??54      ?? 55      -   5         ?? Orientation$ 
Horizontal=?55   !   .+?56      ?? $??3q?6$   Прямоугольник6>   57      ??59      ? 5:      .+?5;      ?? -	   5         ??Name$ StackPanelRectangleOption??5;   %   $	??200??5<   %   $??Right=?5=   %   
???????.+?5?      ? $??40??6#    ? ToolTip$ от 1 до 9??6/   .+?5@   "   ??  ?? TextAlignment$ Center=?6,   .,Колл-во прямоугольников6\   ? 5A   "   $??Bottom=?6'   $??20??5B   '   $
??10 0q?63   .+?5C   &   ?? -
   5         ??Name$ RectangleCount??5C   .   $??3??5E   .   5H   .   ?? 5I   &   -   5        $??Marlett)?5I   -   $??7(?5J   -   $??5??5K   -   $??10??5L   -   $??20??5M   -   $	??Top=?5O   -   $??Right=?5P   -   ?? 5Q   &   -   5        $??Marlett)?5Q   -   $??7(?5R   -   $??6??5S   -   $??10??5T   -   $??20??5U   -   $??Bottom=?5W   -   $??Right=?5X   -   5Y   #   5Z      ? 5[      $??40??6#   $
??0 10q?6/   $ от 0 до 600??6=   .+?5\   "   ?? $ Center=?6,   Высота6K   ? 5]   "   $??Bottom=?6'   $??20??5^   '   $
??10 0q?63   .+?5_   &   ?? -   5        $ RectangleSideA??5_   .   $??60??5`   .   5c   .   ?? 5d   &   -   5        $??Marlett)?5d   -   $??7(?5e   -   $??5??5f   -   $??10??5g   -   $??20??5h   -   $	??Top=?5j   -   $??Right=?5k   -   ?? 5l   &   -   5        $??Marlett)?5l   -   $??7(?5m   -   $??6??5n   -   $??10??5o   -   $??20??5p   -   $??Bottom=?5r   -   $??Right=?5s   -   5t   #   5u      ? 5v      $??40??6#   $
??0 10q?6/   $ от 0 до 600??6=   .+?5w   "   ?? $ Center=?6,   
Длина6J   ? 5x   "   $??Bottom=?6'   $??20??5y   '   $
??10 0q?63   .+?5z   &   ?? -   5        $ RectangleSideB??5z   .   $	??100??5|   .   5   .   ?? 5?   &   -   5        $??Marlett)?5?   -   $??7(?5?   -   $??5??5?   -   $??10??5?   -   $??20??5?   -   $	??Top=?5?   -   $??Right=?5?   -   ?? 5?   &   -   5        $??Marlett)?5?   -   $??7(?5?   -   $??6??5?   -   $??10??5?   -   $??20??5?   -   $??Bottom=?5?   -   $??Right=?5?   -   5?   #   5?      ?? 5?      -   5         ??Name$! ComboBoxRectangleStrokeType??5?   '   $??20??5?   '   $??10q?5?   '   $. (Переключает вид линий??5?   '   $	??Top=?5?   '   .@?5?   "   ??  ?? 
IsSelected . $??Сплошные??6A   6V   ?? 5?   "   $??Штрихованные??6/   6H   ?? 5?   "   $??
Точки??6/   6A   5?      ?? 5?      -   5        $"??ComboBoxRectangleStrokeColor??5?   '   $
??10 0q?5?   '    ?? SelectedValue$ Black??5?   '    ?? DisplayMemberPath$
 Name??5?   '   $0 *Переключает цвет линий??5?   '    ?? SelectedValuePath$
 Name??5?   '   ??5?   '   ??  ?? Source# [ 5?   '   ?? 5?      -   5         ??Name$ CheckBoxRectangles??5?   '   $??	10 10 0 0q?5?   '   .??6:   !Авто перерисовка6L   ?? 5?      -   5        $ CheckBoxRectangleRandom??5?   '   $??	10 10 0 0q?5?   '   .??6:   Случайный цвет6J   ?? 5?      -   5        $??RectanglesRewrite??5?   %   $??Bottom=?5?   %   $??10q?5?   %   .??5?   K   Перерисовать6Y   5?      ?? 5?      -   5         ??Name$ CanvasRectangles??5?   !   .+?5?      ? -   5         ?Name$ 
Rectangles??5?   #   $??Center=?5?   #   $??Center=?5?   #   $	??390??5?   #   $	??570??5?   #   .+?5?   "   ?? $??60??6,   $	??100??5?   ,   $??1??5?   ,   
???   ?5?   #   ?? 5?   "   $??40??6,   $??80??5?   ,   $??1??5?   ,   
???   ?5?   =   ?? 5?   "   $??20??6,   $??60??5?   ,   $??1??5?   ,   
???   ?5?   =   5?      5?      5?      5?      ?? 5?      -   5         ??Name$ 
DrawSquare??5?      ??5?      ?? 5?      -   5        $ 
Horizontal=?5?   !   .+?5?      ?? $??3q?6$   Квадраты69   5?      ??5?      ? 5?      .+?5?      ?? -   5        $ StackPanelSquareOption??5?   %   $	??200??5?   %   $??Right=?5?   %   
???????.+?5?      ? $??40??6#   $ от 1 до 9??6/   .+?5?   "   ?? $ Center=?6,   " Колл-во квадратов6V   ? 5?   "   $??Bottom=?6'   $??20??5?   '   $
??10 0q?63   .+?5?   &   ?? -   5        $ SquareCount??5?   .   $??3??5?   .   5?   .   ?? 5?   &   -   5        $??Marlett)?5?   -   $??7(?5?   -   $??5??5?   -   $??10??5?   -   $??20??5?   -   $	??Top=?5?   -   $??Right=?5?   -   ?? 5?   &   -   5        $??Marlett)?5?   -   $??7(?5?   -   $??6??5?   -   $??10??5?   -   $??20??5?   -   $??Bottom=?5?   -   $??Right=?5?   -   5?   #   5?      ? 5?      $??40??6#   $
??0 10q?6/   $ от 0 до 600??6=   .+?5?   "   ?? $ Center=?6,   Сторона6L   ? 5?   "   $??Bottom=?6'   $??20??5?   '   $
??10 0q?63   .+?5?   &   ?? -    5        $ 
SquareSide??5?   .   $	??200??5?   .   5?   .   ?? 5?   &   -!   5        $??Marlett)?5?   -   $??7(?5?   -   $??5??5   -   $??10??5  -   $??20??5  -   $	??Top=?5  -   $??Right=?5  -   ?? 5  &   -"   5        $??Marlett)?5  -   $??7(?5  -   $??6??5  -   $??10??5	  -   $??20??5
  -   $??Bottom=?5  -   $??Right=?5  -   5  #   5     ? 5     $??40??6#   $
??0 10q?6/   $F @Меня косинус угла наклона квадрата??6=   .+?5  "   ?? $ Center=?6,   86Косинус угла наклона (от 0 до 1)6e   ?? 5  "   -#   5         ??Name$ 	SquareCos??5  )   $??Bottom=?5  )   $
??10 0q?5  )    ? Minimum$
 0.01Q?5  )    ? Maximum$
 0.99Q?5  )    ? Value$	 0.5Q?5  )   5  S   5     ?? 5     -$   5        $ CheckBoxSquare??5  '   $
??10 0q?5  '   .??65   !Авто перерисовка6G   ?? 5     -%   5        $??SquareRewrite??5  %   $??Bottom=?5  %   $??10q?5  %   .??5   K   Перерисовать6Y   5!     ?? 5"     -&   5        $ CanvasSquare??5"  !   .+?5#     ? -'   5        $ Squares??5#  #   $
??Left=?5$  #   $	??390??5%  #   $	??570??5&  #   .+?5'  &   ?? $	??200??60   $	??200??6<   
???   ?
????? ?5(  '   ?? 5)  &   $	??145??60   $	??145??6<   
???   ?
???????  ? LayoutTransform  5*  *   ?? 5+  .   ! ?? Angle$! 60Q?6>   5-  '   ?? 5.  &   $	??104??60   $	??104??6<   
???   ?
????  ?  5/  *   ?? 50  .   $	! 120Q?6>   52  '   53  #   54     55     57     ?? 58     -(   5        $??DrawAnimation??58     ??59     ?? 5:     $ 
Horizontal=?6!   .+?5;     ?? $??3q?6$   Анимация69   5<     ??5>     ? 5?     .+?5@     ?? -)   5        $ StackPanelAnimationOption??5@  %   $	??200??5A  %   $??Right=?5B  %   
???????.+?5D     ? $??40??6#   $
??0 10q?6/   .+?5E  "   ?? $ Center=?6,   Длина стороны6R   ? 5F  "   $??Bottom=?6'   $??20??5G  '   $
??10 0q?63   .+?5H  &   ?? -*   5        $ AnimationSide??5H  .   $	??100??5J  .   5M  .   ?? 5N  &   -+   5        $??Marlett)?5N  -   $??7(?5O  -   $??5??5P  -   $??10??5Q  -   $??20??5R  -   $	??Top=?5T  -   $??Right=?5U  -   ?? 5V  &   -,   5        $??Marlett)?5V  -   $??7(?5W  -   $??6??5X  -   $??10??5Y  -   $??20??5Z  -   $??Bottom=?5\  -   $??Right=?5]  -   5^  #   5_     ? 5`     $??40??6#   $
??0 10q?6/   .+?5a  "   ?? $ Center=?6,   #!Скорость анимации6V   ?? 5b  "   --   5        $ AnimationSpeed??5g  )   $??Bottom=?5b  )   $
??10 0q?5c  )   $
 0.01Q?5d  )   $ 2Q?5e  )   $ 1Q?5f  )   5h  X   5i     ?? 5j     -.   5        " ??Name$" ButtonStart??5j  %   $??
10 10 10 0q?6:   $??
Старт??6N   6|   ?? 5k     -/   5        $??StopButtonAnimation??5k  H   $??
10 10 10 0q?6%   $??Стоп??69   6?   5l     ? 5m     -0   5        $ 
Animations??5m     $	??370??5n     }?. $
??Left=?5p     .+?5q     ?? -1   5        # ??Name$# RectangleAnimation??5q  (   $	??100??6D   $	??100??6P   $??	0 0 290 0q?6]   $??Right=?6p   
???   ?$ J? RenderTransformOrigin$	$ 1,1&?6?   z?5r  "   ?? 5s  &   -2   5        MyAnimation??$! 0Q?5s  K   5u     5v     5w     5y     5z     5{     5|     