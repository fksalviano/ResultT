# Result\<T\>

[![NuGet](https://img.shields.io/nuget/v/ResultT.svg)](https://www.nuget.org/packages/ResultT)
[![Build](https://github.com/fksalviano/ResultT/actions/workflows/build.yml/badge.svg)](https://github.com/fksalviano/ResultT/actions/workflows/build.yml) 
[![Publish](https://github.com/fksalviano/ResultT/actions/workflows/publish.yml/badge.svg)](https://github.com/fksalviano/ResultT/actions/workflows/publish.yml) 

`dotnet add package ResultT`

Simple generic Result pattern model with Error and implicit conversions.

The Error result is implicit converted to the expected result type Result\<T\>:


```cs
using ResultT;

Task<Result<Model>> GetById(int id)
{
    try
    {
        var model = repository.Get(id);

        return Results.Ok(model);
    }
    catch (Exception ex)
    {
        return Results.Error(ex.Message, ex)

        //others error constructors:
        return Results.Error(ex.Message)
        return Results.Error(ex)
    }
}
```

```cs
using ResultT;

Task<Result> Update(Model model)
{
    var rowsUpdated = repository.Update(model);

    if (rowsUpdated > 0)
    {
        return Results.Ok();
    }
    else
    {
        return Results.Error();
    }
}
```


### Simplifyng the code with using static


```cs
using ResultT;
using static ResultT.Results;

Task<Result<Model>> GetById(int id)
{
    try
    {
        var model = repository.Get(id);

        return Ok(model);
    }
    catch (Exception ex)
    {
        return Error(ex.Message, ex)

        //others error constructors:
        return Error(ex.Message)
        return Error(ex)
    }
}
```

```cs
using ResultT;
using static ResultT.Results;

Task<Result> Update(Model model)
{
    var rowsUpdated = repository.Update(model);

    if (rowsUpdated > 0)
    {
        return Ok();
    }
    else
    {
        return Error("Fail to update");
    }
}
```

### Implicit conversions can be made with the result value, error messages string and error exceptions too:


```cs
using ResultT;

Task<Result<Model>> GetById(int id)
{
    try
    {
        var model = repository.Get(id);

        return model;
    }
    catch (Exception ex)
    {
        logger.LogError(ex, ex.Message);
        return ex;        
    }
}
```

```cs
using ResultT;

Task<Result> Update(Model model)
{   
    var rowsUpdated = repository.Update(model);

    if (rowsUpdated > 0)
    {
        return Ok();
    }
    else
    {
        var errorMessage = "Fail to update";
        return errorMessage;
    }
}
```