# Result\<T\>

Simple generic Result pattern model with Error and implicit conversions.

The Error result is implicit converted to the expected result type Result\<T\>:


```cs
    using ResultT;

    Task<Result<Model>> GetById(int id)
    {
        try
        {
            var model = _repository.Get(id);

            return Results.Ok(model);
        }
        catch (Exception ex)
        {
            return Results.Error(ex.Message, ex)
        }
    }
```

```cs
    using ResultT;

    Task<Result> Update(Model model)
    {
        var rowsUpdated = _repository.Update(model);

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
    using static ResultT.Results;

    Task<Result<Model>> GetById(int id)
    {
        try
        {
            var model = _repository.Get(id);

            return Ok(model);
        }
        catch (Exception ex)
        {
            return Error(ex.Message, ex)
        }
    }
```

```cs
    using ResultT;

    Task<Result> Update(Model model)
    {
        var rowsUpdated = _repository.Update(model);

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
