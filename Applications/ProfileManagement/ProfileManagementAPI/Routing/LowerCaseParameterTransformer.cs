namespace ProfileManagement.API.Routing;

public class LowerCaseParameterTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value)
    {
        return value?.ToString()?.ToLower();
    }
}

