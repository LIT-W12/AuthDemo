# Auth Demo

This is a simple demo app that shows how to use authentication in .Net Core. When the user tries to access the Secret page, they get redirected to a login page. There's also a signup page at /account/signup.

A few things to look out for:

When referencing BCrypt in the data class library, make sure to reference BCrypt.Net-Next from Nuget:

<img width="1144" alt="image" src="https://github.com/LITW11/AuthDemo/assets/159099703/9259f1a9-52d0-45fe-a9c0-b328d3c85c2e">

Here are the relevant pieces of code needed to make this work. First, you need to set up Authentication in the `Program.cs` file:

https://github.com/LIT-W12/AuthDemo/blob/master/AuthDemo.Web/Program.cs#L6
https://github.com/LIT-W12/AuthDemo/blob/master/AuthDemo.Web/Program.cs#L12-L18
https://github.com/LIT-W12/AuthDemo/blob/master/AuthDemo.Web/Program.cs#L34-L36

Then, to actually log a user in, here's the code needed for that (in the `AccountController.cs`):

https://github.com/LIT-W12/AuthDemo/blob/master/AuthDemo.Web/Controllers/AccountController.cs#L45-L54

To check if a user is logged in, you can use the `User.Identity.IsAuthenticated` property, and to get the currently logged in users email, you can do `User.Identity.Name`. This can be done either in the controller or in the view.

To log out a user, do the following:

https://github.com/LIT-W12/AuthDemo/blob/master/AuthDemo.Web/Controllers/AccountController.cs#L61-L62

To only give logged in users access to a specific page, use the `[Authorize]` attribute:

https://github.com/LIT-W12/AuthDemo/blob/master/AuthDemo.Web/Controllers/HomeController.cs#L30
