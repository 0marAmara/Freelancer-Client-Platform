   M S B A M L   `   `   `  ����  FreelancerClientPlatform@    :FreelancerClientPlatform.Views.Client.ActiveProjectsWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Active Projects��5   	   $	��550��6!   $
��1100��6.   ���#2C3E50.��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��Assigned Projects��6   
�������$��18(�6?   $
��Left=�6M   $��10,5,0,0q�6h   �� 5   
   -   5         ��Name$ assignedProjectsListView��5   <   $��0��6^   $��10,41,10,239q�6k   ���#34495E��6   �� *AssignedProjects+��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value
 �����63   5       �� View 5      �� 5      .P�5      �� $��Project Name��6%    �� Width$	 200��6a    �� DisplayMemberBinding 6;   �� *name+6a   �� 5      $��Description��6%   $	 400��6g    6:   �� *description+6g   �� 5      $��Timeline��6%   $	 150��6a    67   �� *
timeline+6a   �� 5      $��Budget��6%   $	 100��6]    65   �� *budget+6]   �� 5      $��Assigned Freelancer��6%   $	 200��6r    6B   �� *freelancerName+6r   5      5      �� 5   
   $��Non-Assigned Projects��6   
�������$��18(�6C   $
��Left=�6Q   $��10,255,0,-35q�6l   $��2��6�   �� 5    
   -   5        $! nonAssignedProjectsListView��5    ?   $��0��6d   $��10,293,10,0q�6q   ���#34495E��6   �� *NonAssignedProjects+��5!      �� 5"      " ��6   .�5#      ��  � ��
 �����63   5$       5&      �� 5'      .P�5(      �� $��Project Name��6%   $	 250��6a    6;   �� *name+6a   �� 5)      $��Description��6%   $	 400��6g    6:   �� *description+6g   �� 5*      $��Number of Bids��6%   $	 150��6c    6=   �� *bids+6c   �� 5+      $	 100��6%   	 �� CellTemplate	 5,      �� 5-      .R�5.   "   �� -   5        $��Review Proposals��5.   )   $��90��6D   $��30��6O   $��12(�6[   ���#E74C3C
���������6�   �� 5/      51      52      54      55      56      