using Microsoft.AspNetCore.Mvc.ModelBinding;

internal class CustomCollectionModelBinderProvider : IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        if (context.Metadata.ModelType == typeof(int[]))
        {
            return new CustomCollectionModelBinder();
        }

        return null;
    }
}

internal class CustomCollectionModelBinder : IModelBinder
{
    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext.ModelType == typeof(int[]))
        {
            var name = bindingContext.FieldName;
            var value = bindingContext.ValueProvider.GetValue(name).FirstValue;
            if (!string.IsNullOrEmpty(value))
            {
                bindingContext.Result  = ModelBindingResult.Success(value.ToString().Split(',').Select(x => int.Parse(x)).ToArray());
            }
        }
    }
}