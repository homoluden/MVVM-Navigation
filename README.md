MVVM-Navigation
===============

This is generic implementation of the Page Navigation API for WPF 4.0 Application on MVVM pattern.
Main goal is to provide a common way to navigate between Pages and transfer to these Pages its individual ViewModels.

Implementation
==============

API implemented as Singleton which receives NavigationService from your main navigation Frame. 
All navigation methods from that singleton will perform an actions thru this NavigationService.
The value of *context* parameter of navigation methods will be placed into *DataContext* property of the target Page
in *NavigationService.Navigated* event handler.
