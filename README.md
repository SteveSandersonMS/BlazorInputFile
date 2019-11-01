# &lt;InputFile&gt;

This is a prototype for a file input component that may be added to Blazor in the future.

For installation and usage information, see [this blog post](http://blog.stevensanderson.com/2019/09/13/blazor-inputfile/).

## Using a custom <input> button with MatBlazor:

```csharp
<MatButton OnClick="@(() => OnButtonClick("myInput"))" Label="Choose File"></MatButton>
<InputFile IsElementHidden="true" OnChange="HandleFileSelected" ElementId="myInput"> </InputFile>

@if (file != null)
{
    <p>Name: @file.Name</p>
    <p>Size in bytes: @file.Size</p>
    <p>Last modified date: @file.LastModified.ToShortDateString()</p>
    <p>Content type (not always supplied by the browser): @file.Type</p>
}

@code {

    public async void OnButtonClick(string elementID)
    {
        await JSRuntime.InvokeAsync<string>("BlazorInputFile.wrapInput", elementID);
    }

    IFileListEntry file;

    void HandleFileSelected(IFileListEntry[] files)
    {
        file = files.FirstOrDefault();
    }

}
```

Reference from [here](https://stackoverflow.com/a/9546968)
