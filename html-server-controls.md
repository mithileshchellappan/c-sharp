**HTML Server Controls in C#**

HTML server controls are used in ASP.NET web applications to create dynamic content on a web page. They allow developers to build web applications using familiar HTML syntax and provide server-side functionality to perform various actions.

    HTML server controls are defined using HTML syntax with additional attributes to provide server-side functionality.
    They are used to create dynamic content on a web page that can be modified on the server-side based on user actions or other conditions.
    HTML server controls can be accessed and modified using C# code-behind files to perform various actions such as data validation, processing user input, and generating dynamic content.

Use Cases of HTML Server Controls


    User input forms: HTML server controls such as TextBox, DropDownList, and CheckBox are commonly used to create user input forms for collecting data from users.
    Dynamic content generation: HTML server controls can be used to generate dynamic content on a web page based on user input or other conditions. For example, a Button control can be used to trigger an action that generates dynamic content.
    Data display and manipulation: HTML server controls such as GridView and Repeater can be used to display data from a database and perform various data manipulation operations such as sorting, filtering, and paging.

Advantages of HTML Server Controls

    Simplify development: HTML server controls provide a simplified development model for creating dynamic web applications. Developers can use familiar HTML syntax and easily add server-side functionality using C# code-behind files.
    Consistent user experience: HTML server controls provide a consistent user experience across different web browsers and devices by rendering the same HTML markup regardless of the client environment.
    Client-side and server-side processing: HTML server controls can perform both client-side and server-side processing to provide a responsive user interface and minimize server round trips.

Examples of HTML Server Controls

  **TextBox Control**: The TextBox control allows users to enter text input on a web page. The entered text can be accessed on the server-side to perform various actions. Here is an example of using TextBox control in C#:

```html
<input type="text" name="txtName" id="txtName" runat="server" />
```

In the code-behind file (e.g., "MyPage.aspx.cs"), you can access the value entered in the TextBox control using the "Request.Form" collection:

```csharp
string name = Request.Form["txtName"];
```

**Button Control**: The Button control is used to trigger an action on the server-side when clicked by the user. Here is an example of using Button control in C#:


```html
<button type="submit" name="btnSubmit" id="btnSubmit" runat="server" OnClick="btnSubmit_Click">Submit</button>
```

```csharp
protected void btnSubmit_Click(object sender, EventArgs e)
{
    // Get the value entered in the TextBox control
    string name = Request.Form["txtName"];

    // Show an alert with the message
    string script = "alert('Thank you for submitting your name, " + name + "');";
    ClientScript.RegisterStartupScript(this.GetType(), "ThankYouMessage", script, true);
}
    
