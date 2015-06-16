# netoaster
A .net toaster library for very simple and slightly customizable toaster notifications.
Heavily inspired by [angular-toastr](https://github.com/Foxandxss/angular-toastr "angular-toastr")

![alt tag](http://i.imgur.com/yBZ11Pl.gif)

# how to use

1. Install using [nuget](https://www.nuget.org/packages/netoaster/1.0.6 "nuget") or by including the 
above netoaster project into your WPF app

2. Call it

```
ErrorToaster.Toast("My Error Message!");
``` 

![alt tag](https://raw.github.com/zachatrocity/netoaster/master/toasterdemoapp/error.png)

```
SuccessToaster.Toast("Success message", animation: ToasterAnimation.FadeIn);
```

![alt tag](https://raw.github.com/zachatrocity/netoaster/master/toasterdemoapp/success.png)

```
WarningToaster.Toast("Warning message", ToasterPosition.PrimaryScreenTopRight);
```

![alt tag](https://raw.github.com/zachatrocity/netoaster/master/toasterdemoapp/warning.png)

3. Optional parameters (more to come)
	* message - the text to display in the toaster
	* position - the position to show the toaster, like (default is PrimaryScreenBottomRight) 
    	  * shout out to [jublin](https://github.com/jublin) 
    	  * PrimaryScreenBottomRight
    	  * PrimaryScreenTopRight
    	  * PrimaryScreenBottomLeft
    	  * PrimaryScreenTopLeft
    	  * ApplicationBottomRight
    	  * ApplicationTopRight
    	  * ApplicationBottomLeft
    	  * ApplicationTopLeft
    * animation - the style of the animation
          * FadeIn
          * SlideInFromRight (default)
          * SlideInFromLeft
          * SlideInFromTop
          * SlideInFromBottom
          * GrowFromRight
          * GrowFromLeft
          * GrowFromTop
          * GrowFromBottom
	* margin - the desired distance away from the corner

#To do:
* add optional colors
* for feature requests open a new issue


#Contributers
* myself
* [jublin](https://github.com/jublin)
	
#Concept 
skeleton of code came from [this](http://stackoverflow.com/questions/3034741/create-popup-toaster-notifications-in-windows-with-net/3035755#3035755, "this") stackoverflow post
by [Ray Burns](http://stackoverflow.com/users/199245/ray-burns, "Ray Burns"). I customized it to my own needs.
			
			
#Contribute
feel free to submit pull-requests
